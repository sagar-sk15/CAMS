using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class ClientHolidayCalenderServiceProxy : WcfAdapterBase<IClientHolidayCalenderService>, IClientHolidayCalenderService   
    {
        public ClientHolidayCalenderDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<ClientHolidayCalenderDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<ClientHolidayCalenderDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage)); 
        }

        public ClientHolidayCalenderDto Update(ClientHolidayCalenderDto clienthollidaycalenderDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(clienthollidaycalenderDto, userName));
        }

        public ClientHolidayCalenderDto Create(ClientHolidayCalenderDto clienthollidaycalenderDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(clienthollidaycalenderDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<ClientHolidayCalenderDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}
