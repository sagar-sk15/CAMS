using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Dal.Mappings
{
    public class BankBranchMap:ClassMap<BankBranch>
    {
        public BankBranchMap()
        {
            Table("BankBranches");
            LazyLoad();
            Id(x => x.BranchId).GeneratedBy.Identity().Column("BranchId");
            Map(x => x.Name).Column("Name").Not.Nullable().Length(255);
            Map(x => x.CAId).Column("CAId").Nullable();
            Map(x => x.IFSCCode).Column("IFSCCode").Length(50);
            Map(x => x.MICRCode).Column("MICRCode").Length(50);
            Map(x => x.SWIFTCode).Column("SWIFTCode").Length(50);
            Map(x => x.Email1).Column("Email1").Length(100);
            Map(x => x.Email2).Column("Email2").Length(100);
            Map(x => x.FullDayTimeFrom).Column("FullDayTimeFrom").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.FullDayTimeTo).Column("FullDayTimeTo").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.HalfDayTimeFrom).Column("HalfDayTimeFrom").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.HalfDayTimeTo).Column("HalfDayTimeTo").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.FullDayBreakFrom).Column("FullDayBreakFrom").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.FullDayBreakTo).Column("FullDayBreakTo").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.HalfDayBreakFrom).Column("HalfDayBreakFrom").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.HalfDayBreakTo).Column("HalfDayBreakTo").Nullable().CustomType("TimeAsTimeSpan");
            Map(x => x.BaseBranchId).Column("BaseBranchId").Nullable();
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


            References(x => x.BranchOfBank).Column("BankId").Cascade.SaveUpdate();
            References(x => x.BranchAddress).Column("AddressId").Cascade.SaveUpdate();
            References(x => x.WeeklyHalfDay).Column("WeeklyHalfDayId").Cascade.SaveUpdate();
            References(x => x.WeeklyOffDay).Column("WeeklyOffDayId").Cascade.SaveUpdate();
            HasManyToMany(x => x.BranchContactNos)
                .Table("BankBranchContacts")
                .ParentKeyColumn("BranchId")
                .ChildKeyColumn("ContactDetailsId")
                .Cascade.SaveUpdate();            
            HasMany(x => x.BranchOfClientSubscriptionPayment).KeyColumn("BranchId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasMany(x => x.BranchOfClientPartner).KeyColumn("BranchId")
                .Cascade.SaveUpdate()
                .Inverse();
        }
    }
}
