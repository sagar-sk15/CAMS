using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Logging;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Repository;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class CountryMasterService : ServiceBase<Country, CountryDto>, ICountryMasterService
    {
        #region Constructor
        public CountryMasterService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods

        protected override void CheckForValidations(Country entity)
        { }

        protected override void CheckForValidationsWhileUpdating(Country entity)
        {
            throw new NotImplementedException();
        }

        public override CountryDto EntityToEntityDto(Country entity)
        {
            CountryDto CountryDto = AutoMapper.Mapper.Map<Country, CountryDto>(entity);
            if(entity != null)
            {
                CountryDto.States.Clear();
                if(entity.States != null)
                {
                    foreach(State state in entity.States)
                    {
                        StateDto statedto = new StateDto();
                        statedto = AutoMapper.Mapper.Map<State, StateDto>(state);
                        CountryDto.States.Add(statedto);
                    }
                }
            }
            return CountryDto;
        }

        public override Country EntityDtoToEntity(CountryDto entityDto)
        {
            Country countryMaster = AutoMapper.Mapper.Map<CountryDto, Country>(entityDto);
            if (entityDto != null)
            {
                countryMaster.States.Clear();
                if(entityDto.States != null)
                {
                    foreach(StateDto statedto in entityDto.States)
                    {
                        State states = new State();
                        states = AutoMapper.Mapper.Map<StateDto, State>(statedto);
                        countryMaster.States.Add(states);
                    }
                }
                    
            }
            return countryMaster;
        }

        protected override string GetEntityInstanceName(Country entity)
        {
            return entity.CountryName;
        }

        #endregion
       
        #region Implementation of ICountryMasterService

        public CountryDto GetByCountryName(string countryName)
        {
            LoggingFactory.LogInfo("Invoked Country for User");
            return ExecuteCommand(locator => GetByCountrynameCommand(locator,countryName.Trim()));
        }

        private CountryDto GetByCountrynameCommand(IRepositoryLocator locator, string CountryName)
        {
            CountryDto result = null;
            Query query = new Query();
            Criterion criteriaName = new Criterion("CountryName", CountryName, CriteriaOperator.Equal);
            query.Add(criteriaName);
            var country = locator.GetRepository<Country>().FindBy(query);

            if (country.Count() != 0)
                result = EntityToEntityDto(country.FirstOrDefault());

            return result;
        }

        #endregion
    }
}
