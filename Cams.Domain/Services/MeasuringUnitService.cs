using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Message;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Domain.Entities.ClientMasters;
using AutoMapper;
using System.ServiceModel;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class MeasuringUnitService : ServiceBase<MeasuringUnit, MeasuringUnitDto>, IMeasuringUnitService
    {
        #region Constructor
        public MeasuringUnitService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(MeasuringUnit measuringunit)
        {
            measuringunit.GetBrokenRules();
            foreach (BusinessRule rule in measuringunit.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            //check is Equivalent Unit with the same Unit exists
            Query query = new Query();
            query.Add(new Criterion(Constants.MEASUREMENTUNIT, measuringunit.MeasurementUnit, CriteriaOperator.Equal));
            var result = ExecuteCommand(loc => loc.GetRepository<MeasuringUnit>().FindBy(query));
            if (result.Count() != 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, ClientMasterBusinessRule.CheckMUMeasurementUnit.Rule);
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(MeasuringUnit measuringunit)
        {
            measuringunit.GetBrokenRules();
            foreach (BusinessRule rule in measuringunit.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            //check is Equivalent Unit with the same Unit exists
            Query query = new Query();
            query.Add(new Criterion(Constants.MEASUREMENTUNIT, measuringunit.MeasurementUnit, CriteriaOperator.Equal));
            query.Add(new Criterion(Constants.UNITID, measuringunit.UnitId, CriteriaOperator.NotEqual));
            var result = ExecuteCommand(loc => loc.GetRepository<MeasuringUnit>().FindBy(query));
            if (result.Count() != 0)
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, ClientMasterBusinessRule.CheckMUMeasurementUnit.Rule);
                base.IsValid = false;
                base.IsValidForBasicMandatoryFields = false;
            }
        }

        public override MeasuringUnitDto EntityToEntityDto(MeasuringUnit entity)
        {
            MeasuringUnitDto measuringunitDto = Mapper.Map<MeasuringUnit, MeasuringUnitDto>(entity);
            return measuringunitDto;
        }

        public override MeasuringUnit EntityDtoToEntity(MeasuringUnitDto entityDto)
        {
            MeasuringUnit measuringunit = Mapper.Map<MeasuringUnitDto, MeasuringUnit>(entityDto);
            return measuringunit;
        }

        protected override string GetEntityInstanceName(MeasuringUnit entity)
        {
            return entity.MeasurementUnit;
        }
        #endregion
    }
}
