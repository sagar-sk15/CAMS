using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Extension.Services
{
    public class BankServiceAdapter : ServiceAdapterBase<IBankService>, IBankService 
    {
        public BankServiceAdapter(IBankService service)
            : base(service) { }
     
        public BankDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public BankDto Update(BankDto bankDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(bankDto, userName));
        }

        public BankDto Create(BankDto bankDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(bankDto, userName));
        }

        public Common.Dto.EntityDtos<BankDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<BankDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<BankDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
