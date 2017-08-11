using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services
{
    public class DesignationServiceAdapter : ServiceAdapterBase<IDesignationService>, IDesignationService
    {
        public DesignationServiceAdapter(IDesignationService service)
            : base(service) { }

        #region Implementation of IDesignationService

        public DesignationDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public DesignationDto Update(DesignationDto designation, UserDto userDto)
        {
            return ExecuteCommand(() => Service.Update(designation, userDto));
        }

        public DesignationDto Create(DesignationDto designation, UserDto userDto)
        {
            return ExecuteCommand(() => Service.Create(designation, userDto));
        }

        public Cams.Common.Dto.EntityDtos<DesignationDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }
        #endregion

    }
}