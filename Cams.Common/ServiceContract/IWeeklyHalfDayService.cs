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
    [ServiceContract(Namespace = "http://Cams/weeklyhalfdayservices/")]
    public interface IWeeklyHalfDayService : IContract
    {
        [OperationContract]
        WeeklyHalfDayDto GetById(int id);

        [OperationContract]
        WeeklyHalfDayDto Update(WeeklyHalfDayDto halfdayDto, string userName);

        [OperationContract]
        WeeklyHalfDayDto Create(WeeklyHalfDayDto halfdayDto, string userName);

        [OperationContract]
        EntityDtos<WeeklyHalfDayDto> FindAll();

        [OperationContract]
        EntityDtos<WeeklyHalfDayDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<WeeklyHalfDayDto> FindByQuery(Query query);
    }
}
