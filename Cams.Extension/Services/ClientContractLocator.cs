using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;


namespace Cams.Extension.Services
{
    public class ClientContractLocator : IContractLocator
    {
        private IAddressService AddressServiceInstance;
        private IUserService UserServiceInstance;
        private IUserGroupService UserGroupServiceInstance;
        private IRoleService RoleServiceInstance;
        private IDesignationService DesignationServiceInstance;
        private IUserRolePermissionService UserRolePermissionServiceInstance;
        private ICountryMasterService CountryServiceInstance;
        private IStateService StateServiceInstance;
        private IDistrictService DistrictServiceInstance;
        private ICityVillageService CityVillageServiceInstance;
        private IZoneService ZoneServiceInstance;
        private IRelationShipService RelationshipServiceInstance;
        private ICommodityClassService CommodityClassServiceInstance;
        private ICommodityService CommodityServiceInstance;
        private ILabourChargeTypeService LabourChargeTypeInstance;
        private IChargesPayableToService ChargesPayableToInstance;
        private IMeasuringUnitService MeasuringUnitInstance;
        private IBankService BankServiceInstance;
        private IBankBranchService BankBranchServiceInstance;
        private IWeeklyHalfDayService WeeklyHalfDayServiceInstance;
        private IWeeklyOffDaysService WeeklyOffDaysServiceInstance;
        private IAPMCService APMCServiceInstance;
        private IBusinessConstitutionService BusinessConstitutionServiceInstance;
        private ISubscriptionMasterService SubscriptionMasterServiceInstance;
        private IClientService ClientServiceInstance;
        private IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServiceInstance;
        private IClientCommoditiesHistoryService ClientCommoditiesHistoryServiceInstance;
        private IClientPartnerHistoryService ClientPartnerHistoryServiceInstance;
        private IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServiceInstance;
        private IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServiceInstance;
        private IClientProfileChangeRequestsService ClientProfileChangeRequestsServiceInstance;
        private IClientWeeklyOffDayService ClientWeeklyOffDayServiceInstance; 
        private IClientHolidayCalenderService ClientHolidayCalenderServiceInstance;  
 
        public IContractLocator NextAdapterLocator { get; private set; }

        #region IContractLocator Members

        public IAddressService AddressServices
        {
            get
            {
                if (AddressServiceInstance != null) return AddressServiceInstance;
                AddressServiceInstance = new AddressServiceAdapter(NextAdapterLocator.AddressServices);
                return AddressServiceInstance;
            }
        }

        public IUserService UserServices
        {
            get
            {
                if (UserServiceInstance != null) return UserServiceInstance;
                UserServiceInstance = new UserServiceAdapter(NextAdapterLocator.UserServices);
                return UserServiceInstance;
            }
        }

        public IUserGroupService UserGroupServices
        {
            get
            {
                if (UserGroupServiceInstance != null) return UserGroupServiceInstance;
                UserGroupServiceInstance = new UserGroupServiceAdapter(NextAdapterLocator.UserGroupServices);
                return UserGroupServiceInstance;
            }
        }

        public IRoleService RoleServices
        {
            get
            {
                if(RoleServiceInstance != null) return RoleServiceInstance;
                RoleServiceInstance = new RoleServiceAdapter(NextAdapterLocator.RoleServices);
                return RoleServiceInstance;
            }
        }

        public IDesignationService DesignationServices
        {
            get
            {
                if (DesignationServiceInstance != null) return DesignationServiceInstance;
                DesignationServiceInstance = new DesignationServiceAdapter(NextAdapterLocator.DesignationServices);
                return DesignationServiceInstance;
            }
        }

        public IUserRolePermissionService UserRolePermissionServices
        {
            get
            {
                if (UserRolePermissionServiceInstance != null) return UserRolePermissionServiceInstance;
                UserRolePermissionServiceInstance = new UserRolePermissionServiceAdapter(NextAdapterLocator.UserRolePermissionServices);
                return UserRolePermissionServiceInstance;
            }
        }

        public ICountryMasterService CountryServices
        {
            get
            {
                if (CountryServiceInstance != null) return CountryServiceInstance;
                CountryServiceInstance = new CountryMasterServiceAdapter(NextAdapterLocator.CountryServices);
                return CountryServiceInstance;
            }
        }
        public IStateService StateServices
        {
            get
            {
                if (StateServiceInstance != null) return StateServiceInstance;
                StateServiceInstance = new StatesMasterServiceAdapter(NextAdapterLocator.StateServices);
                return StateServiceInstance;
            }
        }
        public IDistrictService DistrictServices
        {
            get
            {
                if (DistrictServiceInstance != null) return DistrictServiceInstance;
                DistrictServiceInstance = new DistrictServiceAdapter(NextAdapterLocator.DistrictServices);
                return DistrictServiceInstance;
            }
        }
        public ICityVillageService CityVillageServices
        {
            get
            {
                if (CityVillageServiceInstance != null) return CityVillageServiceInstance;
                CityVillageServiceInstance = new CityVillageServiceAdapter(NextAdapterLocator.CityVillageServices);
                return CityVillageServiceInstance;
            }
        }
        public IZoneService ZoneServices
        {
            get
            {
                if (ZoneServiceInstance != null) return ZoneServiceInstance;
                ZoneServiceInstance = new ZoneServiceAdapter(NextAdapterLocator.ZoneServices);
                return ZoneServiceInstance;
            }
        }
        public IRelationShipService RelationshipServices 
        {
            get
            {
                if (RelationshipServiceInstance != null) return RelationshipServiceInstance;
                RelationshipServiceInstance = new RelationshipServiceAdapter(NextAdapterLocator.RelationshipServices);
                return RelationshipServiceInstance;
            }
        }
        public ICommodityClassService CommodityClassServices
        {
            get
            {
                if (CommodityClassServiceInstance != null) return CommodityClassServiceInstance;
                CommodityClassServiceInstance = new CommodityClassServiceAdapter(NextAdapterLocator.CommodityClassServices);
                return CommodityClassServiceInstance;
            }
        }
        public ICommodityService CommodityServices 
        {
            get
            {
                if (CommodityServiceInstance != null) return CommodityServiceInstance;
                CommodityServiceInstance = new CommodityServiceAdapter(NextAdapterLocator.CommodityServices);
                return CommodityServiceInstance;
            }
        }

        public ILabourChargeTypeService LabourChargeTypeServices
        {
            get
            {
                if (LabourChargeTypeInstance != null) return LabourChargeTypeInstance;
                LabourChargeTypeInstance = new LabourChargeTypeAdapter(NextAdapterLocator.LabourChargeTypeServices);
                return LabourChargeTypeInstance;
            }
        }

        public IChargesPayableToService ChargesPayableToServices
        {
            get
            {
                if (ChargesPayableToInstance != null) return ChargesPayableToInstance;
                ChargesPayableToInstance = new ChargesPayableToServiceAdapter(NextAdapterLocator.ChargesPayableToServices);
                return ChargesPayableToInstance;
            }
        }

        public IMeasuringUnitService MeasuringUnitServices
        {
            get
            {
                if (MeasuringUnitInstance != null) return MeasuringUnitInstance;
                MeasuringUnitInstance = new MeasuringUnitServiceAdapter(NextAdapterLocator.MeasuringUnitServices);
                return MeasuringUnitInstance;
            }
        }
        public IBankService BankServices
        {
            get
            {
                if (BankServiceInstance != null) return BankServiceInstance;
                BankServiceInstance = new BankServiceAdapter(NextAdapterLocator.BankServices);
                return BankServiceInstance;
            }
        }
        public IBankBranchService BankBranchServices 
        {
            get
            {
                if (BankBranchServiceInstance != null) return BankBranchServiceInstance;
                BankBranchServiceInstance = new BankBranchServiceAdapter(NextAdapterLocator.BankBranchServices);
                return BankBranchServiceInstance;
            }
        }
        public IWeeklyHalfDayService WeeklyHalfDayServices
        {
            get
            {
                if (WeeklyHalfDayServiceInstance != null) return WeeklyHalfDayServiceInstance;
                WeeklyHalfDayServiceInstance = new WeeklyHalfDayServiceAdapter(NextAdapterLocator.WeeklyHalfDayServices);
                return WeeklyHalfDayServiceInstance;
            }
        }
        public IWeeklyOffDaysService WeeklyOffDaysServices  
        {
            get
            {
                if (WeeklyOffDaysServiceInstance != null) return WeeklyOffDaysServiceInstance;
                WeeklyOffDaysServiceInstance = new WeeklyOffDayServiceAdapter(NextAdapterLocator.WeeklyOffDaysServices);
                return WeeklyOffDaysServiceInstance;
            }
        }
        public IAPMCService APMCServices
        {
            get
            {
                if (APMCServiceInstance != null) return APMCServiceInstance;
                APMCServiceInstance = new APMCServiceAdapter(NextAdapterLocator.APMCServices);
                return APMCServiceInstance;
            }
        }

        public IBusinessConstitutionService BusinessConstitutionServices
        {
            get
            {
                if (BusinessConstitutionServiceInstance != null) return BusinessConstitutionServiceInstance;
                BusinessConstitutionServiceInstance = new BusinessConstitutionServiceAdapter(NextAdapterLocator.BusinessConstitutionServices);
                return BusinessConstitutionServiceInstance;
            }
        }

        public ISubscriptionMasterService SubscriptionMasterServices 
        {
            get
            {
                if (SubscriptionMasterServiceInstance != null) return SubscriptionMasterServiceInstance;
                SubscriptionMasterServiceInstance = new SubscriptionMasterServiceAdapter(NextAdapterLocator.SubscriptionMasterServices);
                return SubscriptionMasterServiceInstance;
            }
        }

        public IClientService ClientServices 
        {
            get
            {
                if (ClientServiceInstance != null) return ClientServiceInstance;
                ClientServiceInstance = new ClientServiceAdapter(NextAdapterLocator.ClientServices);
                return ClientServiceInstance;
            }
        }

        public IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServices 
        {
            get
            {
                if (ClientBusinessConstitutionHistoryServiceInstance != null) return ClientBusinessConstitutionHistoryServiceInstance;
                ClientBusinessConstitutionHistoryServiceInstance = new ClientBusinessConstitutionHistoryServiceAdapter(NextAdapterLocator.ClientBusinessConstitutionHistoryServices);
                return ClientBusinessConstitutionHistoryServiceInstance;
            }
        }

        public IClientCommoditiesHistoryService ClientCommoditiesHistoryServices 
        {
            get
            {
                if (ClientCommoditiesHistoryServiceInstance != null) return ClientCommoditiesHistoryServiceInstance;
                ClientCommoditiesHistoryServiceInstance = new ClientCommoditiesHistoryServiceAdapter(NextAdapterLocator.ClientCommoditiesHistoryServices);
                return ClientCommoditiesHistoryServiceInstance;
            }
        }

        public IClientPartnerHistoryService ClientPartnerHistoryServices  
        {
            get
            {
                if (ClientPartnerHistoryServiceInstance != null) return ClientPartnerHistoryServiceInstance;
                ClientPartnerHistoryServiceInstance = new ClientPartnerHistoryServiceAdapter(NextAdapterLocator.ClientPartnerHistoryServices);
                return ClientPartnerHistoryServiceInstance;
            }
        }

        public IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServices  
        {
            get
            {
                if (ClientPhoneChargesHistoryServiceInstance != null) return ClientPhoneChargesHistoryServiceInstance;
                ClientPhoneChargesHistoryServiceInstance = new ClientPhoneChargesHistoryServiceAdapter(NextAdapterLocator.ClientPhoneChargesHistoryServices);
                return ClientPhoneChargesHistoryServiceInstance;
            }
        }

        public IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServices  
        {
            get
            {
                if (ClientWeeklyOffDayHistoryServiceInstance != null) return ClientWeeklyOffDayHistoryServiceInstance;
                ClientWeeklyOffDayHistoryServiceInstance = new ClientWeeklyOffDayHistoryServiceAdapter(NextAdapterLocator.ClientWeeklyOffDayHistoryServices);
                return ClientWeeklyOffDayHistoryServiceInstance;
            }
        }
        public IClientProfileChangeRequestsService ClientProfileChangeRequestsServices
        {
            get
            {
                if (ClientProfileChangeRequestsServiceInstance != null) return ClientProfileChangeRequestsServiceInstance;
                ClientProfileChangeRequestsServiceInstance = new ClientProfileChangeRequestsServiceAdapter(NextAdapterLocator.ClientProfileChangeRequestsServices);
                return ClientProfileChangeRequestsServiceInstance;
            }
        }
        public IClientWeeklyOffDayService ClientWeeklyOffDayServices  
        {
            get
            {
                if (ClientWeeklyOffDayServiceInstance != null) return ClientWeeklyOffDayServiceInstance;
                ClientWeeklyOffDayServiceInstance = new ClientWeeklyOffDayServiceAdapter(NextAdapterLocator.ClientWeeklyOffDayServices);
                return ClientWeeklyOffDayServiceInstance;
            }
        }
        public IClientHolidayCalenderService ClientHolidayCalenderServices  
        {
            get
            {
                if (ClientHolidayCalenderServiceInstance != null) return ClientHolidayCalenderServiceInstance;
                ClientHolidayCalenderServiceInstance = new ClientHolidayCalenderServiceAdapter(NextAdapterLocator.ClientHolidayCalenderServices);
                return ClientHolidayCalenderServiceInstance;
            }
        }
        #endregion
    }
}
