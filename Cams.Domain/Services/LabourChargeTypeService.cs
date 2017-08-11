using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Common.Message;
using Cams.Common.Querying;
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
    public class LabourChargeTypeService : ServiceBase<LabourChargeType, LabourChargeTypeDto>, ILabourChargeTypeService
    {
        #region Constructor
        public LabourChargeTypeService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(LabourChargeType labourchargetype)
        {
            labourchargetype.GetBrokenRules();
            foreach (BusinessRule rule in labourchargetype.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsLabourChargeTypePresent(labourchargetype, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, LabourChargeTypeBusinessRule.CheckLabourChargeTypePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            //if (!IsAllowed(labourchargetype))
            //{
            //    Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, LabourChargeTypeBusinessRule.CheckActiveLabourChargeTypes.Rule);
            //    base.IsValid = false;
            //    base.AllowSaveWithWarnings = false;
            //}
        }

        protected override void CheckForValidationsWhileUpdating(LabourChargeType labourchargetype)
        {
            labourchargetype.GetBrokenRules();
            foreach (BusinessRule rule in labourchargetype.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsLabourChargeTypePresent(labourchargetype, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, LabourChargeTypeBusinessRule.CheckLabourChargeTypePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override LabourChargeTypeDto EntityToEntityDto(LabourChargeType entity)
        {
            LabourChargeTypeDto labourchargetypedto = Mapper.Map<LabourChargeType, LabourChargeTypeDto>(entity);
            
            return labourchargetypedto;
        }

        public override LabourChargeType EntityDtoToEntity(LabourChargeTypeDto entityDto)
        {
            LabourChargeType labourchargetype = Mapper.Map<LabourChargeTypeDto, LabourChargeType>(entityDto);
            return labourchargetype;
        }

        protected override string GetEntityInstanceName(LabourChargeType entity)
        {
            return entity.LabourCharge;
        }
        #endregion

        #region Private Methods
        private bool IsLabourChargeTypePresent(LabourChargeType labourchargetype,bool IsEdit)
        {
            bool checkLabourChargeTypePresence = false;
            Query query = new Query();
            Criterion criteriaLabourCharge = new Criterion(Constants.LABOURCHARGE, labourchargetype.LabourCharge, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, labourchargetype.CAId, CriteriaOperator.Equal);
            query.Add(criteriaLabourCharge);
            query.Add(criteriaCAId);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.LABOURCHARGEID, labourchargetype.LabourChargeId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.QueryOperator = QueryOperator.And;
            var labourchargetypeList = ExecuteCommand(locator => locator.GetRepository<LabourChargeType>().FindBy(query));
            if (labourchargetypeList.Count() != 0)
            {
                checkLabourChargeTypePresence = true;
            }
            return checkLabourChargeTypePresence;
        }

        //private bool IsAllowed(LabourChargeType labourchargetype)
        //{
        //    bool IsCreateAllowed = false;
        //    int ActiveLabourChargeTypeCount = 0;
        //    if (!labourchargetype.IsActive)
        //        ActiveLabourChargeTypeCount = 0;
        //    else
        //    {
        //        Query query = new Query();
        //        Criterion criteriaIsActive = new Criterion(Constants.ISACTIVE, true, CriteriaOperator.Equal);
        //        query.Add(criteriaIsActive);
        //        query.QueryOperator = QueryOperator.And;
        //        var botanicalNameList = ExecuteCommand(locator => locator.GetRepository<LabourChargeType>().FindBy(query));
        //        if (botanicalNameList.Count() != 0)
        //        {
        //            ActiveLabourChargeTypeCount = botanicalNameList.Count();
        //        }
        //    }


        //    if (ActiveLabourChargeTypeCount < Constants.MAXLABOURCHARGEALLOWED)
        //    {
        //        IsCreateAllowed = true;
        //    }
        //    return IsCreateAllowed;
        //}
        #endregion
    }
}
