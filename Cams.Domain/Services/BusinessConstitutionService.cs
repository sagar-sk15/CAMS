using System.ServiceModel;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using AutoMapper;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class BusinessConstitutionService : ServiceBaseReadOnly<BusinessConstitution, BusinessConstitutionDto>, IBusinessConstitutionService
    {
        #region Constructor
        public BusinessConstitutionService()
        {

        }
        #endregion

        #region Override the base abstract methods

        public override BusinessConstitution EntityDtoToEntity(BusinessConstitutionDto entityDto)
        {
            BusinessConstitution businessconstitution  = Mapper.Map<BusinessConstitutionDto, BusinessConstitution>(entityDto);
            //if (entityDto != null)
            //{
            //    businessconstitution.BusinessConstitutionOfClients.Clear();
            //    if (entityDto.BusinessConstitutionOfClients != null)
            //    {
            //        foreach (ClientDto clientDto in entityDto.BusinessConstitutionOfClients)
            //        {
            //            Client client = new Client();
            //            client = Mapper.Map<ClientDto, Client>(clientDto);
            //            businessconstitution.BusinessConstitutionOfClients.Add(client);
            //        }
            //    }
            //}
            return businessconstitution;
        }

        public override BusinessConstitutionDto EntityToEntityDto(BusinessConstitution entity)
        {
            BusinessConstitutionDto businessconstitutionDto = Mapper.Map<BusinessConstitution, BusinessConstitutionDto>(entity);
            //if (entity != null)
            //{
            //    businessconstitutionDto.BusinessConstitutionOfClients.Clear();
            //    if (entity.BusinessConstitutionOfClients != null)
            //    {
            //        foreach (Client client in entity.BusinessConstitutionOfClients) 
            //        {
            //            ClientDto clientDto = new ClientDto();
            //            clientDto = Mapper.Map<Client, ClientDto>(client);
            //            businessconstitutionDto.BusinessConstitutionOfClients.Add(clientDto);
            //        }
            //    }
            //}
            return businessconstitutionDto;
        }
        #endregion 
    }
}
