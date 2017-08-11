using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "https://cams/clientholidaycalenderservices")]
    public interface IClientHolidayCalenderService : IContract
    {
        [OperationContract]
        ClientHolidayCalenderDto GetById(int id);

        [OperationContract]
        ClientHolidayCalenderDto Update(ClientHolidayCalenderDto clientholidaycalenderDto, string userName);

        [OperationContract]
        ClientHolidayCalenderDto Create(ClientHolidayCalenderDto clientholidaycalenderDto, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<ClientHolidayCalenderDto> FindAll();

        [OperationContract]
        EntityDtos<ClientHolidayCalenderDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientHolidayCalenderDto> FindByQuery(Query query);
    }
}
