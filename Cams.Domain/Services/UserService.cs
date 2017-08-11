using System;
using System.ServiceModel;
using Cams.Common;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using Cams.Domain.AppServices;
using Cams.Common.Message;
using Cams.Domain.Entities;
using AutoMapper;
using Cams.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using Cams.Common.Querying;
using Cams.Common.Logging;
using System.Text;
using System.IO;
using Cams.Common.Dto.Address;
using Cams.Domain.Entities.Masters;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class UserService : ServiceBase<User, UserDto>, IUserService
    {
        public UserService()
        {
            AllowSaveWithWarnings = false;
            base.IsValidForBasicMandatoryFields = true;
            base.PopulateChildObjects = false;
            PopulateRolePermissions = false;
        }

        #region IUserService Members
        //private bool _populateChildObjects = true;
        //public bool PopulateChildObjects { get { return _populateChildObjects; } set { _populateChildObjects = value; } }
        private bool PopulateRolePermissions { get; set; }
        #endregion

        #region Override the base abstract methods

        protected override void CheckForValidations(User user)
        {
            //set PopulateChildObjects to false as child objects are not required on created and updated object
            base.PopulateChildObjects = false;

            user.GetBrokenRules();
            base.IsValid = user.IsValid;
            base.IsValidForBasicMandatoryFields = user.IsValidForBasicMandatoryFields;

            foreach (BusinessRule rule in user.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            int age = (DateTime.Today.Year - user.DateOfBirth.Year);
            if ((!User.IsCAIdNotNull(user) && age < Constants.ACKUSERAGELIMIT) || (User.IsCAIdNotNull(user) && age < Constants.CAUSERAGELIMIT))
            {
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "InValidUserAge");
            }
            //check if user with the same name exists
            Query query = new Query();
            query.Add(new Criterion(Constants.TBLFLDUSERNAME, user.Username, CriteriaOperator.Equal));
            var result = ExecuteCommand(loc => loc.GetRepository<User>().FindBy(query));
            if (result.Count() != 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User with Username '" + user.Username + "' already exist");
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }

            //check if user with the same mobile no exists
            query = new Query();
            query.Add(new Criterion(Constants.TBLFLDMOBILENO, user.MobileNo, CriteriaOperator.Equal));
            result = ExecuteCommand(loc => loc.GetRepository<User>().FindBy(query));
            if (result.Count() != 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User with Mobile No '" + user.MobileNo + "' already exist");
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }

            //check if user with the same email exists
            query = new Query();
            query.Add(new Criterion(Constants.TBLFLDEMAIL, user.Email, CriteriaOperator.Equal));
            result = ExecuteCommand(loc => loc.GetRepository<User>().FindBy(query));
            if (result.Count() != 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User with Email '" + user.Email + "' already exist");
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }

            //user should have atleast one usergroup
            if (user.UserWithUserGroups.Count == 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User should belong to atleast one user group.'");
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }


        }

        protected override void CheckForValidationsWhileUpdating(User user)
        {
            user.GetBrokenRules();
            base.IsValid = user.IsValid;
            base.IsValidForBasicMandatoryFields = user.IsValidForBasicMandatoryFields;

            if (user.IsOnLine != true)
            {
                foreach (BusinessRule rule in user.GetBrokenRules())
                    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

                int age = (DateTime.Today.Year - user.DateOfBirth.Year);
                if ((!User.IsCAIdNotNull(user) && age < Constants.ACKUSERAGELIMIT) || (User.IsCAIdNotNull(user) && age < Constants.CAUSERAGELIMIT))
                {
                    base.IsValid = false;
                    base.IsValidForBasicMandatoryFields = false;
                    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "InValidUserAge");
                }

                Query query = new Query();
                query = new Query();
                query.Add(new Criterion(Constants.TBLFLDMOBILENO, user.MobileNo, CriteriaOperator.Equal));
                query.Add(new Criterion(Constants.TBLFLDUSERNAME, user.Username, CriteriaOperator.NotEqual));
                var result = ExecuteCommand(loc => loc.GetRepository<User>().FindBy(query));
                if (result.Count() != 0)
                {
                    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User with Mobile No '" + user.MobileNo + "' already exist");
                    base.IsValid = false;
                    base.IsValidForBasicMandatoryFields = false;
                }

                //check is user with the same mobile no exists
                query = new Query();
                query.Add(new Criterion(Constants.TBLFLDEMAIL, user.Email, CriteriaOperator.Equal));
                query.Add(new Criterion(Constants.TBLFLDUSERNAME, user.Username, CriteriaOperator.NotEqual));
                result = ExecuteCommand(loc => loc.GetRepository<User>().FindBy(query));
                if (result.Count() != 0)
                {
                    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User with Email '" + user.Email + "' already exist");
                    base.IsValid = false;
                    base.IsValidForBasicMandatoryFields = false;
                }

                //user should have atleast one usergroup
                if (user.UserWithUserGroups.Count == 0)
                {
                    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User should belong to atleast one user group.'");
                    base.IsValid = false;
                    base.IsValidForBasicMandatoryFields = false;
                }

            }
        }

        public override UserDto EntityToEntityDto(User entity)
        {
            UserDto userDto = Mapper.Map<User, UserDto>(entity);
            userDto.UserOfClient = Mapper.Map<Client, ClientDto>(entity.UserOfClient);
            if (entity != null)
            {
                #region MapUserGroup
                userDto.UserWithUserGroups.Clear();
                if (entity.UserWithUserGroups != null)
                {
                    foreach (UserGroup userGroup in entity.UserWithUserGroups)
                        userDto.UserWithUserGroups.Add(Mapper.Map<UserGroup, UserGroupDto>(userGroup));
                }
                #endregion

                #region MapUserRolePermission
                userDto.UserWithRolePermissions.Clear();
                if (entity.UserWithRolePermissions != null)
                {
                    foreach (UserRolePermission userrolepermission in entity.UserWithRolePermissions)
                    {
                        UserRolePermissionDto urPDto = new UserRolePermissionDto();
                        urPDto = Mapper.Map<UserRolePermission, UserRolePermissionDto>(userrolepermission);
                        urPDto.PermissionForRole = Mapper.Map<Role, RoleDto>(userrolepermission.PermissionForRole);
                        userDto.UserWithRolePermissions.Add(urPDto);
                    }
                }
                #endregion

                #region MapUserProfile
                if (entity.UserProfile != null)
                {
                    userDto.UserProfile = Mapper.Map<UserProfile, UserProfileDto>(entity.UserProfile);
                    #region MapUser Address
                    if (entity.UserProfile.UserAddress != null)
                    {
                        userDto.UserProfile.UserAddress = Mapper.Map<Address, AddressDto>(entity.UserProfile.UserAddress);
                        if (entity.UserProfile.UserAddress.CityVillage != null)
                        {
                            userDto.UserProfile.UserAddress.CityVillage = Mapper.Map<CityVillage, CityVillageDto>(entity.UserProfile.UserAddress.CityVillage);
                            if (entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage != null)
                            {
                                userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<District, DistrictDto>(entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage);
                                if (entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                                {
                                    userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict =
                                        Mapper.Map<State, StateDto>(entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                                    if (entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                                        userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                                            Mapper.Map<Country, CountryDto>(entity.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                                }
                            }
                        }
                    }
                    #endregion

                    #region MapUser ContactDetails
                    userDto.UserProfile.ContactNos.Clear();
                    if (entity.UserProfile.ContactNos != null)
                    {
                        foreach (ContactDetails usercontactdetails in entity.UserProfile.ContactNos)
                        {
                            ContactDetailsDto contactdto = new ContactDetailsDto();
                            contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(usercontactdetails);
                            //contactdto.CountryCode = Mapper.Map<Country, CountryDto>(usercontactdetails.CountryCode);
                            //contactdto.ContactDetailsOfUser = Mapper.Map<IEnumerable<UserProfile>, List<UserProfileDto>>(usercontactdetails.ContactDetailsOfUser);
                            //contactdto.ContactDetailsOfEmergencyContact = Mapper.Map<UserEmergencyContactPerson, UserEmergencyContactPersonDto>(usercontactdetails.ContactDetailsOfEmergencyContact);
                            userDto.UserProfile.ContactNos.Add(contactdto);
                        }
                    }
                    #endregion

                    #region MapUserEmergencyContactPerson
                    if (entity.UserProfile.UserEmergencyContactPerson != null)
                    {
                        userDto.UserProfile.UserEmergencyContactPerson =
                            Mapper.Map<UserEmergencyContactPerson, UserEmergencyContactPersonDto>(entity.UserProfile.UserEmergencyContactPerson);

                        #region MapEmergencyContactPerson Address
                        if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress != null)
                        {
                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress =
                                Mapper.Map<Address, AddressDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress);
                            if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage != null)
                            {
                                userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage =
                                    Mapper.Map<CityVillage, CityVillageDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage);
                                if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage != null)
                                {
                                    userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage =
                                        Mapper.Map<District, DistrictDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage);
                                    if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                                    {
                                        userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict =
                                            Mapper.Map<State, StateDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                                        if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                                        {
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                                                Mapper.Map<Country, CountryDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region MapEmergencyContactPerson Relationship With User
                        if (entity.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser != null)
                        {
                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser =
                                Mapper.Map<Relationship, RelationshipDto>(entity.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser);
                        }
                        #endregion

                        #region MapEmergencyContactPerson ContactDetails
                        userDto.UserProfile.UserEmergencyContactPerson.Contacts.Clear();
                        if (entity.UserProfile.UserEmergencyContactPerson.Contacts != null)
                        {
                            foreach (ContactDetails ECPdetails in entity.UserProfile.UserEmergencyContactPerson.Contacts)
                            {
                                ContactDetailsDto ECPdto = new ContactDetailsDto();
                                ECPdto = Mapper.Map<ContactDetails, ContactDetailsDto>(ECPdetails);
                                //ECPdto.CountryCode = Mapper.Map<Country, CountryDto>(ECPdetails.CountryCode);
                                //ECPdto.ContactDetailsOfUser = Mapper.Map<IEnumerable<UserProfile>, List<UserProfileDto>>(ECPdetails.ContactDetailsOfUser);
                                //ECPdto.ContactDetailsOfEmergencyContact = Mapper.Map<UserEmergencyContactPerson, UserEmergencyContactPersonDto>(ECPdetails.ContactDetailsOfEmergencyContact);
                                userDto.UserProfile.UserEmergencyContactPerson.Contacts.Add(ECPdto);
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region MapUserDesignation
                userDto.UserDesignation = Mapper.Map<Designation, DesignationDto>(entity.UserDesignation);
                #endregion
                if (PopulateChildObjects || PopulateRolePermissions)
                {
                    #region MapviewUserUserGroupRolePermissionsMap
                    userDto.ViewOfUserUserGroupRolePermissions.Clear();
                    if (entity.ViewOfUserUserGroupRolePermissions != null)
                    {
                        foreach (viewUserUserGroupRolePermissions viewUserUG in entity.ViewOfUserUserGroupRolePermissions)
                        {
                            viewUserUserGroupRolePermissionsDto viewUserUGDto = new viewUserUserGroupRolePermissionsDto();
                            viewUserUGDto = Mapper.Map<viewUserUserGroupRolePermissions, viewUserUserGroupRolePermissionsDto>(viewUserUG);
                            viewUserUGDto.RolePermissionsOfUser = Mapper.Map<User, UserDto>(viewUserUG.RolePermissionsOfUser);
                            viewUserUGDto.PermissionForRole = Mapper.Map<Role, RoleDto>(viewUserUG.PermissionForRole);
                            userDto.ViewOfUserUserGroupRolePermissions.Add(viewUserUGDto);
                        }
                    }
                    #endregion
                }
                if (PopulateChildObjects)
                {
                    //#region MapviewUserUserGroupRolePermissionsMap
                    //userDto.ViewOfUserUserGroupRolePermissions.Clear();
                    //if (entity.ViewOfUserUserGroupRolePermissions != null)
                    //{
                    //    foreach (viewUserUserGroupRolePermissions viewUserUG in entity.ViewOfUserUserGroupRolePermissions)
                    //    {
                    //        viewUserUserGroupRolePermissionsDto viewUserUGDto = new viewUserUserGroupRolePermissionsDto();
                    //        viewUserUGDto = Mapper.Map<viewUserUserGroupRolePermissions, viewUserUserGroupRolePermissionsDto>(viewUserUG);
                    //        viewUserUGDto.RolePermissionsOfUser = Mapper.Map<User, UserDto>(viewUserUG.RolePermissionsOfUser);
                    //        viewUserUGDto.PermissionForRole = Mapper.Map<Role, RoleDto>(viewUserUG.PermissionForRole);
                    //        userDto.ViewOfUserUserGroupRolePermissions.Add(viewUserUGDto);
                    //    }
                    //}
                    //#endregion

                    #region MapUserOfClient
                    //ClientService clientService = new ClientService();
                    //userDto.UserOfClient = clientService.EntityToEntityDto(entity.UserOfClient);

                    ClientService clientService = new ClientService();
                    if (entity.CAId != null && entity.CAId != 0)
                    {
                        userDto.UserOfClient = new ClientDto();
                        clientService.PopulateChildObjects = false;
                        userDto.UserOfClient = clientService.GetById(Convert.ToInt32(entity.CAId));
                    }
                    else
                        userDto.UserOfClient = clientService.EntityToEntityDto(entity.UserOfClient);
                    #endregion

                    #region AccountManagerOfClients
                    //userDto.AccountManagerOfClients.Clear();
                    //if (entity.AccountManagerOfClients != null)
                    //{
                    //    foreach (Client client in entity.AccountManagerOfClients)
                    //    {
                    //        ClientDto clientDto = clientService.EntityToEntityDto(client);
                    //        userDto.AccountManagerOfClients.Add(clientDto);
                    //    }
                    //}
                    #endregion
                }
            }
            return userDto;
        }

        public override User EntityDtoToEntity(UserDto entityDto)
        {
            User user = Mapper.Map<UserDto, User>(entityDto);
            if (entityDto != null)
            {

                #region MapUserGroup
                user.UserWithUserGroups.Clear();
                foreach (UserGroupDto userGroupDto in entityDto.UserWithUserGroups)
                {
                    if (userGroupDto.UserGroupId != 0)
                    {
                        UserGroupService ugService = new UserGroupService();
                        UserGroupDto ugDto = ugService.GetById(userGroupDto.UserGroupId);
                        user.UserWithUserGroups.Add(Mapper.Map<UserGroupDto, UserGroup>(ugDto));
                    }
                    else
                        user.UserWithUserGroups.Add(Mapper.Map<UserGroupDto, UserGroup>(userGroupDto));
                }
                #endregion

                #region MapUserRolePermission
                user.UserWithRolePermissions.Clear();
                UserDto userDB = null;
                if (entityDto.UserId != 0)
                {
                    PopulateChildObjects = false;
                    PopulateRolePermissions = true;
                    userDB = GetById(entityDto.UserId);
                }
                foreach (UserRolePermissionDto userRolePermissionDto in entityDto.UserWithRolePermissions)
                {
                    UserRolePermission urP = new UserRolePermission();
                    urP = Mapper.Map<UserRolePermissionDto, UserRolePermission>(userRolePermissionDto);
                    if (userRolePermissionDto.PermissionForRole != null)
                    {
                        if (userRolePermissionDto.PermissionForRole.RoleId != 0)
                        {
                            RoleService roleservice = new RoleService();
                            RoleDto roleDto = roleservice.GetById(userRolePermissionDto.PermissionForRole.RoleId);
                            urP.PermissionForRole = Mapper.Map<RoleDto, Role>(roleDto);
                            urP.UserRolePermissionId = 0;
                            if (entityDto.UserId != 0)
                            {
                                var userlist = userDB.UserWithRolePermissions.Where(x => x.PermissionForRole.RoleId == roleDto.RoleId);
                                if (userlist.Count() != 0)
                                {
                                    urP.UserRolePermissionId = userlist.First().UserRolePermissionId;
                                }
                            }
                        }
                    }

                    user.UserWithRolePermissions.Add(urP);
                }
                #endregion

                #region MapUserProfile
                if (entityDto.UserProfile != null)
                {
                    user.UserProfile = Mapper.Map<UserProfileDto, UserProfile>(entityDto.UserProfile);
                    #region MapUser Address
                    if (entityDto.UserProfile.UserAddress != null)
                    {
                        user.UserProfile.UserAddress = Mapper.Map<AddressDto, Address>(entityDto.UserProfile.UserAddress);
                        if (entityDto.UserProfile.UserAddress.CityVillage != null)
                        {
                            if (entityDto.UserProfile.UserAddress.CityVillage.CityVillageId != 0)
                            {
                                CityVillageService cityvillageService = new CityVillageService();
                                CityVillageDto cityvillageDto = cityvillageService.GetById(entityDto.UserProfile.UserAddress.CityVillage.CityVillageId);
                                //Query query = new Query();
                                //Criterion cr = new Criterion("CityVillageId", entityDto.UserProfile.UserAddress.CityVillage.CityVillageId, CriteriaOperator.Equal);
                                ////Alias alias = new Alias("dr", "DistrictOfCityVillage");
                                //query.Add(cr);
                                ////query.Alias = alias;
                                //var result = cityvillageService.FindByQuery(query);
                                //CityVillageDto cityvillageDto = result.Entities.FirstOrDefault<CityVillageDto>();
                                user.UserProfile.UserAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
                                ////user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(cityvillageDto.DistrictOfCityVillage);

                            }
                            else
                            {
                                user.UserProfile.UserAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto.UserProfile.UserAddress.CityVillage);
                            }
                            #region unnecessary code
                            //if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage != null)
                            //{
                            //    if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.DistrictId != 0)
                            //    {
                            //        DistrictService districtservice = new DistrictService();
                            //        //DistrictDto districtDto = districtservice.GetById(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.DistrictId);
                            //        Query query = new Query();
                            //        Criterion crid = new Criterion("DistrictId",entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.DistrictId,CriteriaOperator.Equal);
                            //        query.Add(crid);
                            //        var result = districtservice.FindByQuery(query);
                            //        DistrictDto districtDto = result.Entities.FirstOrDefault<DistrictDto>();
                            //        user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(districtDto);
                            //    }
                            //    else
                            //    {
                            //        user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage);
                            //    }
                            //    if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                            //    {
                            //        if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId != 0)
                            //        {
                            //            StateService stateservice = new StateService();
                            //            //StateDto stateDto = stateservice.GetById(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId);
                            //            Query query = new Query();
                            //            Criterion crstateid = new Criterion("StateId",entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId,CriteriaOperator.Equal);
                            //            query.Add(crstateid);
                            //            var result = stateservice.FindByQuery(query);
                            //            StateDto stateDto = result.Entities.FirstOrDefault<StateDto>();
                            //            user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<StateDto, State>(stateDto);
                            //        }
                            //        else
                            //        {
                            //            user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict =
                            //                Mapper.Map<StateDto, State>(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                            //        }
                            //        if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                            //        {
                            //            if (entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId != 0)
                            //            {
                            //                CountryMasterService countryservice = new CountryMasterService();
                            //                //CountryDto countryDto = countryservice.GetById(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId);
                            //                Query query = new Query();
                            //                Criterion crcountryid = new Criterion("CountryId", entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId, CriteriaOperator.Equal);
                            //                query.Add(crcountryid);
                            //                var result = countryservice.FindByQuery(query);
                            //                CountryDto countryDto = result.Entities.FirstOrDefault<CountryDto>();
                            //                user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry = Mapper.Map<CountryDto, Country>(countryDto);
                            //            }
                            //            else
                            //            {
                            //                user.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                            //                    Mapper.Map<CountryDto, Country>(entityDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                            //            }
                            //        }
                            //    }
                            //}
                            #endregion
                        }
                    }
                    #endregion

                    #region MapUser ContactDetails
                    user.UserProfile.ContactNos.Clear();
                    if (entityDto.UserProfile.ContactNos != null)
                    {
                        foreach (ContactDetailsDto contactdetailsdto in entityDto.UserProfile.ContactNos)
                        {
                            ContactDetails usercontactdetails = new Entities.ContactDetails();
                            usercontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                            //usercontactdetails.CountryCode = Mapper.Map<CountryDto, Country>(contactdetailsdto.CountryCode);
                            //usercontactdetails.ContactDetailsOfUser = Mapper.Map<IEnumerable<UserProfileDto>, List<UserProfile>>(contactdetailsdto.ContactDetailsOfUser);
                            //usercontactdetails.ContactDetailsOfEmergencyContact = Mapper.Map<UserEmergencyContactPersonDto, UserEmergencyContactPerson>(contactdetailsdto.ContactDetailsOfEmergencyContact);
                            user.UserProfile.ContactNos.Add(usercontactdetails);
                        }
                    }
                    #endregion

                    #region MapUserEmergencyContactPerson
                    if (entityDto.UserProfile.UserEmergencyContactPerson != null)
                    {
                        user.UserProfile.UserEmergencyContactPerson =
                            Mapper.Map<UserEmergencyContactPersonDto, UserEmergencyContactPerson>(entityDto.UserProfile.UserEmergencyContactPerson);

                        #region MapEmergencyContactPerson Address
                        if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress != null)
                        {
                            user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress =
                                Mapper.Map<AddressDto, Address>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress);
                            if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage != null)
                            {
                                if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId != 0)
                                {
                                    CityVillageService cvService = new CityVillageService();
                                    CityVillageDto cvDto = cvService.GetById(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId);
                                    //Query query = new Query();
                                    //Criterion cr = new Criterion("CityVillageId", entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId, CriteriaOperator.Equal);
                                    //query.Add(cr);
                                    //var result = cvService.FindByQuery(query);
                                    //CityVillageDto cvDto = result.Entities.FirstOrDefault<CityVillageDto>();
                                    user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cvDto);
                                }
                                else
                                {
                                    user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage =
                                        Mapper.Map<CityVillageDto, CityVillage>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage);
                                }
                                #region unnecessary code
                                //if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage != null)
                                //{
                                //    if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId != 0)
                                //    {
                                //        DistrictService districtService = new DistrictService();
                                //        //DistrictDto districtDto = districtService.GetById(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId);
                                //        Query query = new Query();
                                //        Criterion crid = new Criterion("DistrictId", entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId, CriteriaOperator.Equal);
                                //        query.Add(crid);
                                //        var result = districtService.FindByQuery(query);
                                //        DistrictDto districtDto = result.Entities.FirstOrDefault<DistrictDto>();
                                //        user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(districtDto);
                                //    }
                                //    else
                                //    {
                                //        user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage =
                                //            Mapper.Map<DistrictDto, District>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage);
                                //    }
                                //    if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                                //    {
                                //        if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId != 0)
                                //        {
                                //            StateService stateService = new StateService();
                                //            //StateDto stateDto = stateService.GetById(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId);
                                //            Query query = new Query();
                                //            Criterion crstateid = new Criterion("StateId", entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId, CriteriaOperator.Equal);
                                //            query.Add(crstateid);
                                //            var result = stateService.FindByQuery(query);
                                //            StateDto stateDto = result.Entities.FirstOrDefault<StateDto>();
                                //            user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<StateDto, State>(stateDto);
                                //        }
                                //        else
                                //        {
                                //            user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict =
                                //                Mapper.Map<StateDto, State>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                                //        }
                                //        if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                                //        {
                                //            if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId != 0)
                                //            {
                                //                CountryMasterService countryService = new CountryMasterService();
                                //                //CountryDto countryDto = countryService.GetById(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId);
                                //                Query query = new Query();
                                //                Criterion crcountryid = new Criterion("CountryId", entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryId, CriteriaOperator.Equal);
                                //                query.Add(crcountryid);
                                //                var result = countryService.FindByQuery(query);
                                //                CountryDto countryDto = result.Entities.FirstOrDefault<CountryDto>();
                                //                user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry = Mapper.Map<CountryDto, Country>(countryDto);
                                //            }
                                //            else
                                //            {
                                //                user.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                                //                    Mapper.Map<CountryDto, Country>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                                //            }
                                //        }
                                //    }
                                //}
                                #endregion
                            }
                        }
                        #endregion

                        #region MapEmergencyContactPerson Relationship With User
                        if (entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser != null &&
                            entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser.RelationshipId != 0)
                        {
                            RelationshipService relationshipService = new RelationshipService();
                            RelationshipDto relationshipDto = relationshipService.GetById(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser.RelationshipId);
                            user.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser = Mapper.Map<RelationshipDto, Relationship>(relationshipDto);
                        }
                        else
                            user.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser =
                                Mapper.Map<RelationshipDto, Relationship>(entityDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser);
                        #endregion

                        #region MapEmergencyContactPerson ContactDetails
                        user.UserProfile.UserEmergencyContactPerson.Contacts.Clear();
                        if (entityDto.UserProfile.UserEmergencyContactPerson.Contacts != null)
                        {
                            foreach (ContactDetailsDto ECPcontactdto in entityDto.UserProfile.UserEmergencyContactPerson.Contacts)
                            {
                                ContactDetails ECPcontact = new Entities.ContactDetails();
                                ECPcontact = Mapper.Map<ContactDetailsDto, ContactDetails>(ECPcontactdto);
                                //ECPcontact.CountryCode = Mapper.Map<CountryDto, Country>(ECPcontactdto.CountryCode);
                                //ECPcontact.ContactDetailsOfUser = Mapper.Map<IEnumerable<UserProfileDto>, List<UserProfile>>(ECPcontactdto.ContactDetailsOfUser);
                                //ECPcontact.ContactDetailsOfEmergencyContact = Mapper.Map<UserEmergencyContactPersonDto, UserEmergencyContactPerson>(ECPcontactdto.ContactDetailsOfEmergencyContact);
                                user.UserProfile.UserEmergencyContactPerson.Contacts.Add(ECPcontact);
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion

                #region MapUserDesignation
                if (entityDto.UserDesignation != null && entityDto.UserDesignation.DesignationId != 0)
                {
                    DesignationService designationService = new DesignationService();
                    DesignationDto designationDto = designationService.GetById(entityDto.UserDesignation.DesignationId);
                    user.UserDesignation = Mapper.Map<DesignationDto, Designation>(designationDto);
                }
                else
                    user.UserDesignation = Mapper.Map<DesignationDto, Designation>(entityDto.UserDesignation);

                #endregion

                #region MapviewUserUserGroupRolePermissionsMap
                if (entityDto.ViewOfUserUserGroupRolePermissions != null && entityDto.UserId != 0)
                {
                    foreach (viewUserUserGroupRolePermissionsDto vw in entityDto.ViewOfUserUserGroupRolePermissions)
                        vw.RolePermissionsOfUser.UserId = entityDto.UserId;
                }
                #endregion

                #region MapUserOfClient
                //This section is not required as mapping changed to CAID 
                //ClientService clientService = new ClientService();                
                //if (entityDto.UserOfClient != null && entityDto.UserOfClient.CAId != 0)
                //{
                //    user.UserOfClient = new Client();
                //    ClientDto clientDto = clientService.GetById(entityDto.UserOfClient.CAId);
                //    user.UserOfClient = clientService.EntityDtoToEntity(clientDto);
                //}
                //else
                //    user.UserOfClient = clientService.EntityDtoToEntity(entityDto.UserOfClient);

                #endregion

                #region AccountManagerOfClients
                
                //user.AccountManagerOfClients.Clear();
                //if(entityDto.AccountManagerOfClients != null)
                //{
                //    foreach (ClientDto clientDto in entityDto.AccountManagerOfClients)
                //    {
                //        ClientService clientService = new ClientService();
                //        if(clientDto.CAId != 0)
                //        {
                //            ClientDto clientdto = clientService.GetById(clientDto.CAId);
                //            user.AccountManagerOfClients.Add(clientService.EntityDtoToEntity(clientdto));
                //        }
                //        else
                //            user.AccountManagerOfClients.Add(clientService.EntityDtoToEntity(clientDto));
                //        clientService = null;
                //    }
                //}
                #endregion
            }

            return user;
        }

        protected override string GetEntityInstanceName(User entity)
        {
            return entity.Username;
        }

        public EntityDtos<UserDto> FindByQuery(Query query, bool populateChildObjects)
        {
            base.PopulateChildObjects = populateChildObjects;
            return base.FindByQuery(query);
        }

        public EntityDtos<UserDto> FindBy(Query query, int pageIndex, int recordsPerPage, bool populateChildObjects)
        {
            base.PopulateChildObjects = populateChildObjects;
            return base.FindBy(query, pageIndex, recordsPerPage);
        }

        public override UserDto UpdateCommand(Repository.IRepositoryLocator locator, UserDto entityDto, string userName)
        {
            UserDto userDto = base.UpdateCommand(locator, entityDto, userName);

            if (entityDto.CAId != null && entityDto.CAId != 0 && userName.EndsWith(entityDto.CAId.ToString()))
            {
                ClientPrimaryContactPersonService cs = new ClientPrimaryContactPersonService();
                Query query = new Query();
                Criterion crPan = new Criterion("PAN", entityDto.UserProfile.PAN, CriteriaOperator.Equal);
                Criterion crName = new Criterion("CAPrimaryConatactPersonName", entityDto.Name, CriteriaOperator.Equal);
                query.Add(crPan);
                query.Add(crName);
                var res = cs.FindByQuery(query);
                if (res.TotalRecords>0)
                {
                    ClientPrimaryContactPersonDto cpDto = res.Entities.ToList().FirstOrDefault();
                    cpDto.DateOfBirth = entityDto.DateOfBirth;
                    cpDto.MobileNo = entityDto.MobileNo;
                    cpDto.MothersMaidenName = entityDto.MothersMaidenName;
                    cpDto.Email1 = entityDto.Email;
                    cpDto.ModifiedBy = entityDto.ModifiedBy;
                    cpDto.ModifiedDate = DateTime.Now;
                    cpDto.Gender = entityDto.UserProfile.Gender;
                    cpDto.UID = entityDto.UserProfile.UID;
                    cpDto.Email2 = entityDto.UserProfile.Email2;
                    cpDto.ModifiedBy = entityDto.UserProfile.ModifiedBy;
                    cpDto.ModifiedDate = DateTime.Now;
                    cpDto.ClientPrimaryContactPersonAddress = entityDto.UserProfile.UserAddress;
                    cpDto.ClientPrimaryContacts = entityDto.UserProfile.ContactNos;
                    cs.Update(cpDto, userName);
                }
            }
            return userDto;
        }
        #endregion

        #region Additional Services
        /// <summary>
        /// Method to check the username and password for valid user
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserDto Login(string Username, string Password)
        {
            return ExecuteCommand(locator => LoginCommand(locator, Username, Password));
        }

        private UserDto LoginCommand(IRepositoryLocator locator, string Username, string Password)
        {
            UserDto userDto = GetByUserName(Username);

            //If username is invalid return with error message
            if (userDto == null)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "UserName is invalid");
                return null;
            }
            //If User is already logged in return with error message
            if (userDto.IsOnLine == true)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "You are already logged in");
                return userDto;                
            }
            
            // Calculate the locking time 
            // If user is locked for more then the desired time i.e the locking time is elapsed : unlock user
            double NoOfHrsAfterLastLoginFailed = DateTime.Now.Subtract(userDto.FailedPasswordAttemptWindowStart.Value).TotalHours;
            if (NoOfHrsAfterLastLoginFailed >= Constants.NOOFHOURSUSERLOCKEDOUT)
            {
                userDto.FailedPasswordAttemptCount = 0;
                userDto.IsLockedOut = false;
            }

            if(userDto.IsLockedOut)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "User Locked");
                return userDto; 
            }

            if (userDto.Password != Password.Trim())
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "Password is invalid");
                if (userDto.FailedPasswordAttemptWindowStart != null)
                {
                    userDto.FailedPasswordAttemptWindowStart = DateTime.Now;
                    userDto.FailedPasswordAttemptCount = userDto.FailedPasswordAttemptCount + 1;
                    if (userDto.FailedPasswordAttemptCount == Constants.FAILEDPASSWORDATTEMPTCOUNT)
                    {
                        userDto.IsLockedOut = true;
                    }
                }
                else
                {
                    userDto.FailedPasswordAttemptWindowStart = DateTime.Now;
                    userDto.FailedPasswordAttemptCount = 1;
                }
                var updatedUser = Update(userDto, null);
                return null;
            }
            else
            {
                //userDto.FailedPasswordAttemptWindowStart = DateTime.Now;
                userDto.FailedPasswordAttemptCount = 0;
                userDto.IsOnLine = true;
                userDto.LastLoginDate = DateTime.Now;            
            }
            var user = Update(userDto, userDto.UserName);
            return userDto;
        }

        public List<string> GetAvailableUsernameList(string FullName, string Username)
        {
            string TempUserName = string.Empty;
            List<string> AvailableUsernameList = new List<string> { };
            List<string> Name = new List<string> { };
            UserDto Userdto = null;
            DateTime CurrentDate = DateTime.Now;

            if (!String.IsNullOrEmpty(FullName))
            {
                //Try Full Name removing spaces
                TempUserName = FullName.Replace(" ", "");
                Userdto = GetByUserName(TempUserName);
                if (Userdto == null)
                    AvailableUsernameList.Add(TempUserName);

                //Try Reversing the Full Name
                Name = FullName.Split(' ').ToList();
                Name.Reverse();
                TempUserName = Name.Aggregate((i, j) => i + j);
                Userdto = GetByUserName(Username);
                if (Userdto == null)
                    AvailableUsernameList.Add(TempUserName);
            }

            //Try Conactenating Username with Date
            if (!String.IsNullOrEmpty(Username))
            {
                for (int index = 1; ; index++)
                {
                    if (AvailableUsernameList.Count < 3)
                    {
                        TempUserName = Username + CurrentDate.Day.ToString() + index.ToString();
                        Userdto = GetByUserName(TempUserName);
                        if (Userdto == null)
                            AvailableUsernameList.Add(TempUserName);
                    }
                    else
                        break;
                }
            }
            return AvailableUsernameList;
        }

        public UserDto GetByUserName(string Username)
        {
            LoggingFactory.LogInfo("Invoked GetByUserName for User");
            return ExecuteCommand(locator => GetByUsernameCommand(locator, Username));
        }

        private UserDto GetByUsernameCommand(IRepositoryLocator locator, string Username)
        {
            UserDto result = null;
            //Create criterion using Query object
            Query query = new Query();
            query.Add(new Criterion("Username", Username, CriteriaOperator.Equal));

            List<User> users = null;
            users = locator.GetRepository<User>().FindBy(query).ToList();
            PopulateChildObjects = true;
            if (users.Count != 0)
                result = EntityToEntityDto(users.FirstOrDefault());

            return result;
        }

        public EntityDtos<UserDto> GetAccountManagerList() 
        {
            Query query = new Query();
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            Criterion criteriaDesignation = new Criterion("designation.DesignationName", Constants.ACCOUNTMANAGER, CriteriaOperator.Equal);
            query.Add(criteriaCAIdNull);
            query.Add(criteriaDesignation);            
            query.AddAlias(new Alias("designation", "UserDesignation"));
            query.QueryOperator = QueryOperator.And;             
            var userList = base.FindByQuery(query);
            return userList;
        }
        #endregion
    }
}