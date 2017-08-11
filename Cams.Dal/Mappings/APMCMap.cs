using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Masters;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class APMCMap : ClassMap<APMC>
    {

        public APMCMap()
        {
            Table("APMC");
            LazyLoad();
            Id(x => x.APMCId).GeneratedBy.Identity().Column("APMCId");
            References(x => x.Address).Column("AddressId").Cascade.SaveUpdate(); ;
            
            Map(x => x.Name).Column("Name").Not.Nullable().Length(80);
            Map(x => x.Email1).Column("Email1").Nullable().Length(50);
            Map(x => x.Email2).Column("Email2").Nullable().Length(50);
            Map(x => x.Website).Column("Website").Nullable().Length(100);
            Map(x => x.Status).Column("Status").Not.Nullable().Length(10);
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate).Column("ModifiedDate").CustomType("DateTime")
               .Access.Property()
               .Generated.Always()
               .Default("getdate()")
               .CustomSqlType("datetime");
            //HasMany(x => x.APMCOfClients).KeyColumn("APMCId")
            //    .Cascade.SaveUpdate()
            //    .Inverse();
            HasManyToMany(x => x.ContactNos)
              .Table("APMCContacts")
              .ParentKeyColumn("APMCId").
              ChildKeyColumn("ContactDetailsId")
              .Cascade.SaveUpdate();
        }
    }
}
