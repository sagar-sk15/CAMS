(function ($) { $.QueryString = (function (a) { if (a == "") return {}; var b = {}; for (var i = 0; i < a.length; ++i) { var p = a[i].split('='); if (p.length != 2) continue; b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " ")); } return b; })(window.location.search.substr(1).split('&')) })(jQuery);

function UserGroupPopupSaveButtonCLick(parameters) {
    var grouptext = ppUserGroup.GetText();
    if (grouptext != "") {
        cbp.PerformCallback();
    }
}
function cbp_OnBeginCallback(s, e) {
    var ppUserGroup = ASPxClientControl.GetControlCollection().GetByName('ppUserGroup');
    var ppDescription = ASPxClientControl.GetControlCollection().GetByName('ppDescription');
    e.customArgs["ppGroupName"] = ppUserGroup.GetText();
    e.customArgs["ppDescription"] = ppDescription.GetText();
    UserGroupModal.Hide();
}
function cbp_OnEndCallback() {
    cbpUserGroupList.PerformCallback();    
}

function cbpUserGroupList_OnBeginCallback(s, e) {
    var cmbClient = ASPxClientControl.GetControlCollection().GetByName('cmbClient');
    if (cmbClient) {
        e.customArgs["CAId"] = cmbClient.GetValue();
    }
    e.customArgs["usertype"] = $.QueryString["usertype"];
}