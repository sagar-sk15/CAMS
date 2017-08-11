using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using System.ServiceModel;
using Cams.Common.Dto.ClientRegistration;
using Cams.Domain.Entities.ClientRegistration;
using AutoMapper;
using Cams.Domain.Entities;
using Cams.Common.Message;
using Cams.Domain.AppServices;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class SubscriptionMasterService : ServiceBase<SubscriptionMaster, SubscriptionMasterDto>, ISubscriptionMasterService
    {
        #region Constructor
        public SubscriptionMasterService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(SubscriptionMaster subscriptionmaster) 
        {
            subscriptionmaster.GetBrokenRules();
            foreach (BusinessRule rule in subscriptionmaster.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            
        }

        protected override void CheckForValidationsWhileUpdating(SubscriptionMaster subscriptionmaster)
        {
            subscriptionmaster.GetBrokenRules();
            foreach (BusinessRule rule in subscriptionmaster.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            
        }

        public override SubscriptionMasterDto EntityToEntityDto(SubscriptionMaster entity)
        {
            SubscriptionMasterDto subscriptionmasterDto = Mapper.Map<SubscriptionMaster, SubscriptionMasterDto>(entity);
            return subscriptionmasterDto;
        }

        public override SubscriptionMaster EntityDtoToEntity(SubscriptionMasterDto entityDto)
        {
            SubscriptionMaster subscriptionmaster = Mapper.Map<SubscriptionMasterDto, SubscriptionMaster>(entityDto);
            return subscriptionmaster; 
        }

        protected override string GetEntityInstanceName(SubscriptionMaster entity)
        {
            return string.Empty;
        }
        #endregion 
    }
}
