using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using Cams.Common;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.Masters;
using Cams.Common.Message;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class APMCService : ServiceBase<APMC, APMCDto>, IAPMCService
    {
        private readonly IBusinessNotifier BusinessNotifier;

        #region Constructor
        public APMCService()
        {
            BusinessNotifier = Container.RequestContext.Notifier;
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Overrides of ServiceBase<APMC,APMCDto>

        protected override void CheckForValidations(APMC apmcMaster)
        {
            apmcMaster.GetBrokenRules();
            foreach (BusinessRule rule in apmcMaster.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            if (IsAPMCPresent(apmcMaster, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, "APMC Present");
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(APMC apmcMaster)
        {
            apmcMaster.GetBrokenRules();
            foreach (BusinessRule rule in apmcMaster.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);

            if (IsAPMCPresent(apmcMaster, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, "APMC Present");
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override APMCDto EntityToEntityDto(APMC entity)
        {
            APMCDto apmcDto = Mapper.Map<APMC, APMCDto>(entity);

            #region APMCAddress
            if (entity.Address != null)
            {
                apmcDto.Address = Mapper.Map<Address, AddressDto>(entity.Address);

                if (entity.Address.CityVillage != null)
                {
                    apmcDto.Address.CityVillage = Mapper.Map<CityVillage, CityVillageDto>(entity.Address.CityVillage);
                    if (entity.Address.CityVillage.DistrictOfCityVillage != null)
                    {
                        apmcDto.Address.CityVillage.DistrictOfCityVillage = Mapper.Map<District, DistrictDto>(entity.Address.CityVillage.DistrictOfCityVillage);
                        if (entity.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                        {
                            apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict =
                               Mapper.Map<State, StateDto>(entity.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                            if (entity.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                                apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry =
                                     Mapper.Map<Country, CountryDto>(entity.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry);
                        }
                    }
                }
            }
            #endregion

            #region APMC ContactDetails
            apmcDto.ContactNos.Clear();
            if (entity.ContactNos != null)
            {
                foreach (ContactDetails usercontactdetails in entity.ContactNos)
                {
                    ContactDetailsDto contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(usercontactdetails);
                    apmcDto.ContactNos.Add(contactdto);
                }
            }
            #endregion

            #region APMC Of Clients
            apmcDto.APMCOfClients.Clear();
            if (entity.APMCOfClients != null)
            {
                foreach (Client client in entity.APMCOfClients)
                {
                    ClientDto clientDto = Mapper.Map<Client, ClientDto>(client);
                    apmcDto.APMCOfClients.Add(clientDto);
                }
            }
            #endregion

            return apmcDto;
        }

        public override APMC EntityDtoToEntity(APMCDto entityDto)
        {
            APMC apmc = Mapper.Map<APMCDto, APMC>(entityDto);
            if (entityDto != null)
            {
                #region Apmc Address

                apmc.Address = Mapper.Map<AddressDto, Address>(entityDto.Address);

                if (entityDto.Address != null)
                {
                    if (entityDto.Address.CityVillage != null && entityDto.Address.CityVillage.CityVillageId != 0)
                    {
                        CityVillageService cityvillageService = new CityVillageService();
                        CityVillageDto cityvillageDto = cityvillageService.GetById(entityDto.Address.CityVillage.CityVillageId);
                        apmc.Address.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
                    }
                    else
                    {
                        apmc.Address.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto.Address.CityVillage);
                    }
                }

                #endregion

                #region Apmc ContactDetails
                apmc.ContactNos.Clear();
                if (entityDto.ContactNos != null)
                {
                    foreach (ContactDetailsDto contactdetailsdto in entityDto.ContactNos)
                    {
                        ContactDetails apmccontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                        apmc.ContactNos.Add(apmccontactdetails);
                    }
                }
                #endregion

                #region APMC Of Clients
                apmc.APMCOfClients.Clear();
                if (entityDto.APMCOfClients != null)
                {
                    foreach (ClientDto clientDto in entityDto.APMCOfClients)
                    {
                        Client client = Mapper.Map<ClientDto, Client>(clientDto);
                        apmc.APMCOfClients.Add(client);
                    }
                }
                #endregion
            }
            return apmc;
        }

        protected override string GetEntityInstanceName(APMC entity)
        {
            return entity.Name;
        }

        #endregion

        #region Private Methods
        private bool IsAPMCPresent(APMC apmcMaster,bool IsEdit)
        {
            bool checkapmcPresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion("Name", apmcMaster.Name, CriteriaOperator.Equal);
            Criterion criteriaType = new Criterion("cv.Name", apmcMaster.Address.CityVillage.Name, CriteriaOperator.Equal);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.APMCID, apmcMaster.APMCId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaName);
            query.Add(criteriaType);
            query.AddAlias(new Alias("ad", "Address"));
            query.AddAlias(new Alias("cv", "ad.CityVillage"));
            query.QueryOperator = QueryOperator.And;
            var apmcMasterList = ExecuteCommand(locator => locator.GetRepository<APMC>().FindBy(query));
            if (apmcMasterList.Count() != 0)
            {
                checkapmcPresence = true;
            }
            return checkapmcPresence;
        }
        #endregion
    }
}
