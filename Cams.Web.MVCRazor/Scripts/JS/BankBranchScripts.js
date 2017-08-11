var AddedBankName;

function AddNewBankButtonClick() {
    AddBankModal.Show();
}

function AddBankPopupSaveButtonClick() {
    //debugger;
    var bankname = txtppBankName.GetText();
    var alias = txtppAlias.GetText();
    var url = txtppURL.GetText();
    var errortext = txtppURL.GetErrorText();
    if (bankname != "" && alias != "" && url != "" && (errortext == "Invalid value" || errortext == "")) {
        cbpAddBank.PerformCallback();        
    }
}

function cbpAddBank_OnBeginCallback(s, e) {
    e.customArgs["txtppBankName"] = AddedBankName = txtppBankName.GetText();
    e.customArgs["txtppAlias"] = txtppAlias.GetText();
    e.customArgs["txtppURL"] = txtppURL.GetText();
    //cbpAddBank_OnEndCallback(s, e);
}

function cbpAddBank_OnEndCallback(s, e) {
    cbpBanks.PerformCallback();
}

function cbpBanks_cbpBanksBeginCallback(s, e) {
}

function cbpBanks_cbpBanksEndCallback(s, e) {
    var item;
    if (AddedBankName == undefined) {
    }
    else {
        if (AddedBankName != "") {
            item = cmbBank.FindItemByText(AddedBankName);
            cmbBank.SetSelectedIndex(item.index);
            cmbBank.SetText(item.text);
            cmbBank.SetValue(cmbBank.GetValue());
            cmbBankSelect();
            AddedBankName = '';
        }
    }
}

function ToUpperCase(s, e) {
    s.SetText((s.GetText()).toUpperCase())
}
function ToLowerCase(s, e) {
    s.SetText((s.GetText()).toLowerCase())
}

function ToTitleCase(s, e) {
    var smallWords = /^(a|an|and|as|at|but|by|en|for|if|in|of|on|or|the|to|vs?\.?|via)$/i;

    s.SetText((s.GetText()).replace(/([^\W_]+[^\s-]*) */g, function (match, p1, index, title) {
        if (index > 0 && index + p1.length !== title.length &&
      p1.search(smallWords) > -1 && title.charAt(index - 2) !== ":" &&
      title.charAt(index - 1).search(/[^\s-]/) < 0) {
            return match.toLowerCase();
        }

        if (p1.substr(1).search(/[A-Z]|\../) > -1) {
            return match;
        }

        return match.charAt(0).toUpperCase() + match.substr(1);
    }))
}

//String.prototype.toTitleCase = function () {
//    var smallWords = /^(a|an|and|as|at|but|by|en|for|if|in|of|on|or|the|to|vs?\.?|via)$/i;

//    return this.replace(/([^\W_]+[^\s-]*) */g, function (match, p1, index, title) {
//        if (index > 0 && index + p1.length !== title.length &&
//      p1.search(smallWords) > -1 && title.charAt(index - 2) !== ":" &&
//      title.charAt(index - 1).search(/[^\s-]/) < 0) {
//            return match.toLowerCase();
//        }

//        if (p1.substr(1).search(/[A-Z]|\../) > -1) {
//            return match;
//        }

//        return match.charAt(0).toUpperCase() + match.substr(1);
//    });
//};

//$(function () { $('#txtPAN').keyup(function () { this.value = this.value.toUpperCase(); }); }); 