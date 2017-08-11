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
using Cams.Web.MVCRazor.ZonesMasterServiceReference;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientMastersController : Controller
    {
        private ZonesMasterServiceReference.ZoneServiceClient ZonesMasterClient = null;
        public static string FormMode;
        public static int Id;
        public static long LongId;

        #region public methods
        [CamsAuthorize(Roles = Constants.ZONE, Permissions = CamsAuthorizeAttribute.RolePermission.Add)] 
        public ActionResult AddZoneIndex()
        {
            ZoneModel model = new ZoneModel();
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var ZoneId = Request.QueryString["zoneid"] != null ? Request.QueryString["zoneid"] : null;
            try
            {
                ZonesMasterClient = new ZoneServiceClient();
                if (mode == "edit")
                {
                    FormMode = mode;
                    ZoneDto zonedto = ZonesMasterClient.GetById(ZoneId != null ? Convert.ToInt32(ZoneId) : 0);
                    LongId = zonedto.ZoneId;
                    model.ZoneId = zonedto.ZoneId;
                    model.Name = zonedto.Name;
                    model.ZoneFor = zonedto.ZoneFor;
                    model.IsActive = zonedto.IsActive;
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (ZonesMasterClient != null)
                    ZonesMasterClient.Close();
            }
            return View("AddZone", model);
        }

        [CamsAuthorize(Roles = Constants.ZONE, Permissions = CamsAuthorizeAttribute.RolePermission.Add)] 
        public ActionResult AddZone(ZoneModel model)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            
            try
            {
                ZonesMasterClient = new ZoneServiceClient();
                if (ModelState.IsValid)
                {
                    ZoneDto zonemasterdto = new ZoneDto();

                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
                    zonemasterdto.CAId = Helper.GetCAIdOfUser(currentUserDto);
                    zonemasterdto.ZoneFor = model.ZoneFor;
                    zonemasterdto.Name = model.Name.Trim();
                    zonemasterdto.IsActive = model.IsActive;
                    zonemasterdto.CreatedBy = currentUserDto.UserId;
                    zonemasterdto.CreatedDate = DateTime.Now;
                    zonemasterdto.ModifiedBy = currentUserDto.UserId;
                    zonemasterdto.ModifiedDate = DateTime.Now;

                    if (FormMode == "edit")
                    {
                        zonemasterdto.ZoneId = LongId;
                        zonemasterdto = ZonesMasterClient.Update(zonemasterdto,currentUserDto.UserName);
                    }
                    else
                    {
                        zonemasterdto.CreatedBy = currentUserDto.UserId;
                        zonemasterdto = ZonesMasterClient.Create(zonemasterdto,currentUserDto.UserName);
                    }

                    if (zonemasterdto.Response.HasWarning)
                    {
                        ViewData["Error"] = string.Format(ErrorAndValidationMessages.AddZoneAddZoneFailed, model.Name, model.ZoneFor);
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["StateSaved"] = string.Format(ClientResources.ZoneListZoneUpdated, zonemasterdto.Name, zonemasterdto.ZoneFor.ToString());
                        else
                            TempData["StateSaved"] = string.Format(ClientResources.ZoneListZoneSaved, zonemasterdto.Name, zonemasterdto.ZoneFor.ToString());
                        FormMode = string.Empty;
                        return RedirectToAction("ZoneListIndex", "ClientMasters");

                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (ZonesMasterClient != null)
                    ZonesMasterClient.Close();
            }
            return View(model);
        }

        [CamsAuthorize(Roles = Constants.ZONE, Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult ZoneListIndex()
        {
            ZoneModel model = new ZoneModel();
            try
            {
                FormMode = string.Empty;
                model.ZoneList = GetZoneList();
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            return View("ZoneList", model);
        }
                
        public ActionResult ZoneListGridView(ZoneModel model)
        {
            model.ZoneList = GetZoneList();
            return PartialView("ZoneListGridView", model);
        }

        [CamsAuthorize(Roles = Constants.ZONE, Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult GetZoneView()
        {
            ZonesMasterClient = new ZoneServiceClient();
            ZoneModel model = new ZoneModel();
            var ZoneId = Request.QueryString["zoneid"];
            ZoneDto zonedto = ZonesMasterClient.GetById(ZoneId != null ? Convert.ToInt32(ZoneId) : 0);
            model.ZoneId = zonedto.ZoneId;
            model.Name = zonedto.Name;
            model.ZoneFor = zonedto.ZoneFor;
            model.IsActive = zonedto.IsActive;
            return View("ZoneView", model);
        }

        #endregion

        #region private methods
        private List<ZoneDto> GetZoneList()
        {
            ZonesMasterClient = new ZoneServiceClient();
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(currentUserDto), CriteriaOperator.Equal);
            query.Add(criteriaCAId);
            query.QueryOperator = QueryOperator.And;
            EntityDtos<ZoneDto> zonedtos = ZonesMasterClient.FindByQuery(query);
            ZonesMasterClient.Close();
            return zonedtos.Entities.ToList();
        }
        #endregion

    }
}
