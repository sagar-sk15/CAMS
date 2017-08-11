using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "https://cams/clientservices")]
    public interface IClientService : IContract
    {
        [OperationContract]
        ClientDto GetById(int id);

        [OperationContract]
        ClientDto Update(ClientDto clientDto, string userName);

        [OperationContract]
        ClientDto Create(ClientDto clientDto, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<ClientDto> FindAll();

        [OperationContract]
        EntityDtos<ClientDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientDto> FindByQuery(Query query, bool populateChildObjects);
    }
}
