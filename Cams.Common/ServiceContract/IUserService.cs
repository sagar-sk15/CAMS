using System.ServiceModel;
using Cams.Common.Dto.User;
using System.Collections.Generic;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    ///  Exposes the User services
    /// </summary>
    [ServiceContract(Namespace = "http://Cams/userservices/")]
    public interface IUserService :IContract
    {
        [OperationContract]
        UserDto GetById(long id);

        [OperationContract]
        UserDto Update(UserDto user, string userName);

        [OperationContract]
        UserDto Create(UserDto User, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<UserDto> FindAll ();

        [OperationContract]
        UserDto Login(string Username, string Password);

        [OperationContract]
        UserDto GetByUserName(string Username);

        [OperationContract]
        List<string> GetAvailableUsernameList(string FullName, string Username);

        [OperationContract]
        EntityDtos<UserDto> FindBy(Query query, int pageIndex, int recordsPerPage, bool populateChildObjects);

        [OperationContract]
        EntityDtos<UserDto> FindByQuery(Query query, bool populateChildObjects);

        [OperationContract]
        EntityDtos<UserDto> GetAccountManagerList();
    }
}
