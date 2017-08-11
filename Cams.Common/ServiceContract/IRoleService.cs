using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the Role services
    /// </summary>
    [ServiceContract(Namespace = "http://cams/roleservices/")]
    public interface IRoleService :IContract
    {
        [OperationContract]
        RoleDto GetById(int id);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<RoleDto> FindAll();

        [OperationContract]
        Cams.Common.Dto.EntityDtos<RoleDto> FindByQuery(Query query);
    }
}
