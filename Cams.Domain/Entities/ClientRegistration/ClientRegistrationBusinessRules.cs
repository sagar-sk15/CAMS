using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientRegistrationBusinessRules
    {
        public static readonly BusinessRule MissingCompanyName = new BusinessRule(Constants.CLIENTCOMPANYNAME, Constants.BRCLIENTMISSINGCOMPANYNAME); 
        public static readonly BusinessRule CheckClientPresence = new BusinessRule(Constants.CLIENTCOMPANYNAME, Constants.BRCLIENTUNIQUE); 
        public static readonly BusinessRule CheckPANPresence = new BusinessRule(Constants.CLIENTPAN, Constants.BRCLIENTPANUNIQUE);
        public static readonly BusinessRule CheckTANPresence = new BusinessRule(Constants.CLIENTTAN, Constants.BRCLIENTTANUNIQUE);
        public static readonly BusinessRule CheckAPMCNoPresence = new BusinessRule(Constants.CLIENTAPMCLICENCENO, Constants.BRCLIENTAPMCLICNOUNIQUE);
        public static readonly BusinessRule MissingCityVillage = new BusinessRule(Constants.CLIENTADDRESSCITYVILLAGE, Constants.BRCLIENTMISSINGCITYVILLAGE);

        public static readonly BusinessRule ClientRegExPAN = new BusinessRule("PAN", Constants.CLIENTERRORREGEXPAN);
        public static readonly BusinessRule ClientRegExTAN = new BusinessRule("TAN", Constants.CLIENTERRORREGEXTAN);
        public static readonly BusinessRule ClientRegExPIN = new BusinessRule("PIN", Constants.CLIENTERRORREGEXPIN);
        public static readonly BusinessRule ClientRegExEmail1 = new BusinessRule("Email1", Constants.CLIENTERRORREGEXEMAIL1);
        public static readonly BusinessRule ClientRegExEmail2 = new BusinessRule("Email2", Constants.CLIENTERRORREGEXEMAIL2);
        public static readonly BusinessRule ClientErrorRegExContactNo = new BusinessRule("ContactNo", Constants.CLIENTERRORREGEXCONTACTNO);
        public static readonly BusinessRule ClientErrorRegExSTDCode = new BusinessRule("STDCode", Constants.CLIENTERRORREGEXSTDCODE);
        public static readonly BusinessRule ClientErrorRequiredPAN = new BusinessRule("RequiredPAN", Constants.CLIENTERRORREQUIREDPAN);
        public static readonly BusinessRule ClientErrorRequiredPIN = new BusinessRule("RequiredPIN", Constants.CLIENTERRORREQUIREDPIN);
        public static readonly BusinessRule ClientErrorRequiredEmail1 = new BusinessRule("RequiredEmail1", Constants.CLIENTERRORREQUIREDEMAIL1);
        public static readonly BusinessRule ClientErrorRequiredAccountManager = new BusinessRule("RequiredAccountManager", Constants.CLIENTERRORREQUIREDACCOUNTMANAGER); 
        

        /// <summary>
        /// Client Primary Contact Person
        /// </summary>
        public static readonly BusinessRule ClientPrimaryContactRegExPAN = new BusinessRule("PrimaryContactPersonPAN", Constants.CLIENTPRIMARYCONTACTERRORREGEXPAN);
        public static readonly BusinessRule ClientPrimaryContactRegExUID = new BusinessRule("PrimaryContactPersonUID", Constants.CLIENTPRIMARYCONTACTERRORREGEXUID);
        public static readonly BusinessRule ClientPrimaryContactRegExPIN = new BusinessRule("ClientPrimaryContactPIN", Constants.CLIENTPRIMARYCONTACTERRORREGEXPIN);
        public static readonly BusinessRule ClientPrimaryContactRegExEmail1 = new BusinessRule("ClientPrimaryContactEmail1", Constants.CLIENTPRIMARYCONTACTERRORREGEXEMAIL1);
        public static readonly BusinessRule ClientPrimaryContactRegExEmail2 = new BusinessRule("ClientPrimaryContactEmail2", Constants.CLIENTPRIMARYCONTACTERRORREGEXEMAIL2);
        public static readonly BusinessRule ClientPrimaryContactErrorRegExContactNo = new BusinessRule("ClientPrimaryContactContactNo", Constants.CLIENTPRIMARYCONTACTERRORREGEXCONTACTNO);
        public static readonly BusinessRule ClientPrimaryContactErrorRegExSTDCode = new BusinessRule("ClientPrimaryContactSTDCode", Constants.CLIENTPRIMARYCONTACTERRORREGEXSTDCODE);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredName = new BusinessRule("ClientPrimaryContactRequiredName", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDNAME);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredDesignationName = new BusinessRule("ClientPrimaryContactRequiredDesignationName", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDDESIGNATIONNAME);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredDOB = new BusinessRule("ClientPrimaryContactRequiredDOB", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDDOB);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredMotherName = new BusinessRule("ClientPrimaryContactRequiredMotherName", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDMOTHERNAME);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredPAN = new BusinessRule("ClientPrimaryContactRequiredPAN", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDPAN);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredPIN = new BusinessRule("ClientPrimaryContactRequiredPIN", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDPIN);
        public static readonly BusinessRule ClientPrimaryContactErrorRequiredMobileNo = new BusinessRule("ClientPrimaryContactRequiredMobileNo", Constants.CLIENTPRIMARYCONTACTERRORREQUIREDMOBILENO);
        public static readonly BusinessRule CheckClientPrimaryContactMobileNoPresence = new BusinessRule("ClientPrimaryContactMobileNo", Constants.CLIENTERRORRREQUIREDCOMMODITYCLASS); 

        /// <summary>
        /// APMC
        /// </summary>
        public static readonly BusinessRule ClientAPMCErrorRequiredAPMCName = new BusinessRule("ClientAPMCRequiredAPMCName", Constants.CLIENTAPMCERRORRREQUIREDAPMCNAME);
        public static readonly BusinessRule ClientAPMCErrorRequiredAPMCLicenseNo = new BusinessRule("ClientAPMCRequiredAPMCLicenseNo", Constants.CLIENTAPMCERRORRREQUIREDAPMCLICENSENO);
        public static readonly BusinessRule ClientAPMCErrorAPMCLicenseNoValidUpToDate = new BusinessRule("ClientAPMCLicenseNoDate", Constants.CLIENTAPMCERRORAPMCLICENSENODATE);
        public static readonly BusinessRule ClientAPMCErrorRequiredAPMCLicenseNoValidUpToDate = new BusinessRule("ClientAPMCRequiredAPMCLicenseNoDate", Constants.CLIENTAPMCERRORRREQUIREDAPMCLICENSENODATE);
        public static readonly BusinessRule ClientErrorCommodityClass = new BusinessRule("ClientCommodityClass", Constants.CLIENTERRORCOMMODITYCLASS);
        public static readonly BusinessRule ClientErrorRequiredCommodityClass = new BusinessRule("ClientRequiredCommodityClass", Constants.CLIENTERRORRREQUIREDCOMMODITYCLASS); 

       
    } 
}

