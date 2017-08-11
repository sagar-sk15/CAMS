using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Extension.Services
{
    public class SubscriptionMasterServiceAdapter : ServiceAdapterBase<ISubscriptionMasterService>, ISubscriptionMasterService 
    {
        public SubscriptionMasterServiceAdapter(ISubscriptionMasterService service)
            : base(service) { }

        public SubscriptionMasterDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public SubscriptionMasterDto Update(SubscriptionMasterDto subscriptionmasterDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(subscriptionmasterDto, userName));
        }

        public SubscriptionMasterDto Create(SubscriptionMasterDto subscriptionmasterDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(subscriptionmasterDto, userName));
        }

        public Common.Dto.EntityDtos<SubscriptionMasterDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<SubscriptionMasterDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<SubscriptionMasterDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}
