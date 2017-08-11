using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.BusinessConstitutionServiceReference;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Web.MVCRazor.Models.Shared;
//using Cams.Web.MVCRazor

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public class BusinessConstitutionModel
    {
        public int BusinessConstitutionId { get; set; }
        public int NoOfClientPartners { get; set; }
        public int NoOfClientPartnersAdded { get; set; }
        public int SelectedIndex { get; set; }
        public DesignationModel designationModel { get; set; }
        public DOBnAgeModel dOBnAgeModel { get; set; }
        public int PartnerId { get; set; }
        //public IList<BusinessConstitutionDto> BusinessConstitutions;
        public List<ClientPartnerDetailsDto> ClientPartners;

        public BusinessConstitutionModel()
        {
            NoOfClientPartners = 1;
        }

        public static List<BusinessConstitutionDto> GetBusinessConstitution()
        {
            BusinessConstitutionServiceReference.BusinessConstitutionServiceClient BCclient = new BusinessConstitutionServiceClient();
            Query query = new Query();
            Criterion criteriaActive = new Criterion(Constants.ISACTIVE, true, CriteriaOperator.Equal);
            query.Add(criteriaActive);
            List<BusinessConstitutionDto> BCDto = BCclient.FindByQuery(query).Entities.ToList();
            BCclient.Close();
            return BCDto;
        }
        
    }
}