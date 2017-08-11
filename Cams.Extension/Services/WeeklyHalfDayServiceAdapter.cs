using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    public class WeeklyHalfDayServiceAdapter : ServiceAdapterBase<IWeeklyHalfDayService>, IWeeklyHalfDayService
    {
        public WeeklyHalfDayServiceAdapter(IWeeklyHalfDayService service)
            : base(service) { }
     
        public WeeklyHalfDayDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public WeeklyHalfDayDto Update(WeeklyHalfDayDto halfdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(halfdayDto, userName));
        }

        public WeeklyHalfDayDto Create(WeeklyHalfDayDto halfdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(halfdayDto, userName));
        }

        public Common.Dto.EntityDtos<WeeklyHalfDayDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<WeeklyHalfDayDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<WeeklyHalfDayDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
