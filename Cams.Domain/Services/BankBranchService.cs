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
using Cams.Common.Dto.Address;
using Cams.Domain.Entities.Masters;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto;
using Cams.Domain.Repository;
using Cams.Common.Dto.User;
using Cams.Common.Logging;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class BankBranchService : ServiceBase<BankBranch, BankBranchDto>, IBankBranchService
    {
        #region Constructor
        public BankBranchService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(BankBranch bankbranch)  
        {
            IList<string> warnings = new List<string>();
            bankbranch.GetBrokenRules();
            foreach (BusinessRule rule in bankbranch.GetBrokenRules())
                warnings.Add(rule.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBankBranchPresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckBankBranchPresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckBankBranchPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsIFSCCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckIFSCCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckIFSCCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsMICRCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckMICRCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckMICRCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsSWIFTCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckSWIFTCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckSWIFTCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            foreach (string warning in warnings)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, warning);
        }

        protected override void CheckForValidationsWhileUpdating(BankBranch bankbranch) 
        {
            IList<string> warnings = new List<string>();
            bankbranch.GetBrokenRules();
            foreach (BusinessRule rule in bankbranch.GetBrokenRules())
                warnings.Add(rule.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (IsBankBranchPresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckBankBranchPresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckBankBranchPresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsIFSCCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckIFSCCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckIFSCCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsMICRCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckMICRCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckMICRCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            if (IsSWIFTCodePresent(bankbranch))
            {
                warnings.Add(BankBranchBusinessRule.CheckSWIFTCodePresence.Rule);
                //Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, BankBranchBusinessRule.CheckSWIFTCodePresence.Rule);
                base.IsValid = false;
                base.AllowSaveWithWarnings = false;
            }
            foreach (string warning in warnings)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, warning);
        }

        public override BankBranchDto EntityToEntityDto(BankBranch entity)
        {
            BankBranchDto bankbranchDto = Mapper.Map<BankBranch, BankBranchDto>(entity);
            if(entity != null)
            {
                bankbranchDto.BranchOfBank = Mapper.Map<Bank, BankDto>(entity.BranchOfBank);

                #region BranchAddress
                if (entity.BranchAddress != null)
                {
                    bankbranchDto.BranchAddress = Mapper.Map<Address, AddressDto>(entity.BranchAddress);
                    if (entity.BranchAddress.CityVillage != null)
                    {
                        bankbranchDto.BranchAddress.CityVillage = Mapper.Map<CityVillage, CityVillageDto>(entity.BranchAddress.CityVillage);
                        bankbranchDto.BranchAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<District, DistrictDto>(entity.BranchAddress.CityVillage.DistrictOfCityVillage);
                        bankbranchDto.BranchAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<State, StateDto>(entity.BranchAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict);
                    }
                }
                #endregion 

                #region BranchContactNos
                bankbranchDto.BranchContactNos.Clear();
                if (entity.BranchContactNos != null)
                {
                    foreach (ContactDetails bankbranchcontactdetails in entity.BranchContactNos)
                    {
                        ContactDetailsDto contactdto = new ContactDetailsDto();
                        contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(bankbranchcontactdetails);
                        bankbranchDto.BranchContactNos.Add(contactdto);
                    }
                }
                #endregion 

                #region WeeklyOffDay & WeeklyHalfDay
                bankbranchDto.WeeklyOffDay = Mapper.Map<WeeklyOffDays, WeeklyOffDaysDto>(entity.WeeklyOffDay);                
                bankbranchDto.WeeklyHalfDay = Mapper.Map<WeeklyHalfDay, WeeklyHalfDayDto>(entity.WeeklyHalfDay);
                #endregion

                #region BranchOfClientSubscriptionPayment
                bankbranchDto.BranchOfClientSubscriptionPayment.Clear();
                if(entity.BranchOfClientSubscriptionPayment != null)
                {
                    foreach (ClientSubscriptionPaymentDetails clientsubscriptionpayment in entity.BranchOfClientSubscriptionPayment)
                    {
                        ClientSubscriptionPaymentDetailsDto clientsubscriptionpaymentDto = Mapper.Map<ClientSubscriptionPaymentDetails, ClientSubscriptionPaymentDetailsDto>(clientsubscriptionpayment);
                        bankbranchDto.BranchOfClientSubscriptionPayment.Add(clientsubscriptionpaymentDto);
                    }
                }
                #endregion

                #region BranchOfClientPartner
                bankbranchDto.BranchOfClientPartner.Clear();
                if (entity.BranchOfClientPartner != null)
                { 
                    foreach (ClientPartnerBankDetails clientpartnerbank in entity.BranchOfClientPartner)
                    {
                        ClientPartnerBankDetailsDto clientpartnerbankDto = Mapper.Map<ClientPartnerBankDetails, ClientPartnerBankDetailsDto>(clientpartnerbank);
                        bankbranchDto.BranchOfClientPartner.Add(clientpartnerbankDto);
                    }
                }
                #endregion
            }
            return bankbranchDto;
        }

        public override BankBranch EntityDtoToEntity(BankBranchDto entityDto)
        {
            BankBranch bankbranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto);
            if(entityDto != null)
            {
                #region Branch
                if (entityDto.BranchId != 0)
                {
                    BankBranchService branchservice = new BankBranchService();
                    BankBranchDto branchdto = branchservice.GetById(entityDto.BranchId);
                    bool isDirty = BankBranch.IsDirty(entityDto, branchdto);
                    if(isDirty)
                    {
                        if (entityDto.CAId != null && (entityDto.CAId != branchdto.CAId))
                        {
                            entityDto.BranchId = 0;
                            entityDto.BaseBranchId = branchdto.BranchId;
                            entityDto.BranchAddress.AddressId = 0;                           
                            entityDto.WeeklyOffDay.WeeklyOffDayId = 0;
                            entityDto.WeeklyHalfDay.WeeklyHalfDayId = 0;
                            if (entityDto.BranchContactNos != null)
                            {
                                foreach (ContactDetailsDto cddto in entityDto.BranchContactNos) 
                                {
                                    ContactDetails branchcontactdetails = new Entities.ContactDetails();
                                    branchcontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(cddto);
                                    bankbranch.BranchContactNos.Add(branchcontactdetails);
                                }
                            }
                            bankbranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto);
                        }
                        else if (entityDto.CAId == branchdto.CAId)
                        {
                            bankbranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto);
                        }
                        else
                        {
                            bankbranch = Mapper.Map<BankBranchDto, BankBranch>(branchdto);
                        }
                    }
                }
                #endregion 

                #region Bank
                if (entityDto.BranchOfBank != null && entityDto.BranchOfBank.BankId != 0)
                {
                    BankService bankService = new BankService();
                    BankDto bankDto = bankService.GetById(entityDto.BranchOfBank.BankId);
                    bankbranch.BranchOfBank = Mapper.Map<BankDto, Bank>(bankDto);                    
                }
                else
                {
                    bankbranch.BranchOfBank = Mapper.Map<BankDto, Bank>(entityDto.BranchOfBank);
                }
                #endregion 

                #region Branch Address
                if (entityDto.BranchAddress != null)
                {
                    bankbranch.BranchAddress = Mapper.Map<AddressDto, Address>(entityDto.BranchAddress);
                    if (entityDto.BranchAddress.CityVillage != null)
                    {
                        if (entityDto.BranchAddress.CityVillage.CityVillageId != 0)
                        {
                            CityVillageService cityvillageService = new CityVillageService();
                            CityVillageDto cityvillageDto = cityvillageService.GetById(entityDto.BranchAddress.CityVillage.CityVillageId);
                            bankbranch.BranchAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
                            bankbranch.BranchAddress.CityVillage.DistrictOfCityVillage = Mapper.Map<DistrictDto, District>(cityvillageDto.DistrictOfCityVillage);
                            bankbranch.BranchAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict = Mapper.Map<StateDto, State>(cityvillageDto.DistrictOfCityVillage.StateOfDistrict);
                        }
                        else
                        {
                            bankbranch.BranchAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto.BranchAddress.CityVillage);
                        }
                    }
                }
                #endregion 

                #region Branch Contacts
                bankbranch.BranchContactNos.Clear();
                if(entityDto.BranchContactNos != null)
                {
                    foreach (ContactDetailsDto contactdetailsdto in entityDto.BranchContactNos)
                    {
                        ContactDetails bankbranchcontactdetails = new Entities.ContactDetails();
                        bankbranchcontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                        bankbranch.BranchContactNos.Add(bankbranchcontactdetails);
                    }
                }
                #endregion 

                #region Weekly HalfDay
                bankbranch.WeeklyHalfDay = Mapper.Map<WeeklyHalfDayDto, WeeklyHalfDay>(entityDto.WeeklyHalfDay);
                #endregion

                #region Weekly Offday
                bankbranch.WeeklyOffDay = Mapper.Map<WeeklyOffDaysDto, WeeklyOffDays>(entityDto.WeeklyOffDay);
                #endregion

                #region BranchOfClientSubscriptionPayment
                bankbranch.BranchOfClientSubscriptionPayment.Clear();
                if(entityDto.BranchOfClientSubscriptionPayment != null)
                {
                    foreach (ClientSubscriptionPaymentDetailsDto clientsubscriptionpaymentDto in entityDto.BranchOfClientSubscriptionPayment)
                    {
                        ClientSubscriptionPaymentDetails clientsubscriptionpayment = Mapper.Map<ClientSubscriptionPaymentDetailsDto, ClientSubscriptionPaymentDetails>(clientsubscriptionpaymentDto);
                        bankbranch.BranchOfClientSubscriptionPayment.Add(clientsubscriptionpayment);
                    }
                }
                #endregion

                #region BranchOfClientPartner
                bankbranch.BranchOfClientSubscriptionPayment.Clear();
                if (entityDto.BranchOfClientPartner != null)
                {
                    foreach (ClientPartnerBankDetailsDto clientpartnerbankDto in entityDto.BranchOfClientPartner)
                    {
                        ClientPartnerBankDetails clientpartnerbank = Mapper.Map<ClientPartnerBankDetailsDto, ClientPartnerBankDetails>(clientpartnerbankDto);
                        bankbranch.BranchOfClientPartner.Add(clientpartnerbank);
                    }
                }
                #endregion
            }
            return bankbranch;
        }

        #region Backup of previous EntityDtoToEntity method
        //protected override BankBranch EntityDtoToEntity(BankBranchDto entityDto)
        //{
        //    BankBranch bankbranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto);
        //    if (entityDto != null)
        //    {
        //        if (entityDto.BranchOfBank != null && entityDto.BranchOfBank.BankId != 0)
        //        {
        //            BankService bankService = new BankService();
        //            BankDto bankDto = bankService.GetById(entityDto.BranchOfBank.BankId);
        //            bool isDirty = Bank.IsDirty(entityDto.BranchOfBank, bankDto);
        //            if (isDirty)
        //            {
        //                if (entityDto.BranchOfBank.CAId != null && (entityDto.BranchOfBank.CAId != bankDto.CAId))
        //                    entityDto.BranchOfBank.BankId = 0;

        //                bankbranch.BranchOfBank = Mapper.Map<BankDto, Bank>(entityDto.BranchOfBank);
        //            }
        //            else
        //            {
        //                bankbranch.BranchOfBank = Mapper.Map<BankDto, Bank>(bankDto);
        //            }
        //        }
        //        else
        //        {
        //            BankDto bankDto;
        //            BankService bankService = new BankService();
        //            Query query = new Query();
        //            Criterion cri = new Criterion(Constants.BANKNAME, entityDto.BranchOfBank.BankName, CriteriaOperator.Equal);
        //            Criterion criCaID = new Criterion(Constants.CAID, entityDto.BranchOfBank.CAId, CriteriaOperator.Equal);
        //            query.Add(cri);
        //            query.Add(criCaID);
        //            var result = bankService.FindByQuery(query);

        //            if (result.TotalRecords > 0)
        //                bankDto = result.Entities.ToList().FirstOrDefault();
        //            else
        //            {
        //                query = new Query();
        //                criCaID = new Criterion(Constants.CAID, entityDto.BranchOfBank.CAId, CriteriaOperator.IsNullOrZero);
        //                query.Add(cri);
        //                query.Add(criCaID);
        //                var result1 = bankService.FindByQuery(query);

        //                if (result1.TotalRecords > 0)
        //                    bankDto = result1.Entities.ToList().FirstOrDefault();
        //                else
        //                    bankDto = entityDto.BranchOfBank;
        //            }

        //            bankbranch.BranchOfBank = Mapper.Map<BankDto, Bank>(bankDto);
        //        }

        //        if (entityDto.BranchAddress != null)
        //        {
        //            bankbranch.BranchAddress = Mapper.Map<AddressDto, Address>(entityDto.BranchAddress);
        //            if (entityDto.BranchAddress.CityVillage != null)
        //            {
        //                if (entityDto.BranchAddress.CityVillage.CityVillageId != 0)
        //                {
        //                    CityVillageService cityvillageService = new CityVillageService();
        //                    CityVillageDto cityvillageDto = cityvillageService.GetById(entityDto.BranchAddress.CityVillage.CityVillageId);
        //                    bankbranch.BranchAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
        //                }
        //                else
        //                {
        //                    bankbranch.BranchAddress.CityVillage = Mapper.Map<CityVillageDto, CityVillage>(entityDto.BranchAddress.CityVillage);
        //                }
        //            }
        //        }
        //        bankbranch.BranchContactNos.Clear();
        //        if (entityDto.BranchContactNos != null)
        //        {
        //            foreach (ContactDetailsDto contactdetailsdto in entityDto.BranchContactNos)
        //            {
        //                ContactDetails bankbranchcontactdetails = new Entities.ContactDetails();
        //                bankbranchcontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
        //                bankbranch.BranchContactNos.Add(bankbranchcontactdetails);
        //            }
        //        }
        //        bankbranch.WeeklyHalfDay = Mapper.Map<WeeklyHalfDayDto, WeeklyHalfDay>(entityDto.WeeklyHalfDay);
        //        bankbranch.WeeklyOffDay = Mapper.Map<WeeklyOffDaysDto, WeeklyOffDays>(entityDto.WeeklyOffDay);
        //    }
        //    return bankbranch;
        //}
        #endregion 

        protected override string GetEntityInstanceName(BankBranch entity)
        {
            return entity.Name;
        }

        public override BankBranchDto UpdateCommand(IRepositoryLocator locator, BankBranchDto entityDto, string userName)
        {
            string description = string.Empty;
            BankBranch entityInstance = EntityDtoToEntity(entityDto);
            if (entityInstance.BranchId == 0)
            {
                CheckForValidations(entityInstance);
            }
            else
            {
                CheckForValidationsWhileUpdating(entityInstance);
            }
            if ((AllowSaveWithWarnings && IsValidForBasicMandatoryFields) || IsValid)
            {
                if (entityInstance.BranchId == 0)
                {
                    locator.GetRepository<BankBranch>().Add(entityInstance);
                    LoggingFactory.LogInfo("Created " + typeof(BankBranch).Name + " : Id : ");
                    description = "Created " + typeof(BankBranch).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
                else
                {
                    locator.GetRepository<BankBranch>().Update(entityInstance);
                    description = "Updated " + typeof(BankBranch).Name + " : " + GetEntityInstanceName(entityInstance);
                    LoggActivity(description, userName);
                }
            }
            else
            {
                description = "Failed to create " + typeof(BankBranch).Name + " : " + GetEntityInstanceName(entityInstance);
                LoggingFactory.LogInfo(description);
            }
            return EntityToEntityDto(entityInstance);
        }

        public override EntityDtos<BankBranchDto> FindByQueryCommand(IRepositoryLocator locator, Query query)
        {
            Criterion criteriaBaseBranchIdNotNull = new Criterion(Constants.BASEBRANCHID, null, CriteriaOperator.IsNotNullOrZero);
            Criterion criteriaCAId = new Criterion(Constants.CAID, query.CAId, CriteriaOperator.Equal);

            Query query1 = new Query();
            query1.Add(criteriaCAId);
            query1.Add(criteriaBaseBranchIdNotNull);
            IQueryable<BankBranch> caBranchListWithBaseBranchId = locator.GetRepository<BankBranch>().FindBy(query1);

            IQueryable<BankBranch> BranchList = locator.GetRepository<BankBranch>().FindBy(query);

            //BranchList = BranchList.Except(caBranchListWithBaseBranchId);
            
            var itemIds = caBranchListWithBaseBranchId.Select(x => x.BaseBranchId).ToArray();
            BranchList = BranchList.Where(x => !itemIds.Contains(x.BranchId));

            IList<BankBranchDto> allDto = new List<BankBranchDto>();
            foreach (BankBranch entity in BranchList)
            {
                allDto.Add(EntityToEntityDto(entity));
            }
            var result = new EntityDtos<BankBranchDto> { Entities = allDto };
            result.TotalRecords = locator.GetRepository<BankBranch>().GetCount(query);
            if (result.TotalRecords == 0)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Default, "No records were found");
            return result;
        }
        #endregion 

        #region Private Methods
        
        #region Old Methods
        private bool IsBankBranchPresent1(BankBranch bankbranch)  
        {
            bool checkBankBranchPresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.BANKBRANCHNAME, bankbranch.Name, CriteriaOperator.Equal);
            Criterion criteriaCAId ;
            if( bankbranch.CAId !=null)
                criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            else
                criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);

            if(bankbranch.BranchOfBank.BankId != 0)
            {
                Criterion criteriaBankId = new Criterion("bank.BankId", bankbranch.BranchOfBank.BankId, CriteriaOperator.Equal);
                query.Add(criteriaBankId);
                query.AddAlias(new Alias("bank", "BranchOfBank"));
            }
            Criterion criteriaCV = new Criterion("cv.CityVillageId", bankbranch.BranchAddress.CityVillage.CityVillageId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaCAId);            
            query.Add(criteriaCV);            
            query.AddAlias( new Alias("ba", "BranchAddress"));
            query.AddAlias( new Alias("cv", "ba.CityVillage"));
            query.QueryOperator = QueryOperator.And;
            var bankbranchList = ExecuteCommand(locator => locator.GetRepository<BankBranch>().FindBy(query));
            if (bankbranchList.Count() != 0)
            {
                checkBankBranchPresence = true;
            }
            return checkBankBranchPresence;
        }

        private bool IsIFSCCodePresent1(BankBranch bankbranch)
        {
            bool checkIFSCCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.IFSCCODE, bankbranch.IFSCCode, CriteriaOperator.Equal);
            Criterion criteriaCAId;
            if (bankbranch.CAId != null)
                criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            else
                criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            //Criterion criteriaBankId = new Criterion("bank.BankId", bankbranch.BranchOfBank.BankId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaCAId);
            //query.Add(criteriaBankId);
            //query.Alias = new Alias("bank", "BranchOfBank");
            query.QueryOperator = QueryOperator.And;
            var IFSCCodeList = ExecuteCommand(locator => locator.GetRepository<BankBranch>().FindBy(query));
            if (IFSCCodeList.Count() != 0)
            {
                checkIFSCCodePresence = true;
            }
            return checkIFSCCodePresence;
        }

        private bool IsMICRCodePresent1(BankBranch bankbranch)
        {
            bool checkMICRCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.MICRCODE, bankbranch.MICRCode, CriteriaOperator.Equal);
            Criterion criteriaCAId;
            if (bankbranch.CAId != null)
                criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            else
                criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            //Criterion criteriaBankId = new Criterion("bank.BankId", bankbranch.BranchOfBank.BankId, CriteriaOperator.Equal);
            query.Add(criteriaName);
            query.Add(criteriaCAId);
            //query.Add(criteriaBankId);
            //query.Alias = new Alias("bank", "BranchOfBank");
            query.QueryOperator = QueryOperator.And;
            var MICRCodeList = ExecuteCommand(locator => locator.GetRepository<BankBranch>().FindBy(query));
            if (MICRCodeList.Count() != 0)
            {
                checkMICRCodePresence = true;
            }
            return checkMICRCodePresence;
        }

        private bool IsSWIFTCodePresent1(BankBranch bankbranch)
        {
            bool checkSWIFTCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.SWIFTCODE, bankbranch.SWIFTCode, CriteriaOperator.Equal);
            Criterion criteriaCAId;
            if (bankbranch.CAId != null)
                criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            else
                criteriaCAId = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            Criterion criteriaBankId = new Criterion("bank.BankId", bankbranch.BranchOfBank.BankId, CriteriaOperator.NotEqual);
            query.Add(criteriaName);
            query.Add(criteriaCAId);
            query.Add(criteriaBankId);
            query.AddAlias(new Alias("bank", "BranchOfBank"));
            query.QueryOperator = QueryOperator.And;
            var SWIFTCodeList = ExecuteCommand(locator => locator.GetRepository<BankBranch>().FindBy(query));
            if (SWIFTCodeList.Count() != 0)
            {
                checkSWIFTCodePresence = true;
            }
            return checkSWIFTCodePresence;
        }
        #endregion 

        private bool IsBankBranchPresent(BankBranch bankbranch)
        {
            bool isPresent = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.BANKBRANCHNAME, bankbranch.Name, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
            Criterion criteriaBankId = new Criterion("bank.BankId", bankbranch.BranchOfBank.BankId, CriteriaOperator.Equal);
            query.AddAlias(new Alias("bank", "BranchOfBank"));
            Criterion criteriaCV = new Criterion("cv.CityVillageId", bankbranch.BranchAddress.CityVillage.CityVillageId, CriteriaOperator.Equal);
            query.AddAlias(new Alias("ba", "BranchAddress"));
            query.AddAlias(new Alias("cv", "ba.CityVillage"));

            if (bankbranch.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.Add(criteriaBankId);
                query.Add(criteriaCV);
                query.QueryOperator = QueryOperator.And;
                var branchlist = FindByQuery(query);
                isPresent = (branchlist.TotalRecords != 0) ? true : false;
                //For Update Scenario
                if (isPresent && branchlist.TotalRecords == 1 && branchlist.Entities.ToList().FirstOrDefault().BranchId == bankbranch.BranchId)
                    isPresent = false;
            }
            else
            {
                query.Add(criteriaName);
                query.Add(criteriaBankId);
                query.Add(criteriaCV);
                
                Query subquery = new Query();
                subquery.Add(criteriaCAId);
                subquery.Add(criteriaCAIdNull);
                subquery.QueryOperator = QueryOperator.Or;
                query.AddSubQuery(subquery);
                
                query.QueryOperator = QueryOperator.And;
                query.CAId = (int)bankbranch.CAId;

                var branchlist = FindByQuery(query);
                IEnumerable<BankBranchDto> bankbranchDtoList = branchlist.Entities.AsEnumerable();
                isPresent = (bankbranchDtoList.Count() != 0) ? true : false;
                //For Update Scenario
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BranchId)
                    isPresent = false;
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BaseBranchId)
                    isPresent = false;
            }

            return isPresent;
        }

        private bool IsIFSCCodePresent(BankBranch bankbranch)
        {
            bool checkIFSCCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.IFSCCODE, bankbranch.IFSCCode, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);

            if (bankbranch.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.QueryOperator = QueryOperator.And;
                var IFSCCodeList = FindByQuery(query);
                checkIFSCCodePresence = (IFSCCodeList.TotalRecords != 0) ? true : false;
                //For Update Scenario
                if (checkIFSCCodePresence && IFSCCodeList.TotalRecords == 1 && IFSCCodeList.Entities.ToList().FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkIFSCCodePresence = false;
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
                query.CAId = (int)bankbranch.CAId;

                var IFSCCodeList = FindByQuery(query);
                IEnumerable<BankBranchDto> bankbranchDtoList = IFSCCodeList.Entities.AsEnumerable();

                checkIFSCCodePresence = (bankbranchDtoList.Count() != 0) ? true : false;

                //For Update Scenario
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkIFSCCodePresence = false;
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BaseBranchId)
                    checkIFSCCodePresence = false;
            }
            return checkIFSCCodePresence;
        }

        private bool IsMICRCodePresent(BankBranch bankbranch)
        {
            bool checkMICRCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.MICRCODE, bankbranch.MICRCode, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);

            if (bankbranch.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.QueryOperator = QueryOperator.And;
                var MICRCodeList = FindByQuery(query);
                checkMICRCodePresence = (MICRCodeList.TotalRecords != 0) ? true : false;
                //For Update Scenario
                if (checkMICRCodePresence && MICRCodeList.TotalRecords == 1 && MICRCodeList.Entities.ToList().FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkMICRCodePresence = false;
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
                query.CAId = (int)bankbranch.CAId;

                var MICRCodeList = FindByQuery(query);
                IEnumerable<BankBranchDto> bankbranchDtoList = MICRCodeList.Entities.AsEnumerable();

                checkMICRCodePresence = (bankbranchDtoList.Count() != 0) ? true : false;

                //For Update Scenario
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkMICRCodePresence = false;
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BaseBranchId)
                    checkMICRCodePresence = false;
            }
            return checkMICRCodePresence;
        }

        private bool IsSWIFTCodePresent(BankBranch bankbranch)
        {
            bool checkSWIFTCodePresence = false;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.SWIFTCODE, bankbranch.SWIFTCode, CriteriaOperator.Equal);
            Criterion criteriaCAId = new Criterion(Constants.CAID, bankbranch.CAId, CriteriaOperator.Equal);
            Criterion criteriaCAIdNull = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);

            if (bankbranch.CAId == null)
            {
                query.Add(criteriaName);
                query.Add(criteriaCAIdNull);
                query.QueryOperator = QueryOperator.And;
                var SWIFTCodeList = FindByQuery(query);
                checkSWIFTCodePresence = (SWIFTCodeList.TotalRecords != 0) ? true : false;
                //For Update Scenario
                if (checkSWIFTCodePresence && SWIFTCodeList.TotalRecords == 1 && SWIFTCodeList.Entities.ToList().FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkSWIFTCodePresence = false;
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
                query.CAId = (int)bankbranch.CAId;

                var SWIFTCodeList = FindByQuery(query);
                IEnumerable<BankBranchDto> bankbranchDtoList = SWIFTCodeList.Entities.AsEnumerable();

                checkSWIFTCodePresence = (bankbranchDtoList.Count() != 0) ? true : false;

                //For Update Scenario
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BranchId)
                    checkSWIFTCodePresence = false;
                if (bankbranchDtoList.Count() == 1 && bankbranchDtoList.FirstOrDefault().BranchId == bankbranch.BaseBranchId)
                    checkSWIFTCodePresence = false;
            }
            return checkSWIFTCodePresence;
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
            activityLogDto.ActivityRelatedTo = typeof(BankBranch).Name;

            activityLogService = new ActivityLogService();
            activityLogService.Create(activityLogDto, userName);
        }
        #endregion 
    }
}
