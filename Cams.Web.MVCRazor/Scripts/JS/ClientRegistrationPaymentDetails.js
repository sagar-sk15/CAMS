var isChequeChecked = "false";
var isDDChecked = "false";
var isOnlineChecked = "false";

var removeChequeIndex = parseInt($('#hdnPaymentDetailsCount').val());
var removeOnlineIndex = parseInt($('#hdnPaymentDetailsCount').val());
var removeDDIndex = parseInt($('#hdnPaymentDetailsCount').val());

var chequeArray = new Array();
var ddArray = new Array();
var onlineArray = new Array();

//To toggle div of Cash,Cheque and online payment details
function toggleDiv(id) {
    var count = parseInt($('#hdnPaymentDetailsCount').val());
    var div = document.getElementById(id);
    var current = div.style.display;
    if (current == 'none') {
        div.style.display = 'block';
    }
    else {
        var isTrue = confirm('Are you sure you want to remove ' + id + ' details?');
        if (isTrue) {
            var index = 0;
            div.style.display = 'none';
            if (id == "Cheque") {
                isChequeChecked = "false";
                $('#IsChequeChecked').val('false');
                for (i = 1; i < count; i++) {
                    if (i != 1) {
                        index = chequeArray.indexOf(i);
                    }
                    if (index == 0) {
                        var amt = parseFloat($('#txtAmount' + i).val());
                        var totalAmt = $('#TotalAmount').val();
                        var tdsAmt = $('#TDS').val();
                        totalAmt = totalAmt - amt;
                        $('#TotalAmount').val(totalAmt);
                        $('#NetAmount').val(parseFloat(totalAmt) - parseFloat(tdsAmt));
                        $('#txtAmount' + i).val(0);
                        $('#ChequeNo' + i).val('');

                        var getChequeDate = "ChequeDate" + i;
                        getChequeDate = ASPxClientControl.GetControlCollection().GetByName(getChequeDate);
                        if (getChequeDate != null) {
                            getChequeDate = ASPxClientDateEdit.Cast(getChequeDate);
                            var today = new Date();
                            getChequeDate.SetDate(today);
                        }


                        var getclearanceDate = "ChequeClearanceDate" + i;
                        getclearanceDate = ASPxClientControl.GetControlCollection().GetByName(getclearanceDate);
                        if (getclearanceDate != null) {
                            getclearanceDate = ASPxClientDateEdit.Cast(getclearanceDate);
                            var today = new Date();
                            getclearanceDate.SetDate(today);
                        }

                        var bankandBranchCheque = "BankandBranchCheque" + i;
                        bankandBranchCheque = ASPxClientControl.GetControlCollection().GetByName(bankandBranchCheque);
                        if (bankandBranchCheque != null) {
                            bankandBranchCheque = ASPxClientComboBox.Cast(bankandBranchCheque);
                            bankandBranchCheque.SetSelectedIndex(0);
                            bankandBranchCheque.SetValue(0);
                        }
                        $('#ChequeRTGS' + i).attr("checked", true);
                        $('#ChequeStandard' + i).removeAttr("checked");
                        onChequeFieldsValueChange(i);
                    }
                }
            }

            if (id == "Online") {
                isOnlineChecked = "false";
                $('#IsOnlineChecked').val('false');
                for (i = 2; i < count; i++) {

                    if (i != 2) {
                        index = onlineArray.indexOf(i);
                    }
                    if (index == 0) {
                        var amt = parseFloat($('#txtAmount' + i).val());
                        var totalAmt = $('#TotalAmount').val();
                        var tdsAmt = $('#TDS').val();
                        totalAmt = totalAmt - amt;
                        $('#TotalAmount').val(totalAmt);
                        $('#NetAmount').val(parseFloat(totalAmt) - parseFloat(tdsAmt));
                        $('#txtAmount' + i).val(0);
                        $('#OnlineTransactionNo' + i).val('');


                        var getOnlineTransactionDate = "OnlineTransactionDate" + i;
                        getOnlineTransactionDate = ASPxClientControl.GetControlCollection().GetByName(getOnlineTransactionDate);
                        if (getOnlineTransactionDate != null) {
                            getOnlineTransactionDate = ASPxClientDateEdit.Cast(getOnlineTransactionDate);
                            var today = new Date();
                            getOnlineTransactionDate.SetDate(today);
                        }

                        var bankandBranchOnline = "BankandBranchOnline" + i;
                        bankandBranchOnline = ASPxClientControl.GetControlCollection().GetByName(bankandBranchOnline);
                        if (bankandBranchOnline != null) {
                            bankandBranchOnline = ASPxClientComboBox.Cast(bankandBranchOnline);
                            bankandBranchOnline.SetSelectedIndex(0);
                            bankandBranchOnline.SetValue(0);
                        }
                        $('#OnlineRTGS' + i).attr("checked", true);
                        $('#OnlineNEFT' + i).removeAttr("checked");


                        onOnlineFieldsValueChange(i);
                    }
                }
            }

            if (id == "DD") {
                isDDChecked = "false";
                $('#IsDDChecked').val('false');
                for (i = 3; i < count; i++) {
                    if (i != 3) {
                        index = ddArray.indexOf(i);
                    }

                    if (index == 0) {
                        var amt = parseFloat($('#txtAmount' + i).val());
                        var totalAmt = $('#TotalAmount').val();
                        var tdsAmt = $('#TDS').val();
                        totalAmt = totalAmt - amt;
                        $('#TotalAmount').val(totalAmt);
                        $('#NetAmount').val(parseFloat(totalAmt) - parseFloat(tdsAmt));
                        $('#txtAmount' + i).val(0);
                        $('#DDNo' + i).val('');

                        var getDDDate = "DDDate" + i;
                        getDDDate = ASPxClientControl.GetControlCollection().GetByName(getDDDate);
                        if (getDDDate != null) {
                            getDDDate = ASPxClientDateEdit.Cast(getDDDate);
                            var today = new Date();
                            getDDDate.SetDate(today);
                        }

                        var bankandBranchDD = "BankandBranchDD" + i;
                        bankandBranchDD = ASPxClientControl.GetControlCollection().GetByName(bankandBranchDD);
                        if (bankandBranchDD != null) {
                            bankandBranchDD = ASPxClientComboBox.Cast(bankandBranchDD);
                            bankandBranchDD.SetSelectedIndex(0);
                            bankandBranchDD.SetValue(0);
                        }
                        onDDFieldsValueChange(i);
                    }

                }
            }

            if (id == "Cash") {
                $('#IsCashChecked').val('false');
                var amt = parseFloat($('#txtAmount').val());
                var totalAmt = $('#TotalAmount').val();
                var tdsAmt = $('#TDS').val();
                totalAmt = totalAmt - amt;
                $('#TotalAmount').val(totalAmt);
                $('#NetAmount').val(parseFloat(totalAmt) - parseFloat(tdsAmt));
                $('#txtAmount').val(0);

            }
        }

        else {

            if (id == "Cheque") {
                $('#Chequecheckbox').attr("checked", true);
            }

            if (id == "Online") {
                $('#Onlinecheckbox').attr("checked", true);
            }

            if (id == "DD") {
                $('#DDcheckbox').attr("checked", true);
            }

            if (id == "Cash") {
                $('#Cashcheckbox').attr("checked", true);
            }
        }
    }

    if ($('#Chequecheckbox').attr("checked")) {
        isChequeChecked = "true";
        $('#IsChequeChecked').val('true');
    }
    else {
        isChequeChecked = "false";
        $('#IsChequeChecked').val('false');
    }


    if ($('#Onlinecheckbox').attr("checked")) {
        isOnlineChecked = "true";
        $('#IsOnlineChecked').val('true');
    }
    else {
        isOnlineChecked = "false";
        $('#IsOnlineChecked').val('false');
    }


    if ($('#DDcheckbox').attr("checked")) {
        isDDChecked = "true";
        $('#IsDDChecked').val('true');
    }
    else {
        isDDChecked = "false";
        $('#IsDDChecked').val('false');
    }


    if ($('#Cashcheckbox').attr("checked")) {
        $('#IsCashChecked').val('true');
    }
    else {
        $('#IsCashChecked').val('false');
    }
}
//end toggldiv

