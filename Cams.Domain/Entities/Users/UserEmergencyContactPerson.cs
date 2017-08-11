using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Users
{
    public class UserEmergencyContactPerson : EntityBase<long>
    {
        #region Constructor
        public UserEmergencyContactPerson()
        {
            //ContactPersonofUser = new UserProfile();
            //ContactPersonAddress = new Address();
            //ContactPersonRelationshipWithUser = new Relationship();
            Contacts = new List<ContactDetails>();
        }
        #endregion

        #region Properties
        public virtual long UserEmergencyContactPersonId { get; set; }
        public virtual UserProfile ContactPersonOfUser { get; set; }
        public virtual Address ContactPersonAddress { get; set; }
        public virtual Relationship ContactPersonRelationshipWithUser { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<ContactDetails> Contacts { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        #endregion 

        #region methods

        public override void Validate()
        {
            return;
        }

        //public override int GetHashCode()
        //{
        //    int hashCode = 0;
        //    hashCode = hashCode ^ ContactPersonOfUser.UserId.GetHashCode() ^ ContactPersonAddress.AddressId.GetHashCode() ^ ContactPersonRelationshipWithUser.RelationshipId.GetHashCode();
        //    return hashCode;
        //}

        //public override bool Equals(object obj)
        //{
        //    var toCompare = obj as UserEmergencyContactPerson;
        //    if (toCompare == null)
        //    {
        //        return false;
        //    }
        //    return (this.GetHashCode() != toCompare.GetHashCode());
        //} 
        #endregion
    }
}
