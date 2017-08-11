
/*Client Subscription Details*/
function GetSelectedPackage(controlname) {
    var control = $('#' + controlname);
    if (control[0].checked) {
        if (controlname == 'rbtnSelectStandardPackage') {
            $('#HiddentxtSelectedFees').val($('#HiddentxtStandardFees').val());
        }
        else {
            $('#HiddentxtSelectedFees').val($('#HiddentxtPremiumFees').val());
        }
    }
    UpdateSubscriptionFees();
}

function is_int(value) {
    var flag = false;
    if ((parseFloat(value) == parseInt(value)) && !isNaN(value)) {
        if (value >= 0) {
            flag = true;
        }
    }
    return flag;
}

function is_float(value) {
    var flag = false;
    if (!isNaN(value)) {
        if (parseFloat(value) >= 0) {
            flag = true;
        }
    }
    return flag;
}

function UpdateSubscriptionDates() {
    var period = ($('#txtSubscriptionperiod').val()=='')?0:$('#txtSubscriptionperiod').val();
    var datefrom = txtSubscriptionPeriodFromDate.GetDate();
    var dateto = txtSubscriptionPeriodToDate.GetDate();
    if (period != "") {
        if (is_int(period)) {
            if (datefrom == null) {
                var datefrom = new Date();
                txtSubscriptionPeriodFromDate.SetDate(datefrom);
            }
            dateto.setFullYear(parseInt(datefrom.getFullYear()) + parseInt(period));
            txtSubscriptionPeriodToDate.SetDate(dateto);
        }
        else {
            $('#txtSubscriptionperiod').val("0");
            alert("Invalid Input");
        }
    }
    UpdateSubscriptionFees();
}

function SetTotalAdditionalUsers() {
    var Employees = ($('#txtAdditionalNoOfEmployees').val()=='')?0:$('#txtAdditionalNoOfEmployees').val();
    var Auditors = ($('#txtAdditionalNoOfAuditors').val() == '') ? 0 : $('#txtAdditionalNoOfAuditors').val();
    var Associates = ($('#txtAdditionalNoOfAssociates').val() == '') ? 0 : $('#txtAdditionalNoOfAssociates').val();
    var TotalAdditionalUsers = (parseInt(Employees) + parseInt(Auditors) + parseInt(Associates)).toString();
    $('#txtTotalAdditionalUsers').val(TotalAdditionalUsers);
}

function UpdateTotalAdditionalUsers(control) {
    var newvalue = $('#' + control).val();

    if (!is_int(newvalue)) {
        $('#' + control).val("0");
        alert("Invalid Input");
        $('#' + control).focus();
    }
    SetTotalAdditionalUsers();
    UpdateSubscriptionFees();
}

function SetTotalAdditionalCost() {
    var EmployeeCost = ($('#txtAdditionalCostForEmployees').val() == '') ? 0.00 : $('#txtAdditionalCostForEmployees').val();
    var AuditorCost = ($('#txtAdditionalCostForAuditors').val() == '') ? 0.00 : $('#txtAdditionalCostForAuditors').val();
    var AssociateCost = ($('#txtAdditionalCostForAssociates').val() == '') ? 0.00 : $('#txtAdditionalCostForAssociates').val();
    var TotalAdditionalCost = ((parseFloat(EmployeeCost) + parseFloat(AuditorCost) + parseFloat(AssociateCost)).toFixed(2)).toString();
    $('#txtTotalAdditionalCost').val(TotalAdditionalCost);
}

function UpdateTotalAdditionalCost(control) {
    var newvalue = $('#' + control).val();

    if (!is_float(newvalue)) {
        $('#' + control).val('0.00');
        alert("Invalid Input");
        $('#' + control).focus();
    }
    else {
        newvalue = parseFloat(newvalue).toFixed(2);
        $('#' + control).val(newvalue)
    }
    SetTotalAdditionalCost();
    UpdateSubscriptionFees();
}

