using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Extension.Services
{
    public class BankBranchServiceAdapter : ServiceAdapterBase<IBankBranchService>, IBankBranchService
    {
        public BankBranchServiceAdapter(IBankBranchService service)
            : base(service) { }
     
        public BankBranchDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public BankBranchDto Update(BankBranchDto bankbranchDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(bankbranchDto, userName));
        }

        public BankBranchDto Create(BankBranchDto bankbranchDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(bankbranchDto, userName));
        }

        public Common.Dto.EntityDtos<BankBranchDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<BankBranchDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<BankBranchDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
