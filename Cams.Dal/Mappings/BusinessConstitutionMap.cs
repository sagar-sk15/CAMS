using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Dal.Mappings
{
    public class BusinessConstitutionMap : ClassMap<BusinessConstitution>
    {
        public BusinessConstitutionMap()
        {
            Table("BusinessConstitutions");
            LazyLoad();
            Id(x => x.BusinessConstitutionId).GeneratedBy.Identity().Column("BusinessConstitutionId");
            Map(x => x.BusinessConstitutionName).Column("BusinessConstitutionName").Not.Nullable().Length(50);
            Map(x => x.IsActive).Column("IsActive").Not.Nullable();
            //HasMany(x => x.BusinessConstitutionOfClients).KeyColumn("BusinessConstitutionId")
            //    .Cascade.SaveUpdate()
            //    .Inverse(); 
        }
    }
}
