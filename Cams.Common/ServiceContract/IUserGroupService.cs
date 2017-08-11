using System.ServiceModel;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the UserGroup services
    /// </summary>
    [ServiceContract(Namespace = "http://Cams/usergroupservices/")]
    public interface IUserGroupService : IContract
    {
        [OperationContract]
        UserGroupDto GetById(int id);

        [OperationContract]
        UserGroupDto Update(UserGroupDto UserGroup, string userName);

        [OperationContract]
        UserGroupDto Create(UserGroupDto UserGroup, string userName);

        [OperationContract]
        EntityDtos<UserGroupDto> FindAll();

        [OperationContract]
        EntityDtos<UserGroupDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<UserGroupDto> FindByQuery(Query query);
    }
}