//Add-remove payment details
function ChequeAddNewButtonClick(i) {
    isChequeChecked = "true";
    cbpPaymentDetails.PerformCallback("cheque");
    removeChequeIndex = i;
    chequeArray.push(i);
}

function OnlineAddNewButtonClick(i) {
    isOnlineChecked = "true";
    cbpPaymentDetails.PerformCallback("online");
    removeOnlineIndex = i;
    onlineArray.push(i);
}

function DDAddNewButtonClick(i) {
    isDDChecked = "true";
    cbpPaymentDetails.PerformCallback("dd");
    removeDDIndex = i;
    ddArray.push(i);
}


function ChequeRemoveButtonClick(i) {
    cbpPaymentDetails.PerformCallback("RemovePayment" + i.toString());
}
function OnlineRemoveButtonClick(i) {
    cbpPaymentDetails.PerformCallback("RemovePayment" + i.toString());
}
function DDRemoveButtonClick(i) {
    cbpPaymentDetails.PerformCallback("RemovePayment" + i.toString());
}

//end Add-remove

function cbpPaymentDetails_EndCallback() {
    togglePaymentDetailsDivs();
}

//Calculations
$(document).ready(function () {

    function isFloat(value) {
        var flag = false;
        if (!isNaN(value)) {
            if (parseFloat(value) >= 0) {
                flag = true;
            }
        }
        return flag;
    }

    $('.clsAmount').live('focusout', function () {
        calculateTotalAmount();
    });

    $('.remove').live('click', function (event) {
        if (event.currentTarget.attributes[0].nodeValue === "chequeDetailsRemove") {
            $('#txtAmount' + removeChequeIndex).val(0);
        }
        if (event.currentTarget.attributes[0].nodeValue === "onlineDetailsRemove") {
            $('#txtAmount' + removeOnlineIndex).val(0);
        }
        if (event.currentTarget.attributes[0].nodeValue === "ddDetailsRemove") {
            $('#txtAmount' + removeDDIndex).val(0);
        }
        calculateTotalAmount();
    });

    function calculateTotalAmount() {
        var tdsAmount = 0;
        var cashAmt = 0;
        var amt = 0;
        var paymentDetailsCount = parseInt($('#hdnPaymentDetailsCount').val());
        if (isFloat($('#txtAmount').val())) {
            cashAmt = parseFloat(($('#txtAmount').val() == '') ? 0.00 : $('#txtAmount').val());
        }
        else {
            $('#txtAmount').val(0);
            cashAmt = 0;
            alert('Invalid Input');
        }

        var totalAmount = parseFloat(cashAmt);
        for (var i = 0; i < paymentDetailsCount; i++) {
            if ($('#txtAmount' + i).val() !== undefined) {
                if (isFloat($('#txtAmount' + i).val())) {
                    amt = parseFloat(($('#txtAmount' + i).val() == '') ? 0.00 : $('#txtAmount' + i).val());
                    totalAmount += amt;
                }
                else {
                    $('#txtAmount' + i).val(0);
                    alert('Invalid Input');
                }
            }
        }
        $('#TotalAmount').val(parseFloat(totalAmount));

        if (isFloat($('#TDS').val())) {
            tdsAmount = ($('#TDS').val() == '') ? 0.00 : $('#TDS').val();
        }
        else {
            $('#TDS').val(0);
            tdsAmount = 0;
            alert('Invalid Input');
        }
        $('#NetAmount').val(parseFloat(totalAmount) - parseFloat(tdsAmount));
    }
});
//end Calculations

