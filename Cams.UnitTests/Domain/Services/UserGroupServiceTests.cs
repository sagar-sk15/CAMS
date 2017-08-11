using System;
using System.Collections.Generic;
using System.Linq;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class UserGroupServiceTests : CamsTestBase
    {
        public IUserGroupService UserGroupService { get; set; }
        public UserGroupDto UserGroupInstance { get; set; }
        public IUserService UserService { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        public IRoleService RoleService { get; set; }
        public RoleDto RoleInstance { get; set; }
        long SuperAdminId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.UserGroupService = ClientServiceLocator.Instance().ContractLocator.UserGroupServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.RoleService = ClientServiceLocator.Instance().ContractLocator.RoleServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
        }

        [TestMethod]
        public virtual void CreateUserGroup()
        {
            var userGroupDto = new UserGroupDto
            {
                UserGroupName = "Data Entry Group",
                Description = "Data Entry Operator Group Description",
                CAId = 0,
                IsActive = true,
                IsDeleted = false,
                AllowEdit = true,
                AllowDelete = true,
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now
            };
                        
            this.UserGroupInstance = this.UserGroupService.Create(userGroupDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.UserGroupInstance.UserGroupId == 0, "User Group Id should have been updated");
            Assert.AreEqual(this.UserGroupInstance.UserGroupName, userGroupDto.UserGroupName, "User Group Name are different");
        }

        [TestMethod]
        public virtual void CreateUserGroupWithRolePermissions() 
        {
            var userGroupDto = new UserGroupDto
            {
                UserGroupName = "General Manager",
                Description = "General Manager Description",
                CAId = 0,
                IsActive = true,
                IsDeleted = false,
                AllowEdit = true,
                AllowDelete = true,
                CreatedBy = -1,
                ModifiedBy = -1
            };

            var ugRolePermissionDto = new UserGroupRolePermissionDto 
            {
                AllowAdd = true,
                AllowDelete = true,
                AllowEdit = true,
                AllowPrint = true,
                AllowView = true
            };

            RoleDto roleDto = this.RoleService.GetById(10);
            ugRolePermissionDto.PermissionForRole = roleDto;
            userGroupDto.RolePermissionsInUserGroup.Add(ugRolePermissionDto);
            this.UserGroupInstance = this.UserGroupService.Create(userGroupDto,CurrentUserInstance.UserName);
            Assert.IsFalse(this.UserGroupInstance.UserGroupId == 0, "User Group Id should have been updated");
            Assert.AreEqual(this.UserGroupInstance.UserGroupName, userGroupDto.UserGroupName, "User Group Name are different");
        }

        [TestMethod]
        public virtual void UpdateUserGroup()
        {
            this.CreateUserGroup();
            var id = this.UserGroupInstance.UserGroupId;

            UserGroupInstance.UserGroupName = "Accountant Group";
            UserGroupInstance.Description = "Accountant Group Description";
            UserGroupInstance.IsActive = true;
            UserGroupInstance.ModifiedBy = -1;
            UserGroupInstance.ModifiedDate = DateTime.Now;

            this.UserGroupInstance = this.UserGroupService.Update(UserGroupInstance, CurrentUserInstance.UserName);
            Assert.IsTrue(this.UserGroupInstance.UserGroupId == id, "User Id should have remained the same");
            Assert.AreEqual(this.UserGroupInstance.UserGroupName, "Accountant Group", "Incorrect User Group Name after the update");
        }

        [TestMethod]
        public virtual void GetUserGroupById()
        {
            CreateUserGroup();
            var id = UserGroupInstance.UserGroupId;
            var result = UserGroupService.GetById(id);
            Assert.AreEqual(id, result.UserGroupId, "incorrect User Group id was found");
            Assert.AreEqual(UserGroupInstance.UserGroupName, result.UserGroupName, "Incorrect user group name was found");
            Assert.AreEqual("Data Entry Operator Group", result.UserGroupName, "Incorrect user group name was returned");
        }

        [TestMethod]
        public virtual void FindAllUserGroups()
        {
            //CreateUserGroup();
            var result = this.UserGroupService.FindAll();
            Assert.IsTrue(result.Entities.Count !=0, "One User group instance was expected");
        }

        [TestMethod]
        public virtual void FindByQueryUserGroups()
        {
            Query query = new Query();
            Criterion criteriaCAId;
            criteriaCAId = new Criterion(Constants.CAID, 1, CriteriaOperator.Equal);
            query.Add(criteriaCAId);
            query.QueryOperator = QueryOperator.And;

            var result = this.UserGroupService.FindByQuery(query);
            Assert.IsTrue(result.Entities.Count != 0, "User group instance(s) was expected");
        }

        [TestMethod]
        public virtual void AssignRoletoUserGroup()
        {
            RoleDto roleDto = this.RoleService.GetById(9);
            UserGroupDto ugDto = this.UserGroupService.GetById(2);
            var ugrpDto = new UserGroupRolePermissionDto
            {
                PermissionForUserGroup = new List<UserGroupDto>
                {
                    new UserGroupDto
                    {
                        UserGroupId = ugDto.UserGroupId
                    }
                },
                PermissionForRole = roleDto,
                AllowAdd = false,
                AllowEdit = false,
                AllowView = false,
                AllowPrint = false,
                AllowDelete = false
            };
            ugDto.RolePermissionsInUserGroup.Clear();
            ugDto.RolePermissionsInUserGroup.Add(ugrpDto);
            this.UserGroupInstance = this.UserGroupService.Update(ugDto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.UserGroupInstance.RolePermissionsInUserGroup[0].UserGroupRolePermissionId != 0, "UserGroupRolePermissionId should have been updated");
        }

    }
}
