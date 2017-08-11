using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities;

namespace Cams.Dal.Mappings
{
    public class UserAddressMap : ClassMap<UserAddress>
    {
        public UserAddressMap()
        {
            Table("UsersAddress");
            LazyLoad();
            CompositeId().KeyReference(x => x.AddressofUser, "UserId")
                .KeyReference(x => x.UserEmergencyContactPersonAddress, "UserId");
            Map(x => x.AddressLine1).Column("AddressLine1").Length(255);
            Map(x => x.AddressLine2).Column("AddressLine2").Length(255);
            Map(x => x.Country).Column("Country");
            Map(x => x.StateandUT).Column("StateandUT");            
            Map(x => x.CityVillage).Column("CityVillage");
            Map(x => x.PIN).Column("PIN");
            Map(x => x.ContactNoType).Column("ContactNoType");
            Map(x => x.CountryCode).Column("CountryCode");
            Map(x => x.StdCode).Column("StdCode");
            Map(x => x.ContactNo).Column("ContactNo");
            Map(x => x.Email).Column("Email");
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate).Column("ModifiedDate");
            References(x => x.AddressofUser).Column("UserId").Nullable().Cascade.SaveUpdate();
            References(x => x.UserEmergencyContactPersonAddress).Column("UserId").Nullable().Cascade.SaveUpdate();
        }
    }
}
