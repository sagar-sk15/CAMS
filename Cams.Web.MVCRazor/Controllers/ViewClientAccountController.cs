using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.ClientServiceReference;
using Cams.Web.MVCRazor.Helpers;
using Cams.Web.MVCRazor.Models.ClientRegistration;
using Cams.Web.MVCRazor.UserServiceReference;
using System.Globalization;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientAccountController : CommonController
    {
        [CamsAuthorize(Roles = Constants.MANAGECLIENTUSERS
          , Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        [HttpGet]
        public ActionResult ClientRegistrationViewIndex(int CAId, string mode)
        {
            ClientRegistrationModel clientRegistrationModel = null;
            ClientDto clientDto = null;
            try
            {
                if (CAId > 0)
                {
                    clientRegistrationModel = new ClientRegistrationModel();
                    clientDto = GetClient(CAId, false);

                    if (clientDto != null)
                    {
                        #region CompanyProfile
                        clientRegistrationModel.DisplayClientId = clientDto.DisplayClientId;
                        clientRegistrationModel.CompanyName = clientDto.CompanyName;
                        clientRegistrationModel.Alias = clientDto.Alias;
                        clientRegistrationModel.PAN = clientDto.PAN;
                        clientRegistrationModel.TAN = clientDto.TAN;

                        if (clientDto.RegistrationDate != null)
                        {
                            DateTime clientRegistrationDate = Convert.ToDateTime(clientDto.RegistrationDate);
                            clientRegistrationModel.RegistrationDateString = clientRegistrationDate.ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            clientRegistrationModel.RegistrationDateString = "";
                        }

                        clientRegistrationModel.Image = clientDto.Image;

                        if (clientDto.ClientAddress != null)
                        {
                            clientRegistrationModel.CompanyAddress.SetAddress(clientDto.ClientAddress);
                        }

                        if (clientDto.ClientContacts != null)
                        {
                            clientRegistrationModel.CompanyContacts.Contacts = clientDto.ClientContacts;
                        }
                        clientRegistrationModel.CompanyContacts.Email1 = clientDto.Email1;
                        clientRegistrationModel.CompanyContacts.Email2 = clientDto.Email2;
                        clientRegistrationModel.CompanyContacts.Website = clientDto.Website;

                        #endregion

                        #region ClientPrimaryContactPerson
                        if (clientDto.ClientPrimaryContactPerson != null)
                        {
                            clientRegistrationModel.ClientPrimaryContactPerson = clientDto.ClientPrimaryContactPerson;
                            if (clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                            {
                                clientRegistrationModel.PrimaryContactsAddress.SetAddress(clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress);
                            }
                            if (clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
                            {
                                clientRegistrationModel.PrimaryContactsContacts.Contacts =
                                    clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts;
                            }
                            clientRegistrationModel.ClientPrimaryContactPerson.Email1 = clientDto.ClientPrimaryContactPerson.Email1;
                            clientRegistrationModel.ClientPrimaryContactPerson.Email2 = clientDto.ClientPrimaryContactPerson.Email2;
                            clientRegistrationModel.PrimaryContactsContacts.IsWebsiteApplicable = false;

                            DateTime primaryContactPersonDateOfBirth = Convert.ToDateTime(clientDto.ClientPrimaryContactPerson.DateOfBirth);
                            clientRegistrationModel.PrimaryContactPersonDOBString = primaryContactPersonDateOfBirth.ToString("dd-MM-yyyy");
                        }

                        #endregion

                        #region ClientAPMC
                        if (clientDto.ClientAPMC != null)
                        {
                            clientRegistrationModel.ClientAPMC = clientDto.ClientAPMC;
                            if (clientDto.APMCLicenseValidUpTo != null)
                            {
                                DateTime apmcValidUptoDate = Convert.ToDateTime(clientDto.APMCLicenseValidUpTo);
                                clientRegistrationModel.APMCValiduptoString = apmcValidUptoDate.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                clientRegistrationModel.APMCValiduptoString = "";
                            }
                            if (clientDto.ClientAPMC.Address != null)
                            {
                                clientRegistrationModel.APMCAddress.SetAddress(clientDto.ClientAPMC.Address);
                            }
                            if (clientDto.ClientAPMC.ContactNos != null)
                            {
                                clientRegistrationModel.APMCContacts.Contacts = clientDto.ClientAPMC.ContactNos;
                            }
                            clientRegistrationModel.APMCContacts.Email1 = clientDto.ClientAPMC.Email1;
                            clientRegistrationModel.APMCContacts.Email2 = clientDto.ClientAPMC.Email2;
                            clientRegistrationModel.APMCContacts.Website = clientDto.ClientAPMC.Website;
                            clientRegistrationModel.APMCLicenseNo = clientDto.APMCLicenseNo;
                            clientRegistrationModel.CommodityClassDtoList = clientDto.ClientCommodities;
                        }
                        #endregion

                        #region ClientSubscription
                        if (clientDto.ClientSubscription != null)
                        {
                            if (clientDto.ClientSubscription.ClientSubscriptionPaymentDetails != null)
                            {
                                if (clientRegistrationModel.ClientSubscriptionPaymentDetailsModel != null)
                                    clientRegistrationModel.ClientSubscriptionPaymentDetailsModel.Clear();

                                decimal totalAmount = 0;
                                foreach (var clientSubscriptionPaymentDetailsDto in clientDto.ClientSubscription.ClientSubscriptionPaymentDetails)
                                {
                                    ClientSubscriptionPaymentDetailsModel clientSubscriptionPaymentDetailsModel = new ClientSubscriptionPaymentDetailsModel();

                                    clientSubscriptionPaymentDetailsModel.PaymentMode =
                                        clientSubscriptionPaymentDetailsDto.PaymentMode;

                                    clientSubscriptionPaymentDetailsModel.Amount =
                                        Math.Round(clientSubscriptionPaymentDetailsDto.Amount,2);

                                    if (clientSubscriptionPaymentDetailsDto.ChequeDDTransactionDate != null)
                                    {
                                        DateTime ChequeDDTransactionDate =
                                            Convert.ToDateTime(
                                                clientSubscriptionPaymentDetailsDto.ChequeDDTransactionDate);
                                        clientSubscriptionPaymentDetailsModel.ChequeDDTransactionDateString =
                                            ChequeDDTransactionDate.ToString("dd-MM-yyyy");
                                    }
                                    else
                                    {
                                        clientSubscriptionPaymentDetailsModel.ChequeDDTransactionDateString = "";
                                    }


                                    clientSubscriptionPaymentDetailsModel.ChequeDDTransationNo =
                                        clientSubscriptionPaymentDetailsDto.ChequeDDTransationNo;

                                    if (clientSubscriptionPaymentDetailsDto.ChequeDDClearanceDates != null)
                                    {
                                        DateTime ChequeClearanceDate =
                                            Convert.ToDateTime(
                                                clientSubscriptionPaymentDetailsDto.ChequeDDClearanceDates);
                                        clientSubscriptionPaymentDetailsModel.ChequeClearanceDateString =
                                            ChequeClearanceDate.ToString("dd-MM-yyyy");
                                    }
                                    else
                                    {
                                        clientSubscriptionPaymentDetailsModel.ChequeClearanceDateString = "";
                                    }


                                    clientSubscriptionPaymentDetailsModel.IsRTGS =
                                        clientSubscriptionPaymentDetailsDto.IsRTGS;

                                    clientSubscriptionPaymentDetailsModel.IsStandardCheque =
                                        clientSubscriptionPaymentDetailsDto.IsStandardCheque;

                                    clientSubscriptionPaymentDetailsModel.IsNEFT =
                                        clientSubscriptionPaymentDetailsDto.IsNEFT;

                                    clientSubscriptionPaymentDetailsModel.BankBranch =
                                        clientSubscriptionPaymentDetailsDto.BankBranch;

                                    totalAmount += clientSubscriptionPaymentDetailsDto.Amount;
                                    if (clientRegistrationModel.ClientSubscriptionPaymentDetailsModel != null)
                                        clientRegistrationModel.ClientSubscriptionPaymentDetailsModel.Add(clientSubscriptionPaymentDetailsModel);
                                }

                                if (clientRegistrationModel.ClientSubscriptionPaymentDetailsModel != null && clientRegistrationModel.ClientSubscriptionPaymentDetailsModel.Count > 0)
                                {
                                    clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].TotalAmount =
                                        Math.Round(totalAmount,2);
                                    clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].TDS =
                                        Math.Round(clientDto.TDSOnSubscriptionPayment,2);
                                    clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].NetAmount =
                                        clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].TotalAmount -
                                        clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].TDS;
                                    clientRegistrationModel.ClientSubscriptionPaymentDetailsModel[0].AdditionalInfo =
                                        clientDto.AdditionalInfoForSubscriptionPayment;
                                }
                            }
                            clientRegistrationModel.ClientSubscription = clientDto.ClientSubscription;

                            if (clientRegistrationModel.ClientSubscription.SubscriptionPeriodFromDate != null)
                            {
                                DateTime subscriptionPeriodFromDate = Convert.ToDateTime(clientRegistrationModel.ClientSubscription.SubscriptionPeriodFromDate);

                                clientRegistrationModel.SubscriptionPeriodFromDateString =
                                    subscriptionPeriodFromDate.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                clientRegistrationModel.SubscriptionPeriodFromDateString = "";
                            }
                            if (clientRegistrationModel.ClientSubscription.SubscriptionPeriodToDate != null)
                            {
                                DateTime subscriptionPeriodToDate =
                                    Convert.ToDateTime(clientRegistrationModel.ClientSubscription.SubscriptionPeriodToDate);
                                clientRegistrationModel.SubscriptionPeriodToDateString =
                                    subscriptionPeriodToDate.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                clientRegistrationModel.SubscriptionPeriodToDateString = "";
                            }
                            if (clientRegistrationModel.ClientSubscription.ActivationDate != null)
                            {
                                DateTime subscriptionPeriodActivationDateString =
                                    Convert.ToDateTime(clientRegistrationModel.ClientSubscription.ActivationDate);
                                clientRegistrationModel.SubscriptionPeriodActivationDateString =
                                    subscriptionPeriodActivationDateString.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                clientRegistrationModel.SubscriptionPeriodActivationDateString = "";
                            }


                            #region ClientSubscription Calculations
                            if (clientDto.ClientSubscription.SubscriptionMaster != null)
                            {
                                if (clientDto.ClientSubscription.SubscriptionMaster.SubscriptionType == SubscriptionType.Standard)
                                {
                                    clientRegistrationModel.SubscriptionFees = 50000;
                                }
                                else
                                {
                                    clientRegistrationModel.SubscriptionFees = 100000;
                                }
                            }

                            clientRegistrationModel.TotalAdditionalUsers =
                                clientDto.ClientSubscription.AdditionalNoOfEmployees +
                                clientDto.ClientSubscription.AdditionalNoOfAuditors +
                                clientDto.ClientSubscription.AdditionalNoOfAssociates;

                            clientRegistrationModel.TotalAdditionalCost += clientDto.ClientSubscription.AdditionalCostForEmployees +
                                   clientDto.ClientSubscription.AdditionalCostForAuditors +
                                   clientDto.ClientSubscription.AdditionalCostForAssociates;

                            decimal totalsubFees = 0;
                            int i = clientDto.ClientSubscription.SubscriptionPeriod;
                            var subscriptionMasterDto = clientDto.ClientSubscription.SubscriptionMaster;

                            if (subscriptionMasterDto != null)
                            {
                                if (i > 1)
                                {
                                    totalsubFees =
                                        (clientRegistrationModel.SubscriptionFees *
                                         subscriptionMasterDto.RenewalFeesPerAnnum) / 100;
                                    clientRegistrationModel.SubscriptionFees += (totalsubFees * --i);
                                }
                            }

                            clientRegistrationModel.SubscriptionFees += (clientRegistrationModel.TotalAdditionalCost * clientDto.ClientSubscription.SubscriptionPeriod);


                            clientRegistrationModel.TotalSubscriptionFees = (float)clientRegistrationModel.SubscriptionFees;

                            clientRegistrationModel.NetAmount = (clientRegistrationModel.SubscriptionFees -
                                                                 clientDto.ClientSubscription.DiscountInRupees) +
                                                                clientDto.ClientSubscription.ServiceTax +
                                                                clientDto.ClientSubscription.OtherTax;


                            #endregion

                        }
                        #endregion

                        #region ClientBusinessConstitution
                        if (clientDto.ClientBusinessConstitution != null)
                        {
                            clientRegistrationModel.ClientBusinessConstitution = clientDto.ClientBusinessConstitution;
                        }
                        #endregion

                        #region ClientPartners
                        if (clientDto.ClientPartners != null)
                        {
                            clientRegistrationModel.businessConstitutionModel.ClientPartners =
                                clientDto.ClientPartners.ToList();
                            clientRegistrationModel.businessConstitutionModel.NoOfClientPartners =
                                clientDto.ClientPartners.Count;
                        }
                        #endregion

                        #region Accounmanger
                        clientRegistrationModel.AccountManagerId = clientDto.AccountManagerId;
                        Query queryAccountManger = new Query();
                        Criterion criterion = new Criterion("UserId", clientRegistrationModel.AccountManagerId, CriteriaOperator.Equal);
                        queryAccountManger.Add(criterion);
                        UserServiceReference.UserServiceClient client = new UserServiceClient();
                        IList<UserDto> accountManager = client.FindByQuery(queryAccountManger, false).Entities;
                        if (accountManager != null && accountManager.Count > 0)
                        {
                            clientRegistrationModel.AccountManager = accountManager[0];
                        }
                        else
                            clientRegistrationModel.AccountManager = new UserDto();
                        client.Close();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            return View("ClientRegistrationView", clientRegistrationModel);
        }
    }
}
