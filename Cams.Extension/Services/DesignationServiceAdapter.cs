using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
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

        public DesignationDto Update(DesignationDto designation, string userName)
        {
            return ExecuteCommand(() => Service.Update(designation, userName));
        }

        public DesignationDto Create(DesignationDto designation, string userName)
        {
            return ExecuteCommand(() => Service.Create(designation, userName));
        }

        public Cams.Common.Dto.EntityDtos<DesignationDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }
        #endregion

    }
}