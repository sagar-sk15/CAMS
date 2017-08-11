using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Email;
using FluentNHibernate.Mapping;

namespace Cams.Dal.Mappings
{
    public class EmailMessagesMap : ClassMap<EmailMessages>
    {
        public EmailMessagesMap()
        {
            Table("EmailMessages");
            LazyLoad();
            Id(x => x.EmailMessageId).GeneratedBy.Identity().Column("EmailMessageId");
            Map(x => x.MessageFrom).Column("MessageFrom").Length(100).Nullable();
            Map(x => x.MessageTo).Column("MessageTo").Length(100).Nullable();
            Map(x => x.MessageSubject).Column("MessageSubject").Length(100).Nullable();
            Map(x => x.MessageBody).Column("MessageBody").Length(200).Nullable();
            Map(x => x.MessageCC).Column("MessageCC").Length(100).Nullable();
            Map(x => x.MessageImportance).Column("MessageImportance").Length(20).Nullable();
            Map(x => x.MessagePriority).Column("MessagePriority").Length(20).Nullable();
            Map(x => x.MessageFlag).Column("MessageFlag").Length(20).Nullable();
            Map(x => x.CAId).Column("CAId").Not.Nullable();
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

            HasMany(x => x.EmailAttachmentes).KeyColumn("EmailMessageId").Cascade.SaveUpdate()
               .Inverse();
        }
    }
}
