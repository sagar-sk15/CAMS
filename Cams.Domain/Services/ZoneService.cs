using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Common.Dto.Masters;
using Cams.Domain.Entities.Masters;
using Cams.Common.ServiceContract;
using Cams.Domain.Entities;
using Cams.Common.Message;
using AutoMapper;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ZoneService : ServiceBase<Zone, ZoneDto>, IZoneService
    {
        #region Constructor
        public ZoneService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(Zone zone)
        {
            zone.GetBrokenRules();
            foreach (BusinessRule rule in zone.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsZonePresent(zone, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, ZoneBusinessRule.CheckZonePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(Zone zone)
        {
            zone.GetBrokenRules();
            foreach (BusinessRule rule in zone.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsZonePresent(zone, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, ZoneBusinessRule.CheckZonePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override ZoneDto EntityToEntityDto(Zone entity)
        {
            ZoneDto zoneDto = Mapper.Map<Zone, ZoneDto>(entity);
            return zoneDto;
        }

        public override Zone EntityDtoToEntity(ZoneDto entityDto)
        {
            Zone zone = Mapper.Map<ZoneDto, Zone>(entityDto);
            return zone;
        }

        protected override string GetEntityInstanceName(Zone entity)
        {
            return entity.Name;
        }
        #endregion

        #region Private Methods
        private bool IsZonePresent(Zone zone,bool IsEdit)
        {
            bool checkZonePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.ZONENAME, zone.Name, CriteriaOperator.Equal);
            Criterion criteriaZoneFor = new Criterion(Constants.ZONEFOR, zone.ZoneFor, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, zone.CAId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaZoneFor);
            query.Add(criteriaCAId);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.ZONEID, zone.ZoneId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.QueryOperator = QueryOperator.And;
            var zoneList = ExecuteCommand(locator => locator.GetRepository<Zone>().FindBy(query));
            if(zoneList.Count() != 0)
            {
                checkZonePresence = true;
            }
            return checkZonePresence;
        }
        #endregion
    }
}
