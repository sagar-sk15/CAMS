using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;


namespace Cams.Mvc.Services
{
    public class ClientContractLocator : IContractLocator
    {
        private IAddressService AddressServiceInstance;
        private IUserService UserServiceInstance;
        private IUserGroupService UserGroupServiceInstance;
        private IRoleService RoleServiceInstance;
        private IDesignationService DesignationServiceInstance;
        private IUserRolePermissionService UserRolePermissionServiceInstance;

        public IContractLocator NextAdapterLocator { get; private set; }

        #region IContractLocator Members

        public IAddressService AddressServices
        {
            get
            {
                if (AddressServiceInstance != null) return AddressServiceInstance;
                AddressServiceInstance = new AddressServiceAdapter(NextAdapterLocator.AddressServices);
                return AddressServiceInstance;
            }
        }

        public IUserService UserServices
        {
            get
            {
                if (UserServiceInstance != null) return UserServiceInstance;
                UserServiceInstance = new UserServiceAdapter(NextAdapterLocator.UserServices);
                return UserServiceInstance;
            }
        }

        public IUserGroupService UserGroupServices
        {
            get
            {
                if (UserGroupServiceInstance != null) return UserGroupServiceInstance;
                UserGroupServiceInstance = new UserGroupServiceAdapter(NextAdapterLocator.UserGroupServices);
                return UserGroupServiceInstance;
            }
        }

        public IRoleService RoleServices
        {
            get
            {
                if(RoleServiceInstance != null) return RoleServiceInstance;
                RoleServiceInstance = new RoleServiceAdapter(NextAdapterLocator.RoleServices);
                return RoleServiceInstance;
            }
        }

        public IDesignationService DesignationServices
        {
            get
            {
                if (DesignationServiceInstance != null) return DesignationServiceInstance;
                DesignationServiceInstance = new DesignationServiceAdapter(NextAdapterLocator.DesignationServices);
                return DesignationServiceInstance;
            }
        }

        public IUserRolePermissionService UserRolePermissionServices
        {
            get
            {
                if (UserRolePermissionServiceInstance != null) return UserRolePermissionServiceInstance;
                UserRolePermissionServiceInstance = new UserRolePermissionServiceAdapter(NextAdapterLocator.UserRolePermissionServices);
                return UserRolePermissionServiceInstance;
            }
        }
        #endregion
    }
}
