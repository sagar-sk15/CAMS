// Example header text. Can be configured in the options.
using System;
using System.Linq;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Extension.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cams.Common.Dto;
using System.Collections.Generic;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.UnitTests.Domain.Services
{
    [TestClass]
    public class UserServiceTests : CamsTestBase
    {
        public IUserService UserService { get; set; }
        public ICountryMasterService CountryService { get; set; }
        public IStateService StateService { get; set; }
        public IAddressService AddressService { get; set; }
        public UserDto UserInstance { get; set; }
        public AddressDto AddressInstance { get; set; }  
        public IUserRolePermissionService UserRolePermissionService {get; set; }        
        public IUserGroupService UserGroupService { get; set; }
        public UserGroupDto UserGroupInstance { get; set; }
        public UserDto CurrentUserInstance { get; set; }
        public CountryDto CountryInstance { get; set; }
        public StateDto StateInstance { get; set; }

        public UserRolePermissionDto UserRolePermissionInstance { get; set; }


        public IRoleService RoleService { get; set; }
        public RoleDto RoleInstance { get; set; }
        long SuperAdminId =1;
        //int RoleId = 1;
        int CountryId = 1;
        //int StateId = 1;
        //int UserGroupId = 1;

        [TestInitialize]
        public override void TestsInitialize()
        {
            base.TestsInitialize();            
            this.UserService = ClientServiceLocator.Instance().ContractLocator.UserServices;
            this.AddressService = ClientServiceLocator.Instance().ContractLocator.AddressServices;
            this.UserGroupService = ClientServiceLocator.Instance().ContractLocator.UserGroupServices;
            this.RoleService = ClientServiceLocator.Instance().ContractLocator.RoleServices;
            this.UserRolePermissionService = ClientServiceLocator.Instance().ContractLocator.UserRolePermissionServices;
            this.CountryService = ClientServiceLocator.Instance().ContractLocator.CountryServices;
            this.StateService = ClientServiceLocator.Instance().ContractLocator.StateServices;
            CurrentUserInstance = UserService.GetById(SuperAdminId);
            CountryInstance = CountryService.GetById(CountryId);            
        }

        [TestMethod]
        public virtual void CreateUser()
        {           
            #region UserDto
            var userdto = new UserDto
            {
                Title = "Ms",
                Name = "Smita", //"Sujata",
                UserName = "Smita",// "SujataPant",
                MobileNo = "9499999914",// "9890969234",
                Email = "Smita@gmail.com", //"sujatapant@ack.com",
                CountryCode = "091",
                MothersMaidenName = "paro",// "Anuradha",
                IsActive = true,
                Password = "passwd@123",
                CreatedBy = -1,
                IsLockedOut = false,
                IsOnLine = false,
                ModifiedBy = -1,
                LastPassword = "password",
                SecondLastPassword = "pass",
                IsDeleted = false,
                AllowDelete = true,
                AllowEdit = true,
                UserOfClient = new ClientDto
                {
                    CAId = 1
                }
            };
            #endregion 
                                
            #region UserGroup
            var usergroupDto = new UserGroupDto
            {
                UserGroupId = 3 ,  
            };
            userdto.UserWithUserGroups.Add(usergroupDto);

            #endregion

            #region DesignationDto
            DesignationDto designDto = new DesignationDto
            {
                 DesignationId = 1                
            };
            userdto.UserDesignation = designDto;
            #endregion                       
            
            #region UserProfile
            
            #region userprofileDto
            var userprofiledto = new UserProfileDto
            {
                Gender = "Female",
                MaritalStatus = "Married",
                UID = "testuid123",
                PAN = "agttm6550t",
                PassportNo = "jh27900",
                PassportPlace = "pune",
                BloodGroup = "O+",
                PFNo = "mh/th/2734723",
                CreatedBy = -1,
                ModifiedBy = -1,
                Email1 = "ss@dd.com",
                UserAddress = new AddressDto
                {
                    AddressLine1 = "Navi Peth",
                    AddressLine2 = "b1 c wing c8",
                    PIN = "411040",
                    CreatedBy = -1,
                    ModifiedBy = -1,
                    CityVillage = new CityVillageDto
                    {
                        CityVillageId = 148 
                    }
                }
                ,
            #endregion

                #region User Contact Details
                ContactNos = new List<ContactDetailsDto>
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
            ,
                #endregion

                #region User Emergency ContactPerson

                #region UserEmergencyContactPersonDto
                UserEmergencyContactPerson = new UserEmergencyContactPersonDto
                {
                    Name = "asha",
                    Email1 = "asha@gmail.com",
                    CreatedBy = -1,
                    ModifiedBy = -1,
                    ContactPersonAddress = new AddressDto
                    {
                        AddressLine1 = "market yard solapur",
                        PIN = "413005",
                        CreatedBy = -1,
                        ModifiedBy = -1,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = 15 
                        }
                    }
                    ,
                #endregion

                 #region User Emergency Contact Person ContactDetailsDto
                    Contacts = new List<ContactDetailsDto>
                    {
                        new ContactDetailsDto
                        {
                            ContactNoType = Common.ContactType.MobileNo,
                            STDCode = "",
                            ContactNo = "9924088345",
                            CountryCallingCode = CountryInstance.CallingCode                    
                        }
                    }
                        ,
                 #endregion

                #region RelationshipDto
                ContactPersonRelationshipWithUser = new RelationshipDto
                {
                    RelationshipId = 1
                }
                #endregion
                }

            };
            #endregion

            userdto.UserProfile = userprofiledto;
            #endregion

            this.UserInstance = this.UserService.Create(userdto, CurrentUserInstance.UserName);         
            Assert.IsFalse(this.UserInstance.UserId == 0, "User Id should have been updated");
            Assert.AreEqual(this.UserInstance.Name, userdto.Name, "First Name are different");
        }

        [TestMethod]
        public virtual void UpdateUser1()
        {
            //var id = 42;
            var userdto = UserService.GetByUserName("Smita");
                      
            #region UserDto

            userdto.Title = "Ms";
                userdto.Name = "Himali";
                
                userdto.Email = "HimaliSmita@gmail.com";
                
            #endregion

            #region UserGroup
            var usergroupDto = new UserGroupDto
            {
                UserGroupId = 4,
            };

            userdto.UserWithUserGroups.Clear();
            userdto.UserWithUserGroups.Add(usergroupDto);
            
            #endregion

            #region DesignationDto
            DesignationDto designDto = new DesignationDto
            {
                DesignationId = 2
            };
            userdto.UserDesignation = designDto;
            #endregion


            #region userprofileDto
                       
                userdto.UserProfile.Gender = "Female";
                userdto.UserProfile.BloodGroup = "A+";
                userdto.UserProfile.UserAddress.AddressLine1 = "NIBM";
                userdto.UserProfile.UserAddress.CityVillage.CityVillageId = 2;
            #endregion

            this.UserInstance = this.UserService.Update(userdto, CurrentUserInstance.UserName);

            Assert.IsTrue(this.UserInstance.Name==userdto.Name, "user Updated");

        }

        [TestMethod]
        public virtual void CreateUserWithIncompleteDetails()
        {
            var dto = new UserDto
            {
                Name = "Sujata",
                UserName = "SujataPant",
                MobileNo = "9890969234",
                Email = "sujatapant@ack.com",
                CountryCode = "091",
                MothersMaidenName = "",
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

            this.UserInstance = this.UserService.Create(dto, CurrentUserInstance.UserName);
            Assert.IsFalse(this.UserInstance.UserId == 0, "User Id should have been updated");
            Assert.AreEqual(this.UserInstance.Name, dto.Name,"Actual and Saved names are different");
            Assert.IsTrue(this.UserInstance.Response.BusinessWarnings.Count() == 1, "One warning was only expected");
            Assert.AreEqual(this.UserInstance.Response.BusinessWarnings.Single().Message, "A user must have a valid mothers maiden name.");
            Assert.AreEqual(this.UserInstance.Response.BusinessWarnings.Single().ExceptionType.ToString(), Common.Message.BusinessExceptionEnum.Validation.ToString());
        }

        [TestMethod]
        public virtual void UpdateUser()
        {
            this.CreateUser();
            var id = this.UserInstance.UserId;

            UserInstance.Name="Himali";
            UserInstance.MothersMaidenName = "Padma";
            UserInstance.MobileNo = "9158006159";

            this.UserInstance = this.UserService.Update(UserInstance, CurrentUserInstance.UserName);
            Assert.IsTrue(this.UserInstance.UserId == id, "User Id should have remained the same");
            Assert.AreEqual(this.UserInstance.MobileNo, "9158006159", "Incorrect telephone after the update");
        }

        [TestMethod]
        public virtual void FindAll()
        {
            CreateUser();
            var result = this.UserService.FindAll();
            Assert.IsTrue(result.Entities.Count != 0, "One User instance was expected");
        }

        [TestMethod]
        public virtual void CheckLogin()
        {
            CreateUser();
            var username = "SuperAdmin";
            var password = "fsdagsdfgsd";
            var result = UserService.Login(username, password);
            Assert.IsTrue(result.Response.HasWarning, "User not found");

        }

        [TestMethod]
        public virtual void CheckLoginForValidUser()
        {
            var username = "SuperAdmin";
            var password = "AckSup@123";
            var result = UserService.Login(username, password);
            Assert.IsFalse(result.Response.HasWarning, "User Is Valid");
            Assert.AreEqual(username , result.UserName, "Username Found");
            password = "acksup@123";
            result = UserService.Login(username, password);
            Assert.IsTrue(result.Response.HasWarning, "User not found");
        }

        [TestMethod]
        public virtual void CheckGetAllNotification()
        {
            var result = this.UserService.FindAll();
            Assert.IsTrue(result.Entities.Count == 0, "No Users were expected");
            Assert.IsTrue(result.Response.HasWarning, "Warning flag is not set");
            Assert.IsTrue(result.Response.BusinessWarnings.Count() == 1, "One warning was only expected");
            Assert.AreEqual(result.Response.BusinessWarnings.Single().Message, "No Users were found");
            this.CreateUser();
            result = this.UserService.FindAll();
            Assert.IsFalse(result.Response.HasWarning, "Warning flag is set");
        }

        [TestMethod]
        public virtual void TestFindBy()
        {
            string userGroupIdList = "1;2";
            string[] ugIdList = userGroupIdList.Split(';');

            //Default Criteria
            //int startPage = 0;
            Query query = new Query();
            Criterion criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            query.Add(criteriaCAId);

            Query subquery = null;;
            //Add Filter criteria on selected UserGroups
            Criterion criteriaUserGroup = null;
            foreach (string ugId in ugIdList)
            {
                int userGroupId = Convert.ToInt32(ugId);
                if (userGroupId == 0)
                    break;
                else
                {
                    criteriaUserGroup = new Criterion("ug.UserGroupId", userGroupId, CriteriaOperator.Equal);
                    if(subquery==null) 
                        subquery=new Query();
                    subquery.Add(criteriaUserGroup);
                    subquery.QueryOperator = QueryOperator.Or;
                }
            }
            if (subquery != null)
            {
                query.AddSubQuery(subquery);
                query.QueryOperator = QueryOperator.And;
            }
            var result = this.UserService.FindBy(query,0,100,false);

            Assert.IsTrue(result.Entities.Count == 1, "One User was expected");
        }

        [TestMethod]
        public virtual void AddRole()
        {
            //CreateUser();
        }

        [TestMethod]
        public virtual void GetUserById()
        {
            //CreateUser();
            var id = 1;
            var result = UserService.GetById(id);
            Assert.AreEqual(id, result.UserId, "User was found");
            //Assert.AreEqual("SuperAdmin", result.MothersMaidenName, "Mothers Maiden Name");
            //Assert.AreEqual("SuperAdmin", result.Name, "SuperAdmin");  
        }
    }
}