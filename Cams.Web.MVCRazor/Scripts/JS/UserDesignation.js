function UserDesignationPopupSaveButtonClick(parameters) {
    var designationtext = ppUserDesignation.GetText();
    if (designationtext != "") {
        cbpUserDesignation.PerformCallback();
    }
}
function cbpUserDesignation_OnBeginCallback(s, e) {
    var ppUserDesignation = ASPxClientControl.GetControlCollection().GetByName('ppUserDesignation');
    var designationtext = $.trim(ppUserDesignation.GetText());
    e.customArgs["ppUserDesignation"] = designationtext;
    $('#SelectedDesignation').val(designationtext);
    UserDesignationModal.Hide();
}
function cbpUserDesignation_OnEndCallback() {
    cbpUserDesignationList.PerformCallback();
}
function cbpUserDesignationList_OnBeginCallback(s, e) {
    debugger;
    e.customArgs["AddedDesignation"] = $('#SelectedDesignation').val();
}

function SetDesignationSelectedIndex() {
//    debugger;
    var designation = $('#SelectedDesignation').val();
    if (designation != "") {
        var Item = ddlECDesignation.FindItemByText(designation);
        ddlECDesignation.SetSelectedIndex(Item.value);
        ddlECDesignation.SetText(Item.text);
    }
}

function PopupctrlAddDesignationSave(parameters) {
    var designationtext = ppUserDesignation.GetText();
    if (designationtext != "") {
        CBPCtrlPopupAddDesignation.PerformCallback();
    }
}

function CBPCtrlPopupAddDesignation_OnBeginCallback(s, e) {
    e.customArgs["ppUserDesignation"] = ppUserDesignation.GetText();
    PopupctrlAddDesignation.Hide();
}

function CBPCtrlPopupAddDesignation_OnEndCallback(s, e) {
    cbpctrlUserDesignationList.PerformCallback();
}

function cbpctrlUserDesignationList_OnBeginCallback(s, e, Prefix, HiddenTextboxName) {
    e.customArgs["prefix"] = Prefix;
    var designation = $(HiddenTextboxName).val();
}

function ddlDesignations_SelectedIndexChanged(s, e, Prefix, HiddenTextboxName) {
    $(HiddenTextboxName).val(s.GetValue());
}

