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
    public class BankServiceProxy : WcfAdapterBase<IBankService>, IBankService 
    {
        public BankDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<BankDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<BankDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public BankDto Update(BankDto bankDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(bankDto, userName));
        }

        public BankDto Create(BankDto bankDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(bankDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<BankDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}