function UpdateSubscriptionFees() {
    //debugger;
    var sSubscriptionperiod = ($('#txtSubscriptionperiod').val() == '') ? 0 : $('#txtSubscriptionperiod').val();
    var Subscriptionperiod = parseInt($('#txtSubscriptionperiod').val());

    var sEmployees = ($('#txtAdditionalNoOfEmployees').val() == '') ? 0 : $('#txtAdditionalNoOfEmployees').val();
    var sAuditors = ($('#txtAdditionalNoOfAuditors').val() == '') ? 0 : $('#txtAdditionalNoOfAuditors').val();
    var sAssociates = ($('#txtAdditionalNoOfAssociates').val() == '') ? 0 : $('#txtAdditionalNoOfAssociates').val();

    var Employees = parseInt(sEmployees);
    var Auditors = parseInt(sAuditors);
    var Associates = parseInt(sAssociates);

    var sEmployeeCost = ($('#txtAdditionalCostForEmployees').val() == '') ? 0.00 : $('#txtAdditionalCostForEmployees').val();
    var sAuditorCost = ($('#txtAdditionalCostForAuditors').val() == '') ? 0.00 : $('#txtAdditionalCostForAuditors').val();
    var sAssociateCost = ($('#txtAdditionalCostForAssociates').val() == '') ? 0.00 : $('#txtAdditionalCostForAssociates').val();

    var EmployeeCost = parseFloat(sEmployeeCost).toFixed(2);
    var AuditorCost = parseFloat(sAuditorCost).toFixed(2);
    var AssociateCost = parseFloat(sAssociateCost).toFixed(2);

    var sSelectedSubscriptionFees = ($('#HiddentxtSelectedFees').val() == '') ? 0.00 : $('#HiddentxtSelectedFees').val();
    var sSelectedRenewalFees = ($('#HiddentxtSelectedRenewalFees').val() == '') ? 0.00 : $('#HiddentxtSelectedRenewalFees').val();
    var SelectedSubscriptionFees = parseFloat(sSelectedSubscriptionFees).toFixed(2);
    var SelectedRenewalFees = parseFloat(sSelectedRenewalFees).toFixed(2);

    var TotalAdditional = ((Employees * EmployeeCost) + (Auditors * AuditorCost) + (Associates * AssociateCost)).toFixed(2);

    var Total = parseFloat(0);
    if (Subscriptionperiod > 0) {
        Total = (parseFloat(SelectedSubscriptionFees) + parseFloat(TotalAdditional)).toFixed(2);
        var i = 0;
        var renewalFees = ((parseFloat(SelectedRenewalFees) * parseFloat(SelectedSubscriptionFees)) / 100).toFixed(2);
        for (i = 2; i <= Subscriptionperiod; i++) {
            Total = (parseFloat(Total) + parseFloat(renewalFees) + parseFloat(TotalAdditional)).toFixed(2);
        }
    }
    $('#txtTotalSubscriptionFees').val(Total.toString());
    UpdateDiscountInRupees();
    UpdateNetAmount();
}

function UpdateDiscountInRupees() {
    var discount = $('#txtDiscountInPercentage').val();
    var TotalSubscriptionFees = $('#txtTotalSubscriptionFees').val();
    var result = 0;
    if (is_float(discount)) {
        result = ((parseFloat(discount) * TotalSubscriptionFees) / 100).toFixed(2);
    }
    else {
        $('#txtDiscountInPercentage').val("0");
    }
    $('#txtDiscountInRupees').val(result.toString());
    UpdateNetAmount();
}

function UpdateDiscountInPercentage() {
    var discount = $('#txtDiscountInRupees').val();
    var TotalSubscriptionFees = parseFloat($('#txtTotalSubscriptionFees').val());
    var result = 0;
    if (is_float(discount)) {
        result = ((parseFloat(discount) * 100) / TotalSubscriptionFees).toFixed(2);
    }
    else {
        $('#txtDiscountInRupees').val("0");
    }
    $('#txtDiscountInPercentage').val(result.toString());
    UpdateNetAmount();
}

function UpdateTax(control) {
    var newvalue = $('#' + control).val();

    if (!is_float(newvalue)) {
        $('#' + control).val('0.00');
        alert("Invalid Input");
        $('#' + control).focus();
    }
    else {
        newvalue = parseFloat(newvalue).toFixed(2);
        $('#' + control).val(newvalue)
    }
    UpdateNetAmount();
}

function UpdateNetAmount() {
    var discount = parseFloat($('#txtDiscountInRupees').val());
    var TotalSubscriptionFees = parseFloat($('#txtTotalSubscriptionFees').val());
    var servicetax = parseFloat($('#txtServiceTax').val());
    var othertax = parseFloat($('#txtOtherTax').val());
    var NetAmount = ((TotalSubscriptionFees + servicetax + othertax) - discount).toFixed(2);
    $('#txtNetAmount').val(NetAmount.toString())
}
/*----End of Client Subscription Details----*/


/*Business Constitution and Client Partners*/
function AddClientPartnersButtonClick() {
    PopupCtrlClientPartnerAdd.Show();
}

