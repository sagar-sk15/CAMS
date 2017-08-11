using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;

namespace Cams.Domain.Entities
{
    public class UserAddress :EntityBase<long>
    {
        #region Constructor
        public UserAddress()
        {
            AddressofUser = new UserProfile();
            UserEmergencyContactPersonAddress = new UserEmergencyContactPerson();
        }
        #endregion 

        #region Properties

        public virtual UserProfile AddressofUser { get; set; }
        public virtual UserEmergencyContactPerson UserEmergencyContactPersonAddress { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual int Country { get; set; } // later on replace with country 
        public virtual int StateandUT { get; set; }        
        public virtual int CityVillage { get; set; }
        public virtual Nullable<int> PIN { get; set; }
        public virtual int ContactNoType { get; set; }
        public virtual int CountryCode { get; set; }
        public virtual int StdCode { get; set; }
        public virtual int ContactNo { get; set; }
        public virtual string Email { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        #endregion 

        #region methods

        protected override void Validate()
        {
            return;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = hashCode ^ AddressofUser.User.UserId.GetHashCode() ^ UserEmergencyContactPersonAddress.ContactPersonofUser.User.UserId.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as UserAddress;
            if (toCompare == null)
            {
                return false;
            }
            return (this.GetHashCode() != toCompare.GetHashCode());
        } 
        #endregion
    }
}
