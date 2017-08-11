using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserRegistrationModel : Cams.Common.Dto.User.UserDto
    {
        public UserRegistrationModel()
        {
            UserOfClient = new ClientDto();
            UserGroupList = new List<UserGroupDto>();
            StateList = new List<StateDto>();
            DistrictList = new List<DistrictDto>();
            CityVillageList = new List<CityVillageDto>();            
            ECRelationshipWithUser = new List<RelationshipDto>();
            StateDistrictPlacesControlNames = new List<Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel>();
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel(""));
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel("EC"));

            UserProfile = new UserProfileDto();
            UserProfile.ContactNos = new List<ContactDetailsDto>();
            UserProfile.ContactNos.Add(new ContactDetailsDto()
            {
                ContactNoType = Common.ContactType.MobileNo,
                ContactNo = "",
                STDCode = "020",
                CountryCallingCode = "+91"
            });

            CountryCode = "+91";
            IsActive = true;
            //DateOfBirthModel = new DOBModel();
        }

        public IList<Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel> StateDistrictPlacesControlNames;
        public string CommonControlPrefix { get; set; }
        public string GeneratedPassword{ get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredUsername")]
        [RegularExpression(@"[0-9a-zA-Z\s]{6,15}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExUsername")]
        [Remote("CheckUsername", "Account")]
        public override string UserName { get; set; }

        public override string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredFullName")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,60}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExFullName")]
        [Remote("GetFullName", "Account")]
        public override string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredEmail")]
        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExEmail")]
        public override string Email { get; set; }

        public override string CountryCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredMobileNumber")]
        [RegularExpression(@"\d{10,15}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExMobileNumber")]
        public override string MobileNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredMothersMaidenName")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,15}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExMothersMaidenName")]
        public override string MothersMaidenName { get; set; }

        public override string Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRequiredDOB")]
        public DateTime DOB { get; set; }

        public string SelectedUserGroupList;
        public string SelectedDesignation;
        public string BirthDate;
        public string Age;
        public List<UserGroupDto> UserGroupList;
        public IList<RelationshipDto> ECRelationshipWithUser;
        public IList<StateDto> StateList;
        public IList<DistrictDto> DistrictList;
        public IList<CityVillageDto> CityVillageList;
        [DefaultValue("none")]
        public string mode = string.Empty;
        //public DOBModel DateOfBirthModel;
    }

    //public class DOBModel
    //{
    //    public string Prefix { get; set; }
    //    //public string cbpDOBnAgeName { get; set; }
    //    //public string txtDOBnAgeName { get; set; }
    //    public int Width { get; set; }
    //    public DateTime MinDate { get; set; }
    //    public DateTime MaxDate { get; set; }
    //    public DateTime BindDate { get; set; }

    //    public DOBModel()
    //    {
    //        //Prefix = prefix;
    //        //cbpDOBnAgeName = Prefix + "cbpDOBnAgeName";
    //        //txtDOBnAgeName = Prefix + "txtDOBnAgeName";
    //        Width = 110;
    //        MaxDate = DateTime.Parse("01-01-2099");
    //        MinDate = DateTime.Parse("01-01-1900");
    //    }
    //}
}