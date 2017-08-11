using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Web.MVCRazor.StatesMasterServiceReference;
using Cams.Web.MVCRazor.DistrictServiceReference;
using Cams.Web.MVCRazor.CityVillageServiceReference;
using Cams.Common;
using Cams.Common.Querying;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.Models.Shared;
using DevExpress.Web.ASPxUploadControl;
using System.Drawing;
using System.Web.UI;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Cams.Web.MVCRazor.DesignationServiceReference;
using Cams.Common.Message;
using Cams.Common.Dto.ClientRegistration;
using Cams.Web.MVCRazor.ClientServiceReference;

namespace Cams.Web.MVCRazor.Controllers
{
    public class CommonController : Controller
    {
        public static string UploadImagePath = string.Empty;
        public static string UploadedImageFileName = string.Empty;
        public ActionResult Index()
        {
            return View();
        }

        #region Get Default States,Districts,CityVillages
        public ActionResult GetStates()
        {
            string controlPrefix = Request.Params["CommonControlPrefix"];
            StateDistrictCityControlNamesModel model = new StateDistrictCityControlNamesModel(controlPrefix);
            model.HiddenFieldForDistrictValue = 0;
            model.HiddenFieldForCityVillageValue = 0;

            return PartialView("States", model);
        }

        public ActionResult GetDistrictsOfState()
        {
            string state = "[Select]";
            if (Request.Params["state"] != null)
                state = Request.Params["state"];

            int stateId = 0; 
            if (Request.Params["stateId"] != null)
                stateId = Convert.ToInt32(Request.Params["stateId"]);

            string controlPrefix = Request.Params["CommonControlPrefix"];
            StateDistrictCityControlNamesModel model = new StateDistrictCityControlNamesModel(controlPrefix);
            model.HiddenFieldForStateValue = stateId;
            model.HiddenFieldForDistrictValue = 0;
            string defaultDistrictId = Request.Params["DefaultDistrictId"];
            if (defaultDistrictId != null && defaultDistrictId != "[Select]" && defaultDistrictId != "")
            {
                model.HiddenFieldForDistrictValue = Convert.ToInt32(defaultDistrictId); ;
                if (!CheckIfDistrictBelongsToTheGivenState(stateId, model.HiddenFieldForDistrictValue))
                    model.HiddenFieldForDistrictValue = 0;
            }
            model.HiddenFieldForCityVillageValue = 0;

            return PartialView("Districts", model);
        }

        private bool CheckIfDistrictBelongsToTheGivenState(int StateId, int DistrictId)
        {
            bool isPresent = false;

            Query query = new Query();
            Criterion criteriaState = new Criterion("st.StateId", StateId, CriteriaOperator.Equal);
            Criterion criteriaDistrict = new Criterion("DistrictId", DistrictId, CriteriaOperator.Equal);
            query.Add(criteriaState);
            query.Add(criteriaDistrict);
            query.AddAlias(new Alias("st", "StateOfDistrict"));
            DistrictServiceReference.IDistrictService client = new DistrictServiceClient();
            var districts = client.FindByQuery(query);
            if (districts.TotalRecords > 0)
                isPresent = true;

            return isPresent;
        }

        private bool CheckIfPlaceBelongsToTheGivenDistrict(int DistrictId,int CityVillageId)
        {
            bool isPresent = false;
            Query query = new Query();
            Criterion criteriaDistrict = new Criterion("st.DistrictId", DistrictId, CriteriaOperator.Equal);
            Criterion criteriaPlace = new Criterion("CityVillageId", CityVillageId, CriteriaOperator.Equal);
            query.Add(criteriaDistrict);
            query.Add(criteriaPlace);
            query.AddAlias(new Alias("st", "DistrictOfCityVillage"));

            CityVillageServiceReference.ICityVillageService client = new CityVillageServiceClient();
            var cityVillage = client.FindByQuery(query);
            if (cityVillage.TotalRecords > 0)
                isPresent = true;
            return isPresent;
        }

        public ActionResult GetCityVillage()
        {
            string district = "[Select]";
            if (Request.Params["district"] != null)
                district = Request.Params["district"];

            int districtId = 0; int cityVillageId=0;
            if (Request.Params["districtId"] != "null")
                districtId = Convert.ToInt32(Request.Params["districtId"]);

            string controlPrefix = Request.Params["CommonControlPrefix"];
            StateDistrictCityControlNamesModel model = new StateDistrictCityControlNamesModel(controlPrefix);
            model.HiddenFieldForDistrictValue = districtId;
            model.HiddenFieldForCityVillageValue = 0;
            string defaultCityVillageId = Request.Params["DefaultCityVillageId"];
            if (defaultCityVillageId != null && defaultCityVillageId != "[Select]" && defaultCityVillageId != "" && int.TryParse(defaultCityVillageId,out cityVillageId))
            {
                model.HiddenFieldForCityVillageValue = Convert.ToInt32(defaultCityVillageId);
                if (!CheckIfPlaceBelongsToTheGivenDistrict(districtId, model.HiddenFieldForCityVillageValue))
                    model.HiddenFieldForCityVillageValue = 0;
            }
            return PartialView("Places", model);
        }

#endregion

