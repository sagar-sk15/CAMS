using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Dto.Address;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.APMCMasterServiceReference;
using Cams.Web.MVCRazor.CityVillageServiceReference;
using Cams.Web.MVCRazor.Models.Masters;
using DevExpress.Web.Mvc;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class MastersController : CommonController
    {
        private APMCMasterServiceReference.APMCServiceClient client = null;

        [CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult Apmc()
        {
            APMCModel model = new APMCModel();
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var APMCId = Request.QueryString["apmcid"] != null ? Request.QueryString["apmcid"] : null;
            try
            {
                client = new APMCServiceClient();
                if (mode == "edit")
                {
                    FormMode = mode;
                    APMCDto apmcdto = client.GetById(APMCId != null ? Convert.ToInt32(APMCId) : 0);
                    Id = apmcdto.APMCId;
                    model.Name = apmcdto.Name;
                    model.Address = apmcdto.Address;
                    model.ContactNos = apmcdto.ContactNos;
                    model.Email1 = apmcdto.Email1;
                    model.Email2 = apmcdto.Email2;
                    model.Status = apmcdto.Status;
                    model.Website = apmcdto.Website;
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue = apmcdto.Address.CityVillage.CityVillageId;
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue = apmcdto.Address.CityVillage.DistrictOfCityVillage.DistrictId;
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue = apmcdto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            return View("AddAPMC", model);
        }

        [CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        [HttpPost]
        public ActionResult AddApmc([ModelBinder(typeof(DevExpressEditorsBinder))]APMCModel apmcmodel)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;

            try
            {
                client = new APMCServiceClient();
                apmcmodel.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue =
                    !String.IsNullOrEmpty(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].PlacesComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].PlacesComboName + "_VI"]) : 0;
                apmcmodel.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue =
                    !String.IsNullOrEmpty(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].DistrictComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].DistrictComboName + "_VI"]) : 0;
                apmcmodel.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue =
                    !String.IsNullOrEmpty(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].StateComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[apmcmodel.StateDistrictPlacesControlNames[0].StateComboName + "_VI"]) : 0;
                
                int cityVillageID = 0;
                if (ComboBoxExtension.GetValue<object>("cmbCityVillage") != null)
                {
                    cityVillageID = ComboBoxExtension.GetValue<int>("cmbCityVillage");
                    if (cityVillageID == 0)
                    {
                        ModelState.AddModelError("", ErrorAndValidationMessages.APMCCityRequired);
                    }
                }

                if (ModelState.IsValid)
                {
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
                    APMCDto apmcDto = new APMCDto();
                    apmcDto.Name = apmcmodel.Name;
                    apmcDto.Status = apmcmodel.Status;
                    apmcDto.Website = apmcmodel.Website;
                    apmcDto.Email1 = apmcmodel.Email1;
                    apmcDto.Email2 = apmcmodel.Email2;
                    apmcDto.ModifiedBy = currentUserDto.UserId;

                    if (apmcmodel.ContactNos != null)
                    {
                        apmcDto.ContactNos = apmcmodel.ContactNos;
                        if (apmcDto.ContactNos != null && apmcDto.ContactNos.Count == 1)
                        {
                            if (String.IsNullOrEmpty(apmcDto.ContactNos[0].ContactNo))
                            {
                                apmcDto.ContactNos.RemoveAt(0);
                            }
                        }
                        

                        if (apmcmodel.Address != null)
                        {
                            apmcDto.Address = apmcmodel.Address;
                            //if (ComboBoxExtension.GetValue<object>("cmbCityVillage") != null)
                            //{
                            //    cityVillageID = ComboBoxExtension.GetValue<int>("cmbCityVillage");
                                apmcDto.Address.AddressLine1 = apmcmodel.Address.AddressLine1;
                                apmcDto.Address.PIN = apmcmodel.Address.PIN;
                                apmcDto.Address.CityVillage = new CityVillageDto
                                {
                                    CityVillageId = cityVillageID
                                };
                            //}
                        }
                    }

                    if (FormMode == "edit")
                    {
                        APMCDto ExistingAPMCDto = client.GetById(Id);
                        apmcDto.APMCId = Id;
                        apmcDto = client.Update(apmcDto, currentUserDto.UserName);
                    }
                    else
                    {
                        apmcDto.CreatedBy = currentUserDto.UserId;
                        apmcDto = client.Create(apmcDto, currentUserDto.UserName);
                    }

                    if (apmcDto.Response.HasWarning)
                    {
                        ViewData["Error"] = ErrorAndValidationMessages.APMCExists;
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["Success"] = string.Format(ClientResources.APMCUpdated, apmcDto.Name);
                        else
                            TempData["Success"] = string.Format(ClientResources.APMCSaved, apmcDto.Name);
                        FormMode = string.Empty;
                        return RedirectToAction("APMCListIndex", "Masters");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            return View(apmcmodel);
        }
        /// <summary>
        /// When user wants to add new Apmc using APMC popup.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddNewApmcUsingPopup()
        {
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            APMCDto apmcDto = new APMCDto();
            CityVillageServiceClient cityVillageServiceClient = new CityVillageServiceClient();
            client = new APMCServiceClient();
            try
            {
                apmcDto.Name = Request.Params["ApmcName"];
                apmcDto.Address = new AddressDto();
                apmcDto.Address.AddressLine1 = Request.Params["APMCAddress"];
                apmcDto.Address.PIN = Request.Params["ApmcPin"];
                apmcDto.Website = Request.Params["ApmcWebsite"];
                apmcDto.Email1 = Request.Params["ApmcEmail1"];
                apmcDto.Email2 = Request.Params["ApmcEmail2"];
                apmcDto.Address.PIN = Request.Params["ApmcPin"];
                apmcDto.Status = Request.Params["Status"];

                apmcDto.CreatedBy = currentUserDto.UserId;
                apmcDto.CreatedDate = DateTime.Now;
                apmcDto.ModifiedBy = currentUserDto.UserId;
                apmcDto.ModifiedDate = DateTime.Now;

                Query query = new Query();
                Criterion criteriaName = new Criterion("Name", Request.Params["ApmcPlace"], CriteriaOperator.Equal);
                query.Add(criteriaName);
                query.QueryOperator = QueryOperator.And;
                apmcDto.Address.CityVillage = cityVillageServiceClient.FindByQuery(query).Entities[0];
               
                apmcDto.ContactNos = new List<ContactDetailsDto>();
                for (int i = 0; i < 4; i++)
                {
                    if (Request.Params["ApmcContactNos" + i] != null)
                    {
                        ContactDetailsDto contactDetailsDto = new ContactDetailsDto();
                        contactDetailsDto.ContactNo = Request.Params["ApmcContactNos" + i];
                       
                        switch (Request.Params["ApmcContactNos"+i+"_ContactType"])
                        {
                            case "MobileNo":
                                contactDetailsDto.ContactNoType = ContactType.MobileNo;
                                break;
                            case "OfficeNo":
                                contactDetailsDto.ContactNoType = ContactType.OfficeNo;
                                contactDetailsDto.STDCode = Request.Params["ContactNos_" + i + "__STDCode"];
                                break;
                            case "ResidenceNo":
                                contactDetailsDto.ContactNoType = ContactType.ResidenceNo;
                                contactDetailsDto.STDCode = Request.Params["ContactNos_" + i + "__STDCode"];
                                break;
                            case "Fax":
                                contactDetailsDto.ContactNoType = ContactType.Fax;
                                contactDetailsDto.STDCode = Request.Params["ContactNos_" + i + "__STDCode"];
                                break;
                        }
                        apmcDto.ContactNos.Add(contactDetailsDto);
                    }
                }
                apmcDto=client.Create(apmcDto, currentUserDto.UserName);
                if (apmcDto.Response.HasWarning)
                {
                    ViewData["Apmcpresent"]= ErrorAndValidationMessages.APMCExists;
                }
                else
                {
                    ViewData["ApmcSaved"] = string.Format(ClientResources.APMCSaved, apmcDto.Name);
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");

            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();

                if (cityVillageServiceClient != null && cityVillageServiceClient.State == System.ServiceModel.CommunicationState.Opened)
                    cityVillageServiceClient.Close();
            }
            return null;
        }

        [CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult APMCListIndex()
        {
            APMCModel model = new APMCModel();
            try
            {
                model.APMCList = GetAPMCList();
                return View("APMCList", model);
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
        }

        public ActionResult APMCListGridView(APMCModel model)
        {
            model.APMCList = GetAPMCList();
            return PartialView("APMCListGridView", model);
        }

        public List<APMCDto> GetAPMCList()
        {
            client = new APMCServiceClient();
            var result = client.FindAll();
            client.Close();
            return result.Entities.ToList();
        }

        public ActionResult GetUpdatedApmcList()
        {
            return PartialView("APMCListPartial");
        }

        [CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult GetAPMCView()
        {
            APMCModel model = new APMCModel();
            var ApmcId = Request.QueryString["apmcid"];

            try
            {
                client = new APMCServiceClient();
                APMCDto ApmcDto = client.GetById(ApmcId != null ? Convert.ToInt32(ApmcId) : 0);
                model.APMCId = ApmcDto.APMCId;
                model.Name = ApmcDto.Name;
                model.Status = ApmcDto.Status;
                model.Address = ApmcDto.Address;
                model.ContactNos = ApmcDto.ContactNos;
                model.Website = ApmcDto.Website;
                model.Email1 = ApmcDto.Email1;
                model.Email2 = ApmcDto.Email2;
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            return View("APMCView", model);
        }
    }
}
