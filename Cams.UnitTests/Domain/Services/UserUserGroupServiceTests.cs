using System;
using System.Linq;
using Cams.Common.Dto.User;
using Cams.Common.Dto.Address;
using Cams.Common.ServiceContract;
using Cams.Mvc.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cams.UnitTests.Domain.Services
{
    /// <summary>
    /// Summary description for UserUserGroupServiceTests
    /// </summary>
    [TestClass]
    public class UserUserGroupServiceTests : CamsTestBase
    {
        public IUserService UserService { get; set; }
        public IAddressService AddressService { get; set; }
        public UserDto UserInstance { get; set; }
        public AddressDto AddressInstance { get; set; }
        public IUserGroupService UserGroupService { get; set; }
        public UserGroupDto UserGroupInstance { get; set; }

        public IUserUserGroupService UserUserGroupService { get; set; }
        //public UserUserGroupDto UserUserGroupInstance { get; set; }

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.AddressService = ClientServiceLocator.Instance().ContractLocator.AddressServices;
            this.UserGroupService = ClientServiceLocator.Instance().ContractLocator.UserGroupServices;
            //this.UserUserGroupService = ClientServiceLocator.Instance().ContractLocator.UserUserGroupServices;
        }

        [TestMethod]
        public virtual void CreateUserUserGroup()
        {
            var dtoUser = new UserDto
            {
                Name = "Sujata",
                UserName = "SujataPant",
                MobileNo = "9890969234",
                Email = "sujatapant@ackcezione.com",
                CountryCode = "091",
                MothersMaidenName = "Anuradha",
                IsActive = true,
                DateOfBirth = DateTime.Now,
                Password = "passwd@123",
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                IsLockedOut = false,
                IsOnLine = false,
                LastActivityDate = DateTime.Now,
                LastLockedOutDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now,
                LastPassword = "password",
                LastPasswordChangedDate = DateTime.Now,
                SecondLastPassword = "pass",
                SecondLastPasswordChangedDate = DateTime.Now.AddDays(-1),
                IsDeleted = false,
                AllowDelete = true,
                AllowEdit = true,
            };

            this.UserInstance = this.UserService.Create(dtoUser);

            var dtoUserGroup = new UserGroupDto
            {
                UserGroupName = "Data Entry Operator Group",
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

            this.UserGroupInstance = this.UserGroupService.Create(dtoUserGroup);

            var dtoUserUserGroup = new UserUserGroupDto
            {
                User = dtoUser,
                UserGroup = UserGroupInstance,
                IsDeleted = false,
                AllowEdit = true,
                AllowDelete = true,
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now
            };            

        }

        [TestMethod]
        public virtual void CreateUser()
        {
            var dtoUserUserGroup = new UserUserGroupDto
            {
                IsDeleted = false,
                AllowEdit = true,
                AllowDelete = true,
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
