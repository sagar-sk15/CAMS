using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.Masters;
using Cams.Web.MVCRazor.APMCMasterServiceReference;
using Cams.Web.MVCRazor.CommodityClassServiceReference;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public partial class ClientRegistrationModel
    {
        public int HiddenFieldForAPMCValue { get; set; }
        //[Required]
        public override string APMCLicenseNo { get; set; }
        //public static IList<APMCDto> ApmcDtoList = null;
        public IList<CommodityClassDto> CommodityClassDtoList = null;
        public static IList<APMCDto> GetAllApmc()
        {
            IList<APMCDto> ApmcDtoList = null;
            APMCMasterServiceReference.APMCServiceClient apmcServiceClient = new APMCServiceClient();
            ApmcDtoList = apmcServiceClient.FindAll().Entities.ToList<APMCDto>();
            apmcServiceClient.Close();
            ApmcDtoList.Insert(0, new APMCDto { 
            APMCId=0,
            Name="[Select]"});
            
            return ApmcDtoList;
        }

        public IList<CommodityClassDto> GetAllCommodities()
        {
            CommodityClassServiceReference.CommodityClassServiceClient commodityClassServiceClient = new CommodityClassServiceClient();
            Query query = new Query();
            query.Add(new Criterion(Constants.ISACTIVE, true, CriteriaOperator.Equal));
            CommodityClassDtoList = commodityClassServiceClient.FindByQuery(query).Entities;
            commodityClassServiceClient.Close();
            foreach (CommodityClassDto cl in CommodityClassDtoList)
            {
                cl.IsActive = false;
            }
            return CommodityClassDtoList;
        }
    }
}