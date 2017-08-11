using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Email
{
    public class EmailAttachment : EntityBase<int> 
    {
        #region Constructor
        public EmailAttachment()  
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

        public virtual EmailMessages EmailMessages { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}