//To save Cheque payment details field to session
function onChequeFieldsValueChange(i) {
    var chequeType, chequeNo, chequeDate, clearanceDate, drawnOn, amount;

    if ($('#ChequeRTGS' + i).attr("checked")) {

        chequeType = "RTGS";
    }
    else {
        chequeType = "Standard Cheque";
    }
    chequeNo = $('#ChequeNo' + i).val();

    var getChequeDate = "ChequeDate" + i;
    getChequeDate = ASPxClientControl.GetControlCollection().GetByName(getChequeDate);
    if (getChequeDate != null) {
        getChequeDate = ASPxClientDateEdit.Cast(getChequeDate);
        chequeDate = getChequeDate.GetText();
    }


    var getclearanceDate = "ChequeClearanceDate" + i;
    getclearanceDate = ASPxClientControl.GetControlCollection().GetByName(getclearanceDate);
    if (getclearanceDate != null) {
        getclearanceDate = ASPxClientDateEdit.Cast(getclearanceDate);
        clearanceDate = getclearanceDate.GetText();
    }

    var bankandBranchCheque = "BankandBranchCheque" + i;
    bankandBranchCheque = ASPxClientControl.GetControlCollection().GetByName(bankandBranchCheque);
    if (bankandBranchCheque != null) {
        bankandBranchCheque = ASPxClientComboBox.Cast(bankandBranchCheque);
        drawnOn = bankandBranchCheque.GetValue();
    }

    amount = parseFloat($('#txtAmount' + i).val());
    if (getChequeDate != null || getclearanceDate != null || bankandBranchCheque != null) {
        $.ajax({
            type: "POST",
            url: "/ClientAccount/UpdateChequePaymentDetailsInModel",
            data: { chequeType: chequeType, chequeNo: chequeNo, chequeDate: chequeDate, clearanceDate: clearanceDate,
                drawnOn: drawnOn, amount: amount, modelNo: i
            }
        });
    }
}

