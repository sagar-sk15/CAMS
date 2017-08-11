using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Common.Dto.User;
using Cams.Common.Message;
using Cams.Web.MVCRazor.ClientServiceReference;
using Cams.Web.MVCRazor.DesignationServiceReference;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Web.MVCRazor.UserGroupServiceReference;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        public const int PageSize = 100;
        public bool isGroupSaved = false;
        public static Nullable<int> StaticCAId;
        public static int Id;
        UserListModel ULModel = null;
        public static string FormMode;

        public AccountController()
        {
            ULModel = new UserListModel();
        }

        #region UserGroups List
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS + "," + Constants.MANAGECLIENTUSERGROUP
            , Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult UserGroupsIndex()
        {
            UserGroupsModel UGModel = new UserGroupsModel();
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];

                FormMode = string.Empty;

                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.QueryString["CAId"]))
                    caID = Convert.ToInt32(Request.QueryString["CAId"]);

                string usertype = "";
                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                    usertype = Request.QueryString["userType"];

                CriteriaOperator Operator = CriteriaOperator.Equal;
                if (usertype == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                {
                    UGModel.CAId = null;
                    Operator = CriteriaOperator.IsNullOrZero;
                }
                else if (usertype == "CAUser" && (caID != null || caID != 0))
                    UGModel.CAId = caID;
                else
                    UGModel.CAId = Helper.GetCAIdOfUser(CurrentUser);

                Query query = new Query();
                Criterion criteriaCAId;
                criteriaCAId = new Criterion(Constants.CAID, UGModel.CAId, Operator);
                query.Add(criteriaCAId);

                ViewData["UserGroupList"] = GetUserGroupsList(query);
                UGModel.ClientList = GetCAList();
                StaticCAId = UGModel.CAId;
                ViewData["SelectedClient"] = UGModel.CAId != null ? UGModel.ClientList.ToList().FindIndex(FindClient) : 0;
                ViewData["userType"] = usertype;
                ViewData["CAId"] = UGModel.CAId;
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return View("UserGroups", UGModel);
        }

        public ActionResult UserGroupsGrid()
        {
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                    caID = Convert.ToInt32(Request.Params["CAId"]);

                string usertype = "";
                if (!string.IsNullOrEmpty(Request.Params["userType"]))
                    usertype = Request.Params["userType"];

                CriteriaOperator Operator = CriteriaOperator.Equal;
                if (usertype == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                    Operator = CriteriaOperator.IsNullOrZero;

                Query query = new Query();
                Criterion criteriaCAId;
                criteriaCAId = new Criterion(Constants.CAID, caID, Operator);
                query.Add(criteriaCAId);

                ViewData["UserGroupList"] = GetUserGroupsList(query);
                ViewData["userType"] = usertype;
                ViewData["CAId"] = caID;
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return PartialView("UserGroupsGrid", ViewData["UserGroupList"]);
        }

        public ActionResult cbpUGroupList()
        {
            UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
            Nullable<int> caID = null;
            if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                caID = Convert.ToInt32(Request.Params["CAId"]);

            string usertype = "";
            if (!string.IsNullOrEmpty(Request.Params["userType"]))
                usertype = Request.Params["userType"];

            CriteriaOperator Operator = CriteriaOperator.Equal;
            if (usertype == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                Operator = CriteriaOperator.IsNullOrZero;

            Query query = new Query();
            Criterion criteriaCAId;
            criteriaCAId = new Criterion(Constants.CAID, caID, Operator);
            query.Add(criteriaCAId);

            ViewData["UserGroupList"] = GetUserGroupsList(query);
            return PartialView("cbpUserGroupsList", ViewData["UserGroupList"]);
        }

        public List<UserGroupDto> GetUserGroupsList(Query query)
        {
            UserGroupServiceClient client = new UserGroupServiceClient();
            var result = client.FindByQuery(query);
            client.Close();
            return result.Entities.ToList();
        }

        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS + "," + Constants.MANAGECLIENTUSERGROUP,
            Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult GetUserGroupsView()
        {
            UserGroupModel model = new UserGroupModel();
            UserGroupServiceClient client = null;
            try
            {
                var UsergroupId = Request.QueryString["usergroupid"];
                client = new UserGroupServiceClient();
                UserGroupDto ugdto = client.GetById(UsergroupId != null ? Convert.ToInt32(UsergroupId) : 0);
                client.Close();
                model.UserGroupId = ugdto.UserGroupId;
                model.UserGroupName = ugdto.UserGroupName;
                model.Description = ugdto.Description;
                model.IsActive = ugdto.IsActive;
                model.AllowEdit = ugdto.AllowEdit;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            return View("UserGroupsView", model);
        }

        #endregion

        #region Create User Group
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS + "," + Constants.MANAGECLIENTUSERGROUP, 
            Permissions = CamsAuthorizeAttribute.RolePermission.Add)] 
        public ActionResult UserGroup()
        {
            UserGroupModel model = new UserGroupModel();
            UserGroupServiceClient client = null;
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
                int usergroupid = 0;
                if (Request.QueryString["usergroupid"] != null)
                    usergroupid = Convert.ToInt32(Request.QueryString["usergroupid"]);

                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.QueryString["CAId"]))
                {
                    caID = Convert.ToInt32(Request.QueryString["CAId"]);
                    model.Client = GetClient(Convert.ToInt32(caID));
                }

                string usertype = "";
                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                    usertype = Request.QueryString["userType"];

                if (usertype == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                    model.CAId = null;
                else if (usertype == "CAUser" && (caID != null || caID != 0))
                    model.CAId = caID;
                else
                    model.CAId = Helper.GetCAIdOfUser(CurrentUser);

                if (mode == "edit")
                {
                    FormMode = mode;
                    client = new UserGroupServiceClient();
                    UserGroupDto ugdto = client.GetById(usergroupid);
                    Id = ugdto.UserGroupId;
                    model.UserGroupName = ugdto.UserGroupName;
                    model.Description = ugdto.Description;
                    model.IsActive = ugdto.IsActive;
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                {
                    client.Close();
                }
            }
            return View("CreateUserGroup", model);
        }

        /// <summary>
        /// This method create new user group
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS + "," + Constants.MANAGECLIENTUSERGROUP,
                Permissions = CamsAuthorizeAttribute.RolePermission.Add)] 
        public ActionResult CreateUserGroup(UserGroupModel model)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                string usertype = "";

                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                    usertype = Request.QueryString["userType"];

                if (ModelState.IsValid)
                {
                    UserDto currentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                    UserGroupServiceClient client = new UserGroupServiceClient();
                    UserGroupDto NewUserGroup = new UserGroupDto();
                    if (FormMode == "edit")
                    {
                        NewUserGroup = client.GetById(Id);
                        client.Close();
                    }
                    else
                    {
                        NewUserGroup.IsDeleted = model.IsDeleted;
                        NewUserGroup.AllowEdit = model.AllowEdit;
                        NewUserGroup.AllowDelete = model.AllowDelete;
                        NewUserGroup.CreatedBy = currentUser.UserId;
                    }
                    NewUserGroup.UserGroupName = FirstCharInUpper(model.UserGroupName);
                    NewUserGroup.Description = model.Description;
                    NewUserGroup.CAId = model.CAId;
                    NewUserGroup.IsActive = model.IsActive;
                    
                    NewUserGroup.ModifiedBy = currentUser.UserId;
                    CreateUserGroupService(NewUserGroup, currentUser);
                    if (isGroupSaved)
                        return RedirectToAction("UserGroupsIndex", "Account",
                                                new { usertype = usertype, CAId = model.CAId });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return View(model);
        }

        private void CreateUserGroupService(UserGroupDto NewUserGroup, UserDto currentUser)
        {
            UserGroupServiceClient client = new UserGroupServiceClient();
            try
            {
                if (FormMode == "edit")
                {
                    NewUserGroup.UserGroupId = Id;
                    NewUserGroup = client.Update(NewUserGroup, currentUser.UserName);
                }
                else
                {
                    NewUserGroup.CreatedBy = currentUser.UserId;
                    NewUserGroup = client.Create(NewUserGroup, currentUser.UserName);
                }
                if (NewUserGroup.Response.HasWarning)
                {
                    foreach (BusinessWarning businessWarning in NewUserGroup.Response.BusinessWarnings)
                    {
                        ViewData["Error"] = ErrorAndValidationMessages.ResourceManager.GetString(businessWarning.Message);
                    }
                }
                else
                {
                    if (FormMode == "edit")
                        TempData["GroupSaved"] = String.Format(ClientResources.UserGroupUpdated, NewUserGroup.UserGroupName);
                    else
                        TempData["GroupSaved"] = String.Format(ClientResources.UserGroupAdded, NewUserGroup.UserGroupName);
                    isGroupSaved = true;
                }
            }
            catch (Exception)
            {
                client.Close();
            }
        }

        public void CreateNewUserGroup()
        {
            string userGroupName = Request.Params["ppGroupName"];
            string description = Request.Params["ppDescription"];
            UserDto currentUser = (UserDto)Session[Constants.SKCURRENTUSER];
            UserGroupDto NewUserGroup = new UserGroupDto();
            NewUserGroup.UserGroupName = userGroupName;
            NewUserGroup.Description = description;
            NewUserGroup.CreatedBy = currentUser.UserId;
            NewUserGroup.ModifiedBy = currentUser.UserId;
            NewUserGroup.IsActive = true;
            NewUserGroup.IsDeleted = false;
            NewUserGroup.AllowEdit = true;
            NewUserGroup.AllowDelete = true;
            CreateUserGroupService(NewUserGroup, currentUser);
        }
        /// <summary>
        /// Get the usergroupList when added from UserGroup Popup
        /// </summary>
        /// <returns></returns>
        //[CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS + "," + Constants.MANAGECLIENTUSERGROUP,
        //    Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult GetUpdatedUserGroupList()
        {
            Nullable<int> caID = null;
            if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                caID = Convert.ToInt32(Request.Params["CAId"]);
            List<UserGroupDto> ugList = GetUserGroupList(caID);
            return PartialView("CallBackPanelUserGroupList", ugList);
        }

        public void CreateDesignation()
        {
            DesignationServiceClient client = null;
            try
            {
                string userDesignation = Request.Params["ppUserDesignation"];
                UserDto currentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                DesignationDto designation = new DesignationDto();
                designation.DesignationName = userDesignation;
                designation.CreatedBy = currentUser.UserId;
                designation.ModifiedBy = currentUser.UserId;
                client = new DesignationServiceClient();
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
        }

        
        /// <summary>
        /// This method capitalize first letter of every word in group name.
        /// </summary>
        /// <param name="strname"></param>
        /// <returns></returns>
        public string FirstCharInUpper(string strname)
        {
            var words = strname.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = words.Select(w => w[0].ToString().ToUpper() + w.ToLower().Remove(0, 1)).Aggregate((s, w) => s + ' ' + w);
            return result.Trim();
        }

        private static bool FindClient(ClientDto clientdto)
        {
            if (clientdto.CAId == StaticCAId)
            {
                StaticCAId = 0;
                return true;
            }
            else
                return false;
        }

        #endregion

        #region User List
        public ActionResult UserGroupList()
        {
            Nullable<int> caID = null;
            try
            {
                if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                    caID = Convert.ToInt32(Request.Params["CAId"]);
                ULModel.UserGroupList = GetUserGroupList(caID);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            return PartialView("UserGroupList", ULModel);
        }

        [CamsAuthorize(Roles = Constants.MANAGEACKUSERS + "," + Constants.MANAGECLIENTUSERS,
            Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        public ActionResult UsersIndex()
        {
            try
            {
                ULModel = new UserListModel();
                CheckMode = "none";
                string userGroupIdList = "0";
                if (!string.IsNullOrEmpty(Request.Params["UserGroupIdList"]))
                    userGroupIdList = Convert.ToString(Request.Params["UserGroupIdList"]);

                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                    caID = Convert.ToInt32(Request.Params["CAId"]);
                else if (!string.IsNullOrEmpty(Request.QueryString["CAId"]))
                    caID = Convert.ToInt32(Request.QueryString["CAId"]);

                string usertype = "";
                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                    usertype = Request.QueryString["userType"];

                ULModel.ClientList = GetCAList();
                ULModel.UserGroupList = GetUserGroupList(caID);

                ViewData["UserGroupIdList"] = userGroupIdList;
                ULModel.SelectedUserGroupList = userGroupIdList;
                //Add the default criteria for ack users
                ULModel.SelectedUserGroupList = userGroupIdList;
                ULModel.UserList = GetUsersList(BuildQueryForUserList(userGroupIdList, usertype, caID));
                StaticCAId = caID;
                ViewData["UserGroupList"] = ULModel.UserGroupList;
                ViewData["UserGroupIdList"] = "0";
                ViewData["FilteredUsers"] = ULModel.UserList;
                ViewData["SelectedClient"] = (usertype == "CAUser") && (caID != null) ? ULModel.ClientList.ToList().FindIndex(x => x.CAId == caID) : 0;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            return View("Users", ULModel);
        }

        public List<UserGroupDto> GetUserGroupList(int? CAId)
        {
            UserGroupServiceClient client = new UserGroupServiceClient();
            List<UserGroupDto> ugList = null;
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                string usertype = "";
                if (!string.IsNullOrEmpty(Request.Params["userType"]))
                    usertype = Request.Params["userType"];
                Query query = new Query();
                Criterion criteriaCAId;

                if (usertype == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                    criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                else if (usertype == "CAUser" && (CAId != null || CAId != 0))
                    criteriaCAId = new Criterion(Constants.CAID, CAId, CriteriaOperator.Equal);
                else
                    criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(CurrentUser), CriteriaOperator.Equal);

                query.Add(criteriaCAId);
                query.QueryOperator = QueryOperator.And;
                var usergroupdtos = client.FindByQuery(query);
                ugList = usergroupdtos.Entities.ToList();
                ugList.Insert(0, new UserGroupDto
                {
                    UserGroupId = 0,
                    UserGroupName = "[Select All]"
                });
            }
            catch (Exception ex)
            { }
            finally
            {
                client.Close();
            }
            return ugList;
        }

        public List<ClientDto> GetCAList()
        {
            ClientServiceClient client = new ClientServiceClient();
            //UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
            Query query = new Query();
            Criterion crActive = new Criterion("IsActive", true, CriteriaOperator.Equal);
            query.Add(crActive);
            EntityDtos<ClientDto> clientDtos = client.FindByQuery(query, false);

            //var caDtos = client.FindAll();
            List<ClientDto> caList = clientDtos.Entities.ToList();
            caList.Insert(0, new ClientDto
            {
                CAId = 0,
                CompanyName = "[Select]",
                DisplayClientId = ""
            });
            client.Close();
            return caList;
        }

        public ActionResult CBPPartialUsers()
        {
            string userGroupIdList = "-1";
            if (!string.IsNullOrEmpty(Request.Params["UserGroupIdList"]))
                userGroupIdList = Convert.ToString(Request.Params["UserGroupIdList"]);
            Nullable<int> caID = null;
            if (!string.IsNullOrEmpty(Request.Params["CAId"]) && Request.Params["CAId"]!="null")
                caID = Convert.ToInt32(Request.Params["CAId"]);
            string usertype = "";
            if (!string.IsNullOrEmpty(Request.Params["userType"]) && Request.Params["userType"]!="null")
                usertype = Request.Params["userType"];

            ViewData["UserGroupIdList"] = userGroupIdList;
            ULModel.SelectedUserGroupList = userGroupIdList;
            ULModel.UserList = GetUsersList(BuildQueryForUserList(userGroupIdList, usertype, caID));
            ViewData["FilteredUsers"] = ULModel.UserList;

            return PartialView("CallbackUserGrid", ULModel.UserList);
        }

        private Query BuildQueryForUserList(string UserGroupIdList, string UserType, int? CAId)
        {

            //Default Criteria
            Query query = new Query();
            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                Criterion criteriaCAId;
                string[] ugIdList = UserGroupIdList.Split(';');

                //query.AddAlias(new Alias("UserOfClient", "UserOfClient"));
                //Is SuperAdmin and Ack User
                if (UserType == "AckUser" && !Helper.IsCAIdNotNull(CurrentUser))
                {
                    //query.AddAlias(new Alias("UserOfClient", "UserOfClient",JoinType.LeftOuterJoin));
                    //criteriaCAId = new Criterion("UserOfClient.CAId", null, CriteriaOperator.IsNullOrZero);
                    criteriaCAId = new Criterion("CAId", null, CriteriaOperator.IsNullOrZero);
                    query.Add(criteriaCAId);
                    //IList<Criterion> criList = new List<Criterion>();
                    //criList.Add(criteriaCAId);
                    //query.AddJoinParamteres(new JoinParameters("UserOfClient", "UserOfClient", JoinType.LeftOuterJoin,criList));
                }
                else if (UserType == "CAUser" && (CAId != null || CAId != 0))
                {
                    //query.AddAlias(new Alias("UserOfClient", "UserOfClient"));
                    //criteriaCAId = new Criterion("UserOfClient.CAId", CAId, CriteriaOperator.Equal);
                    criteriaCAId = new Criterion("CAId", CAId, CriteriaOperator.Equal);
                    query.Add(criteriaCAId);
                }
                else
                {
                    //query.AddAlias(new Alias("UserOfClient", "UserOfClient"));
                    //criteriaCAId = new Criterion("UserOfClient.CAId", Helper.GetCAIdOfUser(CurrentUser), CriteriaOperator.Equal);
                    criteriaCAId = new Criterion("CAId", Helper.GetCAIdOfUser(CurrentUser), CriteriaOperator.Equal);
                    query.Add(criteriaCAId);
                }
                
                Query subquery = null; ;
                query.AddAlias(new Alias("ug", "UserWithUserGroups"));
                //Add Filter criteria on selected UserGroups
                Criterion criteriaUserGroup = null;
                foreach (string ugId in ugIdList)
                {
                    int userGroupId = Convert.ToInt32(ugId);
                    if (userGroupId == 0)
                    {
                        //query.AddAlias(new Alias("ug", "UserWithUserGroups"));
                        break;
                    }
                    else
                    {
                        if (userGroupId != -1)
                        {
                            //if (query.Alias.ToList().Count == 0)
                            //    query.AddAlias(new Alias("ug", "UserWithUserGroups"));
                            criteriaUserGroup = new Criterion(Constants.USERGROUPID, userGroupId, CriteriaOperator.Equal);
                            if (subquery == null)
                                subquery = new Query();
                            subquery.Add(criteriaUserGroup);
                            subquery.QueryOperator = QueryOperator.Or;
                        }
                    }
                }
                if (subquery != null)
                {
                    query.AddSubQuery(subquery);
                    query.QueryOperator = QueryOperator.And;
                }
            }
            catch (Exception ex)
            {
            }
            return query;
        }

        public ActionResult UsersGrid()
        {
            try
            {
                string userGroupIdList = "-1";
                if (!string.IsNullOrEmpty(Request.Params["UserGroupIdList"]))
                    userGroupIdList = Convert.ToString(Request.Params["UserGroupIdList"]);
                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                    caID = Convert.ToInt32(Request.Params["CAId"]);
                string usertype = "";
                if (!string.IsNullOrEmpty(Request.Params["userType"]))
                    usertype = Request.Params["userType"];

                ViewData["UserGroupIdList"] = userGroupIdList;
                ULModel.SelectedUserGroupList = userGroupIdList;
                ULModel.UserList = GetUsersList(BuildQueryForUserList(userGroupIdList, usertype, caID));
                ViewData["FilteredUsers"] = ULModel.UserList;
                ViewData["FilteredUsers"] = ULModel.UserList;
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return PartialView("UsersGrid", ViewData["FilteredUsers"]);
        }

        public IList<UserDto> GetUsersList(Query query)
        {
            UserServiceClient client = new UserServiceClient();
            var result = client.FindByQuery(query,false);
            client.Close();
            return result.Entities.ToList<UserDto>();
        }

        #endregion

        #region Private Methods
        private IList<ClientDto> GetClientList()
        {
            ClientServiceClient client = new ClientServiceClient();
            Query query = new Query();
            Criterion crActive = new Criterion("IsActive", true, CriteriaOperator.Equal);
            query.Add(crActive);
            EntityDtos<ClientDto> clientDtos = client.FindByQuery(query,false);
            client.Close();
            return clientDtos.Entities;
        }
        private ClientDto GetClient(int CAId)
        {
            ClientServiceClient client = new ClientServiceClient();
            ClientDto clientDto = client.GetById(CAId);
            client.Close();
            return clientDto;
        }
        #endregion

        #region ClientGridView Action Methods

        public ActionResult ClientUserGroup()
        {
            ViewData["ClientList"] = GetClientList();
            return View("ClientCreateUserGroup");
        }

        public ActionResult ClientGridView()
        {
            ViewData["ClientList"] = GetClientList();
            return PartialView("ClientGridView", ViewData["ClientList"]);
        }
        #endregion
    }
}



