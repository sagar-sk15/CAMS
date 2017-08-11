using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Domain.Entities;
using Cams.Common.Message;
using Cams.Domain.AppServices;
using AutoMapper;
using Cams.Common.Dto.Address;
using Cams.Domain.Entities.Masters;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Domain.Entities.ClientMasters;
using Cams.Common.Logging;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ClientService : ServiceBase<Client, ClientDto>, IClientService
    {
        #region Constructor
        public ClientService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
            base.PopulateChildObjects = false;
        }
        #endregion
        //private bool _populateChildObjects = true;
        IEnumerable<BusinessWarning> Warnings;
        #region Overrides of ServiceBase<Client,ClientDto>

        //public bool PopulateChildObjects { get { return _populateChildObjects; } set { _populateChildObjects = value; } }

        protected override void CheckForValidations(Client client)
        {
            IList<string> warnings = new List<string>();
            
            //set PopulateChildObjects to false as child objects are not required on created and updated object
            base.PopulateChildObjects = false;
            base.AllowSaveWithWarnings = false;
            base.IsValidForBasicMandatoryFields = false;

            client.GetBrokenRules();
            foreach (BusinessRule rule in client.GetBrokenRules())
                warnings.Add(rule.Rule);

            // set the status of client(Active or Inactive)
            if (!String.IsNullOrEmpty(client.CompanyName))
            {
                base.AllowSaveWithWarnings = true;
                base.IsValidForBasicMandatoryFields = true;
            }
            else
            {
                base.AllowSaveWithWarnings = true;
                base.IsValidForBasicMandatoryFields = false;

                return;
            }
            if (warnings.Count > 0)
            {
                client.Status = ClientStatus.InActive;
                return;
            }
            else
            {
                client.Status = ClientStatus.Active;

            }
                //primary contact preson contact details should have atleast one mobileno

                if (IsClientPresent(client, false))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckClientPresence.Rule);
                    base.IsValid = false;
                }
                if (IsPANPresent(client, false))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckPANPresence.Rule);
                    base.IsValid = false;
                }
                if (IsTANPresent(client, false))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckTANPresence.Rule);
                    base.IsValid = false;
                }
                if (IsAPMCLicNoPresent(client, false))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckAPMCNoPresence.Rule);
                    base.IsValid = false;
                }

                if (client.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                {
                    ContactDetails contact = new ContactDetails();
                    IEnumerable<ContactDetails> mobileContact = client.ClientPrimaryContactPerson.ClientPrimaryContacts.Where(x => x.ContactNoType == ContactType.MobileNo);
                    if (mobileContact.Count() > 0)
                    {
                        contact = mobileContact.FirstOrDefault();
                    }
                    if (!string.IsNullOrEmpty(contact.ContactNo))
                    {
                        string mobileno = contact.ContactNo;
                        if (IsMobileNoPresent(mobileno, client.ClientPrimaryContactPerson.CAPrimaryContactPersonId, false))
                        {
                            //warnings.Add(ClientRegistrationBusinessRules.CheckClientPrimaryContactMobileNoPresence.Rule);
                            warnings.Add("Primary contact person with mobile no. '" + mobileno + "' already exist");
                            base.IsValid = false;
                        }
                    }
                }
            
            foreach (string warning in warnings)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, warning);

            Warnings = Container.RequestContext.Notifier.RetrieveWarnings();
        }

        protected override void CheckForValidationsWhileUpdating(Client client) 
        {
            IList<string> warnings = new List<string>(); 

            base.PopulateChildObjects = false;
            base.AllowSaveWithWarnings = false;
            base.IsValidForBasicMandatoryFields = false;

            client.GetBrokenRules();
            foreach (BusinessRule rule in client.GetBrokenRules())
                warnings.Add(rule.Rule);

            if (!String.IsNullOrEmpty(client.CompanyName))
            {
                base.AllowSaveWithWarnings = true;
                base.IsValidForBasicMandatoryFields = true;
            }
            else
            {
                base.AllowSaveWithWarnings = true;
                base.IsValidForBasicMandatoryFields = false;

                return;
            }
            if (warnings.Count > 0)
            {
                client.Status = ClientStatus.InActive;                
            }
            else
            {
                client.Status = ClientStatus.Active;

            }
                if (IsClientPresent(client, true))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckClientPresence.Rule);
                    base.IsValid = false;
                }
                if (IsPANPresent(client, true))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckPANPresence.Rule);
                    base.IsValid = false;
                }
                if (IsTANPresent(client, true))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckTANPresence.Rule);
                    base.IsValid = false;
                }
                if (IsAPMCLicNoPresent(client, true))
                {
                    warnings.Add(ClientRegistrationBusinessRules.CheckAPMCNoPresence.Rule);
                    base.IsValid = false;
                }

                if (client.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                {
                    ContactDetails contact = new ContactDetails();
                    IEnumerable<ContactDetails> mobileContact = client.ClientPrimaryContactPerson.ClientPrimaryContacts.Where(x => x.ContactNoType == ContactType.MobileNo);
                    if (mobileContact.Count() > 0)
                    {
                        contact = mobileContact.FirstOrDefault();
                    }
                    if (!string.IsNullOrEmpty(contact.ContactNo))
                    {
                        string mobileno = contact.ContactNo;
                        if (IsMobileNoPresent(mobileno, client.ClientPrimaryContactPerson.CAPrimaryContactPersonId, true))
                        {
                            //warnings.Add(ClientRegistrationBusinessRules.CheckClientPrimaryContactMobileNoPresence.Rule);
                            warnings.Add("Primary contact person with mobile no. '" + mobileno + "' already exist");
                            base.IsValid = false;
                        }
                    }
                }
            
            foreach (string warning in warnings)
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, warning);
            Warnings = Container.RequestContext.Notifier.RetrieveWarnings();
        }

        public override ClientDto EntityToEntityDto(Client entity)
        {
            ClientDto clientDto = Mapper.Map<Client, ClientDto>(entity);
            if (entity != null)
            {
                #region ClientAddress
                if (entity.ClientAddress != null)
                {                    
                    AddressService addressService = new AddressService();
                    clientDto.ClientAddress = addressService.EntityToEntityDto(entity.ClientAddress);
                }
                #endregion 

                #region ClientAPMC
                if (entity.ClientAPMC != null)
                {                    
                    APMCService apmcService = new APMCService();
                    clientDto.ClientAPMC = apmcService.EntityToEntityDto(entity.ClientAPMC);
                }
                #endregion

                #region ClientBusinessConstitution
                if (entity.ClientBusinessConstitution != null)
                {
                    BusinessConstitutionService bsService = new BusinessConstitutionService();
                    clientDto.ClientBusinessConstitution = bsService.EntityToEntityDto(entity.ClientBusinessConstitution); 
                }
                #endregion

                #region ClientPhoneCharges
                if (entity.ClientPhoneCharges != null)
                {
                    clientDto.ClientPhoneCharges = Mapper.Map<ClientPhoneCharges, ClientPhoneChargesDto>(entity.ClientPhoneCharges);
                }
                #endregion

                #region ClientPrimaryContactPerson
                if (entity.ClientPrimaryContactPerson != null)
                {
                    clientDto.ClientPrimaryContactPerson = Mapper.Map<ClientPrimaryContactPerson, ClientPrimaryContactPersonDto>(entity.ClientPrimaryContactPerson);
                    #region ClientPrimaryContactPerson Address
                    if (entity.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                    {
                        AddressService addressService = new AddressService();
                        clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress = addressService.EntityToEntityDto(entity.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress);
                    }
                    #endregion

                    #region ClientPrimaryContactPerson Designation
                    if(entity.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation != null)
                    {
                        DesignationService designationService = new DesignationService();
                        clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation = designationService.EntityToEntityDto(entity.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation);
                    }
                    #endregion

                    #region ClientPrimaryContactPerson ContactDetails
                    clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts.Clear();
                    if (entity.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                    {
                        foreach (ContactDetails PrimaryContactPersoncontacts in entity.ClientPrimaryContactPerson.ClientPrimaryContacts) 
                        {
                            ContactDetailsDto contactdto = new ContactDetailsDto();
                            contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(PrimaryContactPersoncontacts);
                            clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts.Add(contactdto);
                        }
                    }
                    #endregion
                }
                #endregion

                #region ClientContacts
                clientDto.ClientContacts.Clear();
                if (entity.ClientContacts != null)
                {
                    foreach (ContactDetails usercontactdetails in entity.ClientContacts)
                    {
                        ContactDetailsDto contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(usercontactdetails);
                        clientDto.ClientContacts.Add(contactdto);
                    }
                }
                #endregion

                #region ClientSisterConcerns
                clientDto.ClientSisterConcerns.Clear();
                if (entity.ClientSisterConcerns != null)
                {
                    foreach (ClientSisterConcern clientSisterConcern in entity.ClientSisterConcerns)
                    {
                        ClientSisterConcernDto sisterconcerDto = Mapper.Map<ClientSisterConcern, ClientSisterConcernDto>(clientSisterConcern);
                        clientDto.ClientSisterConcerns.Add(sisterconcerDto);
                    }
                }
                #endregion

                #region ClientTaxationAndLicenses
                clientDto.ClientTaxationAndLicenses.Clear();
                if(entity.ClientTaxationAndLicenses != null)
                {
                    foreach (ClientTaxationAndLicenses clienttaxation in entity.ClientTaxationAndLicenses)
                    {
                        ClientTaxationAndLicensesDto clienttazationDto = Mapper.Map<ClientTaxationAndLicenses, ClientTaxationAndLicensesDto>(clienttaxation);
                        clientDto.ClientTaxationAndLicenses.Add(clienttazationDto);
                    }
                }
                #endregion

                #region ClientSubscription
                if (entity.ClientSubscription != null)
                {
                    clientDto.ClientSubscription = Mapper.Map<ClientSubscription, ClientSubscriptionDto>(entity.ClientSubscription);
                    #region SubscriptionMaster
                    if(entity.ClientSubscription.SubscriptionMaster != null)
                    {
                        SubscriptionMasterService subscriptionmasterService = new SubscriptionMasterService();
                        clientDto.ClientSubscription.SubscriptionMaster = subscriptionmasterService.EntityToEntityDto(entity.ClientSubscription.SubscriptionMaster);
                    }
                    #endregion

                    #region ClientSubscription PaymentDetails
                    clientDto.ClientSubscription.ClientSubscriptionPaymentDetails.Clear();
                    if(entity.ClientSubscription.ClientSubscriptionPaymentDetails != null)
                    {
                        BankBranchService branchservice = new BankBranchService();
                        foreach (ClientSubscriptionPaymentDetails paymentdetails in entity.ClientSubscription.ClientSubscriptionPaymentDetails) 
                        {
                            ClientSubscriptionPaymentDetailsDto paymetdetailsDto = Mapper.Map<ClientSubscriptionPaymentDetails, ClientSubscriptionPaymentDetailsDto>(paymentdetails);
                            paymetdetailsDto.BankBranch = branchservice.EntityToEntityDto(paymentdetails.BankBranch);
                            clientDto.ClientSubscription.ClientSubscriptionPaymentDetails.Add(paymetdetailsDto);
                        }
                    }
                    #endregion
                }
                #endregion

                #region AccountManager
                if(entity.AccountManager != null)
                {
                    UserService userService = new UserService();
                    clientDto.AccountManager = userService.EntityToEntityDto(entity.AccountManager);
                }
                #endregion

                #region ClientCommodities
                clientDto.ClientCommodities.Clear();
                if(entity.ClientCommodities != null)
                {
                    CommodityClassService commodityclassService = new CommodityClassService();
                    foreach (CommodityClass commodityclass in entity.ClientCommodities)
                    {
                        CommodityClassDto commodityclassDto = commodityclassService.EntityToEntityDto(commodityclass);
                        clientDto.ClientCommodities.Add(commodityclassDto);
                    }
                }
                #endregion

                #region ClientPartners
                clientDto.ClientPartners.Clear();
                if(entity.ClientPartners != null)
                {
                    AddressService addressService = new AddressService();
                    DesignationService designationService = new DesignationService();
                    RelationshipService relationshipService = new RelationshipService();
                    BankBranchService branchService = new BankBranchService();

                    foreach (ClientPartnerDetails clientpartner in entity.ClientPartners)
                    {
                        ClientPartnerDetailsDto clientpartnerDto = Mapper.Map<ClientPartnerDetails, ClientPartnerDetailsDto>(clientpartner);

                        #region ClientPartner Address
                        if (clientpartner.ClientPartnerAddress != null)
                        {                            
                            clientpartnerDto.ClientPartnerAddress = addressService.EntityToEntityDto(clientpartner.ClientPartnerAddress);
                        }
                        #endregion

                        #region ClientPartner Designation
                        if (clientpartner.ClientPartnerDesignation != null)
                        {                            
                            clientpartnerDto.ClientPartnerDesignation = designationService.EntityToEntityDto(clientpartner.ClientPartnerDesignation);
                        }  
                        #endregion  
                     
                        #region ClientPartner Contacts
                        clientpartnerDto.ClientPartnerContacts.Clear();
                        if(clientpartner.ClientPartnerContacts != null)
                        {
                            foreach (ContactDetails clientPartnerContact in clientpartner.ClientPartnerContacts)
                            {
                                ContactDetailsDto contactdto = new ContactDetailsDto();
                                contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(clientPartnerContact);
                                clientpartnerDto.ClientPartnerContacts.Add(contactdto);
                            }
                        }
                        #endregion

                        #region ClientPartner Guardian
                        if (clientpartner.ClientPartnerGuardian != null)
                        {
                            ClientPartnerGuardianDetailsDto clientpartnerguardianDto = Mapper.Map<ClientPartnerGuardianDetails, ClientPartnerGuardianDetailsDto>(clientpartner.ClientPartnerGuardian);
                            
                            #region Guardian Address
                            if (clientpartner.ClientPartnerGuardian.ClientPartnerGuardianAddress != null)
                            {
                                clientpartnerguardianDto.ClientPartnerGuardianAddress = addressService.EntityToEntityDto(clientpartner.ClientPartnerGuardian.ClientPartnerGuardianAddress);
                            }
                            #endregion

                            #region Guardian Contacts
                            clientpartnerguardianDto.ClientPartnerGuardianContacts.Clear();
                            if (clientpartner.ClientPartnerGuardian.ClientPartnerGuardianContacts != null)
                            {
                                foreach (ContactDetails clientPartnerGuardianContact in clientpartner.ClientPartnerGuardian.ClientPartnerGuardianContacts) 
                                {
                                    ContactDetailsDto contactdto = new ContactDetailsDto();
                                    contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(clientPartnerGuardianContact);
                                    clientpartnerguardianDto.ClientPartnerGuardianContacts.Add(contactdto);
                                }
                            }
                            #endregion

                            #region Guardian Relationship
                            if (clientpartner.ClientPartnerGuardian.GuardianRelationshipWithClientPartner != null)
                            {
                                clientpartnerguardianDto.GuardianRelationshipWithClientPartner = relationshipService.EntityToEntityDto(clientpartner.ClientPartnerGuardian.GuardianRelationshipWithClientPartner);
                            }
                            #endregion

                            clientpartnerDto.ClientPartnerGuardian = clientpartnerguardianDto;
                        }
                        #endregion

                        #region ClientPartner Nominee
                        if(clientpartner.ClientPartnerNominee != null)
                        {
                            ClientPartnerNomineeDetailsDto clientnomineeDto = Mapper.Map<ClientPartnerNomineeDetails, ClientPartnerNomineeDetailsDto>(clientpartner.ClientPartnerNominee);

                            #region Nominee Address
                            if (clientpartner.ClientPartnerNominee.ClientPartnerNomineeAddress != null)
                            {
                                clientnomineeDto.ClientPartnerNomineeAddress = addressService.EntityToEntityDto(clientpartner.ClientPartnerNominee.ClientPartnerNomineeAddress);
                            }
                            #endregion

                            #region Nominee Contacts
                            clientnomineeDto.ClientPartnerNomineeContacts.Clear();
                            if (clientpartner.ClientPartnerNominee.ClientPartnerNomineeContacts != null)
                            {
                                foreach (ContactDetails clientPartnerNomineeContact in clientpartner.ClientPartnerNominee.ClientPartnerNomineeContacts) 
                                {
                                    ContactDetailsDto contactdto = new ContactDetailsDto();
                                    contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(clientPartnerNomineeContact);
                                    clientnomineeDto.ClientPartnerNomineeContacts.Add(contactdto);
                                }
                            }
                            #endregion

                            #region Nominee Relationship
                            if (clientpartner.ClientPartnerNominee.NomineeRelationshipWithClientPartner != null)
                            {
                                clientnomineeDto.NomineeRelationshipWithClientPartner = relationshipService.EntityToEntityDto(clientpartner.ClientPartnerNominee.NomineeRelationshipWithClientPartner);
                            }
                            #endregion

                            clientpartnerDto.ClientPartnerNominee = clientnomineeDto;
                        }
                        #endregion

                        #region ClientPartner Banks
                        clientpartnerDto.ClientPartnerBanks.Clear();
                        if(clientpartner.ClientPartnerBanks != null)
                        {
                            foreach (ClientPartnerBankDetails clientpartnerbank in clientpartner.ClientPartnerBanks)
                            {
                                ClientPartnerBankDetailsDto clientpartnerbankDto = Mapper.Map<ClientPartnerBankDetails, ClientPartnerBankDetailsDto>(clientpartnerbank);

                                #region BranchOfClientPartner
                                if (clientpartnerbank.BranchOfClientPartner != null)
                                {
                                    clientpartnerbankDto.BranchOfClientPartner = branchService.EntityToEntityDto(clientpartnerbank.BranchOfClientPartner);
                                }
                                #endregion

                                #region BankContactPersonDesignation
                                if (clientpartnerbank.BankContactPersonDesignation != null)
                                {
                                    clientpartnerbankDto.BankContactPersonDesignation = designationService.EntityToEntityDto(clientpartnerbank.BankContactPersonDesignation);
                                }
                                #endregion

                                #region BankContactPersonContacts
                                clientpartnerbankDto.BankContactPersonContacts.Clear();
                                if (clientpartnerbank.BankContactPersonContacts != null)
                                {
                                    foreach (ContactDetails clientPartnerbankContact in clientpartnerbank.BankContactPersonContacts)
                                    {
                                        ContactDetailsDto contactdto = new ContactDetailsDto();
                                        contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(clientPartnerbankContact);
                                        clientpartnerbankDto.BankContactPersonContacts.Add(contactdto);
                                    }
                                }
                                #endregion

                                clientpartnerDto.ClientPartnerBanks.Add(clientpartnerbankDto);
                            }
                        }
                        #endregion

                        clientDto.ClientPartners.Add(clientpartnerDto);
                    }
                }
                #endregion

                
                if (PopulateChildObjects)
                {
                    UserService userService;
                    #region ClientUsers
                    clientDto.ClientUsers.Clear();
                    if (entity.ClientUsers != null)
                    {
                        userService = new UserService();
                        foreach (User user in entity.ClientUsers)
                        {
                            UserDto userDto = userService.EntityToEntityDto(user);
                            clientDto.ClientUsers.Add(userDto);
                        }
                    }
                    #endregion

                    #region Account Manager
                    if (entity.AccountManagerId != 0)
                    {
                        userService = new UserService();
                        clientDto.AccountManager = userService.GetById(entity.AccountManagerId);
                    }
                    #endregion

                }
            }
            return clientDto;
        }

        public override Client EntityDtoToEntity(ClientDto entityDto)
        {
            Client client = Mapper.Map<ClientDto, Client>(entityDto);
            if(entityDto != null)
            {
                #region ClientAddress
                if (entityDto.ClientAddress != null)
                {
                    AddressService addressService = new AddressService();
                    client.ClientAddress = addressService.EntityDtoToEntity(entityDto.ClientAddress);                    
                }
                #endregion

                #region ClientAPMC
                APMCService apmcservice = new APMCService();
                if (entityDto.ClientAPMC != null && entityDto.ClientAPMC.APMCId != 0)
                {
                    APMCDto apmcdto = apmcservice.GetById(entityDto.ClientAPMC.APMCId);

                    client.ClientAPMC = apmcservice.EntityDtoToEntity(apmcdto);
                }
                else
                    client.ClientAPMC = null;

                #endregion

                #region ClientBusinessConstitution
                BusinessConstitutionService bsService = new BusinessConstitutionService();
                if (entityDto.ClientBusinessConstitution != null && entityDto.ClientBusinessConstitution.BusinessConstitutionId != 0)
                {
                    BusinessConstitutionDto bsDto = bsService.GetById(entityDto.ClientBusinessConstitution.BusinessConstitutionId);
                    client.ClientBusinessConstitution = bsService.EntityDtoToEntity(bsDto);
                }
                else
                    client.ClientBusinessConstitution = null;

                #endregion

                #region ClientPhoneCharges
                if(entityDto.ClientPhoneCharges != null)
                {
                    client.ClientPhoneCharges = Mapper.Map<ClientPhoneChargesDto, ClientPhoneCharges>(entityDto.ClientPhoneCharges);
                }
                #endregion

                #region ClientPrimaryContactPerson
                if (entityDto.ClientPrimaryContactPerson != null)
                {
                    client.ClientPrimaryContactPerson = Mapper.Map<ClientPrimaryContactPersonDto, ClientPrimaryContactPerson>(entityDto.ClientPrimaryContactPerson);
                    #region ClientPrimaryContactPerson Address
                    if (entityDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                    {
                        AddressService addressService = new AddressService();
                        client.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress = addressService.EntityDtoToEntity(entityDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress);                        
                    }
                    #endregion

                    #region ClientPrimaryContactPerson Designation
                    DesignationService designationservice = new DesignationService();
                    if (entityDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation != null && entityDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation.DesignationId != 0)
                    {
                        DesignationDto designationdto = designationservice.GetById(entityDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation.DesignationId);
                        client.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation = designationservice.EntityDtoToEntity(designationdto);
                    }
                    else
                        client.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation = null;
                    #endregion

                    #region ClientPrimaryContactPerson ContactDetails
                    client.ClientPrimaryContactPerson.ClientPrimaryContacts.Clear();
                    if (entityDto.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                    {
                        foreach (ContactDetailsDto contactdetailsdto in entityDto.ClientPrimaryContactPerson.ClientPrimaryContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                        {
                            ContactDetails usercontactdetails = new Entities.ContactDetails();
                            usercontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                            client.ClientPrimaryContactPerson.ClientPrimaryContacts.Add(usercontactdetails);
                        }
                    }
                    #endregion
                }
                #endregion

                #region ClientContacts
                client.ClientContacts.Clear();
                if (entityDto.ClientContacts != null)
                {
                    foreach (ContactDetailsDto contactdetailsdto in entityDto.ClientContacts.Where(x=>x.ContactNo!=null && x.ContactNo!=""))
                    {                        
                        ContactDetails contactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                        client.ClientContacts.Add(contactdetails);
                    }
                }
                #endregion

                #region ClientSisterConcerns
                client.ClientSisterConcerns.Clear();
                if(entityDto.ClientSisterConcerns != null)
                {
                    foreach (ClientSisterConcernDto sisterconcernDto in entityDto.ClientSisterConcerns)
                    {
                        ClientSisterConcern sisterconcern = Mapper.Map<ClientSisterConcernDto, ClientSisterConcern>(sisterconcernDto);
                        client.ClientSisterConcerns.Add(sisterconcern);
                    }
                }
                #endregion

                #region ClientTaxationAndLicenses
                client.ClientTaxationAndLicenses.Clear();
                if(entityDto.ClientTaxationAndLicenses != null)
                {
                    foreach (ClientTaxationAndLicensesDto clienttaxationdto in entityDto.ClientTaxationAndLicenses)
                    {
                        ClientTaxationAndLicenses clienttaxation = Mapper.Map<ClientTaxationAndLicensesDto, ClientTaxationAndLicenses>(clienttaxationdto);
                        client.ClientTaxationAndLicenses.Add(clienttaxation);
                    }
                }
                #endregion

                #region ClientSubscription
                if (entityDto.ClientSubscription != null)
                {                   
                    client.ClientSubscription = Mapper.Map<ClientSubscriptionDto, ClientSubscription>(entityDto.ClientSubscription);
                    #region SubscriptionMaster
                    SubscriptionMasterService subscriptionservice = new SubscriptionMasterService();
                    if (entityDto.ClientSubscription.SubscriptionMaster != null && entityDto.ClientSubscription.SubscriptionMaster.SubscriptionId != 0)
                    {
                        SubscriptionMasterDto subscriptionDto = subscriptionservice.GetById(entityDto.ClientSubscription.SubscriptionMaster.SubscriptionId);
                        client.ClientSubscription.SubscriptionMaster = subscriptionservice.EntityDtoToEntity(subscriptionDto);
                    }
                    else
                        client.ClientSubscription.SubscriptionMaster = null;//subscriptionservice.EntityDtoToEntity(entityDto.ClientSubscription.SubscriptionMaster);
                    #endregion

                    #region ClientSubscription PaymentDetails
                    client.ClientSubscription.ClientSubscriptionPaymentDetails.Clear();
                    if (entityDto.ClientSubscription.ClientSubscriptionPaymentDetails != null)
                    {
                        BankBranchService branchservice = new BankBranchService();
                        foreach (ClientSubscriptionPaymentDetailsDto paymentdetailsDto in entityDto.ClientSubscription.ClientSubscriptionPaymentDetails)
                        {
                            ClientSubscriptionPaymentDetails paymetdetails = Mapper.Map<ClientSubscriptionPaymentDetailsDto, ClientSubscriptionPaymentDetails>(paymentdetailsDto);
                            if (paymentdetailsDto.BankBranch != null && paymentdetailsDto.BankBranch.BranchId != 0)
                            {
                                BankBranchDto branchDto = branchservice.GetById(paymentdetailsDto.BankBranch.BranchId);
                                paymetdetails.BankBranch = branchservice.EntityDtoToEntity(branchDto);
                            }
                            else
                            {
                                paymetdetails.BankBranch = null;// branchservice.EntityDtoToEntity(paymentdetailsDto.BankBranch);
                            }
                            client.ClientSubscription.ClientSubscriptionPaymentDetails.Add(paymetdetails);
                        }
                    }
                    #endregion
                }
                #endregion

                #region Commented CODE
                //#region AccountManager
                //client.AccountManager =  Mapper.Map<UserDto, User>(entityDto.AccountManager);
                //UserService userservice = new UserService();
                //if (entityDto.AccountManager != null && entityDto.AccountManager.UserId != 0)
                //{
                //    UserDto userDto = userservice.GetById(entityDto.AccountManager.UserId);
                //    client.AccountManager = userservice.EntityDtoToEntity(userDto);
                //}
                //else
                    //client.AccountManager = userservice.EntityDtoToEntity(entityDto.AccountManager);
                
                //#region ClientUsers
                //client.ClientUsers.Clear();
                //if(entityDto.ClientUsers != null)
                //{
                //    UserService userService = new UserService();
                //    foreach (UserDto userDto in entityDto.ClientUsers)
                //    {
                //        if (userDto.UserId != 0)
                //        {
                //            UserDto userdto = userService.GetById(userDto.UserId);
                //            client.ClientUsers.Add(userService.EntityDtoToEntity(userdto));
                //        }
                //        else
                //            client.ClientUsers.Add(userService.EntityDtoToEntity(userDto));
                //    }
                //}
                //#endregion
                #endregion

                #region ClientCommodities
                client.ClientCommodities.Clear();
                if(entityDto.ClientCommodities != null)
                {
                    CommodityClassService commodityclassService = new CommodityClassService();
                    foreach (CommodityClassDto commodityclassDto in entityDto.ClientCommodities)
                    {
                        if(commodityclassDto.CommodityClassId != 0)
                        {
                            CommodityClassDto commodityclassdto  = commodityclassService.GetById(commodityclassDto.CommodityClassId);
                            client.ClientCommodities.Add(commodityclassService.EntityDtoToEntity(commodityclassdto));
                        }
                        //else
                        //    client.ClientCommodities.Add(commodityclassService.EntityDtoToEntity(commodityclassDto));
                    }
                }
                #endregion

                #region ClientPartners
                client.ClientPartners.Clear();
                if(entityDto.ClientPartners != null)
                {
                    AddressService addressService = new AddressService();
                    DesignationService designationService = new DesignationService();
                    RelationshipService relationshipService = new RelationshipService();
                    BankBranchService branchService = new BankBranchService();

                    foreach (ClientPartnerDetailsDto clientparterDto in entityDto.ClientPartners)
                    {
                        ClientPartnerDetails clientpartner = Mapper.Map<ClientPartnerDetailsDto, ClientPartnerDetails>(clientparterDto);

                        #region ClientPartner Address
                        
                        if (clientparterDto.ClientPartnerAddress != null && clientparterDto.ClientPartnerAddress.AddressId != 0)
                        {                            
                            AddressDto addressDto = addressService.GetById(clientparterDto.ClientPartnerAddress.AddressId);
                            clientpartner.ClientPartnerAddress = addressService.EntityDtoToEntity(addressDto);
                        }
                        else
                        {
                            clientpartner.ClientPartnerAddress = addressService.EntityDtoToEntity(clientparterDto.ClientPartnerAddress);
                        }
                        #endregion

                        #region ClientPartner Designation
                       
                        if (clientparterDto.ClientPartnerDesignation != null && clientparterDto.ClientPartnerDesignation.DesignationId != 0)
                        {
                            DesignationDto designationDto = designationService.GetById(clientparterDto.ClientPartnerDesignation.DesignationId);
                            clientpartner.ClientPartnerDesignation = designationService.EntityDtoToEntity(designationDto);
                        }
                        else
                        {
                            clientpartner.ClientPartnerDesignation = null; 
                        }
                        #endregion 

                        #region ClientPartner Contacts
                        clientpartner.ClientPartnerContacts.Clear();
                        if (clientparterDto.ClientPartnerContacts != null)
                        {
                            foreach (ContactDetailsDto contactdetailsdto in clientparterDto.ClientPartnerContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                            {
                                ContactDetails contactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                                clientpartner.ClientPartnerContacts.Add(contactdetails);
                            }
                        }
                        #endregion 

                        #region ClientPartner Guardian
                        if(clientparterDto.ClientPartnerGuardian != null)
                        {
                            ClientPartnerGuardianDetails clientpartnerGuardian = Mapper.Map<ClientPartnerGuardianDetailsDto, ClientPartnerGuardianDetails>(clientparterDto.ClientPartnerGuardian);

                            #region Guardian Address
                            if (clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianAddress != null && clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianAddress.AddressId != 0)
                            {
                                AddressDto addressDto = addressService.GetById(clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianAddress.AddressId);
                                clientpartnerGuardian.ClientPartnerGuardianAddress = addressService.EntityDtoToEntity(addressDto);
                            }
                            else
                            {
                                clientpartnerGuardian.ClientPartnerGuardianAddress = addressService.EntityDtoToEntity(clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianAddress);
                            }
                            #endregion

                            #region Guardian Contacts
                            clientpartnerGuardian.ClientPartnerGuardianContacts.Clear();
                            if(clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianContacts != null)
                            {
                                foreach (ContactDetailsDto contactdetailsdto in clientparterDto.ClientPartnerGuardian.ClientPartnerGuardianContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                                {
                                    ContactDetails contactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                                    clientpartnerGuardian.ClientPartnerGuardianContacts.Add(contactdetails);
                                }
                            }
                            #endregion

                            #region Guardian Relationship
                            if (clientparterDto.ClientPartnerGuardian.GuardianRelationshipWithClientPartner != null && clientparterDto.ClientPartnerGuardian.GuardianRelationshipWithClientPartner.RelationshipId != 0)
                            {
                                RelationshipDto relationshipDto = relationshipService.GetById(clientparterDto.ClientPartnerGuardian.GuardianRelationshipWithClientPartner.RelationshipId);
                                clientpartnerGuardian.GuardianRelationshipWithClientPartner = relationshipService.EntityDtoToEntity(relationshipDto);
                            }
                            else
                            {
                                clientpartnerGuardian.GuardianRelationshipWithClientPartner = null; // relationshipService.EntityDtoToEntity(clientparterDto.ClientPartnerGuardian.GuardianRelationshipWithClientPartner);
                            }
                            #endregion

                            clientpartner.ClientPartnerGuardian = clientpartnerGuardian;
                        }
                        #endregion

                        #region ClientPartner Nominee
                        if (clientparterDto.ClientPartnerNominee != null)
                        {
                            ClientPartnerNomineeDetails clientpartnernominee = Mapper.Map<ClientPartnerNomineeDetailsDto, ClientPartnerNomineeDetails>(clientparterDto.ClientPartnerNominee);

                            #region Nominee Address
                            if (clientparterDto.ClientPartnerNominee.ClientPartnerNomineeAddress != null && clientparterDto.ClientPartnerNominee.ClientPartnerNomineeAddress.AddressId != 0)
                            {
                                AddressDto addressDto = addressService.GetById(clientparterDto.ClientPartnerNominee.ClientPartnerNomineeAddress.AddressId);
                                clientpartnernominee.ClientPartnerNomineeAddress = addressService.EntityDtoToEntity(addressDto);
                            }
                            else
                            {
                                clientpartnernominee.ClientPartnerNomineeAddress = addressService.EntityDtoToEntity(clientparterDto.ClientPartnerNominee.ClientPartnerNomineeAddress);
                            }
                            #endregion

                            #region Guardian Contacts
                            clientpartnernominee.ClientPartnerNomineeContacts.Clear();
                            if (clientparterDto.ClientPartnerNominee.ClientPartnerNomineeContacts != null)
                            {
                                foreach (ContactDetailsDto contactdetailsdto in clientparterDto.ClientPartnerNominee.ClientPartnerNomineeContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                                {
                                    ContactDetails contactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                                    clientpartnernominee.ClientPartnerNomineeContacts.Add(contactdetails);
                                }
                            }
                            #endregion

                            #region Guardian Relationship
                            if (clientparterDto.ClientPartnerNominee.NomineeRelationshipWithClientPartner != null && clientparterDto.ClientPartnerNominee.NomineeRelationshipWithClientPartner.RelationshipId != 0)
                            {
                                RelationshipDto relationshipDto = relationshipService.GetById(clientparterDto.ClientPartnerNominee.NomineeRelationshipWithClientPartner.RelationshipId);
                                clientpartnernominee.NomineeRelationshipWithClientPartner = relationshipService.EntityDtoToEntity(relationshipDto);
                            }
                            else
                            {
                                clientpartnernominee.NomineeRelationshipWithClientPartner = null; 
                            }
                            #endregion

                            clientpartner.ClientPartnerNominee = clientpartnernominee;
                        }
                        #endregion

                        #region ClientPartner Banks
                        clientpartner.ClientPartnerBanks.Clear();
                        if(clientparterDto.ClientPartnerBanks != null)
                        {
                            foreach(ClientPartnerBankDetailsDto clientpartnerbankDto in clientparterDto.ClientPartnerBanks)
                            {
                                ClientPartnerBankDetails clientpartnerbank = Mapper.Map<ClientPartnerBankDetailsDto, ClientPartnerBankDetails>(clientpartnerbankDto);

                                #region BranchOfClientPartner
                                if (clientpartnerbankDto.BranchOfClientPartner != null && clientpartnerbankDto.BranchOfClientPartner.BranchId != 0)
                                {
                                    BankBranchDto branchDto = branchService.GetById(clientpartnerbankDto.BranchOfClientPartner.BranchId);
                                    clientpartnerbank.BranchOfClientPartner = branchService.EntityDtoToEntity(branchDto);
                                }
                                else
                                {
                                    clientpartnerbank.BranchOfClientPartner = null;
                                }
                                #endregion

                                #region BankContactPersonDesignation
                                if (clientpartnerbankDto.BankContactPersonDesignation != null && clientpartnerbankDto.BankContactPersonDesignation.DesignationId != 0)
                                {
                                    DesignationDto designationDto = designationService.GetById(clientpartnerbankDto.BankContactPersonDesignation.DesignationId);
                                    clientpartnerbank.BankContactPersonDesignation = designationService.EntityDtoToEntity(designationDto);
                                }
                                else
                                {
                                    clientpartnerbank.BankContactPersonDesignation = null;
                                }
                                #endregion

                                #region BankContactPersonContacts
                                clientpartnerbank.BankContactPersonContacts.Clear();
                                if (clientpartnerbankDto.BankContactPersonContacts != null)
                                {
                                    foreach (ContactDetailsDto contactdetailsdto in clientpartnerbankDto.BankContactPersonContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                                    {
                                        ContactDetails contactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                                        clientpartnerbank.BankContactPersonContacts.Add(contactdetails);
                                    }
                                }
                                #endregion

                                clientpartner.ClientPartnerBanks.Add(clientpartnerbank);
                            }
                        }
                        #endregion

                        client.ClientPartners.Add(clientpartner);
                    }
                }
                #endregion
            }
            return client;
        }

        protected override string GetEntityInstanceName(Client entity)
        {
            return entity.CompanyName;
        }

        public override ClientDto CreateNewCommand(Repository.IRepositoryLocator locator, ClientDto entityDto, string userName)
        {
            ClientDto clientDto = base.CreateNewCommand(locator, entityDto, userName);

            entityDto.CAId = clientDto.CAId;
            entityDto.DisplayClientId = Common.Helper.GetDisplayClientID(clientDto.CAId, Common.Constants.DISPLAYCLIENTIDPREFIX, clientDto.CreatedDate);

            //update client to update the DisplayclientID
            //base.UpdateCommand(locator, entityDto, userName);

            // Create the Admin User group and user for client
            string mobileNo = null;
            if (clientDto.Status == Common.ClientStatus.Active)
            {
                if (entityDto.ClientPrimaryContactPerson != null)
                {
                    if (entityDto.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                    {
                        mobileNo = Common.Helper.GetMobileNoFromContacts(entityDto.ClientPrimaryContactPerson.ClientPrimaryContacts);
                    }

                    if (entityDto.ClientPrimaryContactPerson.CAPrimaryConatactPersonName != null && entityDto.ClientPrimaryContactPerson.MothersMaidenName != null
                        && mobileNo != string.Empty && entityDto.ClientPrimaryContactPerson.Email1 != null)
                    {
                        UserDto ClientAdminUser = CreateClientAdminUserFromContactPreson(clientDto.CAId, clientDto.CreatedDate, userName, clientDto.ClientPrimaryContactPerson);
                        clientDto.ClientUsers.Add(ClientAdminUser);
                    }
                }
            }
            //Add the warnings to the response
            if(Warnings!=null)
                clientDto.Response.AddBusinessWarnings(Warnings);

            return clientDto;
        }

        public override ClientDto UpdateCommand(Repository.IRepositoryLocator locator, ClientDto entityDto, string userName)
        {
            entityDto.DisplayClientId = Common.Helper.GetDisplayClientID(entityDto.CAId, Common.Constants.DISPLAYCLIENTIDPREFIX, entityDto.CreatedDate);
            ClientDto clientDto = base.UpdateCommand(locator, entityDto, userName);

            if (clientDto.Status == Common.ClientStatus.Active)
            {
                Query query = new Query();             
                UserService userService = new UserService();
                string UserName = Common.Helper.GetClientAdminUserName(entityDto.CAId, Common.Constants.CLIENTADMINPREFIX, entityDto.CreatedDate);
                Criterion criteriaUserName = new Criterion("Username", UserName, CriteriaOperator.Equal);
                Criterion criteriaId = new Criterion(Constants.CAID, entityDto.CAId, CriteriaOperator.Equal);                
                query.Add(criteriaUserName);
                query.Add(criteriaId);
                query.QueryOperator = QueryOperator.And;
                var res = userService.FindByQuery(query,false);

                if (res.TotalRecords > 0)
                {
                    UserDto userDto = res.Entities.ToList().FirstOrDefault();
                    UserDto ClientAdminUser = UpdateClientAdminUserFromContactPreson(entityDto.ClientPrimaryContactPerson, userName, userDto, entityDto.CAId);
                    clientDto.ClientUsers.Add(ClientAdminUser);
                }
                else
                {
                    UserDto ClientAdminUser = CreateClientAdminUserFromContactPreson(clientDto.CAId, clientDto.CreatedDate, userName, clientDto.ClientPrimaryContactPerson);
                    clientDto.ClientUsers.Add(ClientAdminUser);
                }
            }
            //Add the warnings to the response
            if (Warnings != null)
                clientDto.Response.AddBusinessWarnings(Warnings);

            return clientDto;
        }

        public EntityDtos<ClientDto> FindByQuery(Query query, bool populateChildObjects)
        {
            base.PopulateChildObjects = populateChildObjects;
            return base.FindByQuery(query);
        }
        #endregion

        private UserDto CreateClientAdminUserFromContactPreson(int CAId, DateTime ClientCreatedDate, string userName, ClientPrimaryContactPersonDto caPrimaryContactpersonDto)
        {
            #region Create Client Admin Usergroup
            UserGroupDto ugDto = new UserGroupDto
                                    {
                                        UserGroupName = Common.Constants.CLIENTADMINUSERGROUPNAME,
                                        Description = Common.Constants.CLIENTADMINUSERGROUPNAME,
                                        CreatedBy = caPrimaryContactpersonDto.CreatedBy,
                                        ModifiedBy = caPrimaryContactpersonDto.CreatedBy,
                                        IsActive = true,
                                        AllowEdit = false,
                                        AllowDelete = false,
                                        CAId = CAId
                                    };

            UserGroupService ugService = new UserGroupService();
            ugDto = ugService.Create(ugDto, userName);
            #endregion

            #region FillClientAdminUser details

            UserDto clientAdminUser = new UserDto
            {
                CAId = CAId,
                Title = caPrimaryContactpersonDto.Title,
                Name = caPrimaryContactpersonDto.CAPrimaryConatactPersonName,
                UserName = Common.Helper.GetClientAdminUserName(CAId, Common.Constants.CLIENTADMINPREFIX, ClientCreatedDate),
                MobileNo = Common.Helper.GetMobileNoFromContacts(caPrimaryContactpersonDto.ClientPrimaryContacts),
                Email = caPrimaryContactpersonDto.Email1,
                CountryCode = "091",
                MothersMaidenName = caPrimaryContactpersonDto.MothersMaidenName,
                IsActive = true,
                Password = Common.Helper.Encode(Common.Constants.CLIENTADMINPASSWORD),
                CreatedBy = caPrimaryContactpersonDto.CreatedBy,
                CreatedDate = DateTime.Now,
                IsLockedOut = false,
                IsOnLine = false,
                ModifiedBy = caPrimaryContactpersonDto.CreatedBy,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                AllowDelete = false,
                AllowEdit = true,
                UserWithUserGroups = new List<UserGroupDto>
                {
                      new UserGroupDto
                      {
                          UserGroupId = ugDto.UserGroupId
                      }   
                },
                UserProfile = new UserProfileDto
                {
                    Gender = caPrimaryContactpersonDto.Gender,
                    PAN = caPrimaryContactpersonDto.PAN,
                    UID = caPrimaryContactpersonDto.UID,
                    Email2 = caPrimaryContactpersonDto.Email2,
                    //MaritalStatus = "",
                    //PassportNo = "",
                    //PassportPlace = "",
                    //PassportValidFromDate = null,
                    //PassportValidToDate = null,
                    //BloodGroup = "",
                    //DateOfJoining = null,
                    //PFNo = "",
                    //Email1 = "",                    
                    //UserEmergencyContactPerson = null,
                    CreatedBy = caPrimaryContactpersonDto.CreatedBy,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = caPrimaryContactpersonDto.ModifiedBy,
                    ModifiedDate = DateTime.Now,
                    UserAddress = new AddressDto
                    {
                        AddressLine1 = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.AddressLine1,
                        AddressLine2 = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.AddressLine2,
                        PIN = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.PIN,
                        CreatedBy = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.CreatedBy,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.ModifiedBy,
                        ModifiedDate = DateTime.Now,
                        CityVillage = new CityVillageDto
                        {
                            CityVillageId = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress.CityVillage.CityVillageId
                        }
                    },
                    //ContactNos = new List<ContactDetailsDto>
                    //{
                    //    foreach(ContactDetailsDto contactDto in caPrimaryContactpersonDto.ClientPrimaryContacts.ToList())
                    //    {

                    //    }
                    //}
                }
            };

            if (caPrimaryContactpersonDto.DateOfBirth != null)
            {
                clientAdminUser.DateOfBirth = Convert.ToDateTime(caPrimaryContactpersonDto.DateOfBirth);
            }
            else
            {
                DateTime sqlDefaultDate = Helper.SetDefaultDate();
                clientAdminUser.DateOfBirth = sqlDefaultDate;
            }

            if (caPrimaryContactpersonDto.ClientPrimaryContactPersonDesignation != null)
            {
                clientAdminUser.UserDesignation = new DesignationDto
                {
                    DesignationId = caPrimaryContactpersonDto.ClientPrimaryContactPersonDesignation.DesignationId
                };
            }
            else
                clientAdminUser.UserDesignation = null;

            #endregion

            #region Create Client Admin User
            UserService userService = new UserService();
            clientAdminUser = userService.Create(clientAdminUser, userName);
            userService = null;
            return clientAdminUser;
            #endregion
        }

        private UserDto UpdateClientAdminUserFromContactPreson(ClientPrimaryContactPersonDto caPrimaryContactpersonDto, string userName, UserDto userDto, int CAId) 
        {         

            #region Update User details

            userDto.Title = caPrimaryContactpersonDto.Title;
            userDto.Name = caPrimaryContactpersonDto.CAPrimaryConatactPersonName;
            userDto.MobileNo = Common.Helper.GetMobileNoFromContacts(caPrimaryContactpersonDto.ClientPrimaryContacts);
            userDto.Email = caPrimaryContactpersonDto.Email1;
            userDto.MothersMaidenName = caPrimaryContactpersonDto.MothersMaidenName;
            userDto.ModifiedBy = caPrimaryContactpersonDto.ModifiedBy;
            userDto.ModifiedDate = DateTime.Now;

            #region userprofile
            userDto.UserProfile.Gender = caPrimaryContactpersonDto.Gender;
            userDto.UserProfile.PAN = caPrimaryContactpersonDto.PAN;
            userDto.UserProfile.UID = caPrimaryContactpersonDto.UID;
            userDto.UserProfile.Email2 = caPrimaryContactpersonDto.Email2;
            userDto.UserProfile.ModifiedBy = caPrimaryContactpersonDto.ModifiedBy;
            userDto.UserProfile.ModifiedDate = DateTime.Now;
            userDto.UserProfile.UserAddress = caPrimaryContactpersonDto.ClientPrimaryContactPersonAddress;
            userDto.UserProfile.ContactNos = caPrimaryContactpersonDto.ClientPrimaryContacts;
            #endregion

            #endregion

            #region Update User details
            UserService userService = new UserService();
            userService.PopulateChildObjects = false;
            userDto = userService.Update(userDto, userName);
            userService = null;
            return userDto;
            #endregion
        }
        
        #region Private Methods

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
            activityLogDto.ActivityRelatedTo = typeof(Client).Name;

            activityLogService = new ActivityLogService();
            activityLogService.Create(activityLogDto, userName);
        }

        private bool IsPANPresent(Client client, bool IsEdit) 
        {
            bool isPresent = false;
            Query query = new Query();
            Criterion criteriaPAN = new Criterion(Constants.CLIENTPAN, client.PAN, CriteriaOperator.Equal);
            Criterion criteriaAPMCLicNo = new Criterion(Constants.CLIENTAPMCLICENCENO, client.APMCLicenseNo, CriteriaOperator.Equal);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.CAID, client.CAId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaPAN);
            query.Add(criteriaAPMCLicNo);
            query.QueryOperator = QueryOperator.And;
            var clientlist = ExecuteCommand(locator => locator.GetRepository<Client>().FindBy(query));
            if (clientlist.Count() != 0)
            {
                isPresent = true;
            }
            return isPresent;
        }

        private bool IsTANPresent(Client client, bool IsEdit) 
        {
            bool isPresent = false;
            Query query = new Query(); 
            Criterion criteriaTAN = new Criterion(Constants.CLIENTTAN, client.TAN, CriteriaOperator.Equal);
            Criterion criteriaAPMCLicNo = new Criterion(Constants.CLIENTAPMCLICENCENO, client.APMCLicenseNo, CriteriaOperator.Equal);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.CAID, client.CAId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaTAN);
            query.Add(criteriaAPMCLicNo);
            query.QueryOperator = QueryOperator.And;
            var clientlist = ExecuteCommand(locator => locator.GetRepository<Client>().FindBy(query));
            if (clientlist.Count() != 0)
            {
                isPresent = true;
            }
            return isPresent;
        }

        private bool IsClientPresent(Client client, bool IsEdit) 
        {
            bool isPresent = false;
            Query query = new Query();            
            Criterion criteriaCompanyname = new Criterion(Constants.CLIENTCOMPANYNAME, client.CompanyName, CriteriaOperator.Equal);
            Criterion criteriaPAN = new Criterion(Constants.CLIENTPAN, client.PAN, CriteriaOperator.Equal);
            Criterion criteriaAPMCLicNo = new Criterion(Constants.CLIENTAPMCLICENCENO, client.APMCLicenseNo, CriteriaOperator.Equal);
            Criterion criteriaPlaceName = new Criterion("cv.Name", client.ClientAddress.CityVillage.Name, CriteriaOperator.Equal);

            query.AddAlias(new Alias("clientaddress", "ClientAddress"));
            query.AddAlias(new Alias("cv", "clientaddress.CityVillage"));
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.CAID, client.CAId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaCompanyname);            
            query.Add(criteriaPAN);
            query.Add(criteriaAPMCLicNo);
            query.Add(criteriaPlaceName);
            query.QueryOperator = QueryOperator.And;
            var clientlist = base.FindByQuery(query);
            IEnumerable<ClientDto> clList = clientlist.Entities.AsEnumerable();
            if (clientlist.TotalRecords != 0)
            {
                foreach (ClientDto clDto in clList)   
                {
                    foreach (CommodityClass commodityClass in client.ClientCommodities)
                    {
                        var existsCommodityClass = clDto.ClientCommodities.Where(x => x.CommodityClassId == commodityClass.CommodityClassId);
                        if (existsCommodityClass.Count() != 0)
                        {
                            isPresent = true;
                        }
                    }
                }
            }
            return isPresent;
        }

        private bool IsAPMCLicNoPresent(Client client, bool IsEdit) 
        {
            bool isPresent = false;
            Query query = new Query();
            Criterion criteriaAPMCLicNo = new Criterion(Constants.CLIENTAPMCLICENCENO, client.APMCLicenseNo, CriteriaOperator.Equal);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion(Constants.CAID, client.CAId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaAPMCLicNo);
            query.QueryOperator = QueryOperator.And;
            var clientlist = ExecuteCommand(locator => locator.GetRepository<Client>().FindBy(query));
            if (clientlist.Count() != 0)
            {
                isPresent = true;
            }
            return isPresent;
        }

        private bool IsMobileNoPresent(string MobileNo, int CAPrimaryContactPersonId, bool IsEdit) 
        {
            bool isPresent = false;
            Query query = new Query();            
            Criterion criteriaMobileNo = new Criterion("clientPrimaryPersonContactNo.ContactNo", MobileNo, CriteriaOperator.Equal);
            if (IsEdit)
            {
                Criterion criteriaId = new Criterion("primaryContact.CAPrimaryContactPersonId", CAPrimaryContactPersonId, CriteriaOperator.NotEqual);
                query.Add(criteriaId);
            }
            query.Add(criteriaMobileNo);
            query.AddAlias(new Alias("primaryContact", "ClientPrimaryContactPerson"));
            query.AddAlias(new Alias("clientPrimaryPersonContactNo", "primaryContact.ClientPrimaryContacts"));
            var mobileNoList = base.FindByQuery(query);
            if (mobileNoList.TotalRecords != 0)
            {
                isPresent = true;
            }            
            return isPresent;
        }
        #endregion
    }
}
