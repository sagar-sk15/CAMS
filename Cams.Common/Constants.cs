// Filename     :   Constants.cs
// Purpose      :   
// Module       :   Cams.Common
// Dependencies :	No
// To-do        :	No
// Known issues :	N/A
// Cookies      :   N/A
// Query-string :   N/A
// History      :	Created: Sujata
//			        LastModified: x, date


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace Cams.Common
{
    public static class Constants
    {
        #region String Constants For minimum Age Limits
        public const int ACKUSERAGELIMIT = 18;
        public const int CAUSERAGELIMIT = 15;
        #endregion

        #region Constants for Maximum Labour Charge Limit
        public const int MAXLABOURCHARGEALLOWED = 7;
        #endregion

        #region String Constants For Session Manager
        public const string SKCURRENTUSER = "CurrentLoggedUser";
        public const string SKUSERNAME = "UserName";
        public const string SKSTATES = "StatesInIndia";
        public const string SKUSERPROFILEIMAGE = "UserProfileImage";
        #endregion

        #region Constants For PAN & TAN numbers Length
        public const int PANLENGTH = 10;
        public const int TANLENGTH = 10; 
        #endregion

        #region Constants for client registration maximum commodity class count
        public const int CLIENTMAXIMUMCOMMOCITYCLASS = 3;
        #endregion

        #region String Constants For Cache Manager
        #endregion

        #region String Constants For SuperAdmin
        public const string SUPERADMINGROUP = "SuperAdmin";
        public const string SUPERADMINUSER = "SuperAdmin";
        #endregion

        #region String Constants For ClientAdmin Group
        public const string CLIENTADMINGROUP = "Admin";
        #endregion

        #region String Constants For Resource Files
        // User
        public const string BRUSERNAME = "BRUserName";
        public const string BREMAIL = "BREmail";
        public const string BRMOBILENO = "BRMobileNo";
        public const string BRMOTHERSMAIDENNAME = "BRMothersMaidenName";
        public const string BRNAME = "BRName";
        public const string BRPASSWORD = "BRPassword";
        public const string BRDATEOFBIRTH = "BRDateOfBirth";
        // UserGroup
        public const string BRUSERGROUPNAMEREQUIRED = "BRUserGroupNameRequired";
        public const string BRUSERGROUPNAMEUNIQUE = "BRUserGroupNameUnique";
        public const string BRUSERGROUPNAMEDISPLAY = "BRUserGroupNameDisplay";
        // Designation
        public const string BRDESIGNATIONNAME = "BRDesignationName";
        public const string BRDESIGNATIONUNIQUE = "BRDesignationUnique";
        // Relationship
        public const string BRRELATIONSHIPNAME = "BRRelationshipName";
        public const string BRRELATIONSHIPUNIQUE = "BRRelationshipUnique";
        // State
        public const string BRSTATEVALIDATION = "BRStateValidation";
        // District
        public const string BRDISTRICTNAMEVALIDATION ="BRDistrictNameValidation"; 
        //CityVillage
        public const string BRCITYVILLAGEVALIDATION = "BRCityVillageNameValidation";
        //Zone
        public const string BRZONENAMEVALIDATION = "BRZoneNameValidation";
        //Commodity
        public const string BRCOMMODITYNAMEVALIDATION ="BRCommodityNameValidation";
        public const string BRBOTANICALNAMEVALIDATION ="BRBotanicalNameValidation";
        //Labour charge types
        public const string BRLABOURCHARGEVALIDATION = "BRLabourChargeValidation";
        public const string BRLABOURCHARGEALLOWEDVALIDATION = "BRLabourChargeAllowedValidation";
        //Bank
        public const string BRBANKNAMEVALIDATION = "BRBankNameValidation";
        //Measuring Unit
        public const string BRMUMEASURINGUNITVALIDATION = "BRMUMeasuringUnitValidation";
        //Branch
        public const string BRBANKBRANCHNAMEVALIDATION = "BRBankBranchNameValidation";
        public const string BRIFSCCODE = "BRIFSCCode";
        public const string BRMICRCODE = "BRMICRCode";
        public const string BRSWIFTCODE = "BRSWIFTCode"; 
        //Client
        public const string BRCLIENTMISSINGCOMPANYNAME = "BRClientMissingCompanyName";
        public const string BRCLIENTMISSINGCITYVILLAGE = "BRClientMissingCityVillage";
        public const string BRCLIENTPANUNIQUE = "BRClientPANUnique";
        public const string BRCLIENTTANUNIQUE = "BRClientTANUnique";
        public const string BRCLIENTUNIQUE = "BRClientUnique";
        public const string BRCLIENTAPMCLICNOUNIQUE = "BRClientAPMCLicNoUnique";
        public const string CLIENTERRORREGEXPAN = "ClientErrorRegExPAN";
        public const string CLIENTERRORREQUIREDPAN = "ClientErrorRequiredPAN"; 
        public const string CLIENTERRORREGEXTAN = "ClientErrorRegExTAN";
        public const string CLIENTERRORREGEXPIN = "ClientErrorRegExPIN";
        public const string CLIENTERRORREQUIREDPIN = "ClientErrorRequiredPIN";
        public const string CLIENTERRORREGEXEMAIL1 = "ClientErrorRegExEmail1";
        public const string CLIENTERRORREQUIREDEMAIL1 = "ClientErrorRequiredEmail1";
        public const string CLIENTERRORREGEXEMAIL2 = "ClientErrorRegExEmail2";
        public const string CLIENTERRORREGEXCONTACTNO = "ClientErrorRegExContactNo";
        public const string CLIENTERRORREGEXSTDCODE = "ClientErrorRegExSTDCode";
        public const string CLIENTERRORREQUIREDACCOUNTMANAGER = "ClientErrorRequiredAccountManagerId"; 
        //ClientPrimaryContactPerson
        public const string CLIENTPRIMARYCONTACTERRORREGEXPAN = "ClientPrimaryContactErrorRegExPAN";
        public const string CLIENTPRIMARYCONTACTERRORREGEXUID = "ClientPrimaryContactErrorRegExUID";
        public const string CLIENTPRIMARYCONTACTERRORREGEXPIN = "ClientPrimaryContactErrorRegExPIN";
        public const string CLIENTPRIMARYCONTACTERRORREGEXEMAIL1 = "ClientPrimaryContactErrorRegExEmail1"; 
        public const string CLIENTPRIMARYCONTACTERRORREGEXEMAIL2 = "ClientPrimaryContactErrorRegExEmail2";
        public const string CLIENTPRIMARYCONTACTERRORREGEXCONTACTNO = "ClientPrimaryContactErrorRegExContactNo";
        public const string CLIENTPRIMARYCONTACTERRORREGEXSTDCODE = "ClientPrimaryContactErrorRegExSTDCode";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDNAME = "ClientPrimaryContactRequiredName";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDDESIGNATIONNAME = "ClientPrimaryContactRequiredDesignationName";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDDOB = "ClientPrimaryContactErrorRequiredDOB";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDMOTHERNAME = "ClientPrimaryContactMothersMaidenName"; 
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDPAN  = "ClientPrimaryContactErrorRequiredDOB";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDPIN = "ClientPrimaryContactMothersMaidenName";
        public const string CLIENTPRIMARYCONTACTERRORREQUIREDMOBILENO = "ClientPrimaryContactErrorRequiredMobileNo";  
        public const string CLIENTPRIMARYCONTACTERRORMOBILENO = "ClientPrimaryContactErrorMobileNo";    
        // ClientAPMC
        public const string CLIENTAPMCERRORRREQUIREDAPMCNAME = "ClientErrorRequiredAPMCName";
        public const string CLIENTAPMCERRORRREQUIREDAPMCLICENSENO = "ClientErrorRequiredAPMCLicenseNo"; 
        public const string CLIENTAPMCERRORAPMCLICENSENODATE = "ClientErrorAPMCLicenseNoDate";
        public const string CLIENTAPMCERRORRREQUIREDAPMCLICENSENODATE = "ClientErrorRequiredAPMCLicenseNoDate"; 
        public const string CLIENTERRORCOMMODITYCLASS = "ClientErrorCommodityClass";
        public const string CLIENTERRORRREQUIREDCOMMODITYCLASS = "ClientErrorRequiredCommodityClass";    
        #endregion

        #region String Constants For Roles

        public const string MANAGEACKUSERGROUPS = "Manage Ack User Groups";
        public const string MANAGECLIENTUSERGROUP = "Manage Client User Group";
        public const string MANAGEACKUSERGROUPROLE = "Manage Ack User Group Role";
        public const string MANAGECLIENTUSERGROUPROLE = "Manage Client User Group Role";
        public const string MANAGEACKUSERS = "Manage Ack Users";
        public const string MANAGECLIENTUSERS = "Manage Client Users";
        public const string MANAGEACKUSERROLE = "Manage Ack User Role";
        public const string MANAGECLIENTUSERROLE = "Manage Client User Role";
        public const string CLIENTREGISTRATION = "Client Registration";
        public const string COUNTRY = "Country";
        public const string STATE = "State";
        public const string COMMODITY = "Commodity";
        public const string DISTRICT = "District";
        public const string ACCOUNTMASTER = "Account Master";
        public const string SUBSCRIPTIONRENEWAL = "Subscription Renewal";
        public const string EMAILSETTINGS = "Email Settings";
        public const string SENDEMAIL = "Send Email";
        public const string SMSSETTINGS = "SMS Settings";
        public const string SENDSMS = "Send SMS";
        public const string USERACTIVITYLOG = "User Activity Log";
        public const string MANAGEUSERGROUP = "Manage User Group";
        public const string MANAGEUSERGROUPROLE = "Manage User Group Role";
        public const string MANAGEUSERS = "Manage Users";
        public const string MANAGEUSERROLE = "Manage User Role";
        public const string BANKNBRANCH = "Bank & Branch";
        public const string PLACE = "Place";
        public const string ZONE = "Zone";
        public const string LABOURCHARGETYPE = "Labour Charge Type";
        public const string MEASURINGUNIT = "Measuring Unit";
        public const string BUSINESSREGISTRATION = "Business Registration";
        public const string SISTERCONCERN = "Sister Concern";
        public const string HOLIDAYCALENDAR = "Holiday Calendar";
        public const string COMMODITYREGISTRATION = "Commodity Registration";
        public const string WEIGHTNRATECONTROL = "Weight & Rate Control";
        public const string CUSTOMERRECEIPTBOOK = "Customer Receipt Book";
        public const string BUSINESSSETTINGS = "Business Settings";
        public const string PRINTINGSETTINGS = "Printing settings";
        public const string ROUNDOFF = "Round off";
        public const string PARTNERS = "Partners";
        public const string APMC = "APMC";
        public const string LABOUROFFICE = "Labour Office";
        public const string SUPPLIERS = "Suppliers";
        public const string SUPPLIERRETURNCOMMISSION = "Supplier return commission";
        public const string SUPPLIERINTERESTCALCULATOR = "Supplier Interest Calculator";
        public const string TRANSPORTER = "Transporter";
        public const string TRANSPORTERRETURNCOMMISSION = "Transporter return commission";
        public const string CUSTOMERS = "Customers";
        public const string CUSTOMERCREDITLIMITS = "Customer Credit limits";
        public const string CUSTOMERRETURNCOMMISSION = "Customer Return commission";
        public const string CUSTOMERINTERESTCALCULATOR = "Customer Interest Calculator";
        public const string CONSULTANTS = "Consultants";
        public const string EMPLOYEES = "Employees";
        public const string SALARYCALCULATOR = "Salary Calculator";
        public const string ATTENDANCEREGISTER = "Attendance Register";
        public const string LABOUR = "Labour";
        public const string BANKREGISTRATION = "Bank Registration";
        public const string CHEQUEBOOKMANAGEMENT = "Cheque Book management";
        public const string INTERESTNCHARGES = "Interest & Charges";
        public const string BANKINTERESTCALCULATOR = "Bank Interest calculator";
        public const string RECONCILIATION = "Reconciliation";
        public const string SIGNATORIES = "Signatories";
        public const string CHECKLISTS = "Checklists";
        public const string TERMLOAN = "Term Loan";
        public const string TERMLOANINTERESTCALC = "Term Loan Interest calc";
        public const string VEHICLELOAN = "Vehicle Loan";
        public const string VEHICLELOANINTERESTCALCULATOR = "Vehicle Loan Interest calculator";
        public const string FIXEDASSETS = "Fixed Assets";
        public const string DEPRECIATIONCALCULATOR = "Depreciation Calculator";
        public const string INVESTMENTS = "Investments";
        public const string CURRENTASSETS = "Current Assets";
        public const string EXPENSES = "Expenses";
        public const string INCOME = "Income";
        public const string TRANSPORTERSMEMO = "Transporters memo";
        public const string BACKDATEDTRANSACTION = "Backdated transaction";
        public const string SALESTRANSACTIONENTRY = "Sales Transaction Entry";
        public const string RUNTIMEPACKAGINGCHARGES = "Run Time Packaging charges ";
        public const string SALESADDONEXPENSES = "Sales Add on expenses";
        public const string OTHERCHARGES = "Other Charges";
        public const string RUNTIMECHANGETAREWEIGHT = "Run Time change Tare weight";
        public const string INVOICING = "Invoicing";
        public const string BACKDATEDPRINTING = "Backdated Printing";
        public const string BILLING = "Billing";
        public const string CESSPAIDBILLING = "Cess Paid Billing";
        public const string FINANCIALTRANSACTIONS = "Financial Transactions";
        public const string PAYMENTTOSUPPLIER = "Payment to supplier";
        public const string PAYMENTTOTRANSPORTER = "Payment to transporter";
        public const string BANKDEPOSITS = "Bank deposits";
        public const string PAYMENTSAGAINSTEXPENSES = "Payments against expenses";
        public const string OTHERPAYMENT = "Other Payment";
        public const string RECEIPTFROMCUSTOMER = "Receipt from customer";
        public const string CASHWITHDRAWAL = "Cash withdrawal";
        public const string OTHERRECEIPTS = "Other receipts";
        public const string SUPPLIERSUPPLIERJOURNALVOUCHERS = "Supplier - Supplier Journal Vouchers";
        public const string CUSTOMERCUSTOMERJOURNALVOUCHER = "Customer - Customer Journal Voucher";
        public const string TRANSPORTERTRANSPORTER = "Transporter – Transporter";
        public const string BANKINTEREST = "Bank Interest";
        public const string CHEQUERETURN = "Cheque Return";
        public const string BANKCOMMISSIONNCHARGES = "Bank commission & charges";
        public const string DEPRECIATION = "Depreciation";
        public const string INTERESTPAYABLETOPARTNERS = "Interest payable to partners";
        public const string LOSSDISTRIBUTEDTOPARTNERS = "Loss Distributed to partners";
        public const string PROFITPAYABLETOPARTNERS = "Profit Payable to Partners";
        public const string LOSSONSALEOFASSET = "Loss on sale of asset";
        public const string PAYABLEPROVISIONS = "Payable provisions";
        public const string PROFITONSALEOFASSET = "Profit on sale of asset";
        public const string RECEIVABLEPROVISIONS = "Receivable provisions";
        public const string SALARY = "Salary";
        public const string TAXPAYABLEACCOUNT = "Tax Payable Account";
        public const string PROVISIONFORBADDEBTS = "Provision for bad debts";
        public const string OTHER = "Other";
        public const string REMINDERS = "Reminders";
        public const string ACCOUNTMERGING = "Account Merging";
        public const string SUPPLIERTOSUPPLIER = "Supplier to supplier";
        public const string CUSTOMERTOCUSTOMER = "Customer to customer";
        public const string TRANSPORTERTOTRANSPORTER = "Transporter to transporter";
        public const string BANKTOBANK = "Bank to bank";
        public const string PARTNERTOPARTNER = "Partner to partner";
        public const string EMPLOYEETOEMPLOYEE = "Employee to employee";
        public const string YEARENDACTIVITY = "Year End Activity";
        public const string DATABACKUP = "Data backup";
        public const string CASHANDBANKBOOK = "Cash and Bank book";
        public const string CASHBOOK = "Cash Book";
        public const string BANKBOOK = "Bank Book";
        public const string FINANCIALREPORTS = "Financial Reports";
        public const string SALESREPORTS = "Sales reports";
        public const string JOURNALVOUCHERREGISTER = "Journal Voucher Register";
        public const string VOUCHERS = "Vouchers";
        public const string LEDGERS = "Ledgers";
        public const string STATUTORYREPORTS = "Statutory Reports";
        public const string ASSETREGISTER = "Asset Register";

        #endregion

        #region String constants for Designation service
        public const string DESIGNATIONNAME = "DesignationName";
        #endregion

        public const string CAID = "CAId"; // Common CAID constant 
        public const string MAILTO = "mailto:";
        public const string HTTP = "http://";
        public const string DISPLAYCLIENTIDPREFIX= "CA";
        public const string CLIENTADMINPREFIX = "CA";
        public const string CLIENTADMINPASSWORD = "password";
        public const string CLIENTADMINUSERGROUPNAME = "ClientAdmin";
        public const string MINVALIDYEAR = "1900";
        public const string ACCOUNTMANAGER = "Account Manager";
        
        #region String constants for UserGroup service
        public const string USERGROUPNAME = "UserGroupName";        
        public const string ROLESINUSERGROUP = "RolesInUserGroupCount";
        public const string USERSINUSERGROUP = "UsersInUserGroupCount";
        public const string USERGROUPID = "ug.UserGroupId";
        #endregion

        #region string constants for User table fields
        public const string TBLFLDUSERNAME = "Username";
        public const string TBLFLDMOBILENO = "MobileNo";
        public const string TBLFLDEMAIL = "Email";
        #endregion

        #region string constants for Country table fields
        public const string COUNTRYID = "CountryId";
        public const string COUNTRYNAME = "CountryName";
        public const string CALLINGCODE = "CallingCode";
        public const string AGESTANDARD = "AgeStd";
        public const string CURRENCY = "Currency";
        public const string CURRENCYCODE ="CurrencyCode";
        public const string SYMBOL = "Symbol";
        public const string TIMEZONE = "TimeZone";
        public const string FINANCIALYEARSTART ="FinancialYearStart";
        public const string FINANCIALYEAREND = "FinancialYearEnd";
        public const string STATUS = "Status";
        #endregion

        #region string constants for States table fields
        public const string STATEID = "StateId";
        public const string REGIONTYPE = "RegionType";
        public const string REGIONNAME ="RegionName";        
        #endregion

        #region string constants for Districts table fields
        public const string DISTRICTID = "DistrictId";
        public const string DISTRICTNAME = "Name"; 
        #endregion

        #region string constants for CityVillage table fields
        public const string CITYVILLAGENAME = "Name"; 
        public const string CITYORVILLAGE ="CityOrVillage";
        public const string STDCODE ="STDCode";
        public const string BASECVID= "BaseCityVillageId"; 
        #endregion

        #region string constants for Zones table fields
        public const string ZONEID = "ZoneId";
        public const string ZONENAME = "Name";
        public const string ZONEFOR = "ZoneFor";
        #endregion

        #region string constants for Relationships table fields
        public const string RELATIONSHIPID = "RelationshipId";
        public const string RELATIONSHIPNAME = "Name";
        #endregion 

        #region string constants for CommodityClass table fields
        public const string COMMODITYCLASSID ="CommodityClassId";
        public const string COMMODITYCLASSNAME = "Name";
        #endregion 

        #region string constants for Commodity table fields
        public const string COMMODITYID = "CommodityId";
        public const string COMMODITYNAME = "Name";
        public const string BOTANICALNAME = "BotanicalName";
        #endregion

        #region string constants for LabourChargeTypes table fields
        public const string LABOURCHARGEID = "LabourChargeId";
        public const string LABOURCHARGE = "LabourCharge";
        public const string PAYABLETO = "PayableTo";
        public const string DERIVATIVE1 = "Derivative1";
        public const string D1PAYABLETO = "D1PayableTo";
        public const string DERIVATIVE2 = "Derivative2";
        public const string D2PAYABLETO = "D2PayableTo";
        public const string ISACTIVE = "IsActive";
        #endregion

        #region string constants for Bank table fields
        public const string BANKID = "BankId";
        public const string BANKNAME = "BankName";
        public const string BASEBANKID = "BaseBankId";
        #endregion 

        #region string constants for BankBranch table fields
        public const string BANKBRANCHID = "BranchId";
        public const string BANKBRANCHNAME = "Name"; 
        public const string IFSCCODE="IFSCCode";
        public const string MICRCODE = "MICRCode";
        public const string SWIFTCODE = "SWIFTCode";
        public const string BASEBRANCHID = "BaseBranchId"; 
        #endregion 

        #region string constants for MeasuringUnit table fields
        public const string UNITID = "UnitId";
        public const string UNITTYPE = "UnitType";
        public const string MEASUREMENTUNIT = "MeasurementUnit";
        public const string EQUIVALENTUNIT = "EquivalentUnit";
        #endregion

        #region string constants for APMC table fields
        public const string APMCID = "APMCId";
        public const string WEBSITE = "Website";
        public const string EMAIL1 = "Email1";
        public const string EMAIL2 = "Email2";

        #endregion

        #region string constants for Client table feilds
        public const string CLIENTPAN = "PAN";
        public const string CLIENTTAN = "TAN";
        public const string CLIENTAPMCLICENCENO = "APMCLicenseNo";
        public const string CLIENTCOMPANYNAME = "CompanyName";
        public const string CLIENTADDRESSCITYVILLAGE = "Address";
       
        #endregion

        #region string constants for Business Constitution table fields
        public const string BUSINESSCONSTITUTIONID = "BusinessConstitutionId";
        public const string BUSINESSCONSTITUTIONNAME = "BusinessConstitutionName";
        #endregion

        public const string IMAGEAVATARPATH = "~/Content/UploadedImages/avatar_blank.jpg";
        public const string IMAGEUPLOADPATH = "~/Content/UploadedImages/";
        public const string IMAGEUPLOADCLIENTLOGO = "~/Content/UploadedImages/ClientAccount/";
        public const string IMAGEUPLOADPATHCOMMODITY = "~/Content/UploadedImages/Commodities/";
        public const string IMAGEUPLOADPATHPRIMARYCONTACTPERSON = "~/Content/UploadedImages/ClientAccount/PrimaryContactPerson/";
        public const string IMAGEUPLOADPATHCLIENTPARTNERS = "~/Content/UploadedImages/ClientAccount/ClientPartners/";
        public const string IMAGEUPLOADPATHCLIENTPARTNERGUARDIAN = "~/Content/UploadedImages/ClientAccount/ClientPartnerGardian/";

        public const string BLANKIMAGEPATH = "~/content/images/control/blnk_img.jpg";
        public const string REGEXPIN = @"\d{6,6}";
        public const string REGEXEMAIL = @"^(([^<>()[\]\\.,;:\s@\""]+" + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@" + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}" + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+" + @"[a-zA-Z]{2,}))$";
        public const string REGEXCONTACTNO = @"\d{6,15}";
        public const string REGEXSTDCODE = @"\d{3,5}";
        public const string REGEXUID = @"\d{12,12}";
        public const string REGEXPAN = @"[0-9a-zA-Z]{10,10}";
        public const string REGXIFSCCODE = @"[0-9a-zA-Z]{11,11}";
        public const string REGXSWIFTCODE = @"[0-9a-zA-Z]{8,15}";
        public const string REGXMICRCODE = @"\d{9,9}";
        public const string REGXDATE = @"(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))";
        public const string REGXNAME = @"[0-9a-zA-Z\s]{1,60}";

        public const string DATEFORMATFORDISPAY = "dd-MM-yyyy";

        #region User Service Related
        public const int FAILEDPASSWORDATTEMPTCOUNT = 3;
        public const double NOOFHOURSUSERLOCKEDOUT = 1;
        #endregion
    }
    public enum CityVillageType
    {
        City,
        Village
    }

    public enum ContactType
    {
        MobileNo,
        OfficeNo,
        ResidenceNo,
        Fax
    }

    public enum StateUnionTerritoryType 
    {
        State,
        UnionTerritory
    }

    public enum ZoneFor
    {
        Supplier_Farmer,
        Supplier_Trader,
        Customer,
        Transporter
    }

    public enum ClientStatus
    {
        Active,
        Operational,
        OnHold,
        InActive   
    }


    public enum ClientProfileChangeRequestStatus
    {
        Sent
    }

    public enum PaymentMode
    {
        Cash,
        Cheque,
        Online,
        DD
    }

    public enum SubscriptionType
    {
        Standard,
        Premium
    }

    public enum ClientSisterConcernBusinessRelation
    {
        Supplier,
        Customer,
        Transporter,
        Vendor,
        AssociateAndConsultants  
    }

    public enum PartnerType  
    {
        Working,
        NonWorking  
    }

    public enum BalanceType
    {
        Cr,
        Dr
    }

    public enum AccountType
    {
        CurrentAccount,
        SavingAccount
    }

    public enum EmailMessageImportance  
    {
        High,
        Low
    }

    public enum EmailMessagePriority  
    {
        High,
        Low,
        Medium  
    }

    public enum EmailMessageFlag  
    {
        FollowupRecipient,
        FollowupSender
    }

    [DataContract(Name="MesuringUnitType")]
    public enum UnitType
    {
        [EnumMember(Value="Weight")]
        Weight,
        [EnumMember(Value="Quantity")]
        Quantity
    }
}
