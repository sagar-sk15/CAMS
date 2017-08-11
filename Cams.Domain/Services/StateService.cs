using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.Masters;
using Cams.Common.Message;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Domain.Entities.Masters;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class StateService : ServiceBase<State, StateDto>, IStateService
    {
        #region Constructor
        public StateService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(State statesMaster)
        {
            statesMaster.GetBrokenRules();
            foreach (BusinessRule rule in statesMaster.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            if (IsStatePresent(statesMaster))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, MastersBusinessRule.CheckStatePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(State entity)
        {
            throw new NotImplementedException();
        }

        public override StateDto EntityToEntityDto(State entity)
        {
            StateDto stateDto = Mapper.Map<State, StateDto>(entity);
            if(entity != null)
            {
                stateDto.StateInCountry = Mapper.Map<Country, CountryDto>(entity.StateInCountry);
                stateDto.DistrictsInState.Clear();
                if(entity.DistrictsInState != null)
                {
                    foreach (District district in entity.DistrictsInState)
                    {
                        DistrictDto districtdto = new DistrictDto();
                        districtdto = Mapper.Map<District, DistrictDto>(district);
                        stateDto.DistrictsInState.Add(districtdto);
                    }
                }
            }
            return stateDto;
        }

        public override State EntityDtoToEntity(StateDto entityDto)
        {
            State states = Mapper.Map<StateDto, State>(entityDto);
            if (entityDto != null)
            {
                states.StateInCountry = Mapper.Map<CountryDto, Country>(entityDto.StateInCountry);
                states.DistrictsInState.Clear();
                if(entityDto.DistrictsInState != null)
                {
                    foreach (DistrictDto districtdto in entityDto.DistrictsInState)
                    {
                        District district = new District();
                        district = Mapper.Map<DistrictDto, District>(districtdto);
                        states.DistrictsInState.Add(district);
                    }
                }
            }
            return states;
        }

        protected override string GetEntityInstanceName(State entity)
        {
            return entity.RegionName;
        }
        #endregion

        #region Private Methods
        private bool IsStatePresent(State statesMaster)
        {
            bool checkStatePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.REGIONNAME, statesMaster.RegionName, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.QueryOperator = QueryOperator.And;
            var statesMasterList = ExecuteCommand(locator => locator.GetRepository<State>().FindBy(query));
            if (statesMasterList.Count() != 0)
            {
                checkStatePresence = true;
            }
            return checkStatePresence;
        }
        #endregion
    }
}