        #region AddnewCity
        public ActionResult AddNewCity()
        {
            CityVillageServiceReference.ICityVillageService client = new CityVillageServiceClient();
            DistrictServiceReference.IDistrictService dclient = new DistrictServiceClient();

            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            CityVillageDto cityVillageDto = new CityVillageDto();
            cityVillageDto.Name = Request.Params["ppPlace"].ToString();
            cityVillageDto.STDCode = Request.Params["ppSTDCode"].ToString();
            if (string.Equals(Request.Params["ppCityVillage"].ToString(), "City"))
            {
                cityVillageDto.CityOrVillage = CityVillageType.City;
            }
            else
            {
                cityVillageDto.CityOrVillage = CityVillageType.Village;
            }
            int DistrictId = Convert.ToInt32(Request.Params["ppdistrictId"]);
            cityVillageDto.DistrictOfCityVillage = dclient.GetById(DistrictId);

            cityVillageDto = client.Create(cityVillageDto,currentUserDto.UserName);
            if (cityVillageDto.Response.HasWarning)
            {
                ViewData["Error"] = ErrorAndValidationMessages.BRCityVillageNameValidation;
            }
            else
            {
                TempData["StateSaved"] = "City / Village Saved";
            }
            string controlPrefix = Request.Params["CommonControlPrefix"];

            Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel model = new Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel(controlPrefix);
            model.HiddenFieldForCityVillageValue = cityVillageDto.CityVillageId;
            model.HiddenFieldForDistrictValue = cityVillageDto.DistrictOfCityVillage.DistrictId;

            return PartialView("CallBackPopupAddCity", model);
        }
        #endregion

        #region Add Designation
        public ActionResult CreateNewUserDesignation()
        {
            DesignationServiceClient client = null;
            string Prefix = Request.Params["prefix"];
            DesignationModel designationModel = new DesignationModel(Prefix);
            try
            {
                string userDesignation = Request.Params["ppUserDesignation"];
                UserDto currentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                DesignationDto designation = new DesignationDto();
                designation.DesignationName = userDesignation;
                designation.CreatedBy = currentUser.UserId;
                designation.ModifiedBy = currentUser.UserId;
                client = new DesignationServiceClient();
                currentUser.ViewOfUserUserGroupRolePermissions = null;
                designation = client.Create(designation, currentUser.UserName);
                client.Close();
                if (designation.Response.HasWarning)
                {
                    foreach (BusinessWarning businessWarning in designation.Response.BusinessWarnings)
                    {
                        ViewData["Error"] = "Designation Present";
                    }
                }
                else
                {
                    TempData["DesignationId"] = designation.DesignationId.ToString();
                    TempData["GroupSaved"] = "Designation Saved";
                }
                
            }
            catch (Exception)
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                {
                    client.Close();
                }
            }
            return PartialView("CBPPopupAddDesignation", designationModel);
        }

        public ActionResult GetUpdatedUserDesignationList()
        {
            string Prefix = Request.Params["prefix"];
            DesignationModel designationModel = new DesignationModel(Prefix);
            if (Request.Params["AddedDesignation"] != null)
            {
                designationModel.SelectedId = (designationModel.designations.Find(x=>x.DesignationName == Convert.ToString(Request.Params["AddedDesignation"]))).DesignationId;
            }
            return PartialView("CBPUserDesignationList", designationModel);
        }
        public List<DesignationDto> GetUserDesignationList()
        {
            DesignationServiceReference.DesignationServiceClient client = new DesignationServiceClient();
            List<DesignationDto> designationdtos = client.FindAll().Entities.ToList();
            client.Close();
            designationdtos.Insert(0, new DesignationDto() { DesignationId = 0, DesignationName = "[Select]" });
            return designationdtos;

        }
        #endregion

        #region UnAuthorized Access
        public ActionResult UnAuthorizedAccess()
        {
            return View("UnAuthorizedAccess");
        }
        #endregion

        #region UploadImage Helper Methods
        public class UploadControlDemosHelper
        {
            public static readonly ValidationSettings
                ValidationSettings = new ValidationSettings
                {
                    AllowedFileExtensions =
                        new string[]
                                                {
                                                    ".jpg", ".jpeg", ".jpe",
                                                    ".gif", ".png"
                                                },
                    MaxFileSize = 20971520
                };


