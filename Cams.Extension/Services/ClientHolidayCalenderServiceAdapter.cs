using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Extension.Services
{
    public class ClientHolidayCalenderServiceAdapter : ServiceAdapterBase<IClientHolidayCalenderService>, IClientHolidayCalenderService 
    {
        public ClientHolidayCalenderServiceAdapter(IClientHolidayCalenderService service)
            : base(service) { }

        public ClientHolidayCalenderDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public ClientHolidayCalenderDto Update(ClientHolidayCalenderDto clientholidaycalenderDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(clientholidaycalenderDto, userName));
        }

        public ClientHolidayCalenderDto Create(ClientHolidayCalenderDto clientholidaycalenderDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(clientholidaycalenderDto, userName));
        }

        public Common.Dto.EntityDtos<ClientHolidayCalenderDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<ClientHolidayCalenderDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientHolidayCalenderDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