//function OnChequeDateChange(i) {
//    var getChequeDate = "ChequeDate" + i;
//    getChequeDate = ASPxClientControl.GetControlCollection().GetByName(getChequeDate);
//    if (getChequeDate != null) {
//        getChequeDate = ASPxClientDateEdit.Cast(getChequeDate);
//        chequeDate = getChequeDate.GetText();
//    }
//}


//To save Online payment details field to session
function onOnlineFieldsValueChange(i) {
    var paymentDetailsCount = parseInt($('#hdnPaymentDetailsCount').val());
    var onlineTransactionType, onlineTransactionNo, onlineTransDate, bank, amount;

    if ($('#OnlineRTGS' + i).attr("checked")) {

        onlineTransactionType = "RTGS";
    }
    else {
        onlineTransactionType = "NEFT";
    }
    onlineTransactionNo = $('#OnlineTransactionNo' + i).val();

    var getOnlineTransactionDate = "OnlineTransactionDate" + i;
    getOnlineTransactionDate = ASPxClientControl.GetControlCollection().GetByName(getOnlineTransactionDate);
    if (getOnlineTransactionDate != null) {
        getOnlineTransactionDate = ASPxClientDateEdit.Cast(getOnlineTransactionDate);
        onlineTransDate = getOnlineTransactionDate.GetText();
    }

    var bankandBranchOnline = "BankandBranchOnline" + i;
    bankandBranchOnline = ASPxClientControl.GetControlCollection().GetByName(bankandBranchOnline);
    if (bankandBranchOnline != null) {
        bankandBranchOnline = ASPxClientComboBox.Cast(bankandBranchOnline);
        bank = bankandBranchOnline.GetValue();
    }

    amount = parseFloat($('#txtAmount' + i).val());
    if (onlineTransDate != null || bankandBranchOnline != null) {
        $.ajax({
            type: "POST",
            url: "/ClientAccount/UpdateOnlinePaymentDetailsInModel",
            data: { onlineTransactionType: onlineTransactionType, onlineTransactionNo: onlineTransactionNo, onlineTransDate: onlineTransDate,
                bank: bank, amount: amount, modelNo: i
            }
        });
    }
}

