function cbpDOBnAge_EndCallback(controlname, prefix) {
    //debugger;
    var ctrlDateOfBirth = ASPxClientControl.GetControlCollection().GetByName(controlname);
    var dob = ctrlDateOfBirth.GetText();
    if (prefix == 'Partner') {
        var DatePart = dob.split("-");
        date_yymmdd = DatePart[2] + "-" + DatePart[1] + "-" + DatePart[0];
        if (checkAge(date_yymmdd)) {
            document.getElementById('liGardian').style.display = "none";
        }
        else {
            document.getElementById('liGardian').style.display = "block";
        }
        }
    //alert("1");
}

//YY-MM-DD
function checkAge(birthdate) {
    var today = new Date();
    var d = birthdate;
    if (!/\d{4}\-\d{2}\-\d{2}/.test(d)) {   // check valid format
        //showMessage();
        return false;
    }

    d = d.split("-");
    var byr = parseInt(d[0]);
    var nowyear = today.getFullYear();
    if (byr >= nowyear || byr < 1900) {  // check valid year
        //showMessage();
        return false;
    }
    var bmth = parseInt(d[1], 10) - 1;   // radix 10!
    if (bmth < 0 || bmth > 11) {  // check valid month 0-11
        //showMessage()
        return false;
    }
    var bdy = parseInt(d[2], 10);   // radix 10!
    var dim = daysInMonth(bmth + 1, byr);
    if (bdy < 1 || bdy > dim) {  // check valid date according to month
        //showMessage();
        return false;
    }

    var age = nowyear - byr;
    var nowmonth = today.getMonth();
    var nowday = today.getDate();
    if (bmth > nowmonth) { age = age - 1 }  // next birthday not yet reached
    else if (bmth == nowmonth && nowday < bdy) { age = age - 1 }

    //alert('You are ' + age + ' years old');
    if (age < 18) {
        return false;
    }
    return true;
}

//function showMessage() {
//    if (document.getElementById("dob").value != "") {
//        alert("Invalid date format or impossible year/month/day of birth - please re-enter as nowyearYY-MM-DD");
//        document.getElementById("dob").value = "";
//        document.getElementById("dob").focus();
//    }
//}

function daysInMonth(month, year) {  // months are 1-12
    var dd = new Date(year, month, 0);
    return dd.getDate();
} 