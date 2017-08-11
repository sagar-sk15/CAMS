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
    [ServiceContract(Namespace = "http://cams/relationshipservice/")]
    public interface IRelationShipService:IContract
    {
        [OperationContract]
        RelationshipDto GetById(int id);

        [OperationContract]
        RelationshipDto Update(RelationshipDto relationshipDto, string userName);

        [OperationContract]
        RelationshipDto Create(RelationshipDto relationshipDto, string userName);

        [OperationContract]
        EntityDtos<RelationshipDto> FindAll();

        [OperationContract]
        EntityDtos<RelationshipDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<RelationshipDto> FindByQuery(Query query);
    }
}
