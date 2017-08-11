using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Email;
using Cams.Common.Dto.Email;
using Cams.Common.ServiceContract;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ClientProfileChangeRequestsService : ServiceBase<ClientProfileChangeRequests, ClientProfileChangeRequestsDto>, IClientProfileChangeRequestsService
    {
        #region Constructor
        public ClientProfileChangeRequestsService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientProfileChangeRequests clientprofilechangerequest)   
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientProfileChangeRequests clientprofilechangerequest)  
        {
        }

        public override ClientProfileChangeRequestsDto EntityToEntityDto(ClientProfileChangeRequests entity)
        {
            ClientProfileChangeRequestsDto clientprofilechangerequestDto = Mapper.Map<ClientProfileChangeRequests, ClientProfileChangeRequestsDto>(entity);
            
            if (entity != null)
            {
                #region ClientProfileChangeRequestEmailMessages
                if (entity.ClientProfileChangeRequestEmailMessages != null)
                {
                    clientprofilechangerequestDto.ClientProfileChangeRequestEmailMessages = Mapper.Map<EmailMessages, EmailMessagesDto>(entity.ClientProfileChangeRequestEmailMessages);

                    clientprofilechangerequestDto.ClientProfileChangeRequestEmailMessages.EmailAttachmentes.Clear();
                    if(entity.ClientProfileChangeRequestEmailMessages.EmailAttachmentes != null)
                    {
                        foreach (EmailAttachment emailattachment in entity.ClientProfileChangeRequestEmailMessages.EmailAttachmentes)
                        {
                            EmailAttachmentDto emailattachmentDto = new EmailAttachmentDto();
                            emailattachmentDto = Mapper.Map<EmailAttachment, EmailAttachmentDto>(emailattachment);
                            clientprofilechangerequestDto.ClientProfileChangeRequestEmailMessages.EmailAttachmentes.Add(emailattachmentDto);
                        }
                    }
                }
                #endregion 

                #region ClientProfileChangeRequestFields
                clientprofilechangerequestDto.ClientProfileChangeRequestFields.Clear();
                if(entity.ClientProfileChangeRequestFields != null)
                {
                    foreach (ClientProfileChangeRequestFields cpChangeRequestFeild in entity.ClientProfileChangeRequestFields)
                    {
                        ClientProfileChangeRequestFieldsDto cpChangeRequestFeildDto = new ClientProfileChangeRequestFieldsDto();
                        cpChangeRequestFeildDto = Mapper.Map<ClientProfileChangeRequestFields, ClientProfileChangeRequestFieldsDto>(cpChangeRequestFeild);
                        clientprofilechangerequestDto.ClientProfileChangeRequestFields.Add(cpChangeRequestFeildDto);
                    }
                }
                #endregion
            }

            return clientprofilechangerequestDto;  
        }

        public override ClientProfileChangeRequests EntityDtoToEntity(ClientProfileChangeRequestsDto entityDto)
        {
            ClientProfileChangeRequests clientprofilechangerequest = Mapper.Map<ClientProfileChangeRequestsDto, ClientProfileChangeRequests>(entityDto);
            if(entityDto != null)
            {
                #region ClientProfileChangeRequestEmailMessages
                if (entityDto.ClientProfileChangeRequestEmailMessages != null)
                {
                    clientprofilechangerequest.ClientProfileChangeRequestEmailMessages = Mapper.Map<EmailMessagesDto, EmailMessages>(entityDto.ClientProfileChangeRequestEmailMessages);
                    
                    clientprofilechangerequest.ClientProfileChangeRequestEmailMessages.EmailAttachmentes.Clear();
                    if (entityDto.ClientProfileChangeRequestEmailMessages.EmailAttachmentes != null)
                    {
                        foreach (EmailAttachmentDto emailattachmentDto in entityDto.ClientProfileChangeRequestEmailMessages.EmailAttachmentes)
                        {
                            EmailAttachment emailattachment = new EmailAttachment();
                            emailattachment = Mapper.Map<EmailAttachmentDto, EmailAttachment>(emailattachmentDto);
                            clientprofilechangerequest.ClientProfileChangeRequestEmailMessages.EmailAttachmentes.Add(emailattachment);
                        }
                    }
                }
                #endregion 

                #region ClientProfileChangeRequestFields
                
                clientprofilechangerequest.ClientProfileChangeRequestFields.Clear();
                if (entityDto.ClientProfileChangeRequestFields != null)
                {
                    foreach (ClientProfileChangeRequestFieldsDto cpChangeRequestFeildDto in entityDto.ClientProfileChangeRequestFields)
                    {
                        ClientProfileChangeRequestFields cpChangeRequestFeild = new ClientProfileChangeRequestFields();
                        cpChangeRequestFeild = Mapper.Map<ClientProfileChangeRequestFieldsDto, ClientProfileChangeRequestFields>(cpChangeRequestFeildDto);
                        clientprofilechangerequest.ClientProfileChangeRequestFields.Add(cpChangeRequestFeild);
                    }
                }

                #endregion
            }
            return clientprofilechangerequest;         
        }

        protected override string GetEntityInstanceName(ClientProfileChangeRequests clientprofilechangerequest)
        {
            return string.Empty;
        }

        #endregion
    }
}
