using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Extension.Services
{
    public class ClientServiceAdapter : ServiceAdapterBase<IClientService>, IClientService  
    {
        public ClientServiceAdapter(IClientService service)
            : base(service) { }

        public ClientDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public ClientDto Update(ClientDto clientDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(clientDto, userName));
        }

        public ClientDto Create(ClientDto clientDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(clientDto, userName));
        }

        public Common.Dto.EntityDtos<ClientDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<ClientDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientDto> FindByQuery(Query query, bool populateChildObjects)
        {
            return ExecuteCommand(() => Service.FindByQuery(query, populateChildObjects));
        }
    }
}
