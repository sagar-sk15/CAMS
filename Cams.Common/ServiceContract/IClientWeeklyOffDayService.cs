using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "https://cams/clientweeklyoffdayservices")]
    public interface IClientWeeklyOffDayService : IContract
    {
        [OperationContract]
        ClientWeeklyOffDayDto GetById(int id);

        [OperationContract]
        ClientWeeklyOffDayDto Update(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName);

        [OperationContract]
        ClientWeeklyOffDayDto Create(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<ClientWeeklyOffDayDto> FindAll();

        [OperationContract]
        EntityDtos<ClientWeeklyOffDayDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientWeeklyOffDayDto> FindByQuery(Query query);
    }
}
