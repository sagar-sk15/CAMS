using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Common.Dto.User;
using Cams.Domain.Entities.Users;
using Cams.Common.ServiceContract;
using Cams.Domain.Entities;
using Cams.Common.Message;
using AutoMapper;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class RelationshipService : ServiceBase<Relationship, RelationshipDto>, IRelationShipService
    {
        #region Constructor
        public RelationshipService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(Relationship relationship)
        {
            relationship.GetBrokenRules();
            foreach (BusinessRule rule in relationship.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsRelationshipPresent(relationship))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, RelationshipBusinessRules.RelationshipNameUnique.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(Relationship entity)
        {
            throw new NotImplementedException();
        }

        public override RelationshipDto EntityToEntityDto(Relationship entity)
        {
            RelationshipDto relationshipDto = Mapper.Map<Relationship, RelationshipDto>(entity);
            return relationshipDto;
        }

        public override Relationship EntityDtoToEntity(RelationshipDto entityDto)
        {
            Relationship relationship = Mapper.Map<RelationshipDto, Relationship>(entityDto);
            return relationship;
        }

        protected override string GetEntityInstanceName(Relationship entity)
        {
            return entity.Name;
        }
        #endregion

        #region Private Methods
        private bool IsRelationshipPresent(Relationship relationship)
        {
            bool checkRelationshipPresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.RELATIONSHIPNAME, relationship.Name, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, relationship.CAId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaCAId);
            query.QueryOperator = QueryOperator.And;
            var relationshipList = ExecuteCommand(locator => locator.GetRepository<Relationship>().FindBy(query));
            if (relationshipList.Count() != 0)
            {
                checkRelationshipPresence = true;
            }
            return checkRelationshipPresence;
        }
        #endregion 
    }
}
