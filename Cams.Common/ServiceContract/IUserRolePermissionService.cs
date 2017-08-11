using System.ServiceModel;
using Cams.Common.Dto.User;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the UserRolePermission services
    /// </summary>
    [ServiceContract(Namespace = "http://Cams/userrolepermissionservices/")]
    public interface IUserRolePermissionService : IContract
    {
        [OperationContract]
        UserRolePermissionDto GetById(long id);

        [OperationContract]
        UserRolePermissionDto Update(UserRolePermissionDto UserRolePermission, string userName);

        [OperationContract]
        UserRolePermissionDto Create(UserRolePermissionDto UserRolePermission, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<UserRolePermissionDto> FindAll();
    }
}
