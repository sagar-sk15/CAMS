using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;

namespace Cams.Domain.Services
{
    public class ServerContractLocator : IContractLocator
    {
        IAddressService AddressServiceInstance;
        IUserService UserServiceInstance;
        IRoleService RoleServiceInstance;
        IUserGroupService UserGroupServiceInstance;
        IDesignationService DesignationServiceInstance;
        IUserRolePermissionService UserRolePermissionServiceInstance;
        ICountryMasterService CountryServiceInstance;
        IStateService StateServiceInstance;
        IDistrictService DistrictServiceInstance;
        ICityVillageService CityVillageServiceInstance;
        IZoneService ZoneServiceInstance;
        IRelationShipService RelationshipServiceInstance;
        ICommodityClassService CommodityClassServiceInstance;
        ICommodityService CommodityServiceInstance;
        ILabourChargeTypeService LabourChargeTypeServiceInstance;
        IChargesPayableToService ChargesPayableToInstance;
        IMeasuringUnitService MeasuringUnitInstance;
        IBankService BankServiceInstance;
        IBankBranchService BankBranchServiceInstance;
        IWeeklyHalfDayService WeeklyHalfDayServiceInstance;
        IWeeklyOffDaysService WeeklyOffDaysServiceInstance;
        IAPMCService APMCServiceInstance;
        IBusinessConstitutionService BusinessConstitutionServiceInstance;
        ISubscriptionMasterService SubscriptionMasterServiceInstance;
        IClientService ClientServiceInstance;
        IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServiceInstance;
        IClientCommoditiesHistoryService ClientCommoditiesHistoryServiceInstance;
        IClientPartnerHistoryService ClientPartnerHistoryServiceInstance;
        IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServiceInstance;
        IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServiceInstance;
        IClientProfileChangeRequestsService ClientProfileChangeRequestsServiceInstance;
        IClientWeeklyOffDayService ClientWeeklyOffDayServiceInstance;
        IClientHolidayCalenderService ClientHolidayCalenderServiceInstance;  

        #region IContractLocator Members
                
        public IAddressService AddressServices
        {
            get
            {
                if (AddressServiceInstance != null) return AddressServiceInstance;
                AddressServiceInstance = new AddressService();
                return AddressServiceInstance;
            }
        }

        public IUserService UserServices  
        {
            get
            {
            if (UserServiceInstance != null) return UserServiceInstance;
                UserServiceInstance = new UserService();
            return UserServiceInstance;
            }
        }

        public IRoleService RoleServices
        {
            get
            {
                if (RoleServiceInstance != null) return RoleServiceInstance;
                    RoleServiceInstance = new RoleService();
                return RoleServiceInstance;
            }
        }

        public IUserGroupService UserGroupServices
        {
            get
            {
                if (UserGroupServiceInstance != null) return UserGroupServiceInstance;
                UserGroupServiceInstance = new UserGroupService();
                return UserGroupServiceInstance;
            }
        }

        public IDesignationService DesignationServices
        {
            get
            {
                if (DesignationServiceInstance != null) return DesignationServiceInstance;
                DesignationServiceInstance = new DesignationService();
                return DesignationServiceInstance;
            }
        }

        public IUserRolePermissionService UserRolePermissionServices
        {
            get
            {
                if (UserRolePermissionServiceInstance != null) return UserRolePermissionServiceInstance;
                UserRolePermissionServiceInstance = new UserRolePermissionService();
                return UserRolePermissionServiceInstance;
            }
        }

        public ICountryMasterService CountryServices
        {
            get
            {
                if (CountryServiceInstance != null) return CountryServiceInstance;
                CountryServiceInstance = new CountryMasterService();
                return CountryServiceInstance;
            }
        }
        public IStateService StateServices
        {
            get
            {
                if (StateServiceInstance != null) return StateServiceInstance;
                StateServiceInstance = new StateService();
                return StateServiceInstance;
            }
        }
        public IDistrictService DistrictServices
        {
            get
            {
                if (DistrictServiceInstance != null) return DistrictServiceInstance;
                DistrictServiceInstance = new DistrictService();
                return DistrictServiceInstance;
            }
        }
        public ICityVillageService CityVillageServices
        {
            get
            {
                if (CityVillageServiceInstance != null) return CityVillageServiceInstance;
                CityVillageServiceInstance = new CityVillageService();
                return CityVillageServiceInstance;
            }
        }

        public IZoneService ZoneServices
        {
            get
            {
                if (ZoneServiceInstance != null) return ZoneServiceInstance;
                ZoneServiceInstance = new ZoneService();
                return ZoneServiceInstance;
            }
        }
        public IRelationShipService RelationshipServices
        {
            get
            {
                if (RelationshipServiceInstance != null) return RelationshipServiceInstance;
                RelationshipServiceInstance = new RelationshipService();
                return RelationshipServiceInstance;
            }
        }
        public ICommodityClassService CommodityClassServices
        {
            get
            {
                if (CommodityClassServiceInstance != null) return CommodityClassServiceInstance;
                CommodityClassServiceInstance = new CommodityClassService();
                return CommodityClassServiceInstance;
            }
        }
        public ICommodityService CommodityServices
        {
            get
            {
                if (CommodityServiceInstance != null) return CommodityServiceInstance;
                CommodityServiceInstance = new CommodityService();
                return CommodityServiceInstance;
            }
        }
        public ILabourChargeTypeService LabourChargeTypeServices
        {
            get
            {
                if (LabourChargeTypeServiceInstance != null) return LabourChargeTypeServiceInstance;
                LabourChargeTypeServiceInstance = new LabourChargeTypeService();
                return LabourChargeTypeServiceInstance;
            }
        }

