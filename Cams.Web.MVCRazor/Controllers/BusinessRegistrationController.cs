using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Web.MVCRazor.Models.BusinessRegistration;
using Cams.Common.Dto.ClientRegistration;
using AutoMapper;
using Cams.Common;
using Cams.Common.Dto.User;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class BusinessRegistrationController : CommonController
    {
        //
        // GET: /BusinessRegistration/

        public ActionResult BusinessRegistrationIndex()
        {
            BusinessRegistrationModel model = GetBusinessRegistrationModelFromSession();
            model.hdnCurrentTab = Session["BRActiveTab"] != null ? Convert.ToInt32(Session["BRActiveTab"]) : 0;
            UserDto userDto= (UserDto)Session[Constants.SKCURRENTUSER];
            int caId= Convert.ToInt32( Helper.GetCAIdOfUser(userDto));
            ClientDto clientDto = GetClient(caId, false);

            model = Mapper.Map<ClientDto, BusinessRegistrationModel>(clientDto);  
          
            //model.ClientAddress = clientDto.ClientAddress;
            //model.ClientAPMC = clientDto.ClientAPMC;
            //model.ClientBusinessConstitution = clientDto.ClientBusinessConstitution;
            //model.ClientCommodities = clientDto.ClientCommodities;
            //model.ClientContacts = clientDto.ClientContacts;
            //model.ClientPartners = clientDto.ClientPartners;
            //model.ClientPhoneCharges = clientDto.ClientPhoneCharges;
            //model.ClientPrimaryContactPerson = clientDto.ClientPrimaryContactPerson;
            //model.ClientSisterConcerns = clientDto.ClientSisterConcerns;
            //model.ClientSubscription = clientDto.ClientSubscription;
            //model.ClientTaxationAndLicenses = clientDto.ClientTaxationAndLicenses;

            //model.CompanyAddress.Address = clientDto.ClientAddress;
            //model.CompanyContacts.Contacts = clientDto.ClientContacts;
            //model.CompanyContacts.Email1 = clientDto.Email1;
            //model.CompanyContacts.Email2 = clientDto.Email2;            
            //model.CompanyContacts.Website= clientDto.Website;
                        
            //if (clientDto.ClientPrimaryContactPerson != null)
            //{
            //    model.PrimaryContactsContacts.Email1 = clientDto.ClientPrimaryContactPerson.Email1;
            //    model.PrimaryContactsContacts.Email1 = clientDto.ClientPrimaryContactPerson.Email2; 
            //    if(clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
            //        model.PrimaryContactsAddress.Address = clientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress;
            //    if(clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts != null)
            //        model.PrimaryContactsContacts.Contacts = clientDto.ClientPrimaryContactPerson.ClientPrimaryContacts;
            //}
                          
            
            //if (clientDto.ClientAPMC != null)
            //{
            //    model.ApmcContacts.Email1 = clientDto.ClientAPMC.Email1;
            //    model.ApmcContacts.Email2 = clientDto.ClientAPMC.Email2;
            //    model.ApmcContacts.Website = clientDto.ClientAPMC.Website;

            //    if(clientDto.ClientAPMC.Address != null)
            //        model.ApmcAddress.Address = clientDto.ClientAPMC.Address;
            //    if(clientDto.ClientAPMC.ContactNos != null)
            //        model.ApmcContacts.Contacts = clientDto.ClientAPMC.ContactNos;
            //}
            
            return View("BusinessProfile", model);
        }

        private BusinessRegistrationModel GetBusinessRegistrationModelFromSession()
        {
            BusinessRegistrationModel brModel;
            if (Session["BusinessRegistrationModel"] != null)
                brModel = (BusinessRegistrationModel)Session["BusinessRegistrationModel"];
            else
                brModel = new BusinessRegistrationModel();
            return brModel;
        }

    }
}
