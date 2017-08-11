using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.Masters;
using Cams.Domain.Entities.Masters;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Common.Message;
using AutoMapper;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class DistrictService : ServiceBase<District,DistrictDto>,IDistrictService
    {
        #region Constructor
        public DistrictService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(District district)
        {
            district.GetBrokenRules();
            foreach (BusinessRule rule in district.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if(IsDistrictPresent(district))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, DistrictBusinessRule.CheckDistrictPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(District entity)
        {
            throw new NotImplementedException();
        }

        public override DistrictDto EntityToEntityDto(District entity)
        {
            DistrictDto districtDto = Mapper.Map<District, DistrictDto>(entity);
            if(entity != null)
            {
                if(entity.StateOfDistrict != null)
                {
                    districtDto.StateOfDistrict = Mapper.Map<State, StateDto>(entity.StateOfDistrict);
                    if (entity.StateOfDistrict.StateInCountry != null)
                    {
                        districtDto.StateOfDistrict.StateInCountry = Mapper.Map<Country, CountryDto>(entity.StateOfDistrict.StateInCountry);
                    }
                }
                districtDto.CitiesOrVillages.Clear();
                if(entity.CitiesOrVillages != null)
                {
                    foreach (CityVillage cityvillage in entity.CitiesOrVillages)
                    {
                        CityVillageDto cityvillageDto = new CityVillageDto();
                        cityvillageDto = Mapper.Map<CityVillage, CityVillageDto>(cityvillage);
                        districtDto.CitiesOrVillages.Add(cityvillageDto);
                    }
                }
            }
            return districtDto;
        }

        public override District EntityDtoToEntity(DistrictDto entityDto)
        {
            District district = Mapper.Map<DistrictDto, District>(entityDto);
            if(entityDto.StateOfDistrict != null)
            {
                if (entityDto.StateOfDistrict != null)
                {
                    district.StateOfDistrict = Mapper.Map<StateDto, State>(entityDto.StateOfDistrict);
                    if(entityDto.StateOfDistrict.StateInCountry != null)
                    {
                        district.StateOfDistrict.StateInCountry = Mapper.Map<CountryDto, Country>(entityDto.StateOfDistrict.StateInCountry);
                    }
                }
                district.CitiesOrVillages.Clear();
                if(entityDto.CitiesOrVillages != null)
                {
                    foreach (CityVillageDto cityvillagedto in entityDto.CitiesOrVillages)
                    {
                        CityVillage cityvillage = new CityVillage();
                        cityvillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillagedto);
                        district.CitiesOrVillages.Add(cityvillage);
                    }
                }
            }
            return district;
        }

        protected override string GetEntityInstanceName(District entity)
        {
            return entity.DistrictName;
        }
        #endregion

        #region Private Methods

        private bool IsDistrictPresent(District district)
        {
            bool checkDistrictPresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.DISTRICTNAME, district.DistrictName, CriteriaOperator.Equal);
            Criterion criteriaStateId = new Criterion(Constants.STATEID,district.StateOfDistrict.StateId,CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaStateId);
            query.QueryOperator = QueryOperator.And;
            var DistrictList = ExecuteCommand(locator => locator.GetRepository<District>().FindBy(query));
            if (DistrictList.Count() != 0)
            {
                checkDistrictPresence = true;
            }
            return checkDistrictPresence;
        }
        #endregion
    }
}
