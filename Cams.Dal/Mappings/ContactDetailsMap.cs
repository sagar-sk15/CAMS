using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Cams.Domain.Entities;

namespace Cams.Dal.Mappings
{
    public class ContactDetailsMap :ClassMap<ContactDetails>
    {
        public ContactDetailsMap()
        {
            Table("ContactDetails");
            LazyLoad();
            Id(x => x.ContactDetailsId).GeneratedBy.Identity().Column("ContactDetailsId");
            Map(x => x.ContactNo).Column("ContactNo").Not.Nullable().Length(15);
            Map(x => x.ContactNoType).Column("ContactNoType");
            Map(x => x.CountryCallingCode).Column("CountryCallingCode").Not.Nullable().Length(5);
            Map(x => x.STDCode).Column("STDCode").Nullable().Length(10);
            
            HasManyToMany(x => x.ContactDetailsOfUser)
                .Table("UserContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("UserProfileId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfAPMC)
              .Table("APMCContacts")
              .ParentKeyColumn("ContactDetailsId")
              .ChildKeyColumn("APMCId")
              .Cascade.SaveUpdate()
              .Inverse();
            HasManyToMany(x => x.ContactDetailsOfEmergencyContact)
                .Table("UserEmergencyContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("UserEmergencyContactPersonId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfBankBranch)
                .Table("BankBranchContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("BranchId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClient)
                .Table("ClientContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("CAId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClientPrimaryContactPerson)
                .Table("ClientPrimaryContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("CAPrimaryContactPersonId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClientPartners)
                .Table("ClientPartnerContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("PartnerId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClientPartnerGuardian)
                .Table("ClientPartnerGuardianContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("ClientPartnerGuardianId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClientPartnerNominee)
                .Table("ClientPartnerNomineeContacts")
                .ParentKeyColumn("ContactDetailsId")
                .ChildKeyColumn("ClientPartnerNomineeId")
                .Cascade.SaveUpdate()
                .Inverse();
            HasManyToMany(x => x.ContactDetailsOfClientPartnerBankContactPerson)
              .Table("ClientPartnerBankContactPersonContacts")
              .ParentKeyColumn("ContactDetailsId")
              .ChildKeyColumn("ClientPartnerBankId")
              .Cascade.SaveUpdate();
        }
    }
}
