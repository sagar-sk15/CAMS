using System;
using System.Linq;
using Cams.Common;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.UnitTests.Domain.Services
{
    /// <summary>
    /// Class to test User Role Permission Services
    /// </summary>
    [TestClass]
    public class UserRolePermissionServiceTests : CamsTestBase
    {
        public IUserService UserService { get; set; }
        public UserDto UserInstance { get; set; }

        public IRoleService RoleService { get; set; }
        public RoleDto RoleInstance { get; set; }

        public IUserRolePermissionService UserRolePermissionService { get; set; }
        public UserRolePermissionDto UserRolePermissionInstance { get; set; }

        public UserDto CurrentUserInstance { get; set; }

        long SuperAdminId = 8;
        int RoleId = 10;

         [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.UserRolePermissionService = ClientServiceLocator.Instance().ContractLocator.UserRolePermissionServices;
            this.RoleService = ClientServiceLocator.Instance().ContractLocator.RoleServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
        }

        [TestMethod]
        public virtual void CreateUser()
        {
            var userdto = new UserDto
            {
                Title = "Ms",
                Name = "shraddha",
                UserName = "shraddhashinde",
                MobileNo = "9922077123",
                Email = "shraddhashinde@gmail.com",
                CountryCode = "91",
                MothersMaidenName = "manisha",
                UserOfClient = new ClientDto
                {
                    CAId = 1
                },
                IsActive = true,
                DateOfBirth = Convert.ToDateTime("06/10/1984"),
                Password = Helper.Encode("P@ssword"),
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                IsLockedOut = false,
                IsOnLine = false,
                LastActivityDate = DateTime.Now,
                LastLockedOutDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now,
                LastPassword = Helper.Encode("password"),
                LastPasswordChangedDate = DateTime.Now,
                SecondLastPassword = Helper.Encode("pass"),
                SecondLastPasswordChangedDate = DateTime.Now.AddDays(-1),
                IsDeleted = false,
                AllowDelete = true,
                AllowEdit = true
            };

            var userRolePermissionDto = new UserRolePermissionDto
            {                
                AllowAdd = true,
                AllowDelete = true,
                AllowEdit = true,
                AllowPrint = true,
                AllowView = true
            };

            RoleDto roleDto = this.RoleService.GetById(RoleId);
            userRolePermissionDto.PermissionForRole = roleDto;
            
            userdto.UserWithRolePermissions.Add(userRolePermissionDto);
            this.UserInstance = this.UserService.Create(userdto, CurrentUserInstance.UserName);
                        
            Assert.IsFalse(this.UserInstance.UserId == 0, "User Id should have been updated");
            Assert.AreEqual(this.UserInstance.Name, userdto.Name, "First Name are different");
        }

        public UserRolePermissionServiceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public virtual void AssignRoletoUser()
        {
            RoleDto roleDto = this.RoleService.GetById(9);            
            RoleDto roleDto1 = this.RoleService.GetById(11);
            UserDto userDto = this.UserService.GetById(43);
            var urpdto = new UserRolePermissionDto
            {
                PermissionForUser = new List<UserDto>
                {
                    new UserDto
                    {
                        UserId = userDto.UserId
                    }
                },                
                PermissionForRole = roleDto,
                AllowAdd = true,
                AllowEdit = true,
                AllowView = true,
                AllowDelete = true,
                AllowPrint = false
            };
            var urpdto1 = new UserRolePermissionDto
            {
                PermissionForUser = new List<UserDto>
                {
                    new UserDto
                    {
                        UserId = userDto.UserId
                    }
                },
                PermissionForRole = roleDto1,
                AllowAdd = true,
                AllowEdit = true,
                AllowView = true,
                AllowDelete = false,
                AllowPrint = false
            };            
            userDto.UserWithRolePermissions.Clear();
            userDto.UserWithRolePermissions.Add(urpdto);
            userDto.UserWithRolePermissions.Add(urpdto1);
            this.UserInstance = this.UserService.Update(userDto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.UserInstance.UserWithRolePermissions[0].UserRolePermissionId != 0, "user Id should have been updated");
        }
    }
}
