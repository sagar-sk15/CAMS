using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using Cams.Common;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.UserServiceReference;
using AutoMapper;
using Cams.Common.Dto.ClientRegistration;
using Cams.Web.MVCRazor.Models.Shared;
using Cams.Common.Dto.Address;
using Cams.Common.Dto;

namespace Cams.Web.MVCRazor
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
            );
            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            #region Map ClientDto to BusinessRegistrationModel
            Mapper.CreateMap<ClientDto, Models.BusinessRegistration.BusinessRegistrationModel>()
                .ForMember(x => x.ClientAddress, opts => opts.MapFrom(src => src.ClientAddress))
                .ForMember(x => x.ClientAPMC, opts => opts.MapFrom(src => src.ClientAPMC))
                .ForMember(x => x.ClientBusinessConstitution, opts => opts.MapFrom(src => src.ClientBusinessConstitution))
                .ForMember(x => x.ClientContacts, opts => opts.MapFrom(src => src.ClientContacts))
                .ForMember(x => x.ClientPartners, opts => opts.MapFrom(src => src.ClientPartners))
                .ForMember(x => x.ClientPhoneCharges, opts => opts.MapFrom(src => src.ClientPhoneCharges))
                .ForMember(x => x.ClientPrimaryContactPerson, opts => opts.MapFrom(src => src.ClientPrimaryContactPerson))
                .ForMember(x => x.ClientSisterConcerns, opts => opts.MapFrom(src => src.ClientSisterConcerns))
                .ForMember(x => x.ClientSubscription, opts => opts.MapFrom(src => src.ClientSubscription))
                .ForMember(x => x.ClientTaxationAndLicenses, opts => opts.MapFrom(src => src.ClientTaxationAndLicenses))
                .ForMember(x => x.CompanyAddress, opts => opts.MapFrom(src => new AddressReadOnlyViewModel("")
                {
                    Address = Helper.GetInitializedAddressObject(src.ClientAddress)
                }))
                .ForMember(x => x.PrimaryContactsAddress, opts => opts.MapFrom(src => new AddressReadOnlyViewModel("PCP")
                {
                    Address = (src.ClientPrimaryContactPerson != null) ?
                            Helper.GetInitializedAddressObject(src.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress) :
                            Helper.GetInitializedAddressObject(null)                                        
                }))
                .ForMember(x => x.ApmcAddress, opts => opts.MapFrom(src => new AddressReadOnlyViewModel("APMC")
                {
                    Address = (src.ClientAPMC != null) ?
                            Helper.GetInitializedAddressObject(src.ClientAPMC.Address) :
                            Helper.GetInitializedAddressObject(null)
                }))
                .ForMember(x => x.CompanyContacts, opts => opts.MapFrom(src => new ContactsReadOnlyViewModel("")
                {
                    Contacts = src.ClientContacts,
                    Email1 = src.Email1,
                    Email2 = src.Email2,
                    Website = src.Website
                }))
                .ForMember(x => x.PrimaryContactsContacts, opts => opts.MapFrom(src => new ContactsReadOnlyViewModel("PCP")
                {
                    Contacts = (src.ClientPrimaryContactPerson != null) ? src.ClientPrimaryContactPerson.ClientPrimaryContacts : new List<ContactDetailsDto>(),
                    Email1 = (src.ClientPrimaryContactPerson != null) ? src.ClientPrimaryContactPerson.Email1 : "",
                    Email2 = (src.ClientPrimaryContactPerson != null) ? src.ClientPrimaryContactPerson.Email2 : "",
                    IsWebsiteApplicable = false

                }))
                .ForMember(x => x.ApmcContacts, opts => opts.MapFrom(src => new ContactsReadOnlyViewModel("APMC")
                {
                    Contacts = (src.ClientAPMC != null) ? src.ClientAPMC.ContactNos : new List<ContactDetailsDto>(),
                    Email1 = (src.ClientAPMC != null) ? src.ClientAPMC.Email1 : "",
                    Email2 = (src.ClientAPMC != null) ? src.ClientAPMC.Email2 : "",
                    Website = (src.ClientAPMC != null) ? src.ClientAPMC.Website : "",
                }))
                .ForMember(x => x.AccountManager, opts => opts.MapFrom(src => GetAccountManager(src.AccountManagerId)))
                ;
            #endregion

            #region Map BusinessRegistrationModel to ClientDto
            Mapper.CreateMap<Models.BusinessRegistration.BusinessRegistrationModel, ClientDto>()
                .ForMember(x => x.ClientAddress, opts => opts.MapFrom(src => src.ClientAddress))
                .ForMember(x => x.ClientAPMC, opts => opts.MapFrom(src => src.ClientAPMC))
                .ForMember(x => x.ClientBusinessConstitution, opts => opts.MapFrom(src => src.ClientBusinessConstitution))
                .ForMember(x => x.ClientContacts, opts => opts.MapFrom(src => src.ClientContacts))
                .ForMember(x => x.ClientPartners, opts => opts.MapFrom(src => src.ClientPartners))
                .ForMember(x => x.ClientPhoneCharges, opts => opts.MapFrom(src => src.ClientPhoneCharges))
                .ForMember(x => x.ClientPrimaryContactPerson, opts => opts.MapFrom(src => src.ClientPrimaryContactPerson))
                .ForMember(x => x.ClientSisterConcerns, opts => opts.MapFrom(src => src.ClientSisterConcerns))
                .ForMember(x => x.ClientSubscription, opts => opts.MapFrom(src => src.ClientSubscription))
                .ForMember(x => x.ClientTaxationAndLicenses, opts => opts.MapFrom(src => src.ClientTaxationAndLicenses));
            #endregion
        }

        

        private UserDto GetAccountManager(long AccountManagerId)
        {
            UserDto accountManager = new UserDto();
            if (AccountManagerId != 0)
            {
                UserServiceClient client = new UserServiceClient();
                accountManager = client.GetById(AccountManagerId);
                client.Close();
            }
            return accountManager;
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e) 
        {    
            
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];     
            if (authCookie == null || authCookie.Value == "")         
                return;      
            FormsAuthenticationTicket authTicket;     
            try     
            {         
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);     
            }     
            catch     
            {         
                return;     
            }      
            // retrieve roles from UserData     
            string[] roles = authTicket.UserData.Split(';');      

            if (Context.User != null)         
                Context.User = new GenericPrincipal(Context.User.Identity, roles); 
        } 

        protected void Session_End(object sender,EventArgs e)
        {
            UserDto userDto = (UserDto)Session[Constants.SKCURRENTUSER];
            if (userDto != null)
            {
                userDto.IsOnLine = false;
                userDto.ViewOfUserUserGroupRolePermissions = null;
                UserServiceClient client = new UserServiceClient();
                client.Update(userDto, null);
                client.Close();
            }
        }

    }
}