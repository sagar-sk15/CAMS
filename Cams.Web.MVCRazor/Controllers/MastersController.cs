using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Resources;
using System.Web.UI;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Message;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientMasters;
using Cams.Web.MVCRazor.APMCMasterServiceReference;
using Cams.Web.MVCRazor.CountryMasterServiceReference;
using Cams.Web.MVCRazor.Models;
using Cams.Web.MVCRazor.Models.Masters;
using Cams.Web.MVCRazor.StatesMasterServiceReference;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;
using System.Threading;
using Cams.Web.MVCRazor.CommodityClassServiceReference;
using Cams.Web.MVCRazor.CommodityMasterServiceReference;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.CityVillageServiceReference;
using Cams.Web.MVCRazor.DistrictServiceReference;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class MastersController : CommonController
    {
        private StatesMasterServiceReference.StateServiceClient statesMasterService = null;
        private CommodityClassServiceReference.CommodityClassServiceClient CClassClient = null;
        private CommodityMasterServiceReference.CommodityServiceClient CommodityClient = null;
        private CountryMasterServiceReference.CountryMasterServiceClient countryClient = null;
        //public static string UploadImagePath = string.Empty;
        //public static string UploadedImageFileName = string.Empty;
        public static string FormMode;
        public static int Id;

        #region StateMaster
        [CamsAuthorize(Roles = Constants.STATE, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult State()
        {
            return View("AddState");
        }

        [CamsAuthorize(Roles = Constants.STATE, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        [HttpPost]
        public ActionResult AddState(AddStateModel addState)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            

            try
            {
                statesMasterService = new StateServiceClient();
                countryClient = new CountryMasterServiceClient();
                if (ModelState.IsValid)
                {
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
                    StateDto statesMasterDto = new StateDto();
                    statesMasterDto.StateInCountry = countryClient.GetById(1);
                    statesMasterDto.RegionType = addState.RegionType;
                    statesMasterDto.RegionName = addState.RegionName;
                    statesMasterDto = statesMasterService.Create(statesMasterDto,currentUserDto.UserName);

                    if (statesMasterDto.Response.HasWarning)
                    {
                        ViewData["Error"] = ErrorAndValidationMessages.BRStateValidation;
                    }
                    else
                    {
                        TempData["StateSaved"] = string.Format(ClientResources.StateSaved, addState.RegionType, addState.RegionName);
                        return RedirectToAction("StateList", "Masters");

                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (statesMasterService != null)
                    statesMasterService.Close();
                if (countryClient != null)
                    countryClient.Close();
            }
            return View(addState);
        }

        [CamsAuthorize(Roles = Constants.STATE, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult StateList()
        {
            try
            {
                statesMasterService = new StateServiceClient();
                EntityDtos<StateDto> stateDto = statesMasterService.FindAll();
                ViewData["StateList"] = stateDto.Entities;
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (statesMasterService != null)
                    statesMasterService.Close();
            }
            return View("StateList", ViewData["StateList"]);
        }
                
        public ActionResult StateListGridView()
        {
            statesMasterService = new StateServiceClient();
            EntityDtos<StateDto> stateDto = statesMasterService.FindAll();
            ViewData["StateList"] = stateDto.Entities;
            return PartialView("StateListGridView", ViewData["StateList"]);
        }
        #endregion

        #region CountryMaster

        [CamsAuthorize(Roles = Constants.COUNTRY, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult Country(CountryModel countryModel)
        {
            try
            {
                countryClient = new CountryMasterServiceClient();
                CountryDto countryMasterDto = countryClient.GetByCountryName("India".Trim());
                if (countryMasterDto != null)
                {
                    countryModel.CountryName = countryMasterDto.CountryName;
                    countryModel.CallingCode = countryMasterDto.CallingCode;
                    countryModel.Currency = countryMasterDto.Currency;
                    countryModel.CurrencyCode = countryMasterDto.CurrencyCode;
                    countryModel.Symbol = countryMasterDto.Symbol;
                    countryModel.TimeZone = countryMasterDto.TimeZone;
                    countryModel.Status = countryMasterDto.Status;
                    countryModel.AgeStd = countryMasterDto.AgeStd;
                    countryModel.FinancialYearStart = countryMasterDto.FinancialYearStart;
                    countryModel.FinancialYearEnd = countryMasterDto.FinancialYearEnd;
                }
                else
                {
                    ModelState.AddModelError("", ErrorAndValidationMessages.BRCountryValidation);
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (countryClient != null)
                    countryClient.Close();
            }
            return View("Country", countryModel);
        }
        #endregion

        

        #region Commodity Master

        [CamsAuthorize(Roles = Constants.COMMODITY, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult AddCommodityIndex()
        {
            CommodityModel model = new CommodityModel();
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var CommodityId = Request.QueryString["commodityid"] != null ? Request.QueryString["commodityid"] : null;
            try
            {
                if (mode == "edit")
                {
                    FormMode = mode;
                    CommodityClient = new CommodityServiceClient();
                    CommodityDto cmdto = CommodityClient.GetById(CommodityId != null ? Convert.ToInt32(CommodityId) : 0);
                    Id = cmdto.CommodityId;
                    model.CommoditiesInCommodityClass = cmdto.CommoditiesInCommodityClass;
                    model.CommodityClassId = cmdto.CommoditiesInCommodityClass.CommodityClassId;
                    model.Name = cmdto.Name;
                    model.BotanicalName = cmdto.BotanicalName;
                    model.IsActive = cmdto.IsActive;
                    model.Image = (((!String.IsNullOrEmpty(cmdto.Image)) ? Constants.IMAGEUPLOADPATHCOMMODITY + (Session["UploadedImageFileName"] = cmdto.Image).ToString() : Constants.BLANKIMAGEPATH)).Replace("~/", "../../");
                    model.CommodityClassList = GetCommodityClassList();
                }
                else
                {
                    model.Image = Constants.BLANKIMAGEPATH.Replace("~/", "../../");
                    model.CommodityClassList = GetCommodityClassList();
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (CommodityClient != null)
                    CommodityClient.Close();
            }
            return View("AddCommodity", model);
        }

        [CamsAuthorize(Roles = Constants.COMMODITY, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult AddCommodity(CommodityModel model)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            try
            {
                if ((Session["UploadedImageFileName"] != null) && ModelState.IsValid)
                {
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
                    CommodityDto CommoditymasterDto = new CommodityDto();

                    CClassClient = new CommodityClassServiceClient();
                    CommoditymasterDto.CommoditiesInCommodityClass = CClassClient.GetById(model.CommodityClassId);
                    CommoditymasterDto.Name = model.Name;
                    CommoditymasterDto.BotanicalName = model.BotanicalName;
                    CommoditymasterDto.Image = Session["UploadedImageFileName"].ToString();
                    CommoditymasterDto.IsActive = model.IsActive;
                    CommoditymasterDto.ModifiedBy = currentUserDto.UserId;
                    CommodityClient = new CommodityServiceClient();

                    if (FormMode == "edit")
                    {
                        CommoditymasterDto.CommodityId = Id;
                        CommoditymasterDto = CommodityClient.Update(CommoditymasterDto,currentUserDto.UserName);
                    }
                    else
                    {
                        CommoditymasterDto.CreatedBy = currentUserDto.UserId;
                        CommoditymasterDto = CommodityClient.Create(CommoditymasterDto,currentUserDto.UserName);
                    }


                    //ResXResourceWriter writer = new ResXResourceWriter(@"\..\Resources.resx");
                    if (CommoditymasterDto.Response.HasWarning)
                    {
                        int i = 0;
                        foreach (BusinessWarning bw in CommoditymasterDto.Response.BusinessWarnings)
                        {
                            switch (bw.Message)
                            {
                                case Constants.BRBOTANICALNAMEVALIDATION:
                                    CommodityDto ExistingCommodityDto = GetCommodityByClassId(CommoditymasterDto);
                                    ModelState.AddModelError("err" + (++i).ToString(), string.Format(ErrorAndValidationMessages.BRBotanicalNameValidation, ExistingCommodityDto.Name));
                                    break;
                                case Constants.BRCOMMODITYNAMEVALIDATION:
                                    ModelState.AddModelError("err" + (++i).ToString(), string.Format(ErrorAndValidationMessages.BRCommodityNameValidation));
                                    break;
                            }


                        }
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["StateSaved"] = string.Format(ClientResources.UpdateCommoditySaved, CommoditymasterDto.Name);
                        else
                            TempData["StateSaved"] = string.Format(ClientResources.AddCommoditySaved, CommoditymasterDto.Name, CommoditymasterDto.CommoditiesInCommodityClass.Name);

                        FormMode = string.Empty;
                        return RedirectToAction("CommodityListIndex", "Masters");
                    }
                }
                else
                {
                    ModelState.AddModelError(" ", ErrorAndValidationMessages.AddCommodityImageRequired);
                }
                model.CommodityClassList = GetCommodityClassList();
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (CommodityClient != null)
                    CommodityClient.Close();
            }
            //ViewData["imagepath"] = Constants.IMAGEUPLOADPATHCOMMODITY + Session["UploadedImageFileName"].ToString();
            return View("AddCommodity", model);
        }

        [CamsAuthorize(Roles = Constants.COMMODITY, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult CommodityListIndex()
        {
            CommodityModel model = new CommodityModel();
            FormMode = string.Empty;
            model.CommodityList = GetCommodityList();
            return View("CommodityList", model);
        }
                
        public ActionResult CommodityListGridView(CommodityModel model)
        {
            model.CommodityList = GetCommodityList();
            return PartialView("CommodityListGridView", model);
        }

        public List<CommodityClassDto> GetCommodityClassList()
        {
            CClassClient = new CommodityClassServiceClient();
            var CommodityClassDtos = CClassClient.FindAll();
            return CommodityClassDtos.Entities.ToList();
        }

        public List<CommodityDto> GetCommodityList()
        {
            CommodityClient = new CommodityServiceClient();
            var CommodityDtos = CommodityClient.FindAll();
            CommodityClient.Close();
            return CommodityDtos.Entities.ToList();
        }

        public CommodityDto GetCommodityByClassId(CommodityDto CommoditymasterDto)
        {
            CommodityClient = new CommodityServiceClient();
            Query query = new Query();
            Criterion criteriaClassID = new Criterion("commodityclass.CommodityClassId", CommoditymasterDto.CommoditiesInCommodityClass.CommodityClassId, CriteriaOperator.Equal);
            query.Add(criteriaClassID);
            query.AddAlias ( new Alias("commodityclass", "CommoditiesInCommodityClass"));
            var commoditydtos = CommodityClient.FindByQuery(query);
            CommodityClient.Close();
            return commoditydtos.Entities.FirstOrDefault();
        }

        [CamsAuthorize(Roles = Constants.COMMODITY, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult GetCommodityView()
        {
            CommodityModel model = new CommodityModel();
            var CommodityId = Request.QueryString["commodityid"];
            try
            {
                CommodityClient = new CommodityServiceClient();
                CommodityDto cmdto = CommodityClient.GetById(CommodityId != null ? Convert.ToInt32(CommodityId) : 0);
                model.CommodityId = cmdto.CommodityId;
                model.CommoditiesInCommodityClass = cmdto.CommoditiesInCommodityClass;
                model.Name = cmdto.Name;
                model.BotanicalName = cmdto.BotanicalName;
                model.IsActive = cmdto.IsActive;
                model.Image = (((!String.IsNullOrEmpty(cmdto.Image)) ? Constants.IMAGEUPLOADPATHCOMMODITY + cmdto.Image : Constants.BLANKIMAGEPATH)).Replace("~/", "../../");
                model.CommodityClassList = GetCommodityClassList();
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (CommodityClient != null)
                    CommodityClient.Close();
            }
            return View("CommodityView", model);
        }
        #endregion


        #region UploadImage
        public ActionResult CallbacksImageUpload()
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADPATHCOMMODITY));
            UploadControlExtension.GetUploadedFiles("ImageUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);

            Session["UploadedImageFileName"] = UploadedImageFileName;
            //ViewData["imagepath"] = Constants.IMAGEUPLOADPATHCOMMODITY + UploadedImageFileName;
            return null;
        }

        //public class UploadControlDemosHelper
        //{
        //    public static readonly ValidationSettings ValidationSettings = new ValidationSettings
        //    {
        //        AllowedFileExtensions = new string[]
        //                                            {
        //                                                ".jpg", ".jpeg", ".jpe",
        //                                                ".gif", ".png"
        //                                            },
        //        MaxFileSize = 20971520
        //    };


        //    public static void UploadImage(object sender, FileUploadCompleteEventArgs e)
        //    {
        //        if (e.UploadedFile.IsValid)
        //        {
        //            string Prefix = (Guid.NewGuid()).ToString() + "_";
        //            string resultFilePath = UploadImagePath + Prefix + e.UploadedFile.FileName;
        //            using (Image original = Image.FromStream(e.UploadedFile.FileContent))
        //            using (Image thumbnail = PhotoUtils.Inscribe(original, 100))
        //            {
        //                PhotoUtils.SaveToJpeg(thumbnail, resultFilePath);
        //            }
        //            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
        //            if (urlResolver != null)
        //            {
        //                e.CallbackData = Prefix + e.UploadedFile.FileName;
        //            }

        //            UploadedImageFileName = Prefix + e.UploadedFile.FileName;
        //        }
        //    }


        //    public static class PhotoUtils
        //    {
        //        public static Image Inscribe(Image image, int size)
        //        {
        //            return Inscribe(image, size, size);
        //        }

        //        public static Image Inscribe(Image image, int width, int height)
        //        {
        //            Bitmap result = new Bitmap(width, height);
        //            using (Graphics graphics = Graphics.FromImage(result))
        //            {
        //                double factor = 1.0 * width / image.Width;
        //                if (image.Height * factor < height)
        //                    factor = 1.0 * height / image.Height;
        //                Size size = new Size((int)(width / factor), (int)(height / factor));
        //                Point sourceLocation = new Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2);

        //                SmoothGraphics(graphics);
        //                graphics.DrawImage(image, new Rectangle(0, 0, width, height),
        //                                   new Rectangle(sourceLocation, size), GraphicsUnit.Pixel);
        //            }
        //            return result;
        //        }

        //        private static void SmoothGraphics(Graphics g)
        //        {
        //            g.SmoothingMode = SmoothingMode.AntiAlias;
        //            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        }

        //        public static void SaveToJpeg(Image image, string filePath)
        //        {
        //            MemoryStream memoryStream = new MemoryStream();
        //            FileStream fileStream = null;
        //            try
        //            {
        //                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
        //                image.Save(memoryStream, ImageFormat.Jpeg);
        //                byte[] bytes = memoryStream.ToArray();
        //                fileStream.Write(bytes, 0, bytes.Length);

        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            finally
        //            {
        //                memoryStream.Close();
        //                if (fileStream != null)
        //                    fileStream.Close();
        //            }
        //        }

        //    }
        //}
        #endregion
    }
}
