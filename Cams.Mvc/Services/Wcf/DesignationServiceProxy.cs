using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services.Wcf
{
    public class DesignationServiceProxy : WcfAdapterBase<IDesignationService>, IDesignationService
    {
        #region Implementation of IDesignationService

        public DesignationDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<DesignationDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public DesignationDto Update(DesignationDto designation, UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Update(designation, userDto));
        }

        public DesignationDto Create(DesignationDto designation, UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Create(designation, userDto));
        }
        #endregion
    }
}