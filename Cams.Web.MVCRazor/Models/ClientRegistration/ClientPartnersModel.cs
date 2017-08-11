using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.BusinessConstitutionServiceReference;
using Cams.Web.MVCRazor.Models.Shared;
using System.ComponentModel.DataAnnotations;
using Cams.Common;
//using Cams.Web.MVCRazor

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public class ClientPartnersModel : ClientPartnerDetailsDto
    {
        public ClientPartnersModel()
        {
            StateDistrictPlacesControlNames = new List<StateDistrictCityControlNamesModel>();
            designationModel = new List<DesignationModel>();
            dOBnAgeModellist = new List<DOBnAgeModel>();

            #region Partner Details
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel("Partner"));
            designationModel.Add(new DesignationModel("Partner"));
            dOBnAgeModellist.Add(new DOBnAgeModel("Partner"));
            dOBnAgeModellist[0].MaxDate = DateTime.Now;
            dOBnAgeModellist[0].MinDate = DateTime.Parse("01-01-1900");
            dOBnAgeModellist[0].BindDate = DateTime.Now.AddYears(-18);
            dOBnAgeModellist[0].Width = 110;
            StateDistrictPlacesControlNames[0].LeftLabelsClassName = "width110";
            StateDistrictPlacesControlNames[0].StateLabelName = "lblbcState";
            StateDistrictPlacesControlNames[0].PlacesLabelName = "lblbcplace";
            StateDistrictPlacesControlNames[0].DropDownWidth = System.Web.UI.WebControls.Unit.Pixel(195);

            JoiningDate = DateTime.Now;
            //dOBnAgeModellist.Add(new DOBnAgeModel("PartnerJoiningDate"));
            //dOBnAgeModellist[1].MinDate = DateTime.Parse("01-01-1900");
            //dOBnAgeModellist[1].BindDate = DateTime.Now;
            //dOBnAgeModellist[1].Width = 110;

            RelievingDate = Helper.SetDefaultDate();
            //dOBnAgeModellist.Add(new DOBnAgeModel("PartnerFarewellDate"));
            //dOBnAgeModellist[2].MinDate = DateTime.Parse("01-01-1900");
            //dOBnAgeModellist[2].BindDate = Helper.SetDefaultDate();
            //dOBnAgeModellist[2].Width = 110;

            IsActive = true;
            #endregion

            #region Gardian Details
            ClientPartnerGuardian = new ClientPartnerGuardianDetailsDto();
            Relationships = GetRelationshipDtos();
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel("Gardian"));
            dOBnAgeModellist.Add(new DOBnAgeModel("Gardian"));
            dOBnAgeModellist[1].MaxDate = DateTime.Today;
            dOBnAgeModellist[1].MinDate = DateTime.Parse("01-01-1900");
            dOBnAgeModellist[1].Width = 110;
            StateDistrictPlacesControlNames[1].LeftLabelsClassName = "width110";
            StateDistrictPlacesControlNames[1].StateLabelName = "lblGardianState";
            StateDistrictPlacesControlNames[1].PlacesLabelName = "lblGardianplace";
            StateDistrictPlacesControlNames[1].DropDownWidth = System.Web.UI.WebControls.Unit.Pixel(195);
            #endregion

            //gardianDetailsModel = new GardianDetailsModel();
        }
        public List<DesignationModel> designationModel;
        public List<DOBnAgeModel> dOBnAgeModellist;
        public List<StateDistrictCityControlNamesModel> StateDistrictPlacesControlNames;
        public List<RelationshipDto> Relationships;

        //public GardianDetailsModel gardianDetailsModel;

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRequiredPartnerName")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,60}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRegExPartnerName")]
        public override string PartnerName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRequiredEmail1")]
        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRegExEmail1")]
        public override string Email1 { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRequiredDOB")]
        public override Nullable<DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRequiredPAN")]
        [RegularExpression( Constants.REGEXPAN, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRegExPAN")]
        public override string PAN { get; set; }

        //[RegularExpression(Constants.REGEXUID, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "AOErrorRegExUID")]
        public override string UID { get; set; }

        public static List<RelationshipDto> GetRelationshipDtos()
        {
            RelationShipServiceReference.RelationShipServiceClient RClient = new RelationShipServiceReference.RelationShipServiceClient();
            var Relationships = RClient.FindAll();
            RClient.Close();
            return Relationships.Entities.ToList();
        }
    }
}