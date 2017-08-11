using System.Collections.Generic;
using AutoMapper;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientMasters;
using System.Linq;
using Cams.Common.Dto.Log;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities.ClientMasters;
using Cams.Common.Dto.Address;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;
using Cams.Domain.Entities.Email;
using Cams.Common.Dto.Email;


namespace Cams.Domain.Entities
{
    public class AutoMapperConfigurator
    {
        public static void Install()
        {
            #region UserGroup
            Mapper.CreateMap<UserGroupDto, Users.UserGroup>()
                    .ForMember(x => x.RolePermissionsInUserGroup, opts => opts.Ignore())
                    .ForMember(x => x.UsersInUserGroup, opts => opts.Ignore());
            Mapper.CreateMap<Users.UserGroup, UserGroupDto>()
                    .ForMember(x => x.RolePermissionsInUserGroup, opts => opts.Ignore())
                    .ForMember(x => x.UsersInUserGroup, opts => opts.Ignore())
                    .ForMember(x => x.UsersInUserGroupCount, opt => opt.MapFrom(src => src.UsersInUserGroup.Count()))
                    .ForMember(x => x.RolesInUserGroupCount, opt => opt.MapFrom(src => src.RolePermissionsInUserGroup.Count()));
            #endregion

            #region ActivityLog
            Mapper.CreateMap<ActivityLogDto, ActivityLog>();
            Mapper.CreateMap<ActivityLog, ActivityLogDto>();
            #endregion

            #region Designation
            Mapper.CreateMap<DesignationDto, Designation>()
                .ForMember(x => x.UsersWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPrimaryContactPersonWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerBankContactPersonWithDesignation, opts => opts.Ignore());
            Mapper.CreateMap<Designation, DesignationDto>()
                .ForMember(x => x.UsersWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPrimaryContactPersonWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerWithDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerBankContactPersonWithDesignation, opts => opts.Ignore());
            #endregion

            #region UserRolePermission
            Mapper.CreateMap<UserRolePermissionDto, Users.UserRolePermission>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.PermissionForUser, opts => opts.Ignore());
            //.ForMember(dest => dest.PermissionForRole, opt => opt.MapFrom(src => src.PermissionForRole))
            //.ForMember(dest => dest.PermissionForUser, opt => opt.MapFrom(src => src.PermissionForUser));
            Mapper.CreateMap<Users.UserRolePermission, UserRolePermissionDto>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.PermissionForUser, opts => opts.Ignore());
            //.ForMember(dest => dest.PermissionForRole, opt => opt.MapFrom(src => src.PermissionForRole))
            //.ForMember(dest => dest.PermissionForUser, opt => opt.MapFrom(src => src.PermissionForUser));
            #endregion

