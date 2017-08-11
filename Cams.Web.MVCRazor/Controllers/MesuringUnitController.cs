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
using Cams.Web.MVCRazor.MeasuringUnitServiceReference;
using Cams.Common.Querying;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Message;
using System.Runtime.Serialization;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientMastersController : Controller
    {
        private MeasuringUnitServiceReference.MeasuringUnitServiceClient MUClient = null;

        [CamsAuthorize(Roles = Constants.MEASURINGUNIT, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult AddMeasuringUnitIndex()
        {
            MeasuringUnitModel model = new MeasuringUnitModel();
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var MeasuringUnitId = Request.QueryString["measuringunitid"] != null ? Request.QueryString["measuringunitid"] : null;
            try
            {
                MUClient = new MeasuringUnitServiceClient();
                if (mode == "edit")
                {
                    FormMode = mode;
                    MeasuringUnitDto measuringunitdto = MUClient.GetById(MeasuringUnitId != null ? Convert.ToInt32(MeasuringUnitId) : 0);
                    Id = measuringunitdto.UnitId;
                    model.UnitType = measuringunitdto.UnitType;
                    model.UnitId = measuringunitdto.UnitId;
                    if (model.UnitType == Cams.Common.UnitType.Weight)
                    {
                        model.MeasurementUnitWeight = measuringunitdto.MeasurementUnit;
                        model.EquivalentUnitWeight = measuringunitdto.EquivalentUnit;
                    }
                    else
                    {
                        model.MeasurementUnitQuantity = measuringunitdto.MeasurementUnit;
                        model.EquivalentUnitQuantity = measuringunitdto.EquivalentUnit;
                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (MUClient != null)
                    MUClient.Close();
            }
            return View("AddMeasuringUnit",model);
        }

        [CamsAuthorize(Roles = Constants.MEASURINGUNIT, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult AddMeasuringUnit(MeasuringUnitModel model)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            try
            {
                MUClient = new MeasuringUnitServiceClient();
                if (ModelState.IsValid && ((!String.IsNullOrEmpty(model.MeasurementUnitWeight) && !String.IsNullOrEmpty(model.EquivalentUnitWeight)) || (!String.IsNullOrEmpty(model.MeasurementUnitQuantity) && !String.IsNullOrEmpty(model.EquivalentUnitQuantity))))
                {
                    MeasuringUnitDto measuringunitdto = new MeasuringUnitDto();
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];

                    measuringunitdto.UnitType = model.UnitType;
                    measuringunitdto.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(currentUserDto));
                    measuringunitdto.CreatedBy = currentUserDto.UserId;
                    measuringunitdto.ModifiedBy = currentUserDto.UserId;

                    if (!String.IsNullOrEmpty(model.MeasurementUnitWeight) && !String.IsNullOrEmpty(model.EquivalentUnitWeight))
                    {
                        measuringunitdto.MeasurementUnit = model.MeasurementUnitWeight;
                        measuringunitdto.EquivalentUnit = model.EquivalentUnitWeight;
                    }

                    if (!String.IsNullOrEmpty(model.MeasurementUnitQuantity) && !String.IsNullOrEmpty(model.EquivalentUnitQuantity))
                    {
                        measuringunitdto.MeasurementUnit = model.MeasurementUnitQuantity;
                        measuringunitdto.EquivalentUnit = model.EquivalentUnitQuantity;
                    }

                    if (FormMode == "edit")
                    {
                        measuringunitdto.UnitId = Id;
                        measuringunitdto = MUClient.Update(measuringunitdto,currentUserDto.UserName);
                    }
                    else
                    {
                        measuringunitdto.CreatedBy = currentUserDto.UserId;
                        measuringunitdto = MUClient.Create(measuringunitdto,currentUserDto.UserName);
                    }

                    if (measuringunitdto.Response.HasWarning)
                    {
                        int i = 0;
                        foreach (BusinessWarning bw in measuringunitdto.Response.BusinessWarnings)
                        {
                            if (bw.Message == Constants.BRMUMEASURINGUNITVALIDATION)
                            {
                                ModelState.AddModelError("err" + (++i).ToString(), ErrorAndValidationMessages.BRMUMeasuringUnitValidation);
                            }
                        }
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["StateSaved"] = ClientResources.MUUpdate;
                        else
                            TempData["StateSaved"] = string.Format(ClientResources.MUSaved, measuringunitdto.MeasurementUnit, measuringunitdto.UnitType);
                        FormMode = string.Empty;
                        return RedirectToAction("MeasuringUnitListIndex", "ClientMasters");
                    }
                }
                else
                {
                    ModelState.AddModelError("err", ErrorAndValidationMessages.AddMUDataRequired);
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (MUClient != null)
                    MUClient.Close();
            }
            return View(model);
        }

        [CamsAuthorize(Roles = Constants.MEASURINGUNIT, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult MeasuringUnitListIndex()
        {
            MeasuringUnitModel model = new MeasuringUnitModel();
            FormMode = string.Empty;
            try
            {
                model.UnitType = UnitType.Weight;
                model.MeasuringUnitList = GetMeasuringUnit(model);
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            return View("MeasuringUnitList", model);
        }

        [CamsAuthorize(Roles = Constants.MEASURINGUNIT, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult MeasuringUnitList(MeasuringUnitModel model)
        {
            model.MeasuringUnitList = GetMeasuringUnit(model);
            return View(model);
        }
                
        public ActionResult MeasuringUnitListGridView(MeasuringUnitModel model)
        {
            model.MeasuringUnitList = GetMeasuringUnit(model);
            return PartialView("MeasuringUnitListGridView", model);
        }

        [CamsAuthorize(Roles = Constants.MEASURINGUNIT, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult GetMeasuringUnitView()
        {
            MeasuringUnitModel model = new MeasuringUnitModel();
            var MeasuringUnitId = Request.QueryString["measuringunitid"];
            try
            {
                MUClient = new MeasuringUnitServiceClient();
                MeasuringUnitDto measuringunitdto = MUClient.GetById(MeasuringUnitId != null ? Convert.ToInt32(MeasuringUnitId) : 0);
                model.UnitType = measuringunitdto.UnitType;
                model.UnitId = measuringunitdto.UnitId;
                if (model.UnitType == Cams.Common.UnitType.Weight)
                {
                    model.MeasurementUnitWeight = measuringunitdto.MeasurementUnit;
                    model.EquivalentUnitWeight = measuringunitdto.EquivalentUnit;
                }
                else
                {
                    model.MeasurementUnitQuantity = measuringunitdto.MeasurementUnit;
                    model.EquivalentUnitQuantity = measuringunitdto.EquivalentUnit;
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (MUClient != null)
                    MUClient.Close();
            }
            return View("MeasuringUnitView", model);
        }

        public List<MeasuringUnitDto> GetMeasuringUnit(MeasuringUnitModel model)
        {
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(currentUserDto), CriteriaOperator.Equal);
            Criterion criteriaUnitType;
            if(model.UnitType==Common.UnitType.Weight)
                criteriaUnitType = new Criterion(Constants.UNITTYPE, model.UnitType, CriteriaOperator.Equal);
            else
                criteriaUnitType = new Criterion(Constants.UNITTYPE, model.UnitType, CriteriaOperator.Equal);
            query.Add(criteriaCAId);
            query.Add(criteriaUnitType);
            query.QueryOperator = QueryOperator.And;
            MUClient = new MeasuringUnitServiceClient();
            var MeasuringUnits = MUClient.FindByQuery(query);
            MUClient.Close();
            return MeasuringUnits.Entities.ToList();
        }

    }
}
