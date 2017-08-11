using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Common.Dto.ClientRegistration;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Domain.Entities;
using Cams.Common.Dto;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ClientPrimaryContactPersonService : ServiceBase<ClientPrimaryContactPerson,ClientPrimaryContactPersonDto> 
    {
        #region Constructor
        public ClientPrimaryContactPersonService()
        {
        }
        #endregion

        #region Overrides of ServiceBase<ClientPrimaryContactPerson,ClientPrimaryContactPersonDto>

        protected override void CheckForValidations(ClientPrimaryContactPerson client)
        {
           
        }

        protected override void CheckForValidationsWhileUpdating(ClientPrimaryContactPerson client) 
        {
           
        }

        public override ClientPrimaryContactPersonDto EntityToEntityDto(ClientPrimaryContactPerson entity)
        {
            ClientPrimaryContactPersonDto clientPrimaryContactPersonDto = Mapper.Map<ClientPrimaryContactPerson, ClientPrimaryContactPersonDto>(entity);
            if(entity != null)
            {
                #region ClientPrimaryContactPerson Address
                if (entity.ClientPrimaryContactPersonAddress != null)
                {
                    AddressService addressService = new AddressService();
                    clientPrimaryContactPersonDto.ClientPrimaryContactPersonAddress = addressService.EntityToEntityDto(entity.ClientPrimaryContactPersonAddress);
                }
                #endregion

                #region ClientPrimaryContactPerson Designation
                if (entity.ClientPrimaryContactPersonDesignation != null)
                {
                    DesignationService designationService = new DesignationService();
                    clientPrimaryContactPersonDto.ClientPrimaryContactPersonDesignation = designationService.EntityToEntityDto(entity.ClientPrimaryContactPersonDesignation);
                }
                #endregion

                #region ClientPrimaryContactPerson ContactDetails
                clientPrimaryContactPersonDto.ClientPrimaryContacts.Clear();
                if (entity.ClientPrimaryContacts != null)
                {
                    foreach (ContactDetails PrimaryContactPersoncontacts in entity.ClientPrimaryContacts)
                    {
                        ContactDetailsDto contactdto = new ContactDetailsDto();
                        contactdto = Mapper.Map<ContactDetails, ContactDetailsDto>(PrimaryContactPersoncontacts);
                        clientPrimaryContactPersonDto.ClientPrimaryContacts.Add(contactdto);
                    }
                }
                #endregion
            }
            return clientPrimaryContactPersonDto;
        }

        public override ClientPrimaryContactPerson EntityDtoToEntity(ClientPrimaryContactPersonDto entityDto)
        {
            ClientPrimaryContactPerson clientPrimaryContactPerson = Mapper.Map<ClientPrimaryContactPersonDto, ClientPrimaryContactPerson>(entityDto);
            if (entityDto != null)
            {
                #region ClientPrimaryContactPerson Address
                if (entityDto.ClientPrimaryContactPersonAddress != null)
                {
                    AddressService addressService = new AddressService();
                    clientPrimaryContactPerson.ClientPrimaryContactPersonAddress = addressService.EntityDtoToEntity(entityDto.ClientPrimaryContactPersonAddress);
                }
                #endregion

                #region ClientPrimaryContactPerson Designation
                DesignationService designationservice = new DesignationService();
                if (entityDto.ClientPrimaryContactPersonDesignation != null && entityDto.ClientPrimaryContactPersonDesignation.DesignationId != 0)
                {
                    DesignationDto designationdto = designationservice.GetById(entityDto.ClientPrimaryContactPersonDesignation.DesignationId);
                    clientPrimaryContactPerson.ClientPrimaryContactPersonDesignation = designationservice.EntityDtoToEntity(designationdto);
                }
                else
                    clientPrimaryContactPerson.ClientPrimaryContactPersonDesignation = null;
                #endregion

                #region ClientPrimaryContactPerson ContactDetails
                clientPrimaryContactPerson.ClientPrimaryContacts.Clear();
                if (entityDto.ClientPrimaryContacts != null)
                {
                    foreach (ContactDetailsDto contactdetailsdto in entityDto.ClientPrimaryContacts.Where(x => x.ContactNo != null && x.ContactNo != ""))
                    {
                        ContactDetails usercontactdetails = new Entities.ContactDetails();
                        usercontactdetails = Mapper.Map<ContactDetailsDto, ContactDetails>(contactdetailsdto);
                        clientPrimaryContactPerson.ClientPrimaryContacts.Add(usercontactdetails);
                    }
                }
                #endregion
            }
            return clientPrimaryContactPerson;
        }

        protected override string GetEntityInstanceName(ClientPrimaryContactPerson entity)
        {
            return entity.CAPrimaryConatactPersonName;
        }
        #endregion

    }
}
