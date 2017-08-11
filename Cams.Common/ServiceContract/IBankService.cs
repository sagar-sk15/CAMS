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
    public interface IBankService : IContract
    {
        [OperationContract]
        BankDto GetById(int id);

        [OperationContract]
        BankDto Update(BankDto bankDto, string userName);

        [OperationContract]
        BankDto Create(BankDto bankDto, string userName);

        [OperationContract]
        EntityDtos<BankDto> FindAll();

        [OperationContract]
        EntityDtos<BankDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<BankDto> FindByQuery(Query query);
    }
}
