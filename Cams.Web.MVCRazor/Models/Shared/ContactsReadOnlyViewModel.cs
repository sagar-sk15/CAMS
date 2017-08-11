using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using System.Web.Mvc;
using Cams.Common.Dto.Address;
using Cams.Common.Dto;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class ContactsReadOnlyViewModel
    {
        #region Constructor
        public ContactsReadOnlyViewModel(string prefix)
        {
            Prefix = prefix;
            LeftLabelsClassName = "width110";
            ValueLabelsClassName = "non-editable-txt";
            OuterULClassName = "reset onecolfield";
            ContactTypeColumnWidthClassName = "width110";
            IsWebsiteApplicable = true;
            Contacts = new List<ContactDetailsDto>{
                new ContactDetailsDto()
            };
        }
        #endregion

        #region Properties
        public string Prefix { get; set; }
        public string LeftLabelsClassName { get; set; }
        public string ValueLabelsClassName { get; set; }
        public string OuterULClassName { get; set; }
        public IList<ContactDetailsDto> Contacts;
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }
        public string ContactTypeColumnWidthClassName { get; set; }
        public bool IsWebsiteApplicable { get; set; }
        #endregion

        #region Static Methods
        #endregion

    }
}