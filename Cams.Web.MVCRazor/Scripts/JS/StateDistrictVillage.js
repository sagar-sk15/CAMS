

var districtid;
var cityOrVillage;

function AddnewButtonClick(ppStateUTName, ppDistrictsName, cmbStates, cmbDistricts, addCityVillagePopupName, cbpAddCity) {
    var ppStateUTTextBoxId = '#' + ppStateUTName;
    var ppDistrictsNameTextBoxId = '#' + ppDistrictsName;

    var ctrlCmbStates = ASPxClientControl.GetControlCollection().GetByName(cmbStates);
    var ctrlCmbDistricts = ASPxClientControl.GetControlCollection().GetByName(cmbDistricts);
    var ctrlAddCityVillagePopupName = ASPxClientControl.GetControlCollection().GetByName(addCityVillagePopupName);
    var ctrlcbpAddCity = ASPxClientControl.GetControlCollection().GetByName(cbpAddCity);

    var state = ctrlCmbStates.GetText();
    var stateId = ctrlCmbStates.GetValue();
    var district = ctrlCmbDistricts.GetText();
    districtid = ctrlCmbDistricts.GetValue();

    if (state == '' || district == '' || stateId=='0' || districtid=='0') {
        alert('Please Select value for State and District');
    }
    else {
        $(ppStateUTTextBoxId).text(state);
        $(ppDistrictsNameTextBoxId).text(district);
//        ctrlPpStateUTName.SetText(state);
//        ctrlPpDistrictsName.SetText(district)
        ctrlAddCityVillagePopupName.Show();
    }
}


//function cbpPlacesEndCallback(cmbCityVillage) {
//    alert(cmbCityVillage);

//    var ctrlcmbCityVillage = ASPxClientControl.GetControlCollection().GetByName(cmbCityVillage);
//    alert(ctrlcmbCityVillage);
//    var item;
//    if (cityOrVillage == undefined) {
//    }
//    else{
//        if (cityOrVillage != "") {
//            item = ctrlcmbCityVillage.FindItemByText(cityOrVillage);
//            ctrlcmbCityVillage.SetSelectedIndex(item.index);
//            ctrlcmbCityVillage.SetText(item.text);
//            ctrlcmbCityVillage.SetValue(ctrlcmbCityVillage.GetValue());
//            cityOrVillage = '';
//        }
//    }
//}


function DistrictSelectedIndexChange(prefix) {
    if (prefix == 'PCP') {
        UpdateSameAsCompanyAddressFlag();
    }
}

function PlaceSelectedIndexChange(prefix) {
    if (prefix == 'PCP') {
        UpdateSameAsCompanyAddressFlag();
    }
}

function StateSelectedIndexChange(prefix) {
    if (prefix == 'PCP') {
        UpdateSameAsCompanyAddressFlag();
    }
}

function UpdateSameAsCompanyAddressFlag() {
    if ((PCPcmbStates.GetValue() !== cmbStates.GetValue()) ||
        (PCPcmbDistricts.GetValue() !== cmbDistricts.GetValue()) ||
        (PCPcmbCityVillage.GetValue() !== cmbCityVillage.GetValue()) ||
        ($('#txtCLRPCPAddress').val() != $('#ClientAddress_AddressLine1').val()) ||
        ($('#ClientAddress_PIN').val() != $('#txtCLRPCPPin').val())
        ) {
        $('#ClientPrimaryContactPerson_IsSameAsCompanyAddress')[0].checked = false;
    }
    else {
        $('#ClientPrimaryContactPerson_IsSameAsCompanyAddress')[0].checked = true;
    }
}