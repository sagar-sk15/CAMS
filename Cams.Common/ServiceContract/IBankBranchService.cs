using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://Cams/bankervices/")]
    public interface IBankBranchService : IContract
    {
        [OperationContract]
        BankBranchDto GetById(int id);

        [OperationContract]
        BankBranchDto Update(BankBranchDto bankbranchDto, string userName);

        [OperationContract]
        BankBranchDto Create(BankBranchDto bankbranchDto, string userName);

        [OperationContract]
        EntityDtos<BankBranchDto> FindAll();

        [OperationContract]
        EntityDtos<BankBranchDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<BankBranchDto> FindByQuery(Query query);
    }
}
