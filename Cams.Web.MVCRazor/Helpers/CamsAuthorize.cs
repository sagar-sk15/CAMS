using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Common.Dto.User;
using Cams.Common;

namespace Cams.Web.MVCRazor.Helpers
{
    public class CamsAuthorizeAttribute : AuthorizeAttribute
    {
        public enum RolePermission
        { 
            Add, 
            Update, 
            View, 
            Delete,
            Print
        }

        public RolePermission Permissions { get; set; } 

        public override void OnAuthorization(AuthorizationContext filterContext)     
        {         
            base.OnAuthorization(filterContext);          
            //do custom authorizization using Action and getting ArticleID          
            //from filterContext.HttpContext.Request.QueryString or         
            //filterContext.HttpContext.Request.Form     

            var principal = filterContext.HttpContext.User;
            if (principal == null)
                return ;

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        { 
            if (httpContext == null) 
            { 
                throw new ArgumentNullException("httpContext"); 
            } 

            IPrincipal user = httpContext.User; 
            if (!user.Identity.IsAuthenticated) 
            { 
                return false; 
            }

            UserDto currentUser = (UserDto)httpContext.Session[Constants.SKCURRENTUSER];

            string usertype = httpContext.Request.QueryString["usertype"];

            string oriRolesForActionMethod = base.Roles;
            IList<string> roles = base.Roles.Split(',').ToList();

            if(!String.IsNullOrEmpty(usertype))
            {                
                if(usertype=="AckUser")
                {
                    bool isRemoved = roles.Remove(Constants.MANAGECLIENTUSERS);
                    isRemoved = roles.Remove(Constants.MANAGECLIENTUSERROLE);
                    isRemoved = roles.Remove(Constants.MANAGECLIENTUSERGROUP);
                    isRemoved = roles.Remove(Constants.MANAGECLIENTUSERGROUPROLE);
                }
                if (usertype == "CAUser")
                {
                    bool isRemoved = roles.Remove(Constants.MANAGEACKUSERS);
                    isRemoved = roles.Remove(Constants.MANAGEACKUSERROLE);
                    isRemoved = roles.Remove(Constants.MANAGEACKUSERGROUPS);
                    isRemoved = roles.Remove(Constants.MANAGEACKUSERGROUPROLE);
                }
            }

            
            string mode = httpContext.Request.QueryString["mode"];
            if(!String.IsNullOrEmpty(mode))
            {
                if(mode=="edit")
                    Permissions = RolePermission.Update;
            }

            bool isUserInRole = IsUserInRole(roles, Permissions, currentUser);
            //Once edit mode is found the permission is set to Update
            //As the next call to the same action method uses the same permission update 
            //even in case os add as it refers the same action method
            //reset the permission back to Add for the action method for the next operation
            // the above code will set it to update if the next operation is Edit
            
            if (!String.IsNullOrEmpty(mode))
            {
                if (mode == "edit")
                    Permissions = RolePermission.Add;
            }
            if (!String.IsNullOrEmpty(usertype))
            {
                base.Roles = oriRolesForActionMethod;
            }

            if (!isUserInRole) 
            { 
                return false; 
            } 
            return true; 
        }

        public static bool IsUserInRole(IList<string> roleNames, RolePermission permissions, UserDto currentUser)
        {
            //UserServiceClient client = new UserServiceClient();
            //UserDto currentUser = client.GetByUserName(userName);
            bool hasAccess = false;
            try
            {
                foreach (string roleName in roleNames)
                {
                    var res = currentUser.UserWithRolePermissions.Where(x => x.PermissionForRole.RoleName == roleName);

                    if (res.Count() != 0)
                    {
                        UserRolePermissionDto urpDto = res.FirstOrDefault();
                        switch (permissions)
                        {
                            case RolePermission.Add:
                                hasAccess = urpDto.AllowAdd;
                                break;
                            case RolePermission.Update:
                                hasAccess = urpDto.AllowEdit;
                                break;
                            case RolePermission.View:
                                hasAccess = urpDto.AllowView;
                                break;
                            case RolePermission.Delete:
                                hasAccess = urpDto.AllowDelete;
                                break;
                            case RolePermission.Print:
                                hasAccess = urpDto.AllowPrint;
                                break;
                        }
                        res = null;
                        return hasAccess;
                    }
                    else
                    {
                        var resGroupRole = currentUser.ViewOfUserUserGroupRolePermissions.Where(x => x.PermissionForRole.RoleName == roleName);
                        if (resGroupRole.Count() != 0)
                        {
                            viewUserUserGroupRolePermissionsDto vwUgRoleDto = resGroupRole.FirstOrDefault();
                            switch (permissions)
                            {
                                case RolePermission.Add:
                                    hasAccess = vwUgRoleDto.AllowAdd;
                                    break;
                                case RolePermission.Update:
                                    hasAccess = vwUgRoleDto.AllowEdit;
                                    break;
                                case RolePermission.View:
                                    hasAccess = vwUgRoleDto.AllowView;
                                    break;
                                case RolePermission.Delete:
                                    hasAccess = vwUgRoleDto.AllowDelete;
                                    break;
                                case RolePermission.Print:
                                    hasAccess = vwUgRoleDto.AllowPrint;
                                    break;
                            }
                            //return hasAccess;
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
               
            }

            return hasAccess;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            // Returns HTTP 401 - see comment in HttpUnauthorizedResult.cs.         
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary                                     
                                        {                                        
                                            { "action", "UnAuthorizedAccess" },                                        
                                            { "controller", "Common" }                                    
                                        });     
        } 
    }
}