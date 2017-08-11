using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services.Wcf
{
    public class WcfContractLocator :IContractLocator
    {
        private IAddressService AddressServiceProxyInstance;
        private IUserService UserServiceProxyInstance;
        private IUserGroupService UserGroupServiceProxyInstance;
        private IRoleService RoleServiceProxyInstance;
        private IDesignationService DesignationProxyInstance;
        private IUserRolePermissionService UserRolePermissionServiceProxyInstance;
        //private IUserUserGroupService UserUserGroupServiceProxyInstance;

        public IAddressService AddressServices
        {
            get
            {
                if (AddressServiceProxyInstance != null) return AddressServiceProxyInstance;
                AddressServiceProxyInstance = new AddressServiceProxy();
                return AddressServiceProxyInstance;
            }
        }

        public IUserService UserServices
        {
            get
            {
                if (UserServiceProxyInstance != null) return UserServiceProxyInstance;
                UserServiceProxyInstance = new UserServiceProxy();
                return UserServiceProxyInstance;
            }
        }

        public IUserGroupService UserGroupServices  
        {
            get
            {
                if (UserGroupServiceProxyInstance != null) return UserGroupServiceProxyInstance;
                UserGroupServiceProxyInstance = new UserGroupServiceProxy();
                return UserGroupServiceProxyInstance;
            }
        }

        public IRoleService RoleServices
        {
            get
            {
                if (RoleServiceProxyInstance != null) return RoleServiceProxyInstance;
                RoleServiceProxyInstance = new RoleServiceProxy();
                return RoleServiceProxyInstance;
            }
        }

        public IDesignationService DesignationServices
        {
            get
            {
                if (DesignationProxyInstance != null) return DesignationProxyInstance;
                DesignationProxyInstance = new DesignationServiceProxy();
                return DesignationProxyInstance;
            }
        }

        public IUserRolePermissionService UserRolePermissionServices
        {
            get
            {
                if (UserRolePermissionServiceProxyInstance != null) return UserRolePermissionServiceProxyInstance;
                UserRolePermissionServiceProxyInstance = new UserRolePermissionServiceProxy();
                return UserRolePermissionServiceProxyInstance;
            }
        }
    }
}
