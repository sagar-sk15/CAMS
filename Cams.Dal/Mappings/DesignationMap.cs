using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.Users;

namespace Cams.Dal.Mappings
{
    public class DesignationMap : ClassMap<Designation>
    {
        public DesignationMap()
        {
            Table("Designations");
            LazyLoad();
            Id(x => x.DesignationId).GeneratedBy.Identity().Column("DesignationId");
            Map(x => x.DesignationName).Column("DesignationName").Length(255).Not.Nullable();
            Map(x => x.CAId).Column("CAId").Nullable(); 
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

            HasMany(x => x.UsersWithDesignation).KeyColumn("DesignationId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.ClientPrimaryContactPersonWithDesignation).KeyColumn("DesignationId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.ClientPartnerWithDesignation).KeyColumn("DesignationId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.ClientPartnerBankContactPersonWithDesignation).KeyColumn("DesignationId")
                .Cascade.SaveUpdate()
                .Inverse();
        }
    }
}
