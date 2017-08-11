using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Domain.Entities.ClientMasters;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.Address;
using Cams.Common.Dto;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class ClientMastersServiceTest : CamsTestBase
    {
        public ILabourChargeTypeService LabourChargeTypeService { get; set; }
        public IUserService UserService { get; set; }
        public IChargesPayableToService ChargesPayableToService { get; set; }
        public IMeasuringUnitService MeasuringUnitService { get; set; }
        public IBankService BankService { get; set; }
        public IBankBranchService BankBranchService { get; set; }
        public ICountryMasterService CountryService { get; set; }
        public IAddressService AddressService { get; set; }
        public IWeeklyHalfDayService WeeklyHalfDayService { get; set; }
        public IWeeklyOffDaysService WeeklyOffDaysService { get; set; }

        public UserDto CurrentUserInstance { get; set; }
        public LabourChargeTypeDto LabourChargeInstance { get; set; }
        public MeasuringUnitDto MeasuringUnitInstance { get; set; }
        public BankDto BankInstance { get; set; }
        public BankBranchDto BankBranchInstance { get; set; }
        public CountryDto CountryInstance { get; set; }
        public AddressDto AddressInstance { get; set; }
        public WeeklyHalfDayDto WeeklyHalfDayInstance { get; set; }
        public WeeklyOffDaysDto WeeklyOffDayInstance { get; set; }

        long SuperAdminId = 1;
        int CountryId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.LabourChargeTypeService = ClientServiceLocator.Instance().ContractLocator.LabourChargeTypeServices;
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.ChargesPayableToService = ClientServiceLocator.Instance().ContractLocator.ChargesPayableToServices;
            this.MeasuringUnitService = ClientServiceLocator.Instance().ContractLocator.MeasuringUnitServices;
            this.BankService = ClientServiceLocator.Instance().ContractLocator.BankServices;
            this.BankBranchService = ClientServiceLocator.Instance().ContractLocator.BankBranchServices;
            this.AddressService = ClientServiceLocator.Instance().ContractLocator.AddressServices;
            this.CountryService = ClientServiceLocator.Instance().ContractLocator.CountryServices;
            this.WeeklyHalfDayService = ClientServiceLocator.Instance().ContractLocator.WeeklyHalfDayServices;
            this.WeeklyOffDaysService = ClientServiceLocator.Instance().ContractLocator.WeeklyOffDaysServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
            CountryInstance = CountryService.GetById(CountryId); 
        }

        //[TestMethod]
        //public virtual void CreateLabourCharge()
        //{
        //    var chargespayableto = new ChargesPayableToDto { ChargesPayableToId = 1 };
        //    var chargespayableto1 = new ChargesPayableToDto { ChargesPayableToId = 2 };
        //    var LabourChargeTypedto = new LabourChargeTypeDto
        //    {
        //        LabourCharge = "Kata1234",
        //        LabourChargesPayableTo = chargespayableto,
        //        Derivative1 = "xyz",
        //        D1PayableTo = chargespayableto,
        //        D2PayableTo = chargespayableto1,
        //        Derivative2 = "abc",
        //        CAId = 1,
        //        IsActive = true,
        //        CreatedBy = -1,
        //        ModifiedBy = -1
        //    };
        //    this.LabourChargeInstance = this.LabourChargeTypeService.Create(LabourChargeTypedto, CurrentUserInstance.UserName);
        //    Assert.IsFalse(this.LabourChargeInstance.LabourChargeId == 0, "LabourChargeId should have been updated");
        //    Assert.AreEqual(this.LabourChargeInstance.LabourCharge, LabourChargeTypedto.LabourCharge, "LabourCharge are different");
        //}

        //[TestMethod]
        //public virtual void UpdateLabourCharge()
        //{
        //    var LabourChargeTypedto = new LabourChargeTypeDto
        //    {
        //        LabourChargeId = 1,
        //        LabourCharge = "hamali",
        //        Derivative1 = "xyz",
        //        Derivative2 = "abc",
        //        CAId = 1,
        //        IsActive = true,
        //        CreatedBy = -1,
        //        ModifiedBy = -1
        //    };
        //    this.LabourChargeInstance = this.LabourChargeTypeService.Update(LabourChargeTypedto, CurrentUserInstance.UserName);
        //    Assert.IsFalse(this.LabourChargeInstance.LabourChargeId == 0, "LabourChargeId should have been updated");
        //    Assert.AreEqual(this.LabourChargeInstance.LabourCharge, LabourChargeTypedto.LabourCharge, "LabourCharge are different");
        //}

        //[TestMethod]
        //public virtual void FindLabourChargeTypesOnCAId()
        //{
        //    int CAId = 1;
        //    Query query = new Query();
        //    Criterion criteriaCAId = new Criterion(Constants.CAID, CAId, CriteriaOperator.Equal);
        //    query.Add(criteriaCAId);

        //    var result = this.LabourChargeTypeService.FindByQuery(query);
        //    Assert.IsTrue(result.Entities.Count > 0, "Labour Charge Types found");
        //}

        //[TestMethod]
        //public virtual void FindAllChargesPayableTo()
        //{
        //    var result = this.ChargesPayableToService.FindAll();
        //    Assert.IsTrue(result.Entities.Count > 0, "Labour Charge Types found");
        //}

        //[TestMethod]
        //public virtual void CreateMeasuringUnit()
        //{
        //    var measuringunitdto = new MeasuringUnitDto
        //    {
        //        UnitType = Common.UnitType.Weight,
        //        MeasurementUnit = "Quintal",
        //        EquivalentUnit = "100",
        //        CAId = 1,
        //        CreatedBy = 1,
        //        ModifiedBy = 1
        //    };
        //    this.MeasuringUnitInstance = this.MeasuringUnitService.Create(measuringunitdto, CurrentUserInstance.UserName);
        //    Assert.IsFalse(this.MeasuringUnitInstance.UnitId == 0, "UnitId should have been updated");
        //    Assert.AreEqual(this.MeasuringUnitInstance.MeasurementUnit, MeasuringUnitInstance.MeasurementUnit, "Measuring Units are different");
        //}

        [TestMethod]
        public virtual void CreateBankBranch()
        {
            var bankbranchdto = new BankBranchDto
            {
                Name = "Senapati Bapat RD",
                IFSCCode = "SBI00001237",
                MICRCode = "4112290124",
                SWIFTCode = "345",
                Email1 = "info@icicibank.com",
                Email2 = "contact@icicibank.com",
                FullDayTimeFrom = new TimeSpan(8, 8, 40),
                FullDayTimeTo = new TimeSpan(9, 8, 40),
                HalfDayTimeFrom = new TimeSpan(10, 8, 40),
                HalfDayTimeTo = new TimeSpan(11, 8, 40),
                FullDayBreakFrom = new TimeSpan(12, 8, 40),
                FullDayBreakTo = new TimeSpan(1, 8, 40),
                HalfDayBreakFrom = new TimeSpan(2, 8, 40),
                HalfDayBreakTo = new TimeSpan(3, 8, 40),
                CreatedBy = 1,
                ModifiedBy = 1,

                #region BankAddress
                BranchAddress = new AddressDto
                {
                    AddressLine1 = "Navi Peth",
                    AddressLine2 = "b1 c wing c8",
                    PIN = "411040",
                    CreatedBy = -1,
                    ModifiedBy = -1,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 1
                    }
                },
                #endregion

                #region BankContactDetails
                BranchContactNos = new List<ContactDetailsDto>
                {                   
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.OfficeNo,
                        STDCode = "020",
                        ContactNo = "27658945",                        
                        CountryCallingCode = CountryInstance.CallingCode
                    },
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.Fax,
                        STDCode = "020",
                        ContactNo = "45646456",                        
                        CountryCallingCode = CountryInstance.CallingCode
                         
                    }
                },
                #endregion

                BranchOfBank = new BankDto
                {
                    BankName = "Kotak bank",
                    Alias = "Kotak",
                    CAId = 1,
                    URL = "www.icicibank.co.in",
                    CreatedBy = 1,
                    ModifiedBy = 1
                },
                WeeklyHalfDay = new WeeklyHalfDayDto
                {
                    IsSaturday = false

                },
                WeeklyOffDay = new WeeklyOffDaysDto
                {
                    IsSaturday=true,
                    IsSunday = true
                }
            };

            this.BankBranchInstance = this.BankBranchService.Create(bankbranchdto, CurrentUserInstance.UserName);
            Assert.IsTrue(BankBranchInstance.Response.HasWarning, "passed with warnings");
        }

        [TestMethod]
        public virtual void CreateBranch() 
        {
            var bankbranchdto = new BankBranchDto
            {
                Name = "MG Road",
                IFSCCode = "SBI00001235",
                MICRCode = "4112290122",
                SWIFTCode = null,
                Email1 = "info@sbm.com",
                Email2 = "contact@sbm.com",
                FullDayTimeFrom = TimeSpan.FromHours(9),
                FullDayTimeTo = TimeSpan.FromHours(5),
                HalfDayTimeFrom = TimeSpan.FromHours(9),
                HalfDayTimeTo = TimeSpan.FromHours(1),
                FullDayBreakFrom = TimeSpan.FromHours(1),
                FullDayBreakTo = TimeSpan.FromHours(1),
                HalfDayBreakFrom = TimeSpan.FromHours(11),
                HalfDayBreakTo = TimeSpan.FromHours(11),
                CreatedBy = 1,
                ModifiedBy = 1,

                #region BankAddress
                BranchAddress = new AddressDto
                {
                    AddressLine1 = "Navi Peth",
                    AddressLine2 = "b1 c wing c8",
                    PIN = "411040",
                    CreatedBy = -1,
                    ModifiedBy = -1,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 1
                    }
                },
                #endregion

                #region BankContactDetails
                BranchContactNos = new List<ContactDetailsDto>
                {                   
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.OfficeNo,
                        STDCode = "020",
                        ContactNo = "27658945",                        
                        CountryCallingCode = CountryInstance.CallingCode
                    },
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.Fax,
                        STDCode = "020",
                        ContactNo = "45646456",                        
                        CountryCallingCode = CountryInstance.CallingCode
                         
                    }
                },
                #endregion
                                
                WeeklyHalfDay = new WeeklyHalfDayDto
                {
                    IsSaturday = true

                },
                WeeklyOffDay = new WeeklyOffDaysDto
                {
                    IsSunday = true
                }
            };
            BankDto bankdto = new BankDto
            {
                BankId = 2
            };
            bankbranchdto.BranchOfBank = bankdto;
            this.BankBranchInstance = this.BankBranchService.Create(bankbranchdto, CurrentUserInstance.UserName);
        }

        [TestMethod]
        public virtual void TestFindByQueryBankList()
        {
            Query query = new Query();
            if (CurrentUserInstance.UserOfClient.CAId != 0)
            {
                Criterion criteriaCAId = new Criterion(Constants.CAID, CurrentUserInstance.UserOfClient.CAId, CriteriaOperator.Equal);
                query.Add(criteriaCAId);
            }
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            query.Add(criteriaCAIdNull);
            query.QueryOperator = QueryOperator.Or;
            var Banks = BankService.FindByQuery(query);
            Assert.IsTrue(Banks.TotalRecords > 0, "Found Banks");
        }

        [TestMethod]
        public virtual void TestFindByQueryBankName()
        {
            Query query = new Query();
            if (CurrentUserInstance.UserOfClient.CAId != 0)
            {
                Criterion criteriaCAId = new Criterion(Constants.CAID, CurrentUserInstance.UserOfClient.CAId, CriteriaOperator.Equal);
                query.Add(criteriaCAId);
            }
            Criterion bankname = new Criterion(Constants.BANKNAME, "ICICI bank", CriteriaOperator.Equal);
            query.Add(bankname);
            query.QueryOperator = QueryOperator.And;
            var bank = BankService.FindByQuery(query);            
            Assert.IsTrue(bank.TotalRecords > 0, "Bank found");
        }

        [TestMethod]
        public virtual void UpdateBank()  
        {
            this.CreateBankBranch();
            var id = BankBranchInstance.BranchOfBank.BankId;
            BankBranchInstance.BranchOfBank.BankName = "State Bank of India";
            BankBranchInstance.BranchOfBank.URL = "www.statebankofindia.com";
            this.BankBranchInstance = BankBranchService.Update(BankBranchInstance, CurrentUserInstance.UserName); 
            Assert.IsTrue(this.BankBranchInstance.BranchOfBank.BankId == id, "bank Id should have remained the same");
        }

        [TestMethod]
        public virtual void UpdateBankByChangingCAId()
        {
           // this.CreateBankBranch();
           // var id = BankBranchInstance.BranchOfBank.BankId;
            BankInstance = BankService.GetById(3);
            BankInstance.BankName = "Kotak Mahindra Bank";
            BankInstance.URL = "www.kotak.com";
            BankInstance.CAId = null; // Here we change the CAId. In CreateBankBranch method CAId =0.
            //this.BankBranchInstance = BankBranchService.Update(BankBranchInstance, CurrentUserInstance.UserName);
            this.BankInstance = BankService.Update(BankInstance, CurrentUserInstance.UserName);
           // Assert.IsTrue(this.BankBranchInstance.BranchOfBank.BankId != localbankdto.BankId, "New bank entry created");
        }

        [TestMethod]
        public virtual void GetBankId()
        {
            Query query = new Query();
            Criterion bankname = new Criterion(Constants.BANKNAME, "Kotak Mahindra Bank", CriteriaOperator.Equal);
            CurrentUserInstance.UserOfClient.CAId = 1;
            Criterion caid = new Criterion(Constants.CAID, CurrentUserInstance.UserOfClient.CAId, CriteriaOperator.Equal);
            query.Add(bankname);
            query.Add(caid);
            query.QueryOperator = QueryOperator.And;
            EntityDtos<BankDto> bankdetails = BankService.FindByQuery(query);
            int bankid = bankdetails.Entities[0].BankId;            
        }

        [TestMethod]
        public virtual void UpdateBankBySameCAId() 
        { 
            var localbankdto = BankService.GetById(7);
            localbankdto.Alias = "Kkkkk";
            localbankdto.URL = "kotak.com";
            localbankdto.CAId = 1;
            this.BankBranchInstance = BankBranchService.Update(BankBranchInstance, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankBranchInstance.BranchOfBank.BankId == localbankdto.BankId, "bank Id should have remained the same");
        }
    }
}
