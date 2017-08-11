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
using Cams.Domain.Repository;
using Cams.Common.Dto.User;
using Cams.Common.Logging;
using Cams.Common.Dto;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class BankService : ServiceBase<Bank, BankDto>, IBankService
    {
        #region Constructor
        public BankService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(Bank bank)
        {
            bank.GetBrokenRules();
            foreach (BusinessRule rule in bank.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBankPresent(bank,false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBusinessRule.CheckBankPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(Bank bank) 
        {
            bank.GetBrokenRules();
            foreach (BusinessRule rule in bank.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBankPresent(bank, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBusinessRule.CheckBankPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
        }

        public override BankDto EntityToEntityDto(Bank entity)
        {
            BankDto bankDto = Mapper.Map<Bank, BankDto>(entity);            
            return bankDto;
        }

        public override Bank EntityDtoToEntity(BankDto entityDto)
        {
            Bank bank = Mapper.Map<BankDto, Bank>(entityDto);            
            if(entityDto != null)
            {
                if(entityDto.BankId != 0)
                {
                    BankService bankservice = new BankService();
                    BankDto bankdto = bankservice.GetById(entityDto.BankId);
                    bool isDirty = Bank.IsDirty(entityDto, bankdto);
                    if (isDirty)
                    {
                        if (entityDto.CAId != null && (entityDto.CAId != bankdto.CAId))
                        {
                            entityDto.BankId = 0;
                            entityDto.BaseBankId = bankdto.BankId;
                            bank = Mapper.Map<BankDto, Bank>(entityDto);
                        }
                        else if (entityDto.CAId == bankdto.CAId)
                        {
                            bank = Mapper.Map<BankDto, Bank>(entityDto);
                        }
                        else
                        {
                            bank = Mapper.Map<BankDto, Bank>(bankdto);
                        }
                    }
                }               
            }
            return bank;
        }

        protected override string GetEntityInstanceName(Bank entity)
        {
            return entity.BankName;
        }

        public override BankDto UpdateCommand(IRepositoryLocator locator, BankDto entityDto, string userName)
        {
            string description = string.Empty;
            Bank entityInstance = EntityDtoToEntity(entityDto);
            if (entityInstance.BankId == 0)
            {
                CheckForValidations(entityInstance);
            }
            else
            {
                CheckForValidationsWhileUpdating(entityInstance);            
            }            
            if ((AllowSaveWithWarnings && IsValidForBasicMandatoryFields) || IsValid)
            {
                if (entityInstance.BankId == 0)
                {
                    locator.GetRepository<Bank>().Add(entityInstance);
                    LoggingFactory.LogInfo("Created " + typeof(Bank).Name + " : Id : ");
                    description = "Created " + typeof(Bank).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
                else
                {
                    locator.GetRepository<Bank>().Update(entityInstance);
                    description = "Updated " + typeof(Bank).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
            }
            else
            {
                description = "Failed to create " + typeof(Bank).Name + " : " + GetEntityInstanceName(entityInstance);
                LoggingFactory.LogInfo(description);
                // This is not required as this call will overrite the existing Respose if it has warnings
                //var bankInstance = GetById(entityInstance.BankId);
                //entityInstance = AutoMapper.Mapper.Map<BankDto,Bank>(bankInstance);
            }
            return EntityToEntityDto(entityInstance);
        }

        public override EntityDtos<BankDto> FindByQueryCommand(IRepositoryLocator locator, Query query)
        {
            Criterion criteriaBaseBankIdNotNull = new Criterion(Constants.BASEBANKID, null, CriteriaOperator.IsNotNullOrZero);
            Criterion criteriaCAId = new Criterion(Constants.CAID, query.CAId, CriteriaOperator.Equal);
            
            Query query1 = new Query();
            query1.Add(criteriaCAId);
            query1.Add(criteriaBaseBankIdNotNull);
            IQueryable<Bank> caBankListWithBaseBankId = locator.GetRepository<Bank>().FindBy(query1);

            IQueryable<Bank> bankList = locator.GetRepository<Bank>().FindBy(query);
            //bankList = bankList.Except(caBankListWithBaseBankId);
            //bankList.Union(caBankListWithBaseBankId);

            var itemIds = caBankListWithBaseBankId.Select(x => x.BaseBankId).ToArray();
            bankList = bankList.Where(x => !itemIds.Contains(x.BankId));
            
            IList<BankDto> allDto = new List<BankDto>();
            foreach (Bank entity in bankList)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            
            var result = new EntityDtos<BankDto> { Entities = allDto };
            result.TotalRecords = locator.GetRepository<Bank>().GetCount(query);
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No records were found");
            return result;
        }

        #endregion 

        #region Private Methods
        
        private bool IsBankPresent(Bank bank, bool IsEdit)
        {
            bool isPresent = false;
            Query query = new Query();            
            Criterion criteriaName = new Criterion(Constants.BANKNAME, bank.BankName, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, bank.CAId, CriteriaOperator.Equal);
            Criterion criteriaBaseBankIdNotNull = new Criterion(Constants.BASEBANKID, null, CriteriaOperator.IsNotNullOrZero);
            Criterion criteriaBankId = new Criterion(Constants.BANKID, bank.BankId, CriteriaOperator.NotEqual);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);

            if (bank.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.QueryOperator = QueryOperator.And;
                var bankList = FindByQuery(query);
                isPresent = (bankList.TotalRecords != 0) ? true : false;

                //For Update Scenario
                if (isPresent && bankList.TotalRecords == 1 && bankList.Entities.ToList().FirstOrDefault().BankId == bank.BankId)
                    isPresent = false;
                
            }
            else 
            {
                query.Add(criteriaName);
                Query subquery = new Query();
                subquery.Add(criteriaCAId);
                subquery.Add(criteriaCAIdNull);
                subquery.QueryOperator = QueryOperator.Or;
                query.AddSubQuery(subquery);
                query.QueryOperator = QueryOperator.And;
                query.CAId = (int)bank.CAId;

                var bankList = FindByQuery(query);
                IEnumerable<BankDto> bankDtoList = bankList.Entities.AsEnumerable();

                //Query query1 = new Query();
                //query1.Add(criteriaCAId);
                //query1.Add(criteriaBaseBankIdNotNull);
                //var caBankListWithBaseBankId = FindByQuery(query1);

                //bankDtoList = bankDtoList.Except(caBankListWithBaseBankId.Entities.AsEnumerable());

                isPresent = (bankDtoList.Count() != 0) ? true : false;
                
                //For Update Scenario
                if (bankDtoList.Count() == 1 && bankDtoList.FirstOrDefault().BankId == bank.BankId)
                    isPresent = false;
                if (bankDtoList.Count() == 1 && bankDtoList.FirstOrDefault().BankId == bank.BaseBankId)
                    isPresent = false;
            }

           
            return isPresent;
        }

        /// <summary>
        /// LoggActivity method log the information of the user in ActivityLogDto and pass it to create method of ActivityLogService.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="loggedInUserDto"></param>
        private void LoggActivity(string description, string userName)
        {
            ActivityLogService activityLogService;
            Cams.Common.Dto.Log.ActivityLogDto activityLogDto;

            activityLogDto = new Cams.Common.Dto.Log.ActivityLogDto();
            activityLogDto.LoggedBy = userName;
            activityLogDto.LoggedDate = DateTime.Now;
            activityLogDto.Description = description;
            activityLogDto.ActivityRelatedTo = typeof(Bank).Name;

            activityLogService = new ActivityLogService();
            activityLogService.Create(activityLogDto, userName);
        }
        #endregion 
    }
}
