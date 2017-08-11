using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Email
{
    public class EmailAttachmentDto : DtoBase
    {
        #region Constructor
        public EmailAttachmentDto()  
        {
            
        }
        #endregion

        #region Properties
        public virtual int EmailAttachmentId { get; set; } 
        public virtual string Attachmentname { get; set; }
        public virtual string AttachmentLocation { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual EmailMessagesDto EmailMessages { get; set; }
        #endregion
    }
}
