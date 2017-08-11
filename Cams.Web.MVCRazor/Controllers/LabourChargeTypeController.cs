using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.Models.ClientMasters;
using Cams.Web.MVCRazor.ChargesPayableToServiceReference;
using Cams.Web.MVCRazor.LabourChargeTypesServiceReference;
using Cams.Common.Querying;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Message;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientMastersController : Controller
    {
        LabourChargeTypesServiceReference.LabourChargeTypeServiceClient LCTClient = null;

        [CamsAuthorize(Roles=Constants.LABOURCHARGETYPE,Permissions= CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult AddLabourChargeTypeIndex()
        {
            LabourChargeTypeModel model = new LabourChargeTypeModel();
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var LabourChargeId = Request.QueryString["labourchargeid"] != null ? Request.QueryString["labourchargeid"] : null;
            try
            {
                LCTClient = new LabourChargeTypeServiceClient();
                if (mode == "edit")
                {
                    FormMode = mode;
                    LabourChargeTypeDto labourchargedto = LCTClient.GetById(LabourChargeId != null ? Convert.ToInt32(LabourChargeId) : 0);
                    Id = labourchargedto.LabourChargeId;
                    model.LabourCharge = labourchargedto.LabourCharge;
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (LCTClient != null)
                    LCTClient.Close();
            }
            return View("AddLabourChargeType", model);
        }

        [CamsAuthorize(Roles = Constants.LABOURCHARGETYPE, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        [HttpPost]
        public ActionResult AddLabourChargeType(LabourChargeTypeModel model)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            try
            {
                LCTClient = new LabourChargeTypeServiceClient();
                if (ModelState.IsValid)
                {
                    LabourChargeTypeDto labourchargedto = new LabourChargeTypeDto();
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];

                    labourchargedto.LabourCharge = model.LabourCharge;
                    labourchargedto.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(currentUserDto));
                    labourchargedto.CreatedBy = currentUserDto.UserId;
                    labourchargedto.ModifiedBy = currentUserDto.UserId;



                    if (FormMode == "edit")
                    {
                        labourchargedto.LabourChargeId = Id;
                        labourchargedto = LCTClient.Update(labourchargedto,currentUserDto.UserName);
                    }
                    else
                    {
                        labourchargedto.CreatedBy = currentUserDto.UserId;
                        labourchargedto = LCTClient.Create(labourchargedto,currentUserDto.UserName);
                    }

                    if (labourchargedto.Response.HasWarning)
                    {
                        int i = 0;
                        foreach (BusinessWarning bw in labourchargedto.Response.BusinessWarnings)
                        {
                            if (bw.Message == Constants.BRLABOURCHARGEVALIDATION)
                            {
                                ModelState.AddModelError("err" + (++i).ToString(), ErrorAndValidationMessages.BRLabourChargeValidation);
                            }
                        }
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["LabourChargeSaved"] = ClientResources.AddLCTUpdated;
                        else
                            TempData["LabourChargeSaved"] = ClientResources.AddLCTSaved;
                        FormMode = string.Empty;
                        return RedirectToAction("LabourChargeTypesListIndex", "ClientMasters");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (LCTClient != null)
                    LCTClient.Close();
            }
            //model.ChargesPayableToList = GetChargesPayableTo();
            return View(model);
        }

        [CamsAuthorize(Roles = Constants.LABOURCHARGETYPE, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult LabourChargeTypesListIndex()
        {
            LabourChargeTypeModel model = new LabourChargeTypeModel();
            FormMode = string.Empty;
            try
            {
                model.LabourChargeTypeList = GetLabourChargesType();
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }

            return View("LabourChargeTypeList", model);
        }

        
        public ActionResult LabourChargeTypeListGridView(LabourChargeTypeModel model)
        {
            model.LabourChargeTypeList = GetLabourChargesType();
            return PartialView("LabourChargeTypeGridView", model);
        }

        [CamsAuthorize(Roles = Constants.LABOURCHARGETYPE, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult GetLabourChargeTypeView()
        {
            LabourChargeTypeModel model = new LabourChargeTypeModel();
            var LabourChargeId = Request.QueryString["labourchargeid"];
            try
            {
                LCTClient = new LabourChargeTypeServiceClient();
                LabourChargeTypeDto LCTdto = LCTClient.GetById(LabourChargeId != null ? Convert.ToInt32(LabourChargeId) : 0);
                model.LabourChargeId = LCTdto.LabourChargeId;
                model.LabourCharge = LCTdto.LabourCharge;
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (LCTClient != null)
                    LCTClient.Close();
            }
            return View("LabourChargeTypeView", model);
        }
       
        public List<LabourChargeTypeDto> GetLabourChargesType()
        {
            LCTClient = new LabourChargeTypeServiceClient();
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(currentUserDto), CriteriaOperator.Equal);
            query.Add(criteriaCAId);
            query.QueryOperator = QueryOperator.And;

            
            var labourchargetype = LCTClient.FindByQuery(query);
            LCTClient.Close();
            return labourchargetype.Entities.ToList();
        }
    }
}
