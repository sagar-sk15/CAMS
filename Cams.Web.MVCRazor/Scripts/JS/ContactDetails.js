        var currentIndex = 0;

        function removeContact(hdnCurrentIndex) {           
            currentIndex = $(hdnCurrentIndex)[0].defaultValue;
            $(this).parent().parent().remove();
            currentIndex--;
            $(hdnCurrentIndex).val(currentIndex);
        }

        $('table tr td a.remove').live('click', function () {           
            $(this).parent().parent().remove();
        });


        $('.clsContactNoType').live('change', function () {
            //            alert($(this).html());
            //            alert($(this).val());
            //            alert('change');
            var std = $(this).parent().parent().children('td').eq(2).find('input:first');
            var contact = $(this).parent().parent().children('td').eq(2).find('input:last');
            //            var spaceSpan = $(this).parent().parent().children('td').eq(3).find('span');

            if ($(this).val() != "MobileNo") {
                std.show();
                contact.removeClass('width166');
                contact.addClass('width118 margin5');
                //                spaceSpan.html("");
            }
            else {
                std.hide();
                contact.removeClass('width118 margin5');
                contact.addClass('width166');
                //                spaceSpan.html("&nbsp;");
            }
        });

        $('.clsContactNoType').live('click', function () {
            //            alert($(this).html());
            //            alert($(this).val());
            var std = $(this).parent().parent().children('td').eq(2).find('input:first');
            var contact = $(this).parent().parent().children('td').eq(2).find('input:last');
            //            var spaceSpan = $(this).parent().parent().children('td').eq(3).find('span');
            //            alert('click');
            if ($(this).val() != "MobileNo") {
                std.show();
                contact.removeClass('width166 textfiled');
                contact.addClass('width118 margin5 textfiled');
                //                spaceSpan.html("");
            }
            else {
                std.hide();
                contact.removeClass('width118 margin5 textfiled');
                contact.addClass('width166 textfiled');
                //                spaceSpan.html("&nbsp;");
            }
        });

        function addNewContact(ulContacts, hdnCurrentIndex, maxRows, basePartOfIdGenerated, basePartOfNameGenerated) {
            currentIndex = $(hdnCurrentIndex).val();
            if (currentIndex <= maxRows) {
                var newRow = "<tr><td><select class=\"clsContactNoType\" id=\"" + basePartOfIdGenerated + currentIndex.toString() +
                            "__ContactNoType\" name=\"" + basePartOfNameGenerated + "[" + currentIndex.toString() + "].ContactNoType\" " +
                    " style=\"width:90px; border: medium none; padding: 1px; float:left\"> " +
                    " <option selected=\"selected\" value=\"MobileNo\">Mobile No.</option>" +
                    " <option value=\"OfficeNo\">Office No.</option>" +
                    " <option value=\"ResidenceNo\">Resi. No.</option>" +
                    " <option value=\"Fax\">Fax No.</option>" +
                    " </select></td>" +
                    "<td><input class=\"textfiled\" id=\"" + basePartOfIdGenerated + currentIndex.toString() +
                            "__CountryCallingCode\" name=\"" + basePartOfNameGenerated + "[" + currentIndex.toString() + "].CountryCallingCode\" " +
                    " style=\"width:28px; text-align:center\" type=\"text\" value=\"+91\" disabled=\"disabled\" /> " +
                    " </td>" +
                    "<td><input class=\"textfiled\" id=\"" + basePartOfIdGenerated + currentIndex.toString() +
                            "__STDCode\" name=\"" + basePartOfNameGenerated + "[" + currentIndex.toString() + "].STDCode\" " +
                    " style=\"width:38px; display:none; text-align:center;\" type=\"text\" value=\"020\" />" +
//                    "<span>&nbsp;<span>" +
                //"</td>" +   
                //"<td>" +
                    "<input class=\"textfiled width166\" id=\"" + basePartOfIdGenerated + currentIndex.toString() +
                            "__ContactNo\" maxlength=\"15\" name=\"" + basePartOfNameGenerated + "[" + currentIndex.toString() +
                            "].ContactNo\" type=\"text\" value=\"\" />" +
                    "</td>" +
                    "<td><input type=\"hidden\" name=\"Index\" value=\"" + currentIndex.toString() + "\" />" +
                    "<a href=\"#\" class=\"remove\" onclick=\"javascript:removeContact('" + hdnCurrentIndex + "')\" ></a>"
                    + "</td></tr>";
//                alert(newRow);
                $(ulContacts).append(newRow);
                currentIndex++;
                $(hdnCurrentIndex).val(currentIndex);
            }
        }


        function showEmail2(liEmail2) {
//            $(liEmail2).html();
            $(liEmail2).show();
        }

        function hideEmail2(liEmail2) {      
            $('#UserProfile_Email2').val("");
            $('#UserProfile_UserEmergencyContactPerson_Email2').val("");
            $(liEmail2).html();
            $(liEmail2).hide();
            $('#Email2').val("");

        }
