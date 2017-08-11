using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class BankMap:ClassMap<Bank>
    {
        public BankMap()
        {
            Table("Banks");
            LazyLoad();
            Id(x => x.BankId).GeneratedBy.Identity().Column("BankId");
            Map(x => x.BankName).Column("BankName").Length(255).Not.Nullable();
            Map(x => x.Alias).Column("Alias").Length(15);
            Map(x => x.CAId).Column("CAId").Nullable();
            Map(x => x.URL).Column("URL").Length(100);
            Map(x => x.BaseBankId).Column("BaseBankId").Nullable();
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreatedDate)
                .Column("CreatedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Insert()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModifiedDate)
                .Column("ModifiedDate")
                .CustomType("DateTime")
                .Access.Property()
                .Generated.Always()
                .Default("getdate()")
                .CustomSqlType("datetime")
                .Nullable();
            HasMany(x => x.Branches).KeyColumn("BankId").Inverse().Cascade.SaveUpdate(); 
        }
    }
}
