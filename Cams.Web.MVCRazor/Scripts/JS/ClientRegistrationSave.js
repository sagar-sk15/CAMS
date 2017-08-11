function SaveCompanyProfile() {
    $.ajax({
        type: "POST",
        url: "/ClientAccount/SaveCompanyProfile",
        data: { currentIndex: currentIndex,
            CompanyName: $('#CompanyName').val(),
            Alias: $('#Alias').val(),
            PAN: $('#PAN').val(),
            TAN: $('#TAN').val(),
            AddressLine1: $('#ClientAddress_AddressLine1').val(),
            CityVillageId: cmbCityVillage.GetValue(),            
            PIN: $('#ClientAddress_PIN').val(),
            Email1: $('#Email1').val(),
            Email2: $('#CompanyEmail2').val(),
            Website: $('#Website').val(),
            contactDetails: GetContactDetails('#CompanyContactsCurrentIndex', 'ClientContacts')

        },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function GetContactDetails(hdnCurrentIndex, basePartOfIdGenerated) {
    var currentIndex = $(hdnCurrentIndex).val();
    var contactDetails = '';
    for (i = 0; i < currentIndex ; i++) {
        var contactNoType = $('#' + basePartOfIdGenerated + '_' + i + '__ContactNoType').val();
        contactDetails += contactNoType + ',';
        var sTDCode = $('#' + basePartOfIdGenerated + '_' + i + '__STDCode').val();
        contactDetails += sTDCode + ',';
        var contactNo = $('#' + basePartOfIdGenerated + '_' + i + '__ContactNo').val();
        contactDetails += contactNo + ';';
    }

    return contactDetails;
}

function SavePrimaryContactDetails() {
    var gender = '';
    var rbFemale = $('#rbtnCLRPCPFemaleGender')[0];
    if (rbFemale) {
        gender = rbFemale.checked == true ? 'F' : 'M';
    }

    $.ajax({
        
        type: "POST",
        url: "/ClientAccount/SavePrimaryContactDetails",
        data: {             
            currentIndex: currentIndex,
            Title: $('#ClientPrimaryContactPerson_Title').val(),
            CLRPCPName: $('#txtCLRPCPName').val(),
            Gender: gender,
            MothersMaidenName: $('#txtCLRPCPMotherMaidenName').val(),
            DateOfBirth: PCPtxtDOBnAgeName.GetText(),
            PAN: $('#txtCLRPCPPAN').val(),
            UID: $('#txtCLRPCPUID').val(),
            IsSameAsCompanyAddress: $('#ClientPrimaryContactPerson_IsSameAsCompanyAddress')[0].checked,
            IsSameAsCompanyContact: $('#ClientPrimaryContactPerson_IsSameAsCompanyContact')[0].checked,
            AddressLine1: $('#txtCLRPCPAddress').val(),
            CityVillageId: PCPcmbCityVillage.GetValue(),                  
            DesignationId: PCPDDLDesignations.GetValue(),
            PIN: $('#txtCLRPCPPin').val(),
            Email1: $('#ClientPrimaryContactPerson_Email1').val(),
            Email2: $('#ClientPrimaryContactPerson_Email2').val(),
            contactDetails: GetContactDetails('#CLRPCPCurrentIndex', 'ClientPrimaryContactPerson_ClientPrimaryContacts')
        },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function SaveAPMCDetails() {
    //debugger;
    var APMCId, APMCLicenseNo, APMCLicenseValidUpTodt, SelectedCommodityClassIdList;
    APMCId = APMCList.GetValue();
    APMCLicenseNo = $('#APMCLicenseNo').val();
    APMCLicenseValidUpTodt = APMCLicenseValidUpToDate.GetText();
    SelectedCommodityClassIdList = GetCommodityClassIdList();
    $.ajax({
        type: "POST",
        url: "/ClientAccount/SaveAPMCDetails",
        data: {
                currentIndex: currentIndex,
                APMCId: APMCId,
                APMCLicenseNo: APMCLicenseNo,
                APMCLicenseValidUpToDate: APMCLicenseValidUpTodt,
                SelectedCommodityClassIdList: SelectedCommodityClassIdList
        },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function GetCommodityClassIdList()
{
    var selectedIdList='';
    var cnt= parseInt($('#hdnCommodityClassCount').val());
    for (i=0;i<cnt;i++)
    {
        var commodityClassId = $('#hdnCommodityClassId' + i).val();
        if($('#chkCommodityClass' + i)[0].checked)
        {
            selectedIdList+= commodityClassId + ';' ;
        }
    }    
    return selectedIdList;
}

function SaveBusinessConstitution() {
    //debugger;
    var noOfClientPartners = $('#txtNoOfClientPartners').val();
    var bussinessConstitutionId = cmbBusinessContitutions.GetValue();
    $.ajax({
        type: "POST",
        url: "/ClientAccount/SaveBusinessConstitution",
        data: {
            currentIndex: currentIndex,
            NoOfClientPartners: noOfClientPartners,
            BussinessConstitutionId: bussinessConstitutionId
        },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function SaveSubscriptionDetails() {
    //debugger;
    var period = ($('#txtSubscriptionperiod').val()=='')?0:$('#txtSubscriptionperiod').val();
    var datefrom = txtSubscriptionPeriodFromDate.GetText();
    var dateto = txtSubscriptionPeriodToDate.GetText();
    var selectedPackageId;
    var rbtnStandardPackage = $('#rbtnSelectStandardPackage');
    var rbtnPremiumPackage = $('#rbtnSelectPremiumPackage');
    if (rbtnStandardPackage[0].checked) {
        selectedPackageId = $('#hdnStandardSubscriptionId').val();
    }
    else if (rbtnPremiumPackage[0].checked){
        selectedPackageId = $('#hdnPremiumSubscriptionId').val();
    }
    var Employees = ($('#txtAdditionalNoOfEmployees').val()=='')?0:$('#txtAdditionalNoOfEmployees').val();
    var Auditors = ($('#txtAdditionalNoOfAuditors').val() == '') ? 0 : $('#txtAdditionalNoOfAuditors').val();
    var Associates = ($('#txtAdditionalNoOfAssociates').val() == '') ? 0 : $('#txtAdditionalNoOfAssociates').val();
    var EmployeeCost = ($('#txtAdditionalCostForEmployees').val() == '') ? 0.00 : $('#txtAdditionalCostForEmployees').val();
    var AuditorCost = ($('#txtAdditionalCostForAuditors').val() == '') ? 0.00 : $('#txtAdditionalCostForAuditors').val();
    var AssociateCost = ($('#txtAdditionalCostForAssociates').val() == '') ? 0.00 : $('#txtAdditionalCostForAssociates').val();

    var serviceTax = ($('#txtServiceTax').val() == '') ? 0.00 : $('#txtServiceTax').val();
    var otherTax = ($('#txtOtherTax').val() == '') ? 0.00 : $('#txtOtherTax').val();

    var discountInPercentage = $('#txtDiscountInPercentage').val();
    var discountInRupees = $('#txtDiscountInRupees').val();
    var additionalInfo = $('#txtAdditionalInfo').val();


    $.ajax({
        type: "POST",
        url: "/ClientAccount/SaveSubscriptionDetails",
        data: { currentIndex: currentIndex,
            Period: period,
            SubscriptionPeriodFromDate: datefrom,
            SubscriptionPeriodToDate: dateto,
            SelectedPackageId: selectedPackageId,
            NoOfEmployees: Employees,
            NoOfAuditors: Auditors,
            NoOfAssociates: Associates,
            EmployeeCost: EmployeeCost,
            AuditorCost: AuditorCost,
            AssociateCost: AssociateCost,
            DiscountInPercentage: discountInPercentage,
            DiscountInRupees: discountInRupees,
            ActivationDate: txtActivationDate.GetText(),
            AdditionalInfo: additionalInfo,
            ServiceTax: serviceTax,
            otherTax: otherTax
        },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function SavePaymentDetails() {
    var additionalInfo = $('#AdditionalInfo').val();
    var tds = parseFloat($('#TDS').val());
    $.ajax({
        type: "POST",
        url: "/ClientAccount/SavePaymentDetails",
        data: { currentIndex: currentIndex, additionalInfo: additionalInfo, tds: tds },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function SaveAccountManager() {
    var accountManagerId = cmbAccountManager.GetValue();
    $.ajax({
        type: "POST",
        url: "/ClientAccount/SaveAccountManager",
        data: { currentIndex: currentIndex,
            AccountManagerId: accountManagerId
              },
        success: function (data) {
            if (data) {
                alert('Company Profile Saved.');
            }
        }
    });
}

function CopyCompanyAddress() {
    //txtCLRPCPAddress
    if ($('#ClientPrimaryContactPerson_IsSameAsCompanyAddress')[0].checked) {
        $('#txtCLRPCPAddress').val($('#ClientAddress_AddressLine1').val())
        $('#txtCLRPCPPin').val($('#ClientAddress_PIN').val());
        //alert(cmbStates.GetValue()
        PCPcmbStates.SetValue(cmbStates.GetValue());
        PCPcmbStates.SetText(cmbStates.GetText());
        PCPcmbStates.SetSelectedIndex(cmbStates.GetSelectedIndex());
        $('#PCPhdnDistrict').val(cmbDistricts.GetValue());
        $('#PCPhdnCityVillage').val(cmbCityVillage.GetValue());
        PCPcbpDistricts.PerformCallback();
        //Sleep(1);
    }
}

function Sleep(naptime) {
    naptime = naptime * 1000;
    var sleeping = true;
    var now = new Date();
    var alarm;
    var startingMSeconds = now.getTime();
    //alert("starting nap at timestamp: " + startingMSeconds + "\nWill sleep for: " + naptime + " ms");
    while (sleeping) {
        alarm = new Date();
        alarmMSeconds = alarm.getTime();
        if (alarmMSeconds - startingMSeconds > naptime) { sleeping = false; }
    }
}

function CopyCompanyContacts() {
    if ($('#ClientPrimaryContactPerson_IsSameAsCompanyContact')[0].checked) {

        $('#ClientPrimaryContactPerson_Email1').val($('#Email1').val())
        $('#ClientPrimaryContactPerson_Email2').val($('#CompanyEmail2').val())

        var hdnCompanyContactsCount = '#CompanyContactsCurrentIndex';
        var basePartOfIdGeneratedCompany = 'ClientContacts';
        var companyContactsCount = $(hdnCompanyContactsCount).val();

        var hdnPrimaryContactsCount = '#CLRPCPCurrentIndex';
        var basePartOfIdGeneratedPrimaryContact = 'ClientPrimaryContactPerson_ClientPrimaryContacts';

        var contactDetails = '';
        for (i = 0; i < companyContactsCount; i++) {
            var primaryContactsCount = $(hdnPrimaryContactsCount).val();
            if (companyContactsCount != primaryContactsCount) {
                addNewContact('#CLRPCPContacts', '#CLRPCPCurrentIndex', '5',
                                'ClientPrimaryContactPerson_ClientPrimaryContacts_',
                                'ClientPrimaryContactPerson.ClientPrimaryContacts')
            }
            var contactNoType = $('#' + basePartOfIdGeneratedCompany + '_' + i + '__ContactNoType').val();
            $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNoType').val(contactNoType);

            var sTDCode = $('#' + basePartOfIdGeneratedCompany + '_' + i + '__STDCode').val();
            $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__STDCode').val(sTDCode);

            var contactNo = $('#' + basePartOfIdGeneratedCompany + '_' + i + '__ContactNo').val();
            $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNo').val(contactNo);

            if (contactNoType != "MobileNo") {
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__STDCode').show();
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNo').removeClass('width166');
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNo').addClass('width118 margin5');
                //                spaceSpan.html("");
            }
            else {
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__STDCode').hide();
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNo').removeClass('width118 margin5');
                $('#' + basePartOfIdGeneratedPrimaryContact + '_' + i + '__ContactNo').addClass('width166');
                //                spaceSpan.html("&nbsp;");
            }
        }
    }
}