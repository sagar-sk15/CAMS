using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.SubscriptionMasterServiceReference;
//using Cams.Web.MVCRazor

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public partial class ClientRegistrationModel : ClientDto
    {
        public IList<SubscriptionMasterDto> SubscriptionMasterList;
        public decimal TotalAdditionalUsers;
        public decimal TotalAdditionalCost;
        public decimal SubscriptionFees;
        public decimal NetAmount;
        public DateTime ActivationDate;
        public float TotalSubscriptionFees;
        public float RenewalFees;
        public static int StandardPackageSubscriptionId;
        public static int PremiumPackageSubscriptionId;

        public static List<SubscriptionMasterDto> getSubscriptionMaster()
        {
            SubscriptionMasterServiceReference.SubscriptionMasterServiceClient SMclient = new SubscriptionMasterServiceClient();
            List<SubscriptionMasterDto> SubscriptionMasterdtos = SMclient.FindAll().Entities.ToList();
            //foreach (SubscriptionMasterDto subDto in SubscriptionMasterdtos)
            //{
            //    if (subDto.SubscriptionType == Common.SubscriptionType.Premium)
            //    {
            //        PremiumPackageSubscriptionId = subDto.SubscriptionId;
            //    }
            //    if (subDto.SubscriptionType == Common.SubscriptionType.Premium)
            //    {
            //        StandardPackageSubscriptionId = subDto.SubscriptionId;
            //    }
            //}

            SMclient.Close();
            return SubscriptionMasterdtos;
        }
    }


}