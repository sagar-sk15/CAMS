using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using AutoMapper;
using Cams.Domain.Entities;
using Cams.Domain.AppServices;
using Cams.Common.Message;
using Cams.Domain.Repository;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class DesignationService : ServiceBase<Designation, DesignationDto>, IDesignationService
    {
        public DesignationService()
        {
        }

        #region Private Methods
        /// <summary>
        /// Method to check the designation name unique or not
        /// </summary>
        /// <param name="designation"></param>
        /// <returns></returns>
        private bool IsUniqueName(Designation designation) 
        {
            bool result = false;           
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.DESIGNATIONNAME, designation.DesignationName, CriteriaOperator.Equal);
            query.Add(criteriaName);
            var DesignationList = ExecuteCommand(locator => locator.GetRepository<Designation>().FindBy(query));
            if (DesignationList.Count() != 0)
            {
                result = true;
            }
            return result;           
        }
        #endregion

        #region Ovrride the base abstract methods

        public override Designation EntityDtoToEntity(DesignationDto entityDto)
        {
            return Mapper.Map<DesignationDto, Designation>(entityDto);
        }

        protected override void CheckForValidationsWhileUpdating(Designation entity)
        {
            throw new NotImplementedException();
        }

        public override DesignationDto EntityToEntityDto(Designation entity)
        {
            return Mapper.Map<Designation, DesignationDto>(entity);
        }

        protected override string GetEntityInstanceName(Designation entity)
        {
            return entity.DesignationName;
        }

        protected override void CheckForValidations(Designation designation)
        {
            designation.GetBrokenRules();
            base.IsValid = designation.IsValid;
            base.IsValidForBasicMandatoryFields = designation.IsValidForBasicMandatoryFields;

            foreach (BusinessRule rule in designation.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsUniqueName(designation))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, DesignationBusinessRules.DesignationNameUnique.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }
        #endregion
    }
}
