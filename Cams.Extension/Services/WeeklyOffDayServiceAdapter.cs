using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    public class WeeklyOffDayServiceAdapter : ServiceAdapterBase<IWeeklyOffDaysService>, IWeeklyOffDaysService
    {
        public WeeklyOffDayServiceAdapter(IWeeklyOffDaysService service)
            : base(service) { }

        public WeeklyOffDaysDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public WeeklyOffDaysDto Update(WeeklyOffDaysDto offdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(offdayDto, userName));
        }

        public WeeklyOffDaysDto Create(WeeklyOffDaysDto offdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(offdayDto, userName));
        }

        public Common.Dto.EntityDtos<WeeklyOffDaysDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<WeeklyOffDaysDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<WeeklyOffDaysDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
