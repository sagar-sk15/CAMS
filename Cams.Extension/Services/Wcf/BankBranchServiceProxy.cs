using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class BankBranchServiceProxy : WcfAdapterBase<IBankBranchService>, IBankBranchService
    {
        public BankBranchDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<BankBranchDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<BankBranchDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public BankBranchDto Update(BankBranchDto bankbranchDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(bankbranchDto, userName));
        }

        public BankBranchDto Create(BankBranchDto bankbranchDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(bankbranchDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<BankBranchDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}
