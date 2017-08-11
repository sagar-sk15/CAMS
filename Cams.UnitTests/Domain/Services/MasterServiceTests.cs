using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Common.Dto;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class MasterServiceTests:CamsTestBase
    {
        public IZoneService ZoneService { get; set; }        
        public IUserService UserService { get; set; }        
        public IDistrictService DistrictService { get; set; }
        public ICityVillageService CityVillageService { get; set; }
        public ICountryMasterService CountryService { get; set; }
        public IAPMCService ApmcService { get; set; }

        public ZoneDto ZoneInstance { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        public CountryDto CountryInstance { get; set; }
        public CityVillageDto CVInstance { get; set; }
        public CityVillageDto CVCreatedByCA { get; set; }
        public CityVillageDto NewCreatedCVByCAFromExisting { get; set; }
        public APMCDto APMCInstance { get; set; }

        long SuperAdminId = 1;
        int CountryId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.ZoneService = ClientServiceLocator.Instance().ContractLocator.ZoneServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.DistrictService= ClientServiceLocator.Instance().ContractLocator.DistrictServices;
            this.CityVillageService = ClientServiceLocator.Instance().ContractLocator.CityVillageServices;
            this.CountryService = ClientServiceLocator.Instance().ContractLocator.CountryServices;
            this.ApmcService = ClientServiceLocator.Instance().ContractLocator.APMCServices;
            

            CurrentUserInstance = UserService.GetById(SuperAdminId);
            CountryInstance = CountryService.GetById(CountryId); 
        }

        [TestMethod]
        public virtual void CreateZone()
        {
            var zoneDto = new ZoneDto
            {
                ZoneFor = Common.ZoneFor.Supplier_Farmer,
                Name = "North",
                CAId = 1,
                IsActive = true,
                CreatedBy = -1,                 
                ModifiedBy = -1                
            };
            this.ZoneInstance = this.ZoneService.Create(zoneDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.ZoneInstance.ZoneId == 0, "ZoneId should have been updated");
            Assert.AreEqual(this.ZoneInstance.Name, zoneDto.Name, "zone Name are different");
        }

        [TestMethod]
        public virtual void UpdateZone()
        {
            var zoneDto = new ZoneDto
            {
                ZoneId=1,
                ZoneFor = Common.ZoneFor.Supplier_Farmer,
                Name = "West",
                CAId = 1,
                IsActive = true,
                CreatedBy = -1,                
                ModifiedBy = -1,                
            };
            this.ZoneInstance = this.ZoneService.Update(zoneDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.ZoneInstance.ZoneId == 0, "ZoneId should have been updated");
            Assert.AreEqual(this.ZoneInstance.Name, zoneDto.Name, "zone Name are different");
        }

        [TestMethod]
        public virtual void FindDistricts()
        {
            int stateId = 1;
            Query query = new Query();
            Criterion criteriaState = new Criterion("st.StateId", stateId, CriteriaOperator.Equal);
            query.Add(criteriaState);
            query.AddAlias( new Alias("st", "StateOfDistrict"));

            var result = this.DistrictService.FindByQuery(query);
            Assert.IsTrue(result.Entities.Count > 0, "Districts found");
        }

        [TestMethod]
        public virtual void UpdateAPMC()
        {
            var Apmcid = 4;
            APMCDto apmcdto = this.ApmcService.GetById(Apmcid);
            //apmcdto.APMCId = A;
            List<ContactDetailsDto> contacts = new List<ContactDetailsDto>();
            contacts.Add(new ContactDetailsDto() { ContactNoType = Cams.Common.ContactType.MobileNo, ContactNo = "1234567890" });
            apmcdto.ContactNos = contacts; 


            this.APMCInstance = this.ApmcService.Update(apmcdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.APMCInstance.APMCId == 0, "APMCId should have been updated");
            Assert.AreEqual(this.APMCInstance.Name, apmcdto.Name, "APMC Name are different");
        }

        #region CityVillages TestMethods
        [TestMethod]
        public virtual void CreateNewCVBySuperAdmin()
        {
            var cvdto = new CityVillageDto 
            {
                Name = "CVCreatedBySuperAdmin",
                CityOrVillage = CityVillageType.City,
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 1
                }
            };
            this.CVInstance = this.CityVillageService.Create(cvdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.CVInstance.CityVillageId == 0, "CityVillage Id should have been updated");
        }

        [TestMethod]
        public virtual void UpdateCVBySuperAdmin() 
        {
            this.CVInstance = CityVillageService.GetById(600);
            var cvdto = new CityVillageDto
            {
                CityVillageId = this.CVInstance.CityVillageId,
                Name = "Updated CVCreatedBySuperAdmin",
                CityOrVillage = CityVillageType.Village,
                STDCode = "022",
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 1
                }
            };
            CityVillageDto updatedCV = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.CVInstance.Name == updatedCV.Name, "Cityvillage updated");
            Assert.IsTrue(updatedCV.STDCode != CVInstance.STDCode, "cityvillage std code updated");
        }

        [TestMethod]
        public virtual void CreateNewCVByClientUser() 
        {
            var cvdto = new CityVillageDto
            {
                Name = "Added city by client",
                CityOrVillage = CityVillageType.City,
                CAId = 1,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 1
                }
            };
            this.CVCreatedByCA = this.CityVillageService.Create(cvdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.CVCreatedByCA.CityVillageId == 0, "New city created by client user");
        }

        [TestMethod]
        public virtual void UpdateCVCreatedByClientUser()
        {
            this.CVCreatedByCA = CityVillageService.GetById(601);
            var cvdto = new CityVillageDto
            {
                CityVillageId = CVCreatedByCA.CityVillageId,
                Name = "Updated city by client",
                CityOrVillage = CityVillageType.Village,
                STDCode = "0213",
                CAId = 1,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 1
                }
            };
            this.CVCreatedByCA = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.CVCreatedByCA.CityVillageId == 0, "New cv updated by client user");
        }

        [TestMethod]
        public virtual void CAUserUpdatesCVCreatedBySuperAdmin() 
        {
            this.CVInstance = CityVillageService.GetById(1);
            var cvdto = new CityVillageDto
            {
                CityVillageId = CVInstance.CityVillageId,
                Name = "Nellore By CA",
                CityOrVillage = CityVillageType.City,
                CAId = 1, // default CAId=null selected CityVillageId
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 1
                }
            };
            // we are calling update but it should create a new
            this.NewCreatedCVByCAFromExisting = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.CVInstance.CityVillageId != NewCreatedCVByCAFromExisting.CityVillageId, "New CityVillage created for CA");
            Assert.IsTrue(NewCreatedCVByCAFromExisting.BaseCityVillageId != null, "BaseCityVillageID Updated");
        }

        [TestMethod]
        public virtual void CAUserUpdatesCVCreatedByHimself() 
        {
            this.NewCreatedCVByCAFromExisting = CityVillageService.GetById(603);
            var cvdto = new CityVillageDto
            {
                CityVillageId = this.NewCreatedCVByCAFromExisting.CityVillageId,
                Name = "Nellore By CA",
                CityOrVillage = CityVillageType.City,
                STDCode = "0124",
                CAId = 1, // default CAId=null selected CityVillageId
                CreatedBy = 1,
                BaseCityVillageId = NewCreatedCVByCAFromExisting.BaseCityVillageId,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 2
                }
            };

            CityVillageDto cityvillageDto = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(cityvillageDto.CityVillageId == NewCreatedCVByCAFromExisting.CityVillageId, "CA updates cityvillage created by himsef");
            Assert.IsTrue(NewCreatedCVByCAFromExisting.BaseCityVillageId != null, "BaseCityVillageId Updated");
        }

        [TestMethod]
        public virtual void CAUserUpdatesCVCreatedByHimselfButWithNameSameExistingCityVillage() 
        {
            this.NewCreatedCVByCAFromExisting = CityVillageService.GetById(603);
            var cvdto = new CityVillageDto
            {
                CityVillageId = this.NewCreatedCVByCAFromExisting.CityVillageId,
                Name = "Nellore",
                CAId = 1, // default CAId=null selected CityVillageId
                BaseCityVillageId = NewCreatedCVByCAFromExisting.BaseCityVillageId,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 2
                }
            };
            // Now cityvillage with the same name exist it has CAid NULL and CityVillageId is same as base CityVillageId
            // it should update // in this case ispresent should return false
            CityVillageDto cityvillageDto = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(cvdto.Name == cityvillageDto.Name, "CityVillage Updated as it exists but existing CityVillageId = BaseCityVillageId");
            Assert.IsTrue(NewCreatedCVByCAFromExisting.BaseCityVillageId == cityvillageDto.BaseCityVillageId, "Base Bank ID remains same");
        }

        [TestMethod]
        public virtual void CAUserUpdatesCVChangesNameButCVNamePresentwithDifferentID() 
        {
            this.NewCreatedCVByCAFromExisting = CityVillageService.GetById(603);
            var cvdto = new CityVillageDto
            {
                CityVillageId = this.NewCreatedCVByCAFromExisting.CityVillageId,
                Name = "Raipur",
                CityOrVillage = CityVillageType.City,
                CAId = 1, // default CAId=null selected CityVillageId
                BaseCityVillageId = NewCreatedCVByCAFromExisting.BaseCityVillageId,
                CreatedBy = 1,
                ModifiedBy = 1,
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 599
                }
            };
            // Now cityvillage with the same name exist it has CAid NULL and CityVillageId is not same as base CityVillageId
            // it should not update // in this case ispresent should return true
            CityVillageDto cityvillageDto = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(cityvillageDto.Response.HasWarning, "Place Already Exist");
            Assert.IsTrue(NewCreatedCVByCAFromExisting.BaseCityVillageId == cityvillageDto.BaseCityVillageId, "BaseCityVillageId remains same");
        }

        [TestMethod]
        public virtual void CAUserUpdates1()
        {
            this.NewCreatedCVByCAFromExisting = CityVillageService.GetById(603);
            var cvdto = new CityVillageDto
            {
                CityVillageId = this.NewCreatedCVByCAFromExisting.CityVillageId,
                Name = "Chittor",
                CityOrVillage = CityVillageType.City,
                CAId = 1, // default CAId=null selected bankid
                BaseCityVillageId = NewCreatedCVByCAFromExisting.BaseCityVillageId,
                CreatedBy = 1,
                ModifiedBy = 1,                
                DistrictOfCityVillage = new DistrictDto
                {
                    DistrictId = 9
                }
            };
            // Now cityvillage with the same name exist it has CAid NULL and CityVillageId is not same as base CityVillageId
            // it should not update // in this case ispresent should return true
            CityVillageDto cityvillageDto = this.CityVillageService.Update(cvdto, CurrentUserInstance.UserName);
            Assert.IsTrue(cityvillageDto.Response.HasWarning, "Place Already Exist");
            Assert.IsTrue(NewCreatedCVByCAFromExisting.BaseCityVillageId == cityvillageDto.BaseCityVillageId, "BaseCityVillageId remains same");
        }
        #endregion 
    }
}
