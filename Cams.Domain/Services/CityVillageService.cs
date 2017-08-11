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
using Cams.Common.Dto.Address;
using Cams.Common.Dto;
using Cams.Domain.Repository;
using Cams.Common.Dto.User;
using Cams.Common.Logging;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class CityVillageService : ServiceBase<CityVillage, CityVillageDto>, ICityVillageService
    {
        #region Constructor
        public CityVillageService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(CityVillage cityvillage)
        {
            cityvillage.GetBrokenRules();
            foreach (BusinessRule rule in cityvillage.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsCityVillagePresent(cityvillage))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation,CityVillageBusinessRule.CheckCityVillagePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(CityVillage cityvillage) 
        {
            cityvillage.GetBrokenRules();
            foreach (BusinessRule rule in cityvillage.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsCityVillagePresent(cityvillage))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, CityVillageBusinessRule.CheckCityVillagePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override CityVillageDto EntityToEntityDto(CityVillage entity)
        {
            CityVillageDto cityvillageDto = Mapper.Map<CityVillage, CityVillageDto>(entity);
            if(entity != null)
            {
                if(entity.DistrictOfCityVillage != null)
                {
                    cityvillageDto.DistrictOfCityVillage = Mapper.Map<District, DistrictDto>(entity.DistrictOfCityVillage);
                    if (entity.DistrictOfCityVillage.StateOfDistrict != null)
                    {
                        cityvillageDto.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<State, StateDto>(entity.DistrictOfCityVillage.StateOfDistrict);
                        if(entity.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                        {
                            cityvillageDto.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                                Mapper.Map<Country, CountryDto>(entity.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                        }
                    }
                }
                //cityvillageDto.Addresses.Clear();
                //if(entity.Addresses != null)
                //{
                //    foreach (Address address in entity.Addresses)
                //    {
                //        AddressDto addressDto = new AddressDto();
                //        addressDto = Mapper.Map<Address, AddressDto>(address);
                //        cityvillageDto.Addresses.Add(addressDto);
                //    }
                //}
            }
            return cityvillageDto;
        }

        public override CityVillage EntityDtoToEntity(CityVillageDto entityDto)
        {
            CityVillage cityvillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto);
            if(entityDto != null)
            {
                #region CityorVillage
                if(entityDto.CityVillageId != 0)
                {
                    CityVillageService cvService = new CityVillageService();
                    CityVillageDto cvDto = cvService.GetById(entityDto.CityVillageId);
                    bool isDirty = CityVillage.IsDirty(entityDto, cvDto);
                    if (isDirty)
                    {
                        if (entityDto.CAId != null && (entityDto.CAId != cvDto.CAId))
                        {
                            entityDto.CityVillageId = 0;
                            entityDto.BaseCityVillageId = cvDto.CityVillageId;
                            cityvillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto);
                        }
                        else if (entityDto.CAId == cvDto.CAId)
                        {
                            cityvillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto);
                        }
                        else
                        {
                            cityvillage = Mapper.Map<CityVillageDto, CityVillage>(cvDto);
                        }                        
                    }
                }
                #endregion 
                
                #region District

                #region Old Code of DistrictOfCityVillage
                //if (entityDto.DistrictOfCityVillage != null)
                //{
                //    cityvillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(entityDto.DistrictOfCityVillage);
                //    if(entityDto.DistrictOfCityVillage.StateOfDistrict != null)
                //    {
                //        cityvillage.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<StateDto, State>(entityDto.DistrictOfCityVillage.StateOfDistrict);
                //        if(entityDto.DistrictOfCityVillage.StateOfDistrict.StateInCountry!=null)
                //        {
                //            cityvillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                //                Mapper.Map<CountryDto, Country>(entityDto.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                //        }
                //    }
                //}

                #endregion 

                if (entityDto.DistrictOfCityVillage != null && entityDto.DistrictOfCityVillage.DistrictId != 0)
                {
                    DistrictService districtservice = new DistrictService();
                    DistrictDto districtDto = districtservice.GetById(entityDto.DistrictOfCityVillage.DistrictId);
                    cityvillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(districtDto);
                }
                else
                {
                    cityvillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(entityDto.DistrictOfCityVillage);
                }
                #endregion

                #region Addresses
                cityvillage.Addresses.Clear();
                if(entityDto.Addresses!=null)
                {
                    foreach(AddressDto addressdto in entityDto.Addresses)
                    {
                        Address address = new Address();
                        address = Mapper.Map<AddressDto, Address>(addressdto);
                        cityvillage.Addresses.Add(address);
                    }
                }
                #endregion 
            }
            return cityvillage;
        }

        protected override string GetEntityInstanceName(CityVillage entity)
        {
            return entity.Name;
        }

        public override CityVillageDto UpdateCommand(IRepositoryLocator locator, CityVillageDto entityDto, string userName)
        {
            string description = string.Empty;
            CityVillage entityInstance = EntityDtoToEntity(entityDto);
            if (entityInstance.CityVillageId == 0)
            {
                CheckForValidations(entityInstance);
            }
            else
            {
                CheckForValidationsWhileUpdating(entityInstance);
            }
            if ((AllowSaveWithWarnings && IsValidForBasicMandatoryFields) || IsValid)
            {
                if (entityInstance.CityVillageId == 0)
                {
                    locator.GetRepository<CityVillage>().Add(entityInstance);
                    LoggingFactory.LogInfo("Created " + typeof(CityVillage).Name + " : Id : ");
                    description = "Created " + typeof(CityVillage).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
                else
                {
                    locator.GetRepository<CityVillage>().Update(entityInstance);
                    description = "Updated " + typeof(CityVillage).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
            }
            else
            {
                description = "Failed to create " + typeof(CityVillage).Name + " : " + GetEntityInstanceName(entityInstance);
                LoggingFactory.LogInfo(description);
            }
            return EntityToEntityDto(entityInstance);
        }

        public override EntityDtos<CityVillageDto> FindByQueryCommand(IRepositoryLocator locator, Query query)
        {
            Criterion criteriaBaseCVIdNotNull = new Criterion(Constants.BASECVID, null, CriteriaOperator.IsNotNullOrZero);
            Criterion criteriaCAId = new Criterion(Constants.CAID, query.CAId, CriteriaOperator.Equal);

            Query query1 = new Query();
            query1.Add(criteriaCAId);
            query1.Add(criteriaBaseCVIdNotNull);
            IQueryable<CityVillage> caCVListWithBaseCVId = locator.GetRepository<CityVillage>().FindBy(query1);

            IQueryable<CityVillage> CityVillageList = locator.GetRepository<CityVillage>().FindBy(query);
            //CityVillageList = CityVillageList.Except(caCVListWithBaseCVId);

            var itemIds = caCVListWithBaseCVId.Select(x => x.BaseCityVillageId).ToArray();
            CityVillageList = CityVillageList.Where(x => !itemIds.Contains(x.CityVillageId));

            IList<CityVillageDto> allDto = new List<CityVillageDto>();
            foreach (CityVillage entity in CityVillageList)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            var result = new EntityDtos<CityVillageDto> { Entities = allDto };
            result.TotalRecords = locator.GetRepository<CityVillage>().GetCount(query);
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No records were found");
            return result;
        }
        #endregion

        #region Private Methods
        
        #region old IsCityVillagePresent method
        //private bool IsCityVillagePresent1(CityVillage cityvillage)
        //{
        //    bool checkCityVillagePresence = false;
        //    Query query = new Query();
        //    Criterion criteriaName = new Criterion(Constants.CITYVILLAGENAME, cityvillage.Name, CriteriaOperator.Equal);
        //    Criterion criteriaType = new Criterion(Constants.CITYORVILLAGE, cityvillage.CityOrVillage, CriteriaOperator.Equal);
        //    Criterion criteriaDistrictId = new Criterion("Dt.DistrictId", cityvillage.DistrictOfCityVillage.DistrictId, CriteriaOperator.Equal);
        //    query.Add(criteriaName);
        //    query.Add(criteriaType);
        //    query.Add(criteriaDistrictId);
        //    query.AddAlias(new Alias("Dt", "DistrictOfCityVillage"));
        //    query.QueryOperator = QueryOperator.And;
        //    var cityvillageList = ExecuteCommand(locator => locator.GetRepository<CityVillage>().FindBy(query));
        //    if (cityvillageList.Count() != 0)
        //    {
        //        checkCityVillagePresence = true;
        //    }
        //    return checkCityVillagePresence;
        //}
        #endregion 

        private bool IsCityVillagePresent(CityVillage cityvillage)
        {
            bool checkCityVillagePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.CITYVILLAGENAME, cityvillage.Name, CriteriaOperator.Equal);
            Criterion criteriaType = new Criterion(Constants.CITYORVILLAGE, cityvillage.CityOrVillage, CriteriaOperator.Equal);
            Criterion criteriaDistrictId = new Criterion("Dt.DistrictId", cityvillage.DistrictOfCityVillage.DistrictId, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, cityvillage.CAId, CriteriaOperator.Equal);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            query.AddAlias(new Alias("Dt", "DistrictOfCityVillage"));

            if (cityvillage.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.Add(criteriaDistrictId);
                query.Add(criteriaType);
                query.QueryOperator = QueryOperator.And;
                var cvlist = FindByQuery(query);
                checkCityVillagePresence = (cvlist.TotalRecords != 0) ? true : false;
                //For Update Scenario
                if (checkCityVillagePresence && cvlist.TotalRecords == 1 && cvlist.Entities.ToList().FirstOrDefault().CityVillageId == cityvillage.CityVillageId)
                    checkCityVillagePresence = false;
            }
            else
            {
                query.Add(criteriaName);
                query.Add(criteriaDistrictId);
                query.Add(criteriaType);

                Query subquery = new Query();
                subquery.Add(criteriaCAId);
                subquery.Add(criteriaCAIdNull);
                subquery.QueryOperator = QueryOperator.Or;
                query.AddSubQuery(subquery);

                query.QueryOperator = QueryOperator.And;
                query.CAId = (int)cityvillage.CAId;

                var cvlist = FindByQuery(query);
                IEnumerable<CityVillageDto> cvDtoList = cvlist.Entities.AsEnumerable();
                checkCityVillagePresence = (cvDtoList.Count() != 0) ? true : false;
                //For Update Scenario
                if (cvDtoList.Count() == 1 && cvDtoList.FirstOrDefault().CityVillageId == cityvillage.CityVillageId)
                    checkCityVillagePresence = false;
                if (cvDtoList.Count() == 1 && cvDtoList.FirstOrDefault().CityVillageId == cityvillage.BaseCityVillageId)
                    checkCityVillagePresence = false;
            }
            return checkCityVillagePresence;
        }

        /// <summary>
        /// LoggActivity method log the information of the user in ActivityLogDto and pass it to create method of ActivityLogService.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="loggedInUserDto"></param>
        private void LoggActivity(string description, string userName)
        {
            ActivityLogService activityLogService;
            Cams.Common.Dto.Log.ActivityLogDto activityLogDto;

            activityLogDto = new Cams.Common.Dto.Log.ActivityLogDto();
            activityLogDto.LoggedBy = userName;
            activityLogDto.LoggedDate = DateTime.Now;
            activityLogDto.Description = description;
            activityLogDto.ActivityRelatedTo = typeof(CityVillage).Name;

            activityLogService = new ActivityLogService();
            activityLogService.Create(activityLogDto, userName);
        }
        #endregion
    }
}
