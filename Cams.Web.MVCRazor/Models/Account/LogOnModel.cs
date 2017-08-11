using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class LogOnModel
    {
        public LogOnModel()
        {
     
        }
        [Required(ErrorMessageResourceType = typeof(ClientResources), ErrorMessageResourceName = "ValidateUserName")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ClientResources), ErrorMessageResourceName = "ValidatePassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
  }
