using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Domain.Entities.ClientMasters;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class CommodityServiceTest:CamsTestBase
    {
        public ICommodityService CommodityService { get; set; }
        public CommodityDto CommodityInstance { get; set; }
        public IUserService UserService { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        long SuperAdminId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.CommodityService = ClientServiceLocator.Instance().ContractLocator.CommodityServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
        }

        [TestMethod]
        public virtual void CreateCommodity() 
        {
            var commodityDto = new CommodityDto
            {
                Name = "Sunflower",
                BotanicalName = "Helianthus annuus",
                IsActive = true,
                Image = "16e1a838-3064-470e-8f44-bc1e866dc0ea_Apple",
                CreatedBy = -1,
                ModifiedBy = -1
            };

            CommodityClassDto commodityclassDto = new CommodityClassDto
            {
                CommodityClassId = 2
            };
            commodityDto.CommoditiesInCommodityClass = commodityclassDto;

            this.CommodityInstance = this.CommodityService.Create(commodityDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.CommodityInstance.CommodityId == 0, "CommodityId should have been updated");
            Assert.AreEqual(this.CommodityInstance.Name, commodityDto.Name, "zone Name are different");
        }
    }
}
