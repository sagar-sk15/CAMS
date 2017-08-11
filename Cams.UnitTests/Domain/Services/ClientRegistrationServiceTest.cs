using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.ClientMasters;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class ClientRegistrationServiceTest : CamsTestBase
    {
        public IClientService ClientService { get; set; }
        public IUserService UserService { get; set; }
        public IAddressService AddressService { get; set; }
        public ICountryMasterService CountryService { get; set; }
        public ICommodityClassService CommodityClassService { get; set; }
        public IDesignationService DesignationService { get; set; }
        public ISubscriptionMasterService SubscriptionMasterService { get; set; }
            

        public ClientDto ClientInstance { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        public AddressDto AddressInstance { get; set; }
        public CountryDto CountryInstance { get; set; }
        public CommodityClassDto CommodityClassInstance { get; set; }
        public DesignationDto DesignationInstance { get; set; }
        public SubscriptionMasterDto SubscriptionMasteInstance { get; set; }
            
        
        long SuperAdminId = 1;
        int CountryId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.ClientService = ClientServiceLocator.Instance().ContractLocator.ClientServices;
            this.AddressService = ClientServiceLocator.Instance().ContractLocator.AddressServices;
            this.CountryService = ClientServiceLocator.Instance().ContractLocator.CountryServices;
            this.CommodityClassService = ClientServiceLocator.Instance().ContractLocator.CommodityClassServices;
            this.DesignationService = ClientServiceLocator.Instance().ContractLocator.DesignationServices;
            this.SubscriptionMasterService = ClientServiceLocator.Instance().ContractLocator.SubscriptionMasterServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
            CountryInstance = CountryService.GetById(CountryId);
        }

        [TestMethod]
        public virtual void CreateClient()
        {
            string prefix = "ShivSagar";
            string postfixNum = "2012";
            var clientDto = new ClientDto
            {
                DisplayClientId = "",
                CompanyName = prefix + "Corporation",
                RegistrationDate = DateTime.Now,
                Alias = prefix ,
                PAN = postfixNum + "PANCV72",//20C
                TAN = postfixNum + "TAN456TESN",
                Email1 = prefix + "@gmail.com",
                Email2 = prefix + "@yahoo.co.in",
                Website = "www." +prefix +".com",
                IsActive = true,
                IsDeleted = false,
                Status = Common.ClientStatus.Active,
                AllowEdit = true,
                APMCLicenseNo = postfixNum + "PUNEAPMC12369",
                APMCLicenseValidUpTo = System.DateTime.Now.AddDays(2),//Convert.ToDateTime("18/05/2012"),
                NoOfPartners = 0,
                TDSOnSubscriptionPayment = 1,
                AdditionalInfoForSubscriptionPayment = prefix + "test",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,

                #region ClientAddress
                ClientAddress = new AddressDto
                {
                    AddressLine1 = prefix + "address line1",
                    AddressLine2 = prefix + "address line2",
                    PIN = "411040",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 160
                    }
                }
                #endregion

            };

            #region ClientContacts
            clientDto.ClientContacts = new List<ContactDetailsDto>
            {
                new ContactDetailsDto
                {
                    ContactNoType = Common.ContactType.OfficeNo,
                    STDCode = "020",
                    ContactNo = "276538958",                        
                    CountryCallingCode = CountryInstance.CallingCode
                },
                //new ContactDetailsDto
                //{
                //    ContactNoType = Common.ContactType.Fax,
                //    STDCode = "020",
                //    ContactNo = "45646456",                        
                //    CountryCallingCode = CountryInstance.CallingCode                         
                //}
            };
            #endregion

            #region ClientAPMC

            clientDto.ClientAPMC = new APMCDto
            {
                APMCId = 1
            };
            #endregion

            #region ClientBusinessConstitution
            clientDto.ClientBusinessConstitution = new BusinessConstitutionDto
            {
                BusinessConstitutionId = 1
            };
            #endregion

            #region AccountManager
            clientDto.AccountManager = new UserDto
            {
                UserId = 2
            };
            clientDto.AccountManagerId = 2;
            #endregion

            #region ClientCommodities
            clientDto.ClientCommodities = new List<CommodityClassDto>
            {
                new CommodityClassDto
                {
                    CommodityClassId = 1
                },
                new CommodityClassDto
                {
                    CommodityClassId = 2
                }//,
                // new CommodityClassDto
                //{
                //    CommodityClassId = 3
                //},
                //new CommodityClassDto
                //{
                //    CommodityClassId = 4
                //}

            };
            #endregion

            #region ClientPrimaryContactPerson
            clientDto.ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto
            {
                Title = "Mr",
                CAPrimaryConatactPersonName = prefix + "Manav",
                Gender = "Male",
                DateOfBirth = Convert.ToDateTime("08/08/1985"),
                MothersMaidenName = "varsha",
                PAN = postfixNum + "PAND33445",
                UID = postfixNum + "UID12457",
                Email1 = prefix + "Manav@gmail.com",
                Email2 = prefix + "Manav@yahoo.co.in",
                IsSameAsCompanyAddress = false,
                IsSameAsCompanyContact = false,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,

                #region ClientPrimaryContactPersonAddress
                ClientPrimaryContactPersonAddress = new AddressDto
                {
                    AddressLine1 = prefix + " primary person address line1",
                    AddressLine2 = prefix + " primary person address line2",
                    PIN = "411040",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 148
                    }
                },
                #endregion

                #region ClientPrimaryContactPersonDesignation
                ClientPrimaryContactPersonDesignation = new DesignationDto
                {
                    DesignationId = 1
                },
                #endregion

                #region ClientPrimaryContacts
                ClientPrimaryContacts = new List<ContactDetailsDto>
                {
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.MobileNo,
                        STDCode = "020",
                        ContactNo = "27658945" +postfixNum,                        
                        CountryCallingCode = CountryInstance.CallingCode
                    },
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.Fax,
                        STDCode = "020",
                        ContactNo = "45646456",                        
                        CountryCallingCode = CountryInstance.CallingCode                         
                    }
                }
                #endregion
            };
            #endregion

            #region ClientSubscription
            clientDto.ClientSubscription = new ClientSubscriptionDto
            {
                SubscriptionPeriod = 2,
                SubscriptionPeriodFromDate = DateTime.Now,
                SubscriptionPeriodToDate = Convert.ToDateTime("10/12/2014"),
                AdditionalNoOfAssociates = 3,
                AdditionalNoOfAuditors = 1,
                AdditionalNoOfEmployees = 2,
                AdditionalCostForAssociates = 6000,
                AdditionalCostForAuditors = 6000,
                AdditionalCostForEmployees = 6000,
                DiscountInPercentage = 5,
                DiscountInRupees = 2000,
                ServiceTax = 250,
                OtherTax = 100,
                Status = Common.ClientStatus.Active,
                AdditionalInfo = "test",
                ActivationDate = DateTime.Now,
                AllowEdit = true,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                #region SubscriptionMaster
                SubscriptionMaster = new SubscriptionMasterDto
                {
                    SubscriptionId = 1
                },
                #endregion

                #region ClientSubscriptionPaymentDetails
                ClientSubscriptionPaymentDetails = new List<ClientSubscriptionPaymentDetailsDto>
                {                    
                    new ClientSubscriptionPaymentDetailsDto
                    {
                        PaymentMode = Common.PaymentMode.Cheque,
                        Amount = 50000,
                        IsRTGS = false,
                        IsNEFT = false,
                        IsStandardCheque = true,
                        ChequeDDTransationNo = "6871231",
                        ChequeDDTransactionDate = DateTime.Now,
                        ChequeDDClearanceDates =  DateTime.Now,                        
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        BankBranch = new BankBranchDto
                        {
                            BranchId = 1
                        }
                    }
                }
                #endregion
            };
            #endregion

            #region ClientPartners
            clientDto.ClientPartners = new List<ClientPartnerDetailsDto>
            {
                #region Partner1
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = "prakash",
                    Gender = "female",
                    DateOfBirth = Convert.ToDateTime("01/01/2008"),
                    PAN = postfixNum +"PANW87760B2",
                    UID = postfixNum +"UIDTEST872",
                    Email1 = prefix +"test@gmail.com",
                    Email2 = prefix +"test@yahoo.com",
                    JoiningDate = Convert.ToDateTime("01/01/2001"),
                    RelievingDate = Convert.ToDateTime("01/01/2007"),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +" partner1 address line1",
                        AddressLine2 = prefix +" partner1 address line2",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 2
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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

                    #region ClientPartnerGuardian
                    ClientPartnerGuardian = new ClientPartnerGuardianDetailsDto
                    {
                        Title = "Mr",
                        GuardianName = "mona",
                        Gender = "female",
                        DateOfBirth = Convert.ToDateTime("01/01/1972"),
                        PAN = postfixNum +"PANWerer34534",
                        UID = postfixNum +"UIDTEST8455",
                        Email1 = prefix +"test@gmail.com",
                        Email2 = prefix +"test@yahoo.com",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        
                        ClientPartnerGuardianAddress = new AddressDto
                        {
                            AddressLine1 = prefix +" guardian address line1",
                            AddressLine2 = prefix +" guardian address line2",
                            PIN = "411078",
                            CreatedBy = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedDate = DateTime.Now,
                            CityVillage = new CityVillageDto
                            {
                                CityVillageId = 9
                            }
                        },
                        ClientPartnerGuardianContacts = new List<ContactDetailsDto>
                        {
                            new ContactDetailsDto
                            {
                                ContactNoType = Common.ContactType.OfficeNo,
                                STDCode = "020",
                                ContactNo = "27658945",                        
                                CountryCallingCode = CountryInstance.CallingCode
                            }
                        },
                        GuardianRelationshipWithClientPartner = new RelationshipDto
                        {
                            RelationshipId = 1
                        }
                    },
                    #endregion 
                },
                #endregion

                #region Partner2
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = prefix +"partnername",
                    Gender = "Male",
                    DateOfBirth = Convert.ToDateTime("01/01/1970"),
                    PAN = postfixNum +"PANU1234V2",
                    UID = postfixNum +"UIDTEST232",
                    Email1 = prefix +"partnertestmail@gmail.com",
                    Email2 = prefix +"partnertestmail@yahoo.com",
                    JoiningDate = Convert.ToDateTime("02/02/2001"),
                    RelievingDate = Convert.ToDateTime("02/02/2007"),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +" partner2 address line1",
                        AddressLine2 = prefix +" partner2 address line2",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 3
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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
                    }
                    #endregion
                }                
                #endregion
            };
            #endregion

            #region ClientUsers
            //clientDto.ClientUsers = new List<UserDto>
            //{
            UserDto clientUser = new UserDto
                {
                    //UserId = 9
                    Title = "Ms",
                    Name = prefix + "testuser",
                    UserName = prefix + "1234",
                    MobileNo = "9466666614",
                    Email = prefix + "clientusermail@gmail.com",
                    CountryCode = "091",
                    MothersMaidenName = prefix + "mothersname",
                    DateOfBirth = Convert.ToDateTime("10/10/1985"),
                    IsActive = true,
                    Password = "passwd@123",
                    CreatedBy = -1,
                    CreatedDate = DateTime.Now,
                    IsLockedOut = false,
                    IsOnLine = false,
                    ModifiedBy = -1,
                    ModifiedDate = DateTime.Now,
                    LastPassword = "password",
                    SecondLastPassword = "pass",
                    IsDeleted = false,
                    AllowDelete = true,
                    AllowEdit = true,
                    UserDesignation = new DesignationDto
                    {
                        DesignationId = 4
                    }
                    
                };
                    
            //};
            #endregion
            
            this.ClientInstance = this.ClientService.Create(clientDto, CurrentUserInstance.UserName);            
            Assert.IsFalse(this.ClientInstance.CAId == 0, "CAId should have been updated");
        }

        [TestMethod]
        public virtual void CreateClientWithNullValues() 
        {
            string prefix = "gajanan";
            //string postfixNum = "1001";
            var clientDto = new ClientDto
            {
                DisplayClientId = "",
                CompanyName = prefix + "Corporation",
                RegistrationDate = null,
                Alias = null,
                PAN = null,
                TAN = null,
                Email1 = null,
                Email2 = null,
                Website = null,
                IsActive = true,
                IsDeleted = false,
                Status = Common.ClientStatus.Active,
                AllowEdit = true,
                APMCLicenseNo = null,
                APMCLicenseValidUpTo = null,
                NoOfPartners = 0,
                TDSOnSubscriptionPayment = 0,
                AdditionalInfoForSubscriptionPayment = null,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                ClientAddress = null,
            };
            clientDto.ClientContacts = null;
            clientDto.ClientAPMC = null;
            clientDto.ClientBusinessConstitution = null;
            clientDto.AccountManagerId = 0;
            clientDto.ClientCommodities = null;
            clientDto.ClientPrimaryContactPerson = null;
            clientDto.ClientSubscription = null;
            clientDto.ClientPartners = null;

            this.ClientInstance = this.ClientService.Create(clientDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.ClientInstance.CAId == 0, "CAId should have been updated");
        }

        [TestMethod]
        public virtual void CreateClientWithIncompleteInfo()  
        {
            string prefix = "Mahalaxmi";
            //string postfixNum = "1001";
            var clientDto = new ClientDto
            {
                DisplayClientId = "",
                CompanyName = prefix + "Corporation",
                RegistrationDate = null,
                Alias = null,
                PAN = null,
                TAN = null,
                Email1 = null,
                Email2 = null,
                Website = null,
                IsActive = true,
                IsDeleted = false,
                Status = Common.ClientStatus.Active,
                AllowEdit = true,
                APMCLicenseNo = null,
                APMCLicenseValidUpTo = null,
                NoOfPartners = 0,
                TDSOnSubscriptionPayment = 0,
                AdditionalInfoForSubscriptionPayment = null,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                ClientAddress = null,
            };
            clientDto.ClientContacts = null;
            clientDto.ClientAPMC = null;
            clientDto.ClientBusinessConstitution = null;
            clientDto.AccountManagerId = 0;
            clientDto.ClientCommodities = null;
            
            clientDto.ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto
            {
                Title = "Ms",
                CAPrimaryConatactPersonName = "shraddha",
                Gender = "F",
                DateOfBirth = null,
                MothersMaidenName = "manisha",
                PAN = null,
                UID = null,
                Email1 = "shraddha@ack.com",
                Email2 = null,
                IsSameAsCompanyAddress = false,
                IsSameAsCompanyContact = false,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1, 
                ModifiedDate = DateTime.Now,

                #region ClientPrimaryContactPersonAddress
                ClientPrimaryContactPersonAddress = null,
                #endregion

                #region ClientPrimaryContactPersonDesignation
                ClientPrimaryContactPersonDesignation = null,
                #endregion           
                
                #region ClientPrimaryContacts
                //ClientPrimaryContacts = null
                ClientPrimaryContacts = new List<ContactDetailsDto>
                {
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.MobileNo,
                        STDCode = "020",
                        ContactNo = "9914755864" ,                       
                        CountryCallingCode = CountryInstance.CallingCode
                    },
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.Fax,
                        STDCode = "020",
                        ContactNo = "45646456",                        
                        CountryCallingCode = CountryInstance.CallingCode                         
                    }
                }
                #endregion
            };

            this.ClientInstance = this.ClientService.Create(clientDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.ClientInstance.CAId == 0, "CAId should have been updated");
        }

        [TestMethod]
        public virtual void UpdateClient() 
        {
            this.ClientInstance = ClientService.GetById(9);
            string prefix = "samidha";
            string postfixNum = "116";
            int ContactDetailsId = 26;
            var clientDto = new ClientDto
            {
                CAId = this.ClientInstance.CAId,
                //DisplayClientId = prefix + "21 III 12001",
                CompanyName = prefix + "Corporation",
                RegistrationDate = DateTime.Now,
                Alias = prefix + "ShreeGanesh",
                PAN = "2012PANCV72",
                TAN = "2012TAN456TESN",
                Email1 = prefix + "@gmail.com",
                APMCLicenseNo = "2012PUNEAPMC12369",
                APMCLicenseValidUpTo = System.DateTime.Now.AddDays(2),
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,

                #region ClientAddress
                ClientAddress = new AddressDto
                {
                    AddressId = this.ClientInstance.ClientAddress.AddressId,
                    AddressLine1 = prefix + "client address line1 updated",
                    AddressLine2 = prefix + "client address line2 updated",
                    PIN = "411040",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 148
                    }
                }
                #endregion
            };

            #region ClientAPMC

            clientDto.ClientAPMC = new APMCDto
            {
                APMCId = this.ClientInstance.ClientAPMC.APMCId
            };
            #endregion

            #region ClientBusinessConstitution
            clientDto.ClientBusinessConstitution = new BusinessConstitutionDto
            {
                BusinessConstitutionId = this.ClientInstance.ClientBusinessConstitution.BusinessConstitutionId
            };
            #endregion

            #region AccountManager
            //clientDto.AccountManager = new UserDto
            //{
            //    UserId = this.ClientInstance.AccountManager.UserId
            //};
            clientDto.AccountManagerId = this.ClientInstance.AccountManagerId;
            #endregion

            #region ClientCommodities
            clientDto.ClientCommodities = new List<CommodityClassDto>
            {
                new CommodityClassDto
                {
                    CommodityClassId = 1
                },
                new CommodityClassDto
                {
                    CommodityClassId = 2
                }
            };
            #endregion

            #region ClientPrimaryContactPerson
            clientDto.ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto
            {
                CAPrimaryContactPersonId = this.ClientInstance.ClientPrimaryContactPerson.CAPrimaryContactPersonId,
                Title = "Mr",
                CAPrimaryConatactPersonName = prefix + "SanjayBhosale",
                Gender = "Male",
                DateOfBirth = Convert.ToDateTime("08/08/1985"),
                MothersMaidenName = "varsha",
                PAN = "ARTDV3440O" + postfixNum,
                UID = "TESTUID123456" + postfixNum,
                Email1 = prefix + "@gmail.com",
                Email2 = prefix + "@yahoo.co.in",
                IsSameAsCompanyAddress = false,
                IsSameAsCompanyContact = false,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,

                #region ClientPrimaryContactPersonAddress
                ClientPrimaryContactPersonAddress = new AddressDto
                {
                    AddressId = this.ClientInstance.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.AddressId,
                    AddressLine1 = prefix + "CA primary person address line1 updated",
                    AddressLine2 = prefix + "CA primary person address line2 updated",
                    PIN = "411040",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 148
                    }
                },
                #endregion

                #region ClientPrimaryContactPersonDesignation
                ClientPrimaryContactPersonDesignation = new DesignationDto
                {
                    DesignationId = this.ClientInstance.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation.DesignationId
                },
                #endregion

                #region ClientPrimaryContacts
                
                //ClientPrimaryContacts = new List<ContactDetailsDto>
                //{
                //    new ContactDetailsDto
                //    {
                //        ContactNoType = Common.ContactType.MobileNo,
                //        STDCode = "020",
                //        ContactNo = "27658945" + postfixNum,                        
                //        CountryCallingCode = CountryInstance.CallingCode
                //    },
                //    new ContactDetailsDto
                //    {
                //        ContactNoType = Common.ContactType.Fax,
                //        STDCode = "020",
                //        ContactNo = "45646456",                        
                //        CountryCallingCode = CountryInstance.CallingCode                         
                //    }
                //}
                #endregion
            };

            clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts = this.ClientInstance.ClientPrimaryContactPerson.ClientPrimaryContacts;
            ContactDetailsDto contactdetailsDto = clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts.Where(f => f.ContactDetailsId == ContactDetailsId).First();
            contactdetailsDto.ContactNoType = Common.ContactType.MobileNo;
            contactdetailsDto.ContactNo = "21212121" + postfixNum;
            #endregion

            #region ClientSubscription
            clientDto.ClientSubscription = new ClientSubscriptionDto
            {
                ClientSubscriptionId = this.ClientInstance.ClientSubscription.ClientSubscriptionId,
                SubscriptionPeriod = 22 ,
                SubscriptionPeriodFromDate = DateTime.Now,
                SubscriptionPeriodToDate = Convert.ToDateTime("10/12/2014"),
                AdditionalNoOfAssociates = 32,
                AdditionalNoOfAuditors = 1,
                AdditionalNoOfEmployees = 2,
                AdditionalCostForAssociates = 5000,
                AdditionalCostForAuditors = 5000,
                AdditionalCostForEmployees = 5000,
                DiscountInPercentage = 5,
                DiscountInRupees = 1000,
                ServiceTax = 2,
                OtherTax = 1,
                Status = Common.ClientStatus.Active,
                AdditionalInfo = prefix + "test",
                ActivationDate = DateTime.Now,
                AllowEdit = true,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                #region SubscriptionMaster
                SubscriptionMaster = new SubscriptionMasterDto
                {
                    SubscriptionId = this.ClientInstance.ClientSubscription.SubscriptionMaster.SubscriptionId
                },
                #endregion

                #region ClientSubscriptionPaymentDetails
                //ClientSubscriptionPaymentDetails = new List<ClientSubscriptionPaymentDetailsDto>
                //{                    
                //    new ClientSubscriptionPaymentDetailsDto
                //    {
                //        PaymentMode = Common.PaymentMode.Cheque,
                //        Amount = 50000,
                //        IsRTGS = false,
                //        IsNEFT = false,
                //        IsStandardCheque = true,
                //        ChequeDDTransationNo = "687123",
                //        ChequeDDTransactionDate = DateTime.Now,
                //        ChequeDDClearanceDates =  DateTime.Now,
                //        TDS = 1,
                //        AdditionalInfo = "test",
                //        CreatedBy = 1,
                //        CreatedDate = DateTime.Now,
                //        ModifiedBy = 1,
                //        ModifiedDate = DateTime.Now,
                //        BankBranch = new BankBranchDto
                //        {
                //            BranchId = 1
                //        }
                //    }
                //}
                #endregion
            };
            #endregion

            #region ClientPartners
            clientDto.ClientPartners = new List<ClientPartnerDetailsDto>
            {
                #region Partner1
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = "Shankar",
                    Gender = "Male",
                    DateOfBirth = Convert.ToDateTime("01/01/1970"),
                    PAN = postfixNum + "THFWE87760B",
                    UID = postfixNum +"UIDTEST987",
                    Email1 = "Shankar@gmail.com",
                    Email2 = "Shankar@yahoo.com",
                    JoiningDate = Convert.ToDateTime("01/01/2001"),
                    RelievingDate = Convert.ToDateTime("01/01/2007"),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +"partner address line1",
                        AddressLine2 = prefix +"partner address line2",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 2
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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
                    }
                    #endregion
                },
                #endregion

                #region Partner2
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = "Pratham",
                    Gender = "Male",
                    DateOfBirth = Convert.ToDateTime("01/01/1970"),
                    PAN = postfixNum + "CVBYU1234V",
                    UID = postfixNum + "UIDTEST123",
                    Email1 = prefix + "@gmail.com",
                    Email2 = prefix + "@yahoo.com",
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +"partner2 address line1 updated",
                        AddressLine2 = prefix +"partner2 address line2 updated",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 3
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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
                    }
                    #endregion
                }                
                #endregion
            };
            #endregion

            #region ClientUsers
            //clientDto.ClientUsers = new List<UserDto>
            //{
            //    new UserDto
            //    {
            //         //UserId = 9
            //        Title = "Ms",
            //        Name = "Smita", 
            //        UserName = "Smita",
            //        MobileNo = "9499999914",
            //        Email = "Smita@gmail.com", 
            //        CountryCode = "091",
            //        MothersMaidenName = "paro",
            //        DateOfBirth = Convert.ToDateTime("10/10/1985"),
            //        IsActive = true,
            //        Password = "passwd@123",
            //        CreatedBy = -1,
            //        IsLockedOut = false,
            //        IsOnLine = false,
            //        ModifiedBy = -1,
            //        LastPassword = "password",
            //        SecondLastPassword = "pass",
            //        IsDeleted = false,
            //        AllowDelete = true,
            //        AllowEdit = true,
            //        UserDesignation = new DesignationDto
            //        {
            //            DesignationId = 4
            //        }
            //    },
                    
            //};
            #endregion

            this.ClientInstance = this.ClientService.Update(clientDto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.ClientInstance.Alias == clientDto.Alias, "Client Updated");
        }

        [TestMethod]
        public virtual void CreatClientAccount()
        {
            string prefix = "gurukrupa 123";
            string postfixNum = "2011";
            var clientDto = new ClientDto
            {
                DisplayClientId = prefix + "21 III 12001",
                CompanyName = prefix + "Corporation",
                RegistrationDate = DateTime.Now,
                Alias = prefix,
                PAN = postfixNum + "PANCV72",//20C
                TAN = postfixNum + "TAN456TESN",
                Email1 = prefix + "@gmail.com",
                Email2 = prefix + "@yahoo.co.in",
                Website = "www." + prefix + ".com",
                IsActive = true,
                IsDeleted = false,
                Status = Common.ClientStatus.Active,
                AllowEdit = true,
                APMCLicenseNo = postfixNum + "PUNEAPMC12369",
                //APMCLicenseValidUpTo = Convert.ToDateTime("18/04/2012"),
                NoOfPartners = 0,
                TDSOnSubscriptionPayment = 1,
                AdditionalInfoForSubscriptionPayment = prefix + "test",
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,

                #region ClientAddress
                ClientAddress = new AddressDto
                {
                    AddressLine1 = prefix + "address line1",
                    AddressLine2 = prefix + "address line2",
                    PIN = "411040",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 160
                    }
                }
                #endregion
            };

            #region ClientPartners
            clientDto.ClientPartners = new List<ClientPartnerDetailsDto>
            {
                #region Partner1
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = "prakash",
                    Gender = "female",
                    DateOfBirth = Convert.ToDateTime("01/01/2008"),
                    PAN = postfixNum +"PANW87760B2",
                    UID = postfixNum +"UIDTEST872",
                    Email1 = prefix +"test@gmail.com",
                    Email2 = prefix +"test@yahoo.com",
                    JoiningDate = Convert.ToDateTime("01/01/2001"),
                    RelievingDate = Convert.ToDateTime("01/01/2007"),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +" partner1 address line1",
                        AddressLine2 = prefix +" partner1 address line2",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 2
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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

                    #region ClientPartnerGuardian
                    ClientPartnerGuardian = new ClientPartnerGuardianDetailsDto
                    {
                        Title = "Mr",
                        GuardianName = "mona",
                        Gender = "female",
                        DateOfBirth = Convert.ToDateTime("01/01/1972"),
                        PAN = postfixNum +"PANWerer34534",
                        UID = postfixNum +"UIDTEST8455",
                        Email1 = prefix +"test@gmail.com",
                        Email2 = prefix +"test@yahoo.com",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        
                        ClientPartnerGuardianAddress = new AddressDto
                        {
                            AddressLine1 = prefix +" guardian address line1",
                            AddressLine2 = prefix +" guardian address line2",
                            PIN = "411078",
                            CreatedBy = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedDate = DateTime.Now,
                            CityVillage = new CityVillageDto
                            {
                                CityVillageId = 9
                            }
                        },
                        ClientPartnerGuardianContacts = new List<ContactDetailsDto>
                        {
                            new ContactDetailsDto
                            {
                                ContactNoType = Common.ContactType.OfficeNo,
                                STDCode = "020",
                                ContactNo = "27658945",                        
                                CountryCallingCode = CountryInstance.CallingCode
                            }
                        },
                        GuardianRelationshipWithClientPartner = new RelationshipDto
                        {
                            RelationshipId = 1
                        }
                    },
                    #endregion 
                },
                #endregion

                #region Partner2
                new ClientPartnerDetailsDto
                {
                    Title = "Mr",
                    PartnerName = prefix +"partnername",
                    Gender = "Male",
                    DateOfBirth = Convert.ToDateTime("01/01/1970"),
                    PAN = postfixNum +"PANU1234V2",
                    UID = postfixNum +"UIDTEST232",
                    Email1 = prefix +"partnertestmail@gmail.com",
                    Email2 = prefix +"partnertestmail@yahoo.com",
                    JoiningDate = Convert.ToDateTime("02/02/2001"),
                    RelievingDate = Convert.ToDateTime("02/02/2007"),
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                        
                    #region ClientPartnerAddress
                    ClientPartnerAddress = new AddressDto
                    {
                        AddressLine1 = prefix +" partner2 address line1",
                        AddressLine2 = prefix +" partner2 address line2",
                        PIN = "411040",
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = 1,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 148
                        }
                    },
                    #endregion

                    #region ClientPartnerDesignation
                    ClientPartnerDesignation = new DesignationDto
                    {
                        DesignationId = 3
                    },
                    #endregion

                    #region ClientPartnerContacts
                    ClientPartnerContacts = new List<ContactDetailsDto>
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
                    }
                    #endregion
                }                
                #endregion
            };
            #endregion

            this.ClientInstance = this.ClientService.Create(clientDto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.ClientInstance.CAId == 0, "CAId should have been updated");
        }

        
        [TestMethod]
        public virtual void UpdateClientWithRemainingInformation() 
        {
            this.ClientInstance = ClientService.GetById(8);
            string prefix = "bhakti";
            string postfixNum = "107";
            int PartnerId = 1;
           
            var clientDto = new ClientDto
            {
                CAId = this.ClientInstance.CAId,
                DisplayClientId = Common.Helper.GetDisplayClientID(this.ClientInstance.CAId, Common.Constants.DISPLAYCLIENTIDPREFIX, this.ClientInstance.CreatedDate),
                CompanyName = prefix + "Corporation",
                RegistrationDate = DateTime.Now,
                Alias = prefix + "ShreeGanesh",
                PAN = "ATHCV2220C",
                TAN = "TAN133TEST",
                Email1 = prefix + "@gmail.com",
                APMCLicenseNo = "PUNEAPMC123",
                APMCLicenseValidUpTo = Convert.ToDateTime("12/12/2014"),
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
            };

            #region ClientPhoneCharges
            clientDto.ClientPhoneCharges = new ClientPhoneChargesDto
            {
                WithEffectFromDate = DateTime.Now,
                WSFarmerAmount = 100,
                OSFarmerAmount = 100,
                WSTraderAmount = 100,
                OSTraderAmount = 100,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now
            };
            #endregion 

            #region ClientSisterConcerns
            clientDto.ClientSisterConcerns = new List<ClientSisterConcernDto>
            {
                new ClientSisterConcernDto
                {
                    BusinessRelation = Common.ClientSisterConcernBusinessRelation.Supplier,
                    ClientSisterConcerName = "OM",
                    RelationshipWithEntity = null,
                    EntityId = 0,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                }
            };
            #endregion 

            #region ClientTaxationAndLicenses
            clientDto.ClientTaxationAndLicenses = new List<ClientTaxationAndLicensesDto>
            {
                new ClientTaxationAndLicensesDto
                {
                    TaxName = "Shop Act No",
                    LicenseNo = "ahgfh73643726",
                    IsWithEffectFromDateApplicable = true,
                    IsRenewalDateApplicable = true,
                    WithEffectFromDate = DateTime.Now,
                    RenewalDate = DateTime.Now,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                }
            };
            #endregion 

            #region ClientPartners
            clientDto.ClientPartners = this.ClientInstance.ClientPartners;
            ClientPartnerDetailsDto clientPartnerDetailsDto = clientDto.ClientPartners.Where(f => f.PartnerId == PartnerId).First();
            clientPartnerDetailsDto.PartnerDisplayId = "test12III12001";
            clientPartnerDetailsDto.MaritialStatus = "Single";
            clientPartnerDetailsDto.PassportNo = "ahsgd7367";
            clientPartnerDetailsDto.Place = "pune";
            clientPartnerDetailsDto.IssuedOn = DateTime.Now;
            clientPartnerDetailsDto.ValidUpTo = DateTime.Now;
            clientPartnerDetailsDto.PartnerType = Common.PartnerType.NonWorking;
            clientPartnerDetailsDto.CapitalRatio = 5;
            clientPartnerDetailsDto.ProfitRatio = 5;
            clientPartnerDetailsDto.ProfitRatio = 5;
            clientPartnerDetailsDto.LossRatio = 5;
            clientPartnerDetailsDto.OpeningBalance = 20000;
            clientPartnerDetailsDto.BalanceType = Common.BalanceType.Cr;
            clientPartnerDetailsDto.AsOnDate = DateTime.Now;
          
            #region ClientPartnerNominee
            clientPartnerDetailsDto.ClientPartnerNominee = new ClientPartnerNomineeDetailsDto
            {
                Title = "MS",
                PartnerNomineeName = prefix + "name",
                Gender = "F",
                DateOfBirth = DateTime.Now,
                PAN = "PANTEST" + postfixNum,
                UID = "UIDTEST" + postfixNum,
                Image = null,
                Email1 = prefix + "@gmail.com",
                Email2 = prefix + "yahoomail.com",
                MaritialStatus = "single",
                PassportNo = "ahsgd7367",
                Place = "pune",
                IssuedOn = DateTime.Now,
                ValidUpTo = DateTime.Now,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1,
                ModifiedDate = DateTime.Now,
                ClientPartnerNomineeAddress = new AddressDto
                {
                    AddressLine1 = prefix + " Nominee address line1",
                    AddressLine2 = prefix + " Nominee address line2",
                    PIN = "411078",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 9
                    }
                },
                ClientPartnerNomineeContacts = new List<ContactDetailsDto>
                {
                    new ContactDetailsDto
                    {
                        ContactNoType = Common.ContactType.OfficeNo,
                        STDCode = "020",
                        ContactNo = "27658945" + postfixNum,                        
                        CountryCallingCode = CountryInstance.CallingCode
                    }
                },
                NomineeRelationshipWithClientPartner = new RelationshipDto
                {
                    RelationshipId = 2
                }
            };
            #endregion 

            #region ClientPartnerBanks
            clientPartnerDetailsDto.ClientPartnerBanks = new List<ClientPartnerBankDetailsDto>
            {
                new ClientPartnerBankDetailsDto
                {
                    Accounttype = Common.AccountType.CurrentAccount,
                    AccountNo = "accountno" +postfixNum,
                    StandingInstructions = prefix + "test",
                    BankContactPersonName = prefix + "name",
                    Email1 = prefix +"@gamil.com",
                    Email2 = prefix + "yahoomail.com",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now,
                    BranchOfClientPartner = new BankBranchDto
                    {
                        BranchId = 1
                    },
                    BankContactPersonDesignation = new DesignationDto
                    {
                        DesignationId = 1
                    },
                    BankContactPersonContacts = new List<ContactDetailsDto>
                    {
                        new ContactDetailsDto
                        {
                            ContactNoType = Common.ContactType.OfficeNo,
                            STDCode = "020",
                            ContactNo = "27658945" + postfixNum,                        
                            CountryCallingCode = CountryInstance.CallingCode
                        }
                    }
                }
            };
            #endregion 

            #endregion

            this.ClientInstance = this.ClientService.Update(clientDto, CurrentUserInstance.UserName);
            Assert.IsTrue(this.ClientInstance.Alias == clientDto.Alias, "Client Updated");
        }
    }
}