function AddPartner(designationname,dobname,cityvillagename) {
    var name = document.getElementById("txtAOName");
    alert(name.value);
    var designation = $('#' + designationname).GetText();
    alert(designation);
    var dob = $('#' + dobname).GetText();
    var gendermale = document.getElementById("rbtnAOGenderMale");
    var genderfemale = document.getElementById("rbtnAOGenderFemale");
    var gender;
    if (gendermale.checked)
        gender = "Male";
    else
        gender = "Female";
    alert(gender);

}

function OnCPLGridViewFocusedRowChanged(s, e) {
    if (s.focusedRowIndex != -1) {
        if (s.GetRowKey(s.GetFocusedRowIndex()) != null) {
            $('#HiddenPartnerId').val(s.GetRowKey(s.GetFocusedRowIndex()).toString());
        }
    }
}

function cmbBusinessContitutions_SelectedIndexChanged(s, e, ActivePartnerCount) {
    ActivePartnerCount = parseInt(ActivePartnerCount);
    if (cmbBusinessContitutions.GetText().indexOf("Sole") != -1) {
        if (ActivePartnerCount <= 1) {
            $('#txtNoOfClientPartners').val("1");
            $('#liNoofPartners').hide();
        }
        else {
            alert("Invalid Selection. You have already added " + ActivePartnerCount + " 'Active' partners");
            //cmbBusinessContitutions.
            cmbBusinessContitutions.SetSelectedIndex(0);
            cmbBusinessContitutions.SetValue(0);
        }

    }
    else {
        $('#txtNoOfClientPartners').val("2");
        $('#liNoofPartners').show();
    }
}

//function ClientPartnerAddClick(s, e) {
//    var PreviousPage = "BusinessConstitutionList";
//    var ActiveTab = "3";
//    var ActionMethod = "AddClientPartnerIndex";
//    var SelectedIndex = cmbBusinessContitutions.GetSelectedIndex();
//    var SelectedValue = cmbBusinessContitutions.GetValue();
//    var NoOfClientPartnersAdded = parseInt($('#HiddenNoOfClientPartners').val());
//    var NoOfClientPartners = parseInt($('#txtNoOfClientPartners').val());

//    
//    if (NoOfClientPartnersAdded < NoOfClientPartners) {
//        $.ajax({
//            type: "POST",
//            url: "/ClientAccount/AddClientPartner",
//            data: {
//                PreviousPage: PreviousPage,
//                ActiveTab: ActiveTab,
//                ActionMethod: ActionMethod,
//                SelectedIndex: SelectedIndex,
//                SelectedValue: SelectedValue,
//                NoOfClientPartnersAdded: NoOfClientPartnersAdded.toString(),
//                NoOfClientPartners: NoOfClientPartners.toString()
//            }
//        });
//    }
//}

function CheckNoOfPartners(ActivePartnerCount) {
    var value = 1;
    var addedpartners = parseInt(ActivePartnerCount);
    var noofpartners = parseInt($('#txtNoOfClientPartners').val());
    if (is_int(noofpartners)) {
        if ((noofpartners <= 1 || noofpartners > 20)) {
            if (addedpartners > 2) {
                value = 2;
            }
        }
        else {
            if (noofpartners > addedpartners) {
                value = 3;
            }
            else if (addedpartners > 2) {
                value = 2;
            }
        }
        switch (value) {
            case 1:
                $('#txtNoOfClientPartners').val("2");
                break;
            case 2:
                $('#txtNoOfClientPartners').val(addedpartners.toString());
                break;
            case 3:
                $('#txtNoOfClientPartners').val(noofpartners.toString());
                break;
        }
    }
}

function IsAddClientPartnerAllowed(ActivePartners) {
    var flag = false;
    ActivePartners = parseInt(ActivePartners);
    NoOfClientPartners = parseInt($('#txtNoOfClientPartners').val());
    alert("No. of Active Partners = " + ActivePartners.toString() + ", No. of Client Partners value = " + NoOfClientPartners.toString());
    if (ActivePartners < NoOfClientPartners) {
        flag = true;
    }
    alert(flag.toString());
    return flag;
}
/*End of Business Constitution and Client Partners*/

/*Account Manager*/
function cmbAccountManager_SelectedIndexChanged() {
    var AccountManagerId = cmbAccountManager.GetValue();
    $.ajax({
        type: "POST",
        url: "/ClientAccount/GetAccountManagerDetails",
        data: { AccountManagerId: AccountManagerId },
        success: function (data) {
            if (data) {
                var userid = data[0];
                var name = data[1];
                var username = data[2];
                var email = data[3];
                var mobno = data[4];
                $('#AMName').html(name);
                $('#AMUsername').html(username);
                $('#AMEmail').html(email);
                $('#AMMobileNo').html(mobno);
            }
        }
    });
}
/*End of Account Manager*/
