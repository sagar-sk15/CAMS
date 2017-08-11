
/*Convert text to Title case*/
function ToTitleCase(control) {
    var smallWords = /^(a|an|and|as|at|but|by|en|for|if|in|of|on|or|the|to|vs?\.?|via)$/i;

    $('#' + control).val($('#' + control).val().replace(/([^\W_]+[^\s-]*) */g, function (match, p1, index, title) {
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

/*Convert text to UPPER case*/
function ToUpperCase(control) {
    $('#' + control).val($('#' + control).val().toUpperCase())
}

/*Convert text to lower case*/
function ToLowerCase(control) {
    $('#' + control).val($('#' + control).val().toLowerCase())
}


(function ($) {
    $.QueryString = (function (a) {
        if (a == "")
            return {};
        var b = {};
        for (var i = 0; i < a.length; ++i) {
            var p = a[i].split('=');
            if (p.length != 2)
                continue;
            b[p[0]] = decodeURIComponent(p[1].replace(/\+/g, " "));
        }
        return b;
    })(window.location.search.substr(1).split('&'))
})(jQuery);


function OnValueChanged(s, fieldName, rolePermissionId, roleId, roleGroup, userGroupId, url) {    
    $.ajax({
        type: "POST",
        url: url,
        data: { fieldName: fieldName, rolePermissionId: rolePermissionId, roleId: roleId,
            roleGroup: roleGroup, userGroupId: userGroupId, value: s.GetValue()
        }
    });
}

function OnValueChangedinUserRolesGrid(s, fieldName,userRolePermissionId, url) {    
    $.ajax({
        type: "POST",
        url: url,
        data: {
            fieldName: fieldName,
            userRolePermissionId: userRolePermissionId,
            value: s.GetValue(),
            username: $.QueryString["username"]
        }
    });
}


function SetAddressContactDivHeight(divCmpnyAddClientId, divCmpnyCntsClientId) {
    var divCmpnyAdd = $('#' + divCmpnyAddClientId);
    var divCmpnyCnts = $('#' + divCmpnyCntsClientId);
    var height = divCmpnyCnts.height();
    if (divCmpnyAdd.height() > height)
        height = divCmpnyAdd.height();

    divCmpnyAdd.height(height);
    divCmpnyCnts.height(height);
}