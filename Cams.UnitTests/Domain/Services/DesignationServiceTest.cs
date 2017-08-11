using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Cams.Extension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.User;


namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class DesignationServiceTest : CamsTestBase
    {
        public IDesignationService DesignationService { get; set; }
        public DesignationDto DesignationInstance { get; set; }
        public IUserService UserService { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        long SuperAdminId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.DesignationService = ClientServiceLocator.Instance().ContractLocator.DesignationServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
        }

        [TestMethod]
        public virtual void CreateDesignation()
        {
            var designationdto = new DesignationDto
            {
                DesignationName = "Account Manager",
                CreatedBy = -1,
                CreatedDate = DateTime.Now,
                ModifiedBy = -1,
                ModifiedDate = DateTime.Now
            };
            this.DesignationInstance = this.DesignationService.Create(designationdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.DesignationInstance.DesignationId == 0, "User Group Id should have been updated");
            Assert.AreEqual(this.DesignationInstance.DesignationName, designationdto.DesignationName, "designation Name are different");
        }
    }
}