        public IChargesPayableToService ChargesPayableToServices
        {
            get
            {
                if (ChargesPayableToInstance != null) return ChargesPayableToInstance;
                ChargesPayableToInstance = new ChargesPayableToService();
                return ChargesPayableToInstance;
            }
        }

        public IMeasuringUnitService MeasuringUnitServices
        {
            get
            {
                if (MeasuringUnitInstance != null) return MeasuringUnitInstance;
                MeasuringUnitInstance = new MeasuringUnitService();
                return MeasuringUnitInstance;
            }
        }
        public IBankService BankServices 
        {
            get
            {
                if (BankServiceInstance != null) return BankServiceInstance;
                BankServiceInstance = new BankService();
                return BankServiceInstance;
            }
        }
        public IBankBranchService BankBranchServices 
        {
            get
            {
                if (BankBranchServiceInstance != null) return BankBranchServiceInstance;
                BankBranchServiceInstance = new BankBranchService();
                return BankBranchServiceInstance;
            }
        }
        public IWeeklyOffDaysService WeeklyOffDaysServices 
        {
            get
            {
                if (WeeklyOffDaysServiceInstance != null) return WeeklyOffDaysServiceInstance;
                WeeklyOffDaysServiceInstance = new WeeklyOffDaysService();
                return WeeklyOffDaysServiceInstance;
            }
        }
        public IWeeklyHalfDayService WeeklyHalfDayServices 
        {
            get
            {
                if (WeeklyHalfDayServiceInstance != null) return WeeklyHalfDayServiceInstance;
                WeeklyHalfDayServiceInstance = new WeeklyHalfDayService();
                return WeeklyHalfDayServiceInstance;
            }
        }
        public IAPMCService APMCServices
        {
            get
            {
                if (APMCServiceInstance != null) return APMCServiceInstance;
                APMCServiceInstance = new APMCService();
                return APMCServiceInstance;
            }
        }
        public IBusinessConstitutionService BusinessConstitutionServices 
        {
            get
            {
                if (BusinessConstitutionServiceInstance != null) return BusinessConstitutionServiceInstance;
                BusinessConstitutionServiceInstance = new BusinessConstitutionService();
                return BusinessConstitutionServiceInstance;
            }
        }
        public ISubscriptionMasterService SubscriptionMasterServices  
        {
            get
            {
                if (SubscriptionMasterServiceInstance != null) return SubscriptionMasterServiceInstance;
                SubscriptionMasterServiceInstance = new SubscriptionMasterService();
                return SubscriptionMasterServiceInstance;
            }
        }
        public IClientService ClientServices  
        {
            get
            {
                if (ClientServiceInstance != null) return ClientServiceInstance;
                ClientServiceInstance = new ClientService();
                return ClientServiceInstance;
            }
        }
        public IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServices 
        {
            get
            {
                if (ClientBusinessConstitutionHistoryServiceInstance != null) return ClientBusinessConstitutionHistoryServiceInstance;
                ClientBusinessConstitutionHistoryServiceInstance = new ClientBusinessConstitutionHistoryService();
                return ClientBusinessConstitutionHistoryServiceInstance;
            }
        }
        public IClientCommoditiesHistoryService ClientCommoditiesHistoryServices 
        {
            get
            {
                if (ClientCommoditiesHistoryServiceInstance != null) return ClientCommoditiesHistoryServiceInstance;
                ClientCommoditiesHistoryServiceInstance = new ClientCommoditiesHistoryService();
                return ClientCommoditiesHistoryServiceInstance;
            }
        }
        public IClientPartnerHistoryService ClientPartnerHistoryServices  
        {
            get
            {
                if (ClientPartnerHistoryServiceInstance != null) return ClientPartnerHistoryServiceInstance;
                ClientPartnerHistoryServiceInstance = new ClientPartnerHistoryService();
                return ClientPartnerHistoryServiceInstance;
            }
        }
        public IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServices  
        {
            get
            {
                if (ClientPhoneChargesHistoryServiceInstance != null) return ClientPhoneChargesHistoryServiceInstance;
                ClientPhoneChargesHistoryServiceInstance = new ClientPhoneChargesHistoryService();
                return ClientPhoneChargesHistoryServiceInstance;
            }
        }
        public IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServices  
        {
            get
            {
                if (ClientWeeklyOffDayHistoryServiceInstance != null) return ClientWeeklyOffDayHistoryServiceInstance;
                ClientWeeklyOffDayHistoryServiceInstance = new ClientWeeklyOffDayHistoryService();
                return ClientWeeklyOffDayHistoryServiceInstance;
            }
        }
        public IClientProfileChangeRequestsService ClientProfileChangeRequestsServices  
        {
            get
            {
                if (ClientProfileChangeRequestsServiceInstance != null) return ClientProfileChangeRequestsServiceInstance;
                ClientProfileChangeRequestsServiceInstance = new ClientProfileChangeRequestsService();
                return ClientProfileChangeRequestsServiceInstance;
            }
        }
        public IClientWeeklyOffDayService ClientWeeklyOffDayServices  
        {
            get
            {
                if (ClientWeeklyOffDayServiceInstance != null) return ClientWeeklyOffDayServiceInstance;
                ClientWeeklyOffDayServiceInstance = new ClientWeeklyOffDayService();
                return ClientWeeklyOffDayServiceInstance;
            }
        } 
        public IClientHolidayCalenderService ClientHolidayCalenderServices
        {
            get
            {
                if (ClientHolidayCalenderServiceInstance != null) return ClientHolidayCalenderServiceInstance;
                ClientHolidayCalenderServiceInstance = new ClientHolidayCalenderService();
                return ClientHolidayCalenderServiceInstance;
            }
        }
        #endregion
    }
}
