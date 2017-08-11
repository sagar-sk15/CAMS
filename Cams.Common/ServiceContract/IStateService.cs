using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://Cams/statesmasterservices/")]
    public interface IStateService : IContract
    {
        [OperationContract]
        StateDto GetById(int id);

        [OperationContract]
        StateDto Update(StateDto StateDto, string userName);

        [OperationContract]
        StateDto Create(StateDto StateDto, string userName);

        [OperationContract]
        EntityDtos<StateDto> FindAll();

        [OperationContract]
        EntityDtos<StateDto> FindBy(Query query, int pageIndex, int recordsPerPage);

    }
}