            public static void UploadImage(object sender, FileUploadCompleteEventArgs e)
            {
                if (e.UploadedFile.IsValid)
                {
                    string fileName = e.UploadedFile.FileName;
                    if (fileName.Contains('_'))
                    {
                        fileName = fileName.Replace('_', '-');
                    }
                    string imageNameWithGuid = (Guid.NewGuid()).ToString() + "_" + fileName;
                    string resultFilePath = UploadImagePath + imageNameWithGuid;
                    using (Image original = Image.FromStream(e.UploadedFile.FileContent))
                    using (Image thumbnail = PhotoUtils.Inscribe(original, 100))
                    {
                        PhotoUtils.SaveToJpeg(thumbnail, resultFilePath);
                    }
                    IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                    if (urlResolver != null)
                        // e.CallbackData = e.UploadedFile.FileName;
                        e.CallbackData = imageNameWithGuid;

                    UploadedImageFileName = imageNameWithGuid;
                }
            }


            public static class PhotoUtils
            {
                public static Image Inscribe(Image image, int size)
                {
                    return Inscribe(image, size, size);
                }

                public static Image Inscribe(Image image, int width, int height)
                {
                    Bitmap result = new Bitmap(width, height);
                    using (Graphics graphics = Graphics.FromImage(result))
                    {
                        double factor = 1.0 * width / image.Width;
                        if (image.Height * factor < height)
                            factor = 1.0 * height / image.Height;
                        Size size = new Size((int)(width / factor), (int)(height / factor));
                        Point sourceLocation = new Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2);

                        SmoothGraphics(graphics);
                        graphics.DrawImage(image, new Rectangle(0, 0, width, height),
                                           new Rectangle(sourceLocation, size), GraphicsUnit.Pixel);
                    }
                    return result;
                }

                private static void SmoothGraphics(Graphics g)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }

                public static void SaveToJpeg(Image image, string filePath)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                        image.Save(memoryStream, ImageFormat.Jpeg);
                        byte[] bytes = memoryStream.ToArray();
                        fileStream.Write(bytes, 0, bytes.Length);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    finally
                    {
                        memoryStream.Close();
                        if (fileStream != null)
                            fileStream.Close();
                    }
                }

            }
        }
        #endregion

        #region Date of Birth and Age
        public ActionResult GetAgeInYearsAndMonths()
        {
            string result = null;
            string sDate = Request.Params["newDate"];
            string prefix = Request.Params["prefix"];
            DateTime MaxDate = Convert.ToDateTime(Request.Params["MaxDate"]);
            DateTime MinDate = Convert.ToDateTime(Request.Params["MinDate"]);
            int Width = Convert.ToInt32(Request.Params["Width"]);
            DateTime birthDate = new DateTime();
            if (!String.IsNullOrEmpty(sDate))
            {
                string[] sDOB = sDate.Split('-');
                birthDate = new DateTime(Convert.ToInt32(sDOB[2]), Convert.ToInt32(sDOB[1]), Convert.ToInt32(sDOB[0]));
            }

            Age age = Helper.CalculateAge(birthDate);
            result = string.Format(ClientResources.URAgeInYearsMonths, age.Years, age.Months);
            DOBnAgeModel model = new DOBnAgeModel(prefix);
            model.BindDate = birthDate;
            model.MaxDate = MaxDate;
            model.MinDate = MinDate;
            model.Width = Width;
            ViewData["AgeinYearsMonths"] = result;
            return PartialView("CBPDOBnAge", model);
        }
        #endregion

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    // If session exists
        //    if (isUserLoggedout)
        //    {
        //        if (filterContext.HttpContext.Session != null)
        //        {
        //            if (this.Session[Constants.SKUSERNAME] == null)
        //            {
        //                filterContext.Result = RedirectToAction("LogOn", "Account");
        //                return;
        //            }
        //        }
        //        //otherwise continue with action
        //        base.OnActionExecuting(filterContext);
        //    }
        //}

        #region Common methods
        public ClientDto GetClient(int CAId, bool PopulateChildObjects)
        {
            ClientServiceClient clientService = new ClientServiceClient();
            ClientDto clientDto=null;
            clientService = new ClientServiceClient();
            Query query = new Query();
            Criterion criterionCAId = new Criterion("CAId", CAId, CriteriaOperator.Equal);
            query.Add(criterionCAId);
            var clients= clientService.FindByQuery(query, PopulateChildObjects);
            if (clients.TotalRecords != 0)
            {
                clientDto = clients.Entities.FirstOrDefault<ClientDto>();
            }

            return clientDto;
        }

        #endregion
    }
}