//To save DD payment details field to session
function onDDFieldsValueChange(i) {
    var ddNo, ddDate, bank, amount;

    ddNo = $('#DDNo' + i).val();

    var getDDDate = "DDDate" + i;
    getDDDate = ASPxClientControl.GetControlCollection().GetByName(getDDDate);
    if (getDDDate != null) {
        getDDDate = ASPxClientDateEdit.Cast(getDDDate);
        ddDate = getDDDate.GetText();
    }

    var bankandBranchDD = "BankandBranchDD" + i;
    bankandBranchDD = ASPxClientControl.GetControlCollection().GetByName(bankandBranchDD);
    if (bankandBranchDD != null) {
        bankandBranchDD = ASPxClientComboBox.Cast(bankandBranchDD);
        bank = bankandBranchDD.GetValue();
    }

    amount = parseFloat($('#txtAmount' + i).val());
    if (ddDate != null || bankandBranchDD != null) {
        $.ajax({
            type: "POST",
            url: "/ClientAccount/UpdateDDPaymentDetailsInModel",
            data: { ddNo: ddNo, ddDate: ddDate,
                bank: bank, amount: amount, modelNo: i
            }
        });
    }
}

function onCashFieldsValueChange() {
    var amount = parseFloat($('#txtAmount').val());
    $.ajax({
        type: "POST",
        url: "/ClientAccount/UpdateCashPaymentDetailsInModel",
        data: { amount: amount
        }
    });
}

function onAdditionalFieldValueChange() {    
    var additionalInfo = $('#AdditionalInfo').val();
    $.ajax({
    type:"POST",
    url:"/ClientAccount/UpdateAdditionalFieldInModel",
    data:{additionalInfo:additionalInfo}
    });
}

function onTDSValueChange() {
    var tds = parseFloat($('#TDS').val());
    $.ajax({
        type: "POST",
        url: "/ClientAccount/UpdateTDSFieldInModel",
        data: { tds: tds }
    });
}
//end Save payment details

//Search Bank related events
var popupIndex, paymentType;
function SearchBankBranchImageClick(ppIndex, pType) {
    popupIndex = ppIndex;
    paymentType = pType;
    PopupSearchBank.Show();
}


var bankName, bankBranch, place, IFSCCode, MICRCode, SWIFTCode;
function SearchBankBranch() {
    bankName = txtBankName.GetText();
    bankBranch = txtBranchName.GetText();
    place = txtPlaceName.GetText(); ;
    IFSCCode = txtIFSCName.GetText();
    MICRCode = txtMICRCode.GetText();
    SWIFTCode = txtSWIFTCode.GetText();
    CBPSearchBankBranchPopup.PerformCallback();
}

function CBPSearchBankBranchPopup_OnBeginCallback(s, e) {
    e.customArgs["bankName"] = bankName;
    e.customArgs["bankBranch"] = bankBranch;
    e.customArgs["place"] = place;
    e.customArgs["IFSCCode"] = IFSCCode;
    e.customArgs["MICRCode"] = MICRCode;
    e.customArgs["SWIFTCode"] = SWIFTCode;
}


var gridSelectedRowIndex;
function OngvSearchBankBranchFocusedRowChanged(s, e) {
    gridSelectedRowIndex = s.GetRowKey(s.GetFocusedRowIndex());
}

