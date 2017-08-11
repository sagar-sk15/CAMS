using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Web.MVCRazor.Helpers;
using Cams.Common;
using Cams.Web.MVCRazor.Models.ClientRegistration;
using Cams.Web.MVCRazor.Models.Shared;
using Cams.Web.MVCRazor.ClientServiceReference;
using Cams.Common.Dto.User;
using Cams.Common.Dto;
using DevExpress.Web.Mvc;
using Cams.Common.Dto.Masters;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.APMCMasterServiceReference;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientAccountController : CommonController
    {
        /// <summary>
        /// This function return data in Json format to JavaScript function:APMCSelect()
        /// which is in Companyprofile.cshtml script section
        /// </summary>
        /// <param name="apmcId"></param>
        /// <returns></returns>
        public JsonResult GetSelectedApmcDetails(int apmcId)
        {
            APMCMasterServiceReference.APMCServiceClient apmcServiceClient = new APMCServiceClient();
            List<string> jsonResult = new List<string>();
            string email = string.Empty;
            string mobileNo = string.Empty;
            string address = string.Empty;
            string state = string.Empty;
            string country = string.Empty;
            try
            {
                APMCDto apmcDto = apmcServiceClient.GetById(apmcId);
                if (apmcDto != null)
                {
                    email = apmcDto.Email1;
                    email = !String.IsNullOrEmpty(apmcDto.Email2) ? email + "<br />" + apmcDto.Email2 : email;
                    email = !String.IsNullOrEmpty(apmcDto.Website) ? email + "<br />" + apmcDto.Website : email;

                    if (apmcDto.ContactNos != null && apmcDto.ContactNos.Count > 0)
                    {
                        foreach (ContactDetailsDto contact in apmcDto.ContactNos)
                        {
                            if (contact.ContactNoType != Cams.Common.ContactType.MobileNo)
                            {
                                mobileNo += "(" + contact.CountryCallingCode + ") - " + contact.STDCode + " - " + contact.ContactNo + "<br />";
                            }
                            else
                            {
                                mobileNo += "(" + contact.CountryCallingCode + ") - " + contact.ContactNo + "<br />";
                            }
                        }
                    }
                    if (apmcDto.Address != null && apmcDto.Address.CityVillage != null &&
                        apmcDto.Address.CityVillage.DistrictOfCityVillage != null)
                    {
                        address = apmcDto.Address.AddressLine1 + ",<br/>" + apmcDto.Address.CityVillage.Name + ","
                                  + apmcDto.Address.CityVillage.DistrictOfCityVillage.DistrictName + ",<br/>"
                                  + apmcDto.Address.PIN;

                        if (apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict != null)
                        {
                            state = apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.RegionName;

                            if (apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry != null)
                            {
                                country = apmcDto.Address.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateInCountry.CountryName;
                            }
                        }
                    }

                    jsonResult.Add(email);
                    jsonResult.Add(mobileNo);
                    jsonResult.Add(address);
                    jsonResult.Add(state);
                    jsonResult.Add(country);
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                if (apmcServiceClient != null && apmcServiceClient.State == System.ServiceModel.CommunicationState.Opened)
                    apmcServiceClient.Close();
            }
            return Json(jsonResult);
        }

    }
}
