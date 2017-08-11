using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Email
{
    public class EmailMessagesDto : DtoBase
    {
        #region Constructor
        public EmailMessagesDto()  
        {
            EmailAttachmentes = new List<EmailAttachmentDto>();
        }
        #endregion

        #region Properties
        public virtual int EmailMessageId { get; set; }
        public virtual string MessageFrom { get; set; }
        public virtual string MessageTo   { get; set; }
        public virtual string MessageSubject { get; set; }
        public virtual string MessageBody{ get; set; }
        public virtual string MessageCC { get; set; }
        public virtual Common.EmailMessageImportance MessageImportance { get; set; }
        public virtual Common.EmailMessagePriority MessagePriority { get; set; }
        public virtual Common.EmailMessageFlag MessageFlag { get; set; }
        public virtual int CAId { get; set; }
        public virtual int RetryCount { get; set; }
        public virtual bool IsFailedToSend { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual IList<EmailAttachmentDto> EmailAttachmentes { get; set; }
        #endregion
    }
}