function BankSelectButtonClick() {
    switch (paymentType) {
        case "Cheque":
            var bankandBranchCheque = "BankandBranchCheque" + popupIndex;
            bankandBranchCheque = ASPxClientControl.GetControlCollection().GetByName(bankandBranchCheque);
            if (bankandBranchCheque != null) {
                bankandBranchCheque = ASPxClientComboBox.Cast(bankandBranchCheque);
                bankandBranchCheque.SetValue(gridSelectedRowIndex);
                bankandBranchCheque.SetSelectedIndex(gridSelectedRowIndex);
                onChequeFieldsValueChange(popupIndex);
            }

            break;
        case "DD":
            var bankandBranchDD = "BankandBranchDD" + popupIndex;
            bankandBranchDD = ASPxClientControl.GetControlCollection().GetByName(bankandBranchDD);
            if (bankandBranchDD != null) {
                bankandBranchDD = ASPxClientComboBox.Cast(bankandBranchDD);
                bankandBranchDD.SetValue(gridSelectedRowIndex);
                bankandBranchDD.SetSelectedIndex(gridSelectedRowIndex);
                onDDFieldsValueChange(popupIndex);
            }
            break;
        case "Online":
            var bankandBranchOnline = "BankandBranchOnline" + popupIndex;
            bankandBranchOnline = ASPxClientControl.GetControlCollection().GetByName(bankandBranchOnline);
            if (bankandBranchOnline != null) {
                bankandBranchOnline = ASPxClientComboBox.Cast(bankandBranchOnline);
                bankandBranchOnline.SetValue(gridSelectedRowIndex);
                bankandBranchOnline.SetSelectedIndex(gridSelectedRowIndex);
                onOnlineFieldsValueChange(popupIndex);
            }
            break;
    }

    PopupSearchBank.Hide();
}


//For edit payment details
function CheckFloat(value) {
    var flag = false;
    if (!isNaN(value)) {
        if (parseFloat(value) >= 0) {
            flag = true;
        }
    }
    return flag;
}

function calculateSubscriptionPaymentTotalAmount() {
    var tdsAmount = 0;
    var cashAmt = 0;
    var amt = 0;
    var paymentDetailsCount = parseInt($('#hdnPaymentDetailsCount').val());
    if (CheckFloat($('#txtAmount').val())) {
        cashAmt = parseFloat(($('#txtAmount').val() == '') ? 0.00 : $('#txtAmount').val());
    }
    else {
        $('#txtAmount').val(0);
        cashAmt = 0;
        alert('Invalid Input');
    }

    var totalAmount = parseFloat(cashAmt);
    for (var i = 0; i < paymentDetailsCount; i++) {
        if ($('#txtAmount' + i).val() !== undefined) {
            if (CheckFloat($('#txtAmount' + i).val())) {
                amt = parseFloat(($('#txtAmount' + i).val() == '') ? 0.00 : $('#txtAmount' + i).val());
                totalAmount += amt;
            }
            else {
                $('#txtAmount' + i).val(0);
                alert('Invalid Input');
            }
        }
    }
    $('#TotalAmount').val(parseFloat(totalAmount));

    if (CheckFloat($('#TDS').val())) {
        tdsAmount = ($('#TDS').val() == '') ? 0.00 : $('#TDS').val();
    }
    else {
        $('#TDS').val(0);
        tdsAmount = 0;
        alert('Invalid Input');
    }
    $('#NetAmount').val(parseFloat(totalAmount) - parseFloat(tdsAmount));
}


function togglePaymentDetailsDivs() {
    var cheque = $('#IsChequeChecked').val();
    var cash = $('#IsCashChecked').val();
    var online = $('#IsOnlineChecked').val();
    var dd = $('#IsDDChecked').val();
    if (cheque === "true") {
        $('#Chequecheckbox').attr("checked", true);
        var divcheque = document.getElementById('Cheque');
        divcheque.style.display = 'block';
        isChequeChecked = true;
    }
    if (cash === "true") {
        $('#Cashcheckbox').attr("checked", true);
        var divcash = document.getElementById('Cash');
        divcash.style.display = 'block';
    }
    if (online === "true") {
        $('#Onlinecheckbox').attr("checked", true);
        var divonline = document.getElementById('Online');
        divonline.style.display = 'block';
        isOnlineChecked = true;
    }
    if (dd === "true") {
        $('#DDcheckbox').attr("checked", true);
        var divdd = document.getElementById('DD');
        divdd.style.display = 'block';
        isDDChecked = true;
    }
}