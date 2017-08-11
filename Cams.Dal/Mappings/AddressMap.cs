using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities;

namespace Cams.Dal.Mappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Addresses");
            LazyLoad();
            Id(x => x.AddressId).GeneratedBy.Identity().Column("AddressId");//.UnsavedValue(-1); 
            Map(x => x.AddressLine1).Column("AddressLine1").Length(255);
            Map(x => x.AddressLine2).Column("AddressLine2").Length(255);
            Map(x => x.PIN).Column("PIN").Length(10);

            References(x => x.CityVillage).Column("CityVillageId").Nullable();

            // SUJATA : if ever any developer needs the following mapping to be mentioned 
            // just uncomment the following lines and use as it is without the foreign key

            //HasOne(x => x.AddressOfUser).PropertyRef(r=>r.UserAddress).Cascade.SaveUpdate();
            //HasOne(x => x.AddressOfEmergencyContact).PropertyRef(r=>r.ContactPersonAddress).Cascade.SaveUpdate();
            //HasOne(x => x.AddressofAPMC).PropertyRef(r=>r.Address) .Cascade.SaveUpdate();
            //HasOne(x => x.AddressofBankBranch).PropertyRef(r=>r.BranchAddress).Cascade.SaveUpdate();

            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate).Column("ModifiedDate").CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime");
        }
    }
}
