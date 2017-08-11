using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class RelationshipServiceAdapter : ServiceAdapterBase<IRelationShipService>, IRelationShipService
    {
        public RelationshipServiceAdapter(IRelationShipService service)
            : base(service) { }

        public RelationshipDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public RelationshipDto Update(RelationshipDto relationshipDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(relationshipDto, userName));
        }

        public RelationshipDto Create(RelationshipDto relationshipDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(relationshipDto, userName));
        }

        public Common.Dto.EntityDtos<RelationshipDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<RelationshipDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<RelationshipDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
