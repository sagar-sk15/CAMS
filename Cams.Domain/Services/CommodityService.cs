using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Message;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Domain.Entities.ClientMasters;
using AutoMapper;
using System.ServiceModel;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class CommodityService : ServiceBase<Commodity, CommodityDto>, ICommodityService
    {
        #region Constructor
        public CommodityService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(Commodity commodity)
        {
            commodity.GetBrokenRules();
            foreach (BusinessRule rule in commodity.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBotanicalNamePresent(commodity, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, CommodityBusinessRule.CheckBotanicalNamePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsCommodityPresent(commodity, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, CommodityBusinessRule.CheckCommodityPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(Commodity commodity)
        {
            commodity.GetBrokenRules();
            foreach (BusinessRule rule in commodity.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBotanicalNamePresent(commodity, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, CommodityBusinessRule.CheckBotanicalNamePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsCommodityPresent(commodity, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, CommodityBusinessRule.CheckCommodityPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override CommodityDto EntityToEntityDto(Commodity entity)
        {
            CommodityDto commodityDto = Mapper.Map<Commodity, CommodityDto>(entity);
            if (entity != null)
            {
                commodityDto.CommoditiesInCommodityClass = Mapper.Map<CommodityClass, CommodityClassDto>(entity.CommoditiesInCommodityClass);
            }
            return commodityDto;
        }

        public override Commodity EntityDtoToEntity(CommodityDto entityDto)
        {
            Commodity commodity = Mapper.Map<CommodityDto, Commodity>(entityDto);
            if (entityDto != null)
            {
                if (entityDto.CommoditiesInCommodityClass != null && entityDto.CommoditiesInCommodityClass.CommodityClassId != 0)
                {
                    CommodityClassService commodityclassService = new CommodityClassService();
                    CommodityClassDto commodityclassDto = commodityclassService.GetById(entityDto.CommoditiesInCommodityClass.CommodityClassId);
                    commodity.CommoditiesInCommodityClass = Mapper.Map<CommodityClassDto, CommodityClass>(commodityclassDto);
                }
                else
                {
                    commodity.CommoditiesInCommodityClass = Mapper.Map<CommodityClassDto, CommodityClass>(entityDto.CommoditiesInCommodityClass);
                }
            }
            return commodity;
        }

        protected override string GetEntityInstanceName(Commodity entity)
        {
            return entity.Name;
        }
        #endregion

        #region Private Methods
        private bool IsCommodityPresent(Commodity commodity,bool IsEdit)
        {
            bool checkCommodityPresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.COMMODITYNAME, commodity.Name, CriteriaOperator.Equal);
            Criterion criteriaClassID = new Criterion("commodityclass.CommodityClassId", commodity.CommoditiesInCommodityClass.CommodityClassId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaClassID);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.COMMODITYID, commodity.CommodityId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.AddAlias( new Alias("commodityclass", "CommoditiesInCommodityClass"));
            query.QueryOperator = QueryOperator.And;
            var commodityList = ExecuteCommand(locator => locator.GetRepository<Commodity>().FindBy(query));
            if (commodityList.Count() != 0)
            {
                checkCommodityPresence = true;
            }
            return checkCommodityPresence;
        }

        private bool IsBotanicalNamePresent(Commodity commodity, bool IsEdit)
        {
            bool checkBotanicalName = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.BOTANICALNAME, commodity.BotanicalName, CriteriaOperator.Equal);
            query.Add(criteriaName);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.COMMODITYID, commodity.CommodityId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.QueryOperator = QueryOperator.And;
            var botanicalNameList = ExecuteCommand(locator => locator.GetRepository<Commodity>().FindBy(query));
            if (botanicalNameList.Count() != 0)
            {
                checkBotanicalName = true;
            }
            return checkBotanicalName;
        }
        #endregion
    }
}
