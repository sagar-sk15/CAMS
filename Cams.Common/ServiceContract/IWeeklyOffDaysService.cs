using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://Cams/weeklyoffservice/")]
    public interface IWeeklyOffDaysService : IContract
    {
        [OperationContract]
        WeeklyOffDaysDto GetById(int id);

        [OperationContract]
        WeeklyOffDaysDto Update(WeeklyOffDaysDto offdayDto, string userName);

        [OperationContract]
        WeeklyOffDaysDto Create(WeeklyOffDaysDto offdayDto, string userName);

        [OperationContract]
        EntityDtos<WeeklyOffDaysDto> FindAll();

        [OperationContract]
        EntityDtos<WeeklyOffDaysDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<WeeklyOffDaysDto> FindByQuery(Query query);
    }
}
