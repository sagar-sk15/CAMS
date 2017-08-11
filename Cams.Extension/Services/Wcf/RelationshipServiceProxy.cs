using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class RelationshipServiceProxy : WcfAdapterBase<IRelationShipService>, IRelationShipService
    {
        public RelationshipDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<RelationshipDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<RelationshipDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public RelationshipDto Update(RelationshipDto relationshipDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(relationshipDto, userName));
        }

        public RelationshipDto Create(RelationshipDto relationshipDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(relationshipDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<RelationshipDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
    }
}
