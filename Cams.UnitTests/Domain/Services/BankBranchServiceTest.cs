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
    public class BankBranchServiceTest : CamsTestBase
    {
        public IUserService UserService { get; set; }
        public IBankService BankService { get; set; }
        public ICountryMasterService CountryService { get; set; }
        public IBankBranchService BankBranchService { get; set; }
        public IAddressService AddressService { get; set; }
        public IWeeklyHalfDayService WeeklyHalfDayService { get; set; }
        public IWeeklyOffDaysService WeeklyOffDaysService { get; set; }
        

        public UserDto CurrentUserInstance { get; set; }
        public BankDto BankInstance { get; set; }
        public BankBranchDto BankBranchInstance { get; set; }
        public CountryDto CountryInstance { get; set; }
        public AddressDto AddressInstance { get; set; }
        public WeeklyHalfDayDto WeeklyHalfDayInstance { get; set; }
        public WeeklyOffDaysDto WeeklyOffDayInstance { get; set; }
        public BankDto BankCreatedByCA { get; set; }
        public BankDto NewCreatedBankByCAFromExisting { get; set; }

        long SuperAdminId = 1;
        int CountryId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.BankService = ClientServiceLocator.Instance().ContractLocator.BankServices;
            this.BankBranchService = ClientServiceLocator.Instance().ContractLocator.BankBranchServices;
            this.AddressService = ClientServiceLocator.Instance().ContractLocator.AddressServices;
            this.CountryService = ClientServiceLocator.Instance().ContractLocator.CountryServices;
            this.WeeklyHalfDayService = ClientServiceLocator.Instance().ContractLocator.WeeklyHalfDayServices;
            this.WeeklyOffDaysService = ClientServiceLocator.Instance().ContractLocator.WeeklyOffDaysServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
            CountryInstance = CountryService.GetById(CountryId); 
        }

        #region Bank TestMethods
        [TestMethod]
        public virtual void CreateNewBankBySuperAdmin()
        {
            var bankdto = new BankDto
            {
                BankName = "Canara Bank",
                Alias = "Canara",
                URL = "Canarabank.in",
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            this.BankInstance = this.BankService.Create(bankdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.BankInstance.BankId == 0, "Bank Id should have been updated");
        }

        [TestMethod]
        public virtual void UpdateBankBySuperAdmin()
        {
            this.BankInstance = BankService.GetById(18);
            var bankdto = new BankDto
            {
                BankId = this.BankInstance.BankId,
                BankName = "Canara Bank",
                Alias = "Canara",
                URL = "www.Canarabank.co.in",
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            BankDto updatedBank = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankInstance.BankName == updatedBank.BankName, "Bank updated");
            Assert.IsTrue(updatedBank.URL != BankInstance.URL, "Bank URL updated");
        }


        /// <summary>
        /// This Testmethod senario : Client(i.e. CAId)  created new bank record 
        /// </summary>
        [TestMethod]
        public virtual void CreateNewBankByClientUser() 
        {
            var bankdto = new BankDto
            {
                BankName = "Karad Urban",
                Alias = "karad",
                URL = "karadurban.co.in",
                CAId = 1,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            this.BankCreatedByCA = this.BankService.Create(bankdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.BankCreatedByCA.BankId == 0, "New Bank created by client user");
        }
        
        [TestMethod]
        public virtual void UpdateBankCreatedByClientUser()
        {
            this.BankCreatedByCA = BankService.GetById(19);
            var bankdto = new BankDto
            {
                BankId=BankCreatedByCA.BankId,
                BankName = "Karad Urban cooperative",
                Alias = "karad",
                URL = "www.karadurban.co.in",
                CAId = 1,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            this.BankCreatedByCA = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.BankCreatedByCA.BankId == 0, "New Bank created by client user");
        }

        /// <summary>
        /// This Testmethod senario : If Client(i.e. CAId) updated the default registered bank which was added by ack,
        ///                           then ack created new entry of that bank for that perticular client(i.e. CAId)
        /// </summary>
        [TestMethod]
        public virtual void CAUserUpdatesBankCreatedBySuperAdmin()
        {
            this.BankInstance = BankService.GetById(2);
            var bankdto = new BankDto
            {
                BankId=BankInstance.BankId,
                BankName = "ICICI Bank By CA",
                Alias = "ICICI",
                URL = "www.ICICI.in",
                CAId = 1, // default CAId=null selected bankid
                CreatedBy = 1, 
                ModifiedBy = 1
            };            
            // we are calling update but it should create a new
            this.NewCreatedBankByCAFromExisting = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankInstance.BankId != NewCreatedBankByCAFromExisting.BankId, "New bank created for CA");
            Assert.IsTrue(NewCreatedBankByCAFromExisting.BaseBankId!=null, "Base Bank Updated");
        }

        [TestMethod]
        public virtual void CAUserUpdatesBankCreatedByHimself()
        {
            this.NewCreatedBankByCAFromExisting = BankService.GetById(20);
            var bankdto = new BankDto
            {
                BankId = this.NewCreatedBankByCAFromExisting.BankId,
                BankName = "Canara Bank of CA",
                Alias = "Canara",
                URL = "www.canara.in",
                CAId = 1, // default CAId=null selected bankid
                CreatedBy = 1,
                BaseBankId = NewCreatedBankByCAFromExisting.BaseBankId,
                ModifiedBy = 1
            };
            
            BankDto bankD = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(bankD.BankId == NewCreatedBankByCAFromExisting.BankId, "CA updates bank created by himsef");
            Assert.IsTrue(NewCreatedBankByCAFromExisting.BaseBankId != null, "Base Bank Updated");
        }

        [TestMethod]
        public virtual void CAUserUpdatesBankCreatedByHimselfButWithNameSameExistingBank()
        {
            this.NewCreatedBankByCAFromExisting = BankService.GetById(20);
            var bankdto = new BankDto
            {
                BankId = NewCreatedBankByCAFromExisting.BankId,
                BankName = "Canara Bank",
                CAId = 1, // default CAId=null selected bankid
                BaseBankId = NewCreatedBankByCAFromExisting.BaseBankId,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            // Now bank with the same name exist it has CAid NULL and bankid is same as base bankid
            // it should update // in this case ispresent should return false
            BankDto bankD = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(bankdto.BankName == bankD.BankName, "Bank Updated as it exists but existing bnakid = basebankid");
            Assert.IsTrue(NewCreatedBankByCAFromExisting.BaseBankId == bankD.BaseBankId, "Base Bank ID remains same");
        }

        [TestMethod]
        public virtual void CAUserUpdatesBankChangesNameButBankNamePresentwithDifferentID()
        {
            this.NewCreatedBankByCAFromExisting = BankService.GetById(20);
            var bankdto = new BankDto
            {
                BankId = NewCreatedBankByCAFromExisting.BankId,
                BankName = "ICICI Bank",
                CAId = 1, // default CAId=null selected bankid
                BaseBankId = NewCreatedBankByCAFromExisting.BaseBankId,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            // Now bank with the same name exist it has CAid NULL and bankid is not same as base bankid
            // it should not update // in this case ispresent should return true
            BankDto bankD = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(bankD.Response.HasWarning, "Bank Already Exist");
            Assert.IsTrue(NewCreatedBankByCAFromExisting.BaseBankId == bankD.BaseBankId, "Base Bank ID remains same");
        }

        [TestMethod]
        public virtual void CAUserUpdates1()
        {
            this.NewCreatedBankByCAFromExisting = BankService.GetById(20);
            var bankdto = new BankDto
            {
                BankId = NewCreatedBankByCAFromExisting.BankId,
                BankName = "HDFC Bank",
                CAId = 1, // default CAId=null selected bankid
                BaseBankId = NewCreatedBankByCAFromExisting.BaseBankId,
                CreatedBy = 1,
                ModifiedBy = 1
            };
            // Now bank with the same name exist it has CAid NULL and bankid is not same as base bankid
            // it should not update // in this case ispresent should return true
            BankDto bankD = this.BankService.Update(bankdto, CurrentUserInstance.UserName);
            Assert.IsTrue(bankD.Response.HasWarning, "Bank Already Exist");
            Assert.IsTrue(NewCreatedBankByCAFromExisting.BaseBankId == bankD.BaseBankId, "Base Bank ID remains same");
        }
        
        #endregion 

        #region Branch Testmethods

        [TestMethod]
        public virtual void CreateNewBranchBySuperAdmin() 
        {
            var bankbranchdto = new BankBranchDto
            {
                Name = "Nigdi",
                IFSCCode = "NigdiIFSC01",
                MICRCode = "NigdiMICR01",
                SWIFTCode = "NigdiSWIFT01",
                Email1 = "info@axis.com",
                Email2 = "contact@axis.com",
                FullDayTimeFrom = TimeSpan.FromHours(9),
                FullDayTimeTo = TimeSpan.FromHours(5),
                HalfDayTimeFrom = TimeSpan.FromHours(9),
                HalfDayTimeTo = TimeSpan.FromHours(1),
                FullDayBreakFrom = TimeSpan.FromHours(1),
                FullDayBreakTo = TimeSpan.FromHours(1),
                HalfDayBreakFrom = TimeSpan.FromHours(11),
                HalfDayBreakTo = TimeSpan.FromHours(11),
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1,

                #region BankAddress
                BranchAddress = new AddressDto
                {
                    AddressLine1 = "Nigdi",
                    AddressLine2 = "near busstop",
                    PIN = "411044",
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
                BankId = 9
            };
            bankbranchdto.BranchOfBank = bankdto;
            this.BankBranchInstance = this.BankBranchService.Create(bankbranchdto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.BankBranchInstance.BranchId == 0, "Branch Id should have been updated");
        }

        [TestMethod]
        public virtual void UpdateBranchBySuperAdmin() 
        {
            this.BankBranchInstance = BankBranchService.GetById(14);
            
            var bankbranchdto = new BankBranchDto
            {
                BranchId = this.BankBranchInstance.BranchId,
                Name = "PS Road",
                IFSCCode = "PSIFSC01",
                MICRCode = "PSMICR01",
                SWIFTCode = "PSSWIFT01",
                Email1 = "information@axis.com",
                Email2 = "contact@axis.com",
                FullDayTimeFrom = TimeSpan.FromHours(6),
                FullDayTimeTo = TimeSpan.FromHours(6),
                HalfDayTimeFrom = TimeSpan.FromHours(6),
                HalfDayTimeTo = TimeSpan.FromHours(6),
                FullDayBreakFrom = TimeSpan.FromHours(1),
                FullDayBreakTo = TimeSpan.FromHours(1),
                HalfDayBreakFrom = TimeSpan.FromHours(11),
                HalfDayBreakTo = TimeSpan.FromHours(11),
                CAId = null,
                CreatedBy = 1,
                ModifiedBy = 1,                             

                #region BankAddress
                BranchAddress = new AddressDto
                {
                    AddressId = this.BankBranchInstance.BranchAddress.AddressId,
                    AddressLine1 = "updated pn road",
                    AddressLine2 = "updated near busstop",
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
                //BranchContactNos = new List<ContactDetailsDto>
                //{     
                //    foreach(ContactDetailsDto cbDto in  bankbranchdto.BranchContactNos)
                //    {
                //        cbDto.ContactDetailsId,
                //        cbDto.STDCode = "020"
                //    };
                //    //new ContactDetailsDto
                //    //{                        
                //    //    ContactNoType = Common.ContactType.OfficeNo,
                //    //    STDCode = "020",
                //    //    ContactNo = "27658945",                        
                //    //    CountryCallingCode = CountryInstance.CallingCode
                //    //},
                //    //new ContactDetailsDto
                //    //{
                //    //    ContactNoType = Common.ContactType.Fax,
                //    //    STDCode = "020",
                //    //    ContactNo = "45646456",                        
                //    //    CountryCallingCode = CountryInstance.CallingCode
                         
                //    //}
                //},
                #endregion

                WeeklyHalfDay = new WeeklyHalfDayDto
                {
                    WeeklyHalfDayId = this.BankBranchInstance.WeeklyHalfDay.WeeklyHalfDayId,
                    IsSaturday = false,
                    IsThursday=true
                },
                WeeklyOffDay = new WeeklyOffDaysDto
                {
                    WeeklyOffDayId = this.BankBranchInstance.WeeklyOffDay.WeeklyOffDayId,
                    IsSunday = true
                }
            };
            BankDto bankdto = new BankDto
            {
                BankId = 9
            };
            bankbranchdto.BranchOfBank = bankdto;
            BankBranchDto updatedBankBranch = this.BankBranchService.Update(bankbranchdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankBranchInstance.Name == updatedBankBranch.Name, "Branch updated");
            Assert.IsTrue(updatedBankBranch.Email1 != BankBranchInstance.Email1, "Branch Email1 updated");
        }

        /// <summary>
        /// This Testmethod senario : Client(i.e. CAId)  created new branch record 
        /// </summary>
        [TestMethod]
        public virtual void CreateNewBranchByClientUser()  
        {
            var bankbranchdto = new BankBranchDto
            {
                Name = "MG Road",
                IFSCCode = "SBI00001235",
                MICRCode = "4112290122",
                SWIFTCode = "1234",
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
                CAId = 1,
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
            Assert.IsFalse(this.BankBranchInstance.BranchId == 0, "Branch Id should have been updated");
        }

        /// <summary>
        /// This Testmethod senario : If Client(i.e. CAId) updated the default registered branch which was added by ack,
        ///                           then ack created new entry of that branch for that perticular client(i.e. CAId)
        /// </summary>
        [TestMethod]
        public virtual void UpdateDefaultRegisterBranchByClientUser() 
        {
            var branchdto = BankBranchService.GetById(4);
            branchdto.Name = "fCollege road";
            branchdto.CAId = 5; // default CAId=null selected branchid
            branchdto.SWIFTCode = "FC1234";
            branchdto.CreatedBy = 1;
            branchdto.ModifiedBy = 1;
            branchdto.WeeklyHalfDay.IsThursday = true;
            branchdto.WeeklyHalfDay.IsSaturday= false;
            this.BankBranchInstance = this.BankBranchService.Update(branchdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankBranchInstance.Name == branchdto.Name, "Updated branch");
        }

        /// <summary>
        /// This Testmethod senario : Updated only that branch records which was added by that client(i.e. CAId) 
        /// </summary>
        [TestMethod]
        public virtual void UpdateBranchAddedBySameClientUser() 
        {
            var branchdto = BankBranchService.GetById(9);
            branchdto.Name = "fCollege road";
            branchdto.CAId = 5; // Same for CAId=1 and selected branchid also same
            branchdto.SWIFTCode = "FC1234";
            branchdto.CreatedBy = 1;
            branchdto.ModifiedBy = 1;
            branchdto.WeeklyHalfDay.IsThursday = true;
            branchdto.WeeklyHalfDay.IsSaturday = false;
            this.BankBranchInstance = this.BankBranchService.Update(branchdto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.BankBranchInstance.Name == branchdto.Name, "Updated branch");
        }

        [TestMethod]
        public virtual void FindBranchesOfCA()
        {
            UserDto currentUserDto = UserService.GetById(42);
            Query subquery1 = new Query();
            if (currentUserDto.UserOfClient.CAId > 0)
            {
                Criterion criteriaCAId = new Criterion(Constants.CAID, currentUserDto.UserOfClient.CAId, CriteriaOperator.Equal);
                subquery1.Add(criteriaCAId);
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                subquery1.Add(criteriaCAIdNULL);
                subquery1.QueryOperator = QueryOperator.Or;
            }
            else
            {
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                subquery1.Add(criteriaCAIdNULL);
            }

            Query query = new Query();
            if (currentUserDto.UserOfClient.CAId > 0)
                query.CAId = Convert.ToInt32(currentUserDto.UserOfClient.CAId);
            Criterion criteriaBankId = new Criterion("banks.BankId", 1, CriteriaOperator.Equal);
            query.Add(criteriaBankId);
            query.AddAlias(new Alias("banks", "BranchOfBank"));
            query.QueryOperator = QueryOperator.And;
            query.AddSubQuery(subquery1);

            var BankBranches = BankBranchService.FindByQuery(query);
            Assert.IsTrue(BankBranches.Entities.ToList().Count > 0, "found bank branch");
        }

        #endregion
    }
}
