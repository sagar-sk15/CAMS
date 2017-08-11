using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using System.Web.Mvc;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class DOBnAgeModel
    {
        public string Prefix { get; set; }
        public string cbpDOBnAgeName { get; set; }
        public string txtDOBnAgeName { get; set; }
        public int Width { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime BindDate { get; set; }

        public DOBnAgeModel(string prefix)
        {
            Prefix = prefix;
            cbpDOBnAgeName = Prefix + "cbpDOBnAgeName";
            txtDOBnAgeName = Prefix + "txtDOBnAgeName";
            Width = 110;
            MaxDate = DateTime.Parse("01-01-2099");
            MinDate = DateTime.Parse("01-01-1900");
            BindDate = DateTime.Today;
        }
    }
}