            #region UserGroupRolePermission
            Mapper.CreateMap<UserGroupRolePermissionDto, Users.UserGroupRolePermission>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.PermissionForUserGroup, opts => opts.Ignore());
            Mapper.CreateMap<Users.UserGroupRolePermission, UserGroupRolePermissionDto>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.PermissionForUserGroup, opts => opts.Ignore());
            #endregion

            #region User

            Mapper.CreateMap<Users.User, UserDto>()
                .ForMember(x => x.UserWithRolePermissions, opts => opts.Ignore())
                .ForMember(x => x.UserWithUserGroups, opts => opts.Ignore())
                .ForMember(x => x.UserDesignation, opts => opts.Ignore())
                .ForMember(x => x.UserProfile, opts => opts.Ignore())
                .ForMember(x => x.ViewOfUserUserGroupRolePermissions, opts => opts.Ignore())
                .ForMember(x => x.UserRolesCount, opt => opt.MapFrom(src => src.UserWithRolePermissions.Count()))
                .ForMember(x => x.UserGroupsCount, opt => opt.MapFrom(src => src.UserWithUserGroups.Count()))
                .ForMember(x => x.UserOfClient, opts => opts.Ignore());
                    //.ForMember(x => x.ClientAccountManager, opts => opts.Ignore());
            //.ForMember(dest => dest.UserWithRolePermissions, opt => opt.MapFrom(src => src.UserWithRolePermissions))
            //.ForMember(dest => dest.UserWithUserGroups, opt => opt.MapFrom(src => src.UserWithUserGroups));
            Mapper.CreateMap<UserDto, Users.User>()
                .ForMember(x => x.UserWithRolePermissions, opts => opts.Ignore())
                .ForMember(x => x.UserWithUserGroups, opts => opts.Ignore())
                .ForMember(x => x.UserDesignation, opts => opts.Ignore())
                .ForMember(x => x.ViewOfUserUserGroupRolePermissions, opts => opts.Ignore())
                .ForMember(x => x.UserProfile, opts => opts.Ignore())
                .ForMember(x => x.UserOfClient, opts => opts.Ignore());
                    //.ForMember(x => x.ClientAccountManager, opts => opts.Ignore());
            //.ForMember(dest => dest.UserWithRolePermissions, opt => opt.MapFrom(src => src.UserWithRolePermissions))
            //.ForMember(dest => dest.UserWithUserGroups, opt => opt.MapFrom(src => src.UserWithUserGroups));
            #endregion

            #region viewUserUserGroupRolePermissions
            Mapper.CreateMap<Users.viewUserUserGroupRolePermissions, viewUserUserGroupRolePermissionsDto>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.RolePermissionsOfUser, opts => opts.Ignore());
            Mapper.CreateMap<viewUserUserGroupRolePermissionsDto, viewUserUserGroupRolePermissions>()
                    .ForMember(x => x.PermissionForRole, opts => opts.Ignore())
                    .ForMember(x => x.RolePermissionsOfUser, opts => opts.Ignore());
            #endregion 

            #region Role
            Mapper.CreateMap<Users.Role, RoleDto>()
                    .ForMember(x => x.RolesInUserGroupRolePermissions, opts => opts.Ignore())
                    .ForMember(x => x.RolesInUserRolePermissions, opts => opts.Ignore());
            Mapper.CreateMap<RoleDto, Users.Role>()
                    .ForMember(x => x.RolesInUserGroupRolePermissions, opts => opts.Ignore())
                    .ForMember(x => x.RolesInUserRolePermissions, opts => opts.Ignore());
            #endregion

            #region IList of UserRolePermission
            Mapper.CreateMap<IList<UserRolePermission>, IList<UserRolePermissionDto>>();
            #endregion

            #region Country
            Mapper.CreateMap<Country, CountryDto>()
                .ForMember(x => x.States, opts => opts.Ignore());
            Mapper.CreateMap<CountryDto, Country>()
                .ForMember(x => x.States, opts => opts.Ignore());
            #endregion

            #region State
            Mapper.CreateMap<State, StateDto>()
                .ForMember(x => x.DistrictsInState, opts => opts.Ignore())
                .ForMember(x => x.StateInCountry, opts => opts.Ignore());
            Mapper.CreateMap<StateDto, State>()
                .ForMember(x => x.DistrictsInState, opts => opts.Ignore())
                .ForMember(x => x.StateInCountry, opts => opts.Ignore());
            #endregion

            #region District
            Mapper.CreateMap<District, DistrictDto>()
                .ForMember(x => x.StateOfDistrict, opts => opts.Ignore())
                .ForMember(x => x.CitiesOrVillages, opts => opts.Ignore());
            Mapper.CreateMap<DistrictDto, District>()
                .ForMember(x => x.StateOfDistrict, opts => opts.Ignore())
                .ForMember(x => x.CitiesOrVillages, opts => opts.Ignore());
            #endregion

            #region CityVillage
            Mapper.CreateMap<CityVillage, CityVillageDto>()
                .ForMember(x => x.DistrictOfCityVillage, opts => opts.Ignore())
                .ForMember(x => x.Addresses, opts => opts.Ignore());
            Mapper.CreateMap<CityVillageDto, CityVillage>()
                .ForMember(x => x.DistrictOfCityVillage, opts => opts.Ignore())
                .ForMember(x => x.Addresses, opts => opts.Ignore());
            #endregion

            #region Zone
            Mapper.CreateMap<Zone, ZoneDto>();
            Mapper.CreateMap<ZoneDto, Zone>();
            #endregion

            #region UserProfile
            Mapper.CreateMap<UserProfile, UserProfileDto>()
                .ForMember(x => x.UserAddress, opts => opts.Ignore())
                .ForMember(x => x.UserEmergencyContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactNos, opts => opts.Ignore());
            Mapper.CreateMap<UserProfileDto, UserProfile>()
                .ForMember(x => x.UserAddress, opts => opts.Ignore())
                .ForMember(x => x.UserEmergencyContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactNos, opts => opts.Ignore());
            #endregion

            #region UserEmergencyContactPerson
            Mapper.CreateMap<UserEmergencyContactPerson, UserEmergencyContactPersonDto>()
                .ForMember(x => x.ContactPersonAddress, opts => opts.Ignore())
                .ForMember(x => x.ContactPersonRelationshipWithUser, opts => opts.Ignore())
                .ForMember(x => x.ContactPersonOfUser, opts => opts.Ignore());
            Mapper.CreateMap<UserEmergencyContactPersonDto, UserEmergencyContactPerson>()
                .ForMember(x => x.ContactPersonAddress, opts => opts.Ignore())
                .ForMember(x => x.ContactPersonOfUser, opts => opts.Ignore())
                .ForMember(x => x.ContactPersonRelationshipWithUser, opts => opts.Ignore());
            #endregion

            #region Relationship
            Mapper.CreateMap<Relationship, RelationshipDto>()
                .ForMember(x => x.EmergencyContactPersonRelationshipWithUser, opts => opts.Ignore())
                .ForMember(x => x.CPGuardianRelationshipWithClientPartner, opts => opts.Ignore())
                .ForMember(x => x.NomineeRelationshipWithClientPartner, opts => opts.Ignore());
            Mapper.CreateMap<RelationshipDto, Relationship>()
                .ForMember(x => x.EmergencyContactPersonRelationshipWithUser, opts => opts.Ignore())
                .ForMember(x => x.CPGuardianRelationshipWithClientPartner, opts => opts.Ignore())
                .ForMember(x => x.NomineeRelationshipWithClientPartner, opts => opts.Ignore());
            #endregion

            #region Address
            Mapper.CreateMap<Address, AddressDto>()
                .ForMember(x => x.CityVillage, opts => opts.Ignore())
                .ForMember(x => x.AddressOfUser, opts => opts.Ignore())
                .ForMember(x => x.AddressOfEmergencyContact, opts => opts.Ignore())
                .ForMember(x => x.AddressofBankBranch, opts => opts.Ignore())
                .ForMember(x => x.AddressofAPMC, opts => opts.Ignore());
            Mapper.CreateMap<AddressDto, Address>()
                .ForMember(x => x.CityVillage, opts => opts.Ignore())
                .ForMember(x => x.AddressOfUser, opts => opts.Ignore())
                .ForMember(x => x.AddressOfEmergencyContact, opts => opts.Ignore())
                .ForMember(x => x.AddressofBankBranch, opts => opts.Ignore())
                .ForMember(x => x.AddressofAPMC, opts => opts.Ignore());
            #endregion

            #region ContactDetails
            Mapper.CreateMap<ContactDetails, ContactDetailsDto>()
                .ForMember(x => x.ContactDetailsOfUser, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfEmergencyContact, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfBankBranch, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfAPMC, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClient, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPrimaryContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartners, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerGuardian, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerBankContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerNominee, opts => opts.Ignore());
            Mapper.CreateMap<ContactDetailsDto, ContactDetails>()
                .ForMember(x => x.ContactDetailsOfUser, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfEmergencyContact, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfBankBranch, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfAPMC, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClient, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPrimaryContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartners, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerGuardian, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerBankContactPerson, opts => opts.Ignore())
                .ForMember(x => x.ContactDetailsOfClientPartnerNominee, opts => opts.Ignore());
            #endregion

            #region BusinessConstitution
            Mapper.CreateMap<BusinessConstitution, BusinessConstitutionDto>()
                .ForMember(x => x.BusinessConstitutionOfClients, opts => opts.Ignore());
            Mapper.CreateMap<BusinessConstitutionDto, BusinessConstitution>()
                .ForMember(x => x.BusinessConstitutionOfClients, opts => opts.Ignore());
            #endregion

            #region Client
            Mapper.CreateMap<Client, ClientDto>()
                        .ForMember(x => x.DisplayClientId, opt => opt.MapFrom(src => Common.Helper.GetDisplayClientID(src.CAId, Common.Constants.DISPLAYCLIENTIDPREFIX, src.CreatedDate)))
                        .ForMember(x => x.ClientAddress, opts => opts.Ignore())
                        .ForMember(x => x.ClientAPMC, opts => opts.Ignore())
                        .ForMember(x => x.ClientBusinessConstitution, opts => opts.Ignore())
                        .ForMember(x => x.ClientPrimaryContactPerson, opts => opts.Ignore())
                        .ForMember(x => x.ClientContacts, opts => opts.Ignore())
                        .ForMember(x => x.ClientSubscription, opts => opts.Ignore())
                        .ForMember(x => x.AccountManager, opts => opts.Ignore())
                        .ForMember(x => x.ClientUsers, opts => opts.Ignore())
                        .ForMember(x => x.ClientCommodities, opts => opts.Ignore())
                        .ForMember(x => x.ClientPartners, opts => opts.Ignore())
                        .ForMember(x => x.ClientPhoneCharges, opts => opts.Ignore())
                        .ForMember(x => x.ClientSisterConcerns, opts => opts.Ignore())
                        .ForMember(x => x.ClientTaxationAndLicenses, opts => opts.Ignore());
            Mapper.CreateMap<ClientDto, Client>()
                        .ForMember(x => x.ClientAddress, opts => opts.Ignore())
                        .ForMember(x => x.ClientAPMC, opts => opts.Ignore())
                        .ForMember(x => x.ClientBusinessConstitution, opts => opts.Ignore())
                        .ForMember(x => x.ClientPrimaryContactPerson, opts => opts.Ignore())
                        .ForMember(x => x.ClientContacts, opts => opts.Ignore())
                        .ForMember(x => x.ClientSubscription, opts => opts.Ignore())
                        .ForMember(x => x.AccountManager, opts => opts.Ignore())
                        .ForMember(x => x.ClientUsers, opts => opts.Ignore())
                        .ForMember(x => x.ClientCommodities, opts => opts.Ignore())
                        .ForMember(x => x.ClientPartners, opts => opts.Ignore())
                        .ForMember(x => x.ClientPhoneCharges, opts => opts.Ignore())
                        .ForMember(x => x.ClientSisterConcerns, opts => opts.Ignore())
                        .ForMember(x => x.ClientTaxationAndLicenses, opts => opts.Ignore());

            #endregion

            #region ClientCommodity
            //Mapper.CreateMap<ClientCommodity, ClientCommodityDto>()
            //    .ForMember(x => x.Client, opts => opts.Ignore())
            //    .ForMember(x => x.CommodityClass, opts => opts.Ignore());
            //Mapper.CreateMap<ClientCommodityDto, ClientCommodity>()
            //    .ForMember(x => x.Client, opts => opts.Ignore())
            //    .ForMember(x => x.CommodityClass, opts => opts.Ignore());
            #endregion
            
            #region ClientPartnerDetails
            Mapper.CreateMap<ClientPartnerDetails, ClientPartnerDetailsDto>()
                .ForMember(x => x.ClientPartnerAddress, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartners, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerContacts, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerGuardian, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerBanks, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerNominee, opts => opts.Ignore());
            Mapper.CreateMap<ClientPartnerDetailsDto, ClientPartnerDetails>()
                .ForMember(x => x.ClientPartnerAddress, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerDesignation, opts => opts.Ignore())
                .ForMember(x => x.ClientPartners, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerContacts, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerGuardian, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerBanks, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerNominee, opts => opts.Ignore());
            #endregion

            #region ClientPartnerGuardianDetails 
            Mapper.CreateMap<ClientPartnerGuardianDetails, ClientPartnerGuardianDetailsDto>()
                .ForMember(x => x.ClientPartnerGuardianAddress, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerGuardianContacts, opts => opts.Ignore())
                .ForMember(x => x.GuardianofClientPartner, opts => opts.Ignore())
                .ForMember(x => x.GuardianRelationshipWithClientPartner, opts => opts.Ignore());
            Mapper.CreateMap<ClientPartnerGuardianDetailsDto, ClientPartnerGuardianDetails>()
                .ForMember(x => x.ClientPartnerGuardianAddress, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerGuardianContacts, opts => opts.Ignore())
                .ForMember(x => x.GuardianofClientPartner, opts => opts.Ignore())
                .ForMember(x => x.GuardianRelationshipWithClientPartner, opts => opts.Ignore());
            #endregion

            #region ClientPartnerBanks
            Mapper.CreateMap<ClientPartnerBankDetails,ClientPartnerBankDetailsDto>()
                .ForMember(x => x.BankDetailsOfClient, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientPartner, opts => opts.Ignore())
                .ForMember(x => x.BankContactPersonDesignation, opts => opts.Ignore())
                .ForMember(x => x.BankContactPersonContacts, opts => opts.Ignore());
                Mapper.CreateMap<ClientPartnerBankDetailsDto,ClientPartnerBankDetails>()
                .ForMember(x => x.BankDetailsOfClient, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientPartner, opts => opts.Ignore())
                .ForMember(x => x.BankContactPersonDesignation, opts => opts.Ignore())
                .ForMember(x => x.BankContactPersonContacts, opts => opts.Ignore());
            #endregion

            #region ClientPartnerNominee
            Mapper.CreateMap<ClientPartnerNomineeDetails,ClientPartnerNomineeDetailsDto>()
                .ForMember(x => x.ClientPartnerNomineeAddress, opts => opts.Ignore())
                .ForMember(x => x.NomineeRelationshipWithClientPartner, opts => opts.Ignore())
                .ForMember(x => x.NomineeOfClientPartner, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerNomineeContacts, opts => opts.Ignore());
            Mapper.CreateMap<ClientPartnerNomineeDetailsDto,ClientPartnerNomineeDetails>()
                .ForMember(x => x.ClientPartnerNomineeAddress, opts => opts.Ignore())
                .ForMember(x => x.NomineeRelationshipWithClientPartner, opts => opts.Ignore())
                .ForMember(x => x.NomineeOfClientPartner, opts => opts.Ignore())
                .ForMember(x => x.ClientPartnerNomineeContacts, opts => opts.Ignore());
            #endregion

            #region ClientPhoneCharges
            Mapper.CreateMap<ClientPhoneCharges, ClientPhoneChargesDto>()
                .ForMember(x => x.PhoneChargesOfClient, opts => opts.Ignore());
            Mapper.CreateMap<ClientPhoneChargesDto, ClientPhoneCharges>()
                .ForMember(x => x.PhoneChargesOfClient, opts => opts.Ignore());
            #endregion

            #region ClientSisterConcern
            Mapper.CreateMap<ClientSisterConcern, ClientSisterConcernDto>()
                .ForMember(x => x.SisterConcernOfClient, opts => opts.Ignore());
            Mapper.CreateMap<ClientSisterConcernDto, ClientSisterConcern>()
                .ForMember(x => x.SisterConcernOfClient, opts => opts.Ignore());
            #endregion

            #region ClientTaxationAndLicenses
            Mapper.CreateMap<ClientTaxationAndLicenses, ClientTaxationAndLicensesDto>()
                .ForMember(x => x.TaxationAndLicensesofClient, opts => opts.Ignore());
            Mapper.CreateMap<ClientTaxationAndLicensesDto, ClientTaxationAndLicenses>()
                .ForMember(x => x.TaxationAndLicensesofClient, opts => opts.Ignore());
            #endregion

            #region ClientHolidayCalender
            Mapper.CreateMap<ClientHolidayCalender, ClientHolidayCalenderDto>();
            Mapper.CreateMap<ClientHolidayCalenderDto, ClientHolidayCalender>();
            #endregion

            #region ClientWeeklyOffDay
            Mapper.CreateMap<ClientWeeklyOffDay, ClientWeeklyOffDayDto>();
            Mapper.CreateMap<ClientWeeklyOffDayDto, ClientWeeklyOffDay>();
            #endregion

            #region ClientPrimaryContactPerson
            Mapper.CreateMap<ClientPrimaryContactPerson, ClientPrimaryContactPersonDto>()
            .ForMember(x => x.ClientPrimaryContactPersonAddress, opts => opts.Ignore())
            .ForMember(x => x.ClientPrimaryContactPersonDesignation, opts => opts.Ignore())
            .ForMember(x => x.ClientPrimaryContacts, opts => opts.Ignore())
            .ForMember(x => x.PrimaryContactPersonofClient, opts => opts.Ignore());
             Mapper.CreateMap<ClientPrimaryContactPersonDto, ClientPrimaryContactPerson>()
            .ForMember(x => x.ClientPrimaryContactPersonAddress, opts => opts.Ignore())
            .ForMember(x => x.ClientPrimaryContactPersonDesignation, opts => opts.Ignore())
            .ForMember(x => x.ClientPrimaryContacts, opts => opts.Ignore())
            .ForMember(x => x.PrimaryContactPersonofClient, opts => opts.Ignore());
            #endregion

            #region ClientSubscription
            Mapper.CreateMap<ClientSubscription, ClientSubscriptionDto>()
                .ForMember(x => x.SubscriptionMaster, opts => opts.Ignore())
                .ForMember(x => x.ClientSubscriptionPaymentDetails, opts => opts.Ignore());
            Mapper.CreateMap<ClientSubscriptionDto, ClientSubscription>()
                .ForMember(x => x.SubscriptionMaster, opts => opts.Ignore())
                .ForMember(x => x.ClientSubscriptionPaymentDetails, opts => opts.Ignore());                
            #endregion

            #region ClientSubscriptionPaymentDetails
            Mapper.CreateMap<ClientSubscriptionPaymentDetails, ClientSubscriptionPaymentDetailsDto>()
                .ForMember(x => x.ClientSubscription, opts => opts.Ignore())
                .ForMember(x => x.BankBranch, opts => opts.Ignore());
            Mapper.CreateMap<ClientSubscriptionPaymentDetailsDto, ClientSubscriptionPaymentDetails>()
                .ForMember(x => x.ClientSubscription, opts => opts.Ignore())
                .ForMember(x => x.BankBranch, opts => opts.Ignore());
            #endregion

            #region SubscriptionMaster
            Mapper.CreateMap<SubscriptionMaster, SubscriptionMasterDto>()
                .ForMember(x => x.ClientSubscriptions, opts => opts.Ignore());
            Mapper.CreateMap<SubscriptionMasterDto, SubscriptionMaster>()
                .ForMember(x => x.ClientSubscriptions, opts => opts.Ignore());
            #endregion

            #region EmailMessages
            Mapper.CreateMap<EmailMessages, EmailMessagesDto>()
                .ForMember(x => x.EmailAttachmentes, opts => opts.Ignore());
            Mapper.CreateMap<EmailMessagesDto, EmailMessages>()
                .ForMember(x => x.EmailAttachmentes, opts => opts.Ignore());
            #endregion

            #region EmailAttachment
            Mapper.CreateMap<EmailAttachment, EmailAttachmentDto>()
                .ForMember(x => x.EmailMessages, opts => opts.Ignore());
            Mapper.CreateMap<EmailAttachmentDto, EmailAttachment>()
                .ForMember(x => x.EmailMessages, opts => opts.Ignore());
            #endregion

            #region ClientProfileChangeRequests
            Mapper.CreateMap<ClientProfileChangeRequests, ClientProfileChangeRequestsDto>()
               .ForMember(x => x.ClientProfileChangeRequestEmailMessages, opts => opts.Ignore())
               .ForMember(x => x.ClientProfileChangeRequestFields, opts => opts.Ignore());
            Mapper.CreateMap<ClientProfileChangeRequestsDto, ClientProfileChangeRequests>()
                .ForMember(x => x.ClientProfileChangeRequestEmailMessages, opts => opts.Ignore())
                .ForMember(x => x.ClientProfileChangeRequestFields, opts => opts.Ignore());
            #endregion

            #region ClientProfileChangeRequestFields
            Mapper.CreateMap<ClientProfileChangeRequestFields, ClientProfileChangeRequestFieldsDto>()
                .ForMember(x => x.ClientProfileChangeRequests, opts => opts.Ignore());
            Mapper.CreateMap<ClientProfileChangeRequestFieldsDto, ClientProfileChangeRequestFields>()
                .ForMember(x => x.ClientProfileChangeRequests, opts => opts.Ignore());
            #endregion

            #region CommodityClass
            Mapper.CreateMap<CommodityClass, CommodityClassDto>()
                .ForMember(x => x.Commodities, opts => opts.Ignore())
                .ForMember(x => x.CommoditiesofClients, opts => opts.Ignore());
            Mapper.CreateMap<CommodityClassDto, CommodityClass>()
                .ForMember(x => x.Commodities, opts => opts.Ignore())
                .ForMember(x => x.CommoditiesofClients, opts => opts.Ignore());
            #endregion

            #region Commodity
            Mapper.CreateMap<Commodity, CommodityDto>()
                .ForMember(x => x.CommoditiesInCommodityClass, opts => opts.Ignore());
            Mapper.CreateMap<CommodityDto, Commodity>()
                .ForMember(x => x.CommoditiesInCommodityClass, opts => opts.Ignore());
            #endregion

            #region LabourChargeType
            Mapper.CreateMap<LabourChargeType, LabourChargeTypeDto>();
            Mapper.CreateMap<LabourChargeTypeDto, LabourChargeType>();
            #endregion

            #region ChargesPayableTo
            Mapper.CreateMap<ChargesPayableTo, ChargesPayableToDto>();
            Mapper.CreateMap<ChargesPayableToDto, ChargesPayableTo>();
            #endregion

            #region APMC
            Mapper.CreateMap<APMC, APMCDto>()
                .ForMember(x => x.Address, opts => opts.Ignore())
                .ForMember(x => x.ContactNos, opts => opts.Ignore())
                .ForMember(x => x.APMCOfClients, opts => opts.Ignore());
            Mapper.CreateMap<APMCDto, APMC>()
                  .ForMember(x => x.Address, opts => opts.Ignore())
                  .ForMember(x => x.ContactNos, opts => opts.Ignore())
                  .ForMember(x => x.APMCOfClients, opts => opts.Ignore());
            #endregion

            #region MeasuringUnit
            Mapper.CreateMap<MeasuringUnit, MeasuringUnitDto>();
            Mapper.CreateMap<MeasuringUnitDto, MeasuringUnit>();
            #endregion

            #region Bank
            Mapper.CreateMap<Bank, BankDto>()
                .ForMember(x => x.Branches, opts => opts.Ignore());
            Mapper.CreateMap<BankDto, Bank>()
                .ForMember(x => x.Branches, opts => opts.Ignore());
            #endregion

            #region BankBranch
            Mapper.CreateMap<BankBranch, BankBranchDto>()
                .ForMember(x => x.BranchOfBank, opts => opts.Ignore())
                .ForMember(x => x.BranchAddress, opts => opts.Ignore())
                .ForMember(x => x.BranchContactNos, opts => opts.Ignore())
                .ForMember(x => x.WeeklyHalfDay, opts => opts.Ignore())
                .ForMember(x => x.WeeklyOffDay, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientSubscriptionPayment, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientPartner, opts => opts.Ignore());
            Mapper.CreateMap<BankBranchDto, BankBranch>()
                .ForMember(x => x.BranchOfBank, opts => opts.Ignore())
                .ForMember(x => x.BranchAddress, opts => opts.Ignore())
                .ForMember(x => x.BranchContactNos, opts => opts.Ignore())
                .ForMember(x => x.WeeklyHalfDay, opts => opts.Ignore())
                .ForMember(x => x.WeeklyOffDay, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientSubscriptionPayment, opts => opts.Ignore())
                .ForMember(x => x.BranchOfClientPartner, opts => opts.Ignore());
            #endregion

            #region WeekDays
            Mapper.CreateMap<WeekDays, WeekDaysDto>();
            Mapper.CreateMap<WeekDaysDto, WeekDays>();
            #endregion

            #region WeeklyHalfDay
            Mapper.CreateMap<WeeklyHalfDay, WeeklyHalfDayDto>()
                .ForMember(x => x.WeeklyHalfDayOfBranch, opts => opts.Ignore());
            Mapper.CreateMap<WeeklyHalfDayDto, WeeklyHalfDay>()
               .ForMember(x => x.WeeklyHalfDayOfBranch, opts => opts.Ignore());
            #endregion

            #region WeeklyOffDays
            Mapper.CreateMap<WeeklyOffDays, WeeklyOffDaysDto>()
                .ForMember(x => x.WeeklyOffDayOfBranch, opts => opts.Ignore());
            Mapper.CreateMap<WeeklyOffDaysDto, WeeklyOffDays>()
                .ForMember(x => x.WeeklyOffDayOfBranch, opts => opts.Ignore());
            #endregion
        }
                
    }
    
}
