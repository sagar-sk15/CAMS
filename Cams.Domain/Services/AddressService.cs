using System.ServiceModel;
using AutoMapper;
using Cams.Common.Dto.Address;
using Cams.Common.Message;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Repository;
using Cams.Domain.Entities;
using Cams.Domain.Entities.Masters;
using Cams.Common.Dto.Masters;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class AddressService : ServiceBase<Address,AddressDto>, IAddressService
    {

        private readonly IBusinessNotifier BusinessNotifier;

        public AddressService()
        {
            BusinessNotifier = Container.RequestContext.Notifier;
        }

        #region Implementation of IAddressService

        //public AddressDto GetById(long id)
        //{
        //    return base.GetById(id);
        //}

        //public AddressDto UpdateAddress(AddressDto addressDto)
        //{
        //    return base.Update (addressDto);
        //}

        //public AddressDto CreateNewAddress(AddressDto addressDto)
        //{
        //    return base.CreateNew (addressDto);
        //}

        //public DtoResponse DeleteAddress (long addressId)
        //{
        //    return base.Delete(addressId);
        //}

        //private DtoResponse DeleteAddressCommand (IRepositoryLocator locator, long addressId)
        //{
        //    var address = locator.GetById<Address> (addressId);
        //    BusinessNotifier.AddWarning(BusinessWarningEnum.Default,
        //                                string.Format("Address with id:{0} was deleted",
        //                                address.Id));

        //    locator.Remove(address);
        //    return new DtoResponse();
        //}

        #endregion

        #region Private Methods

        private static AddressDto AddressToAddressDto(Address address)
        {
            return Mapper.Map<Address, AddressDto>(address);
        }

        #endregion

        #region Override the base abstract methods

        protected override void CheckForValidations(Address user)
        {
            user.GetBrokenRules();
            foreach (BusinessRule rule in user.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
        }

        protected override void CheckForValidationsWhileUpdating(Address entity)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetEntityInstanceName(Address entity)
        {
            return entity.AddressLine1;
        }

        public override AddressDto EntityToEntityDto(Address entity)
        {
            AddressDto addressDto = Mapper.Map<Address, AddressDto>(entity);
            if(entity != null)
            {
                if(entity.CityVillage != null)
                {
                    CityVillageService cvService = new CityVillageService();
                    //addressDto.CityVillage = Mapper.Map<CityVillage, CityVillageDto>(entity.CityVillage);
                    addressDto.CityVillage = cvService.EntityToEntityDto(entity.CityVillage);
                    
                }
            }
            return addressDto;
        }

        public override Address EntityDtoToEntity(AddressDto entityDto)
        {
            Address address = Mapper.Map<AddressDto, Address>(entityDto);
            if(entityDto != null)
            {
                if (entityDto.CityVillage != null)
                {
                    CityVillageService cityvillageService = new CityVillageService();
                    CityVillageDto cityvillageDto = cityvillageService.GetById(entityDto.CityVillage.CityVillageId);
                    address.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
                }
                else
                {
                    address.CityVillage = Mapper.Map<CityVillageDto,CityVillage>(entityDto.CityVillage);
                }
            }
            return address;
        }
        #endregion
    }
}
