using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class WcfContractLocator :IContractLocator
    {
        private IAddressService AddressServiceProxyInstance;
        private IUserService UserServiceProxyInstance;
        private IUserGroupService UserGroupServiceProxyInstance;
        private IRoleService RoleServiceProxyInstance;
        private IDesignationService DesignationProxyInstance;
        private IUserRolePermissionService UserRolePermissionServiceProxyInstance;
        private ICountryMasterService CountryServiceProxyInstance;
        private IStateService StateServiceProxyInstance;
        private IDistrictService DistrictServiceProxyInstance;
        private ICityVillageService CityVillageServiceProxyInstance;
        private IZoneService ZoneServiceProxyInstance;
        private IRelationShipService RelationShipServiceProxyInstance;
        private ICommodityClassService CommodityClassProxyInstance;
        private ICommodityService CommodityProxyInstance;
        private ILabourChargeTypeService LabourChargeTypeProxyInstance;
        private IChargesPayableToService ChargesPayableToProxyInstance;
        private IMeasuringUnitService MeasuringUnitProxyInstance;
        private IBankService BankProxyInstance;
        private IBankBranchService BankBranchProxyInstance;
        private IWeeklyHalfDayService WeeklyHalfDayProxyInstance;
        private IWeeklyOffDaysService WeeklyOffDayProxyInstance;
        private IAPMCService APMCProxyInstance;
        private IBusinessConstitutionService BusinessConstitutionProxyInstance;
        private ISubscriptionMasterService SubscriptionMasterProxyInstance;
        private IClientService ClientProxyInstance;
        private IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryProxyInstance;
        private IClientCommoditiesHistoryService ClientCommoditiesHistoryProxyInstance;
        private IClientPartnerHistoryService ClientPartnerHistoryProxyInstance;
        private IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServiceInstance;
        private IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServiceInstance;
        private IClientProfileChangeRequestsService ClientProfileChangeRequestsServiceInstance;
        private IClientWeeklyOffDayService ClientWeeklyOffDayServiceInstance;
        private IClientHolidayCalenderService ClientHolidayCalenderServiceInstance;

        public IAddressService AddressServices
        {
            get
            {
                if (AddressServiceProxyInstance != null) return AddressServiceProxyInstance;
                AddressServiceProxyInstance = new AddressServiceProxy();
                return AddressServiceProxyInstance;
            }
        }

        public IUserService UserServices
        {
            get
            {
                if (UserServiceProxyInstance != null) return UserServiceProxyInstance;
                UserServiceProxyInstance = new UserServiceProxy();
                return UserServiceProxyInstance;
            }
        }

        public IUserGroupService UserGroupServices  
        {
            get
            {
                if (UserGroupServiceProxyInstance != null) return UserGroupServiceProxyInstance;
                UserGroupServiceProxyInstance = new UserGroupServiceProxy();
                return UserGroupServiceProxyInstance;
            }
        }

        public IRoleService RoleServices
        {
            get
            {
                if (RoleServiceProxyInstance != null) return RoleServiceProxyInstance;
                RoleServiceProxyInstance = new RoleServiceProxy();
                return RoleServiceProxyInstance;
            }
        }

        public IDesignationService DesignationServices
        {
            get
            {
                if (DesignationProxyInstance != null) return DesignationProxyInstance;
                DesignationProxyInstance = new DesignationServiceProxy();
                return DesignationProxyInstance;
            }
        }

        public IUserRolePermissionService UserRolePermissionServices
        {
            get
            {
                if (UserRolePermissionServiceProxyInstance != null) return UserRolePermissionServiceProxyInstance;
                UserRolePermissionServiceProxyInstance = new UserRolePermissionServiceProxy();
                return UserRolePermissionServiceProxyInstance;
            }
        }

        public ICountryMasterService CountryServices
        {
            get
            {
                if (CountryServiceProxyInstance != null) return CountryServiceProxyInstance;
                CountryServiceProxyInstance = new CountryMasterServiceProxy();
                return CountryServiceProxyInstance;
            }
        }

        public IStateService StateServices
        {
            get
            {
                if (StateServiceProxyInstance != null) return StateServiceProxyInstance;
                StateServiceProxyInstance = new StatesMasterServiceProxy();
                return StateServiceProxyInstance;
            }
        }

        public IDistrictService DistrictServices
        {
            get
            {
                if (DistrictServiceProxyInstance != null) return DistrictServiceProxyInstance;
                DistrictServiceProxyInstance = new DistrictServiceProxy();
                return DistrictServiceProxyInstance;
            }
        }

        public ICityVillageService CityVillageServices
        {
            get
            {
                if (CityVillageServiceProxyInstance != null) return CityVillageServiceProxyInstance;
                CityVillageServiceProxyInstance = new CityVillageServiceProxy();
                return CityVillageServiceProxyInstance;
            }
        }

        public IZoneService ZoneServices
        {
            get
            {
                if (ZoneServiceProxyInstance != null) return ZoneServiceProxyInstance;
                ZoneServiceProxyInstance = new ZoneServiceProxy();
                return ZoneServiceProxyInstance;
            }
        }

        public IRelationShipService RelationshipServices  
        {
            get
            {
                if (RelationShipServiceProxyInstance != null) return RelationShipServiceProxyInstance;
                RelationShipServiceProxyInstance = new RelationshipServiceProxy();
                return RelationShipServiceProxyInstance;
            }
        }

        public ICommodityClassService CommodityClassServices
        {
            get
            {
                if (CommodityClassProxyInstance != null) return CommodityClassProxyInstance;
                CommodityClassProxyInstance = new CommodityClassServiceProxy();
                return CommodityClassProxyInstance;
            }
        }

        public ICommodityService CommodityServices
        {
            get
            {
                if (CommodityProxyInstance != null) return CommodityProxyInstance;
                CommodityProxyInstance = new CommodityServiceProxy();
                return CommodityProxyInstance;
            }
        }

        public ILabourChargeTypeService LabourChargeTypeServices
        {
            get
            {
                if (LabourChargeTypeProxyInstance != null) return LabourChargeTypeProxyInstance;
                LabourChargeTypeProxyInstance = new LabourChargeTypeServiceProxy();
                return LabourChargeTypeProxyInstance;
            }
        }

        public IChargesPayableToService ChargesPayableToServices
        {
            get
            {
                if (ChargesPayableToProxyInstance != null) return ChargesPayableToProxyInstance;
                ChargesPayableToProxyInstance = new ChargesPayableToServiceProxy();
                return ChargesPayableToProxyInstance;
            }
        }

        public IMeasuringUnitService MeasuringUnitServices
        {
            get
            {
                if (MeasuringUnitProxyInstance != null) return MeasuringUnitProxyInstance;
                MeasuringUnitProxyInstance = new MeasuringUnitServiceProxy();
                return MeasuringUnitProxyInstance;
            }
        }

        public IBankService BankServices
        {
            get
            {
                if (BankProxyInstance != null) return BankProxyInstance;
                BankProxyInstance = new BankServiceProxy();
                return BankProxyInstance;
            }
        }
        public IBankBranchService BankBranchServices
        {
            get
            {
                if (BankBranchProxyInstance != null) return BankBranchProxyInstance;
                BankBranchProxyInstance = new BankBranchServiceProxy();
                return BankBranchProxyInstance;
            }
        }
        public IWeeklyOffDaysService WeeklyOffDaysServices  
        {
            get
            {
                if (WeeklyOffDayProxyInstance != null) return WeeklyOffDayProxyInstance;
                WeeklyOffDayProxyInstance = new WeeklyOffDayProxy();
                return WeeklyOffDayProxyInstance;
            }
        }
        public IWeeklyHalfDayService WeeklyHalfDayServices  
        {
            get
            {
                if (WeeklyHalfDayProxyInstance != null) return WeeklyHalfDayProxyInstance;
                WeeklyHalfDayProxyInstance = new WeeklyHalfDayProxy();
                return WeeklyHalfDayProxyInstance;
            }
        }
        public IAPMCService APMCServices
        {
            get
            {
                if (APMCProxyInstance != null) return APMCProxyInstance;
                APMCProxyInstance = new APMCServiceProxy();
                return APMCProxyInstance;
            }
        }
        public IBusinessConstitutionService BusinessConstitutionServices  
        {
            get
            {
                if (BusinessConstitutionProxyInstance != null) return BusinessConstitutionProxyInstance;
                BusinessConstitutionProxyInstance = new BusinessConstitutionServiceProxy();
                return BusinessConstitutionProxyInstance;
            }
        }
        public ISubscriptionMasterService SubscriptionMasterServices 
        {
            get
            {
                if (SubscriptionMasterProxyInstance != null) return SubscriptionMasterProxyInstance;
                SubscriptionMasterProxyInstance = new SubscriptionMasterServiceProxy();
                return SubscriptionMasterProxyInstance;
            }
        }
        public IClientService ClientServices  
        {
            get
            {
                if (ClientProxyInstance != null) return ClientProxyInstance;
                ClientProxyInstance = new ClientServiceProxy();
                return ClientProxyInstance;
            }
        }

        public IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServices
        {
            get
            {
                if (ClientBusinessConstitutionHistoryProxyInstance != null) return ClientBusinessConstitutionHistoryProxyInstance;
                ClientBusinessConstitutionHistoryProxyInstance = new ClientBusinessConstitutionHistoryServiceProxy();
                return ClientBusinessConstitutionHistoryProxyInstance;
            }
        }

        public IClientCommoditiesHistoryService ClientCommoditiesHistoryServices 
        {
            get
            {
                if (ClientCommoditiesHistoryProxyInstance != null) return ClientCommoditiesHistoryProxyInstance;
                ClientCommoditiesHistoryProxyInstance = new ClientCommoditiesHistoryServiceProxy();
                return ClientCommoditiesHistoryProxyInstance;
            }
        }

        public IClientPartnerHistoryService ClientPartnerHistoryServices 
        {
            get
            {
                if (ClientPartnerHistoryProxyInstance != null) return ClientPartnerHistoryProxyInstance;
                ClientPartnerHistoryProxyInstance = new ClientPartnerHistoryServiceProxy();
                return ClientPartnerHistoryProxyInstance;
            }
        }

        public IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServices  
        {
            get
            {
                if (ClientPhoneChargesHistoryServiceInstance != null) return ClientPhoneChargesHistoryServiceInstance;
                ClientPhoneChargesHistoryServiceInstance = new ClientPhoneChargesHistoryServiceProxy();
                return ClientPhoneChargesHistoryServiceInstance;
            }
        }

        public IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServices
        {
            get
            {
                if (ClientWeeklyOffDayHistoryServiceInstance != null) return ClientWeeklyOffDayHistoryServiceInstance;
                ClientWeeklyOffDayHistoryServiceInstance = new ClientWeeklyOffDayHistoryServiceProxy(); 
                return ClientWeeklyOffDayHistoryServiceInstance;
            }
        }
        public IClientProfileChangeRequestsService ClientProfileChangeRequestsServices
        {
            get
            {
                if (ClientProfileChangeRequestsServiceInstance != null) return ClientProfileChangeRequestsServiceInstance;
                ClientProfileChangeRequestsServiceInstance = new ClientProfileChangeRequestsServiceProxy();
                return ClientProfileChangeRequestsServiceInstance;
            }
        }
        public IClientWeeklyOffDayService ClientWeeklyOffDayServices  
        {
            get
            {
                if (ClientWeeklyOffDayServiceInstance != null) return ClientWeeklyOffDayServiceInstance;
                ClientWeeklyOffDayServiceInstance = new ClientWeeklyOffDayServiceProxy();
                return ClientWeeklyOffDayServiceInstance;
            }
        }
        public IClientHolidayCalenderService ClientHolidayCalenderServices  
        {
            get
            {
                if (ClientHolidayCalenderServiceInstance != null) return ClientHolidayCalenderServiceInstance;
                ClientHolidayCalenderServiceInstance = new ClientHolidayCalenderServiceProxy();
                return ClientHolidayCalenderServiceInstance;
            }
        }
    }
}
