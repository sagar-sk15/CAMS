using System.ServiceModel;
using Cams.Common.Dto.User;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://Cams/designationervices/")]
    public interface IDesignationService : IContract
    {
        [OperationContract]
        DesignationDto GetById(int id);

        [OperationContract]
        DesignationDto Update(DesignationDto Designation, string userName);

        [OperationContract]
        DesignationDto Create(DesignationDto Designation, string userName);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<DesignationDto> FindAll();
    }
}
