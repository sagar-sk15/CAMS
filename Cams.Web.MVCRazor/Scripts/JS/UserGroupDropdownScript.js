//<![CDATA[
    var textSeparator = ";";
    function OnListBoxSelectionChanged(listBox, args) {
        if (args.index == 0)
            args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
        UpdateSelectAllItemState();
        UpdateText();
    }
    function UpdateSelectAllItemState() {
        IsAllSelected() ? listUserGroup.SelectIndices([0]) : listUserGroup.UnselectIndices([0]);
    }
    function IsAllSelected() {
        for (var i = 1; i < listUserGroup.GetItemCount(); i++)
            if (!listUserGroup.GetItem(i).selected)
                return false;
        return true;
    }
    function UpdateText() {
        var selectedItems = listUserGroup.GetSelectedItems();
        ddlUserGroup.SetText(GetSelectedItemsText(selectedItems));
        $('#SelectedUserGroupList').val(listUserGroup.GetSelectedValues().join(textSeparator));
        userGroupsSelectionChanged($('#SelectedUserGroupList').val());
//        alert($('#SelectedUserGroupList').val());
    }

    function UpdateSelectionByIdList() {
        var IdList = $('#SelectedUserGroupList').val();
        var values = IdList.split(textSeparator);
        listUserGroup.SelectValues(values);
        UpdateText();
    }
    
    function userGroupsSelectionChanged(ugList) {
    }

    function SynchronizeListBoxValues(dropDown, args) {
        listUserGroup.UnselectAll();
        var texts = dropDown.GetText().split(textSeparator);
        var values = GetValuesByTexts(texts);
        listUserGroup.SelectValues(values);
        UpdateSelectAllItemState();
        UpdateText(); // for remove non-existing texts
    }
    function GetSelectedItemsText(items) {
        var texts = [];
        for (var i = 0; i < items.length; i++)
            if (items[i].index != 0)
                texts.push(items[i].text);
        return texts.join(textSeparator);
    }
    function GetValuesByTexts(texts) {
        var actualValues = [];
        var item;
        for (var i = 0; i < texts.length; i++) {
            item = listUserGroup.FindItemByText(texts[i]);
            if (item != null)
                actualValues.push(item.value);
        }
        return actualValues;
    }

    