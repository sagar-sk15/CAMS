using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Common.ServiceContract
{
    public interface IContractLocator
    {
        IUserService UserServices { get; }
        IAddressService AddressServices { get; }
        IRoleService RoleServices { get; }
        IUserGroupService UserGroupServices { get; }
        IDesignationService DesignationServices { get; }
        IUserRolePermissionService UserRolePermissionServices { get; }
        ICountryMasterService CountryServices { get; }
        IStateService StateServices { get; }
        IDistrictService DistrictServices { get; }
        ICityVillageService CityVillageServices { get; }
        IZoneService ZoneServices { get; } 
        IRelationShipService RelationshipServices {get;}
        ICommodityClassService CommodityClassServices { get; }
        ICommodityService CommodityServices { get; }
        ILabourChargeTypeService LabourChargeTypeServices { get; }
        IChargesPayableToService ChargesPayableToServices { get; }
        IMeasuringUnitService MeasuringUnitServices { get; }
        IBankService BankServices { get; }
        IBankBranchService BankBranchServices { get; }
        IWeeklyHalfDayService WeeklyHalfDayServices { get; }
        IWeeklyOffDaysService WeeklyOffDaysServices { get; }
        IAPMCService APMCServices { get; }
        IBusinessConstitutionService BusinessConstitutionServices { get; }
        ISubscriptionMasterService SubscriptionMasterServices { get; }
        IClientService ClientServices { get; }
        IClientBusinessConstitutionHistoryService ClientBusinessConstitutionHistoryServices { get; }
        IClientPartnerHistoryService ClientPartnerHistoryServices { get; }
        IClientCommoditiesHistoryService ClientCommoditiesHistoryServices { get; }
        IClientPhoneChargesHistoryService ClientPhoneChargesHistoryServices { get; }
        IClientWeeklyOffDayHistoryService ClientWeeklyOffDayHistoryServices { get; }
        IClientProfileChangeRequestsService ClientProfileChangeRequestsServices { get; }
        IClientWeeklyOffDayService ClientWeeklyOffDayServices { get; }
        IClientHolidayCalenderService ClientHolidayCalenderServices { get; }
    }
}
