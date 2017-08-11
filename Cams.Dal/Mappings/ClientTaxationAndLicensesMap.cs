using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class ClientTaxationAndLicensesMap : ClassMap<ClientTaxationAndLicenses>
    {
        public ClientTaxationAndLicensesMap()
        {
            Table("ClientTaxationAndLicensesDetails");
            LazyLoad();
            Id(x => x.ClientTaxationAndLicensesId).GeneratedBy.Identity().Column("ClientTaxationAndLicensesId");
            Map(x => x.TaxName).Column("TaxName").Nullable().Length(100);
            Map(x => x.LicenseNo).Column("LicenseNo").Nullable().Length(30);
            Map(x => x.IsWithEffectFromDateApplicable).Column("IsWithEffectFromDateApplicable").Not.Nullable();
            Map(x => x.IsRenewalDateApplicable).Column("IsRenewalDateApplicable").Not.Nullable();
            Map(x => x.WithEffectFromDate).Column("WithEffectFromDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.RenewalDate).Column("RenewalDate")
                .Nullable()
                .CustomType("DateTime")
                //.Default("getdate()")
               .CustomSqlType("datetime");
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");
            Map(x => x.ModifiedBy).Column("ModifiedBy").Not.Nullable();
            Map(x => x.ModifiedDate).Column("ModifiedDate").Not.Nullable().CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                 .CustomType("DateTime")
                .Default("getdate()")
                .CustomSqlType("datetime");

            HasManyToMany(x => x.TaxationAndLicensesofClient)
            .Table("ClientTaxationAndLicenses")
            .ParentKeyColumn("ClientTaxationAndLicensesId")
            .ChildKeyColumn("CAId")
            .Cascade.SaveUpdate();
        }
    }
}
