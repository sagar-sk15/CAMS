using Cams.Domain.Entities.Masters;
using FluentNHibernate.Mapping;


namespace Cams.Dal.Mappings
{
    public class CountryMap : ClassMap<Country>
    {

        public CountryMap()
        {
            Table("Country");
            LazyLoad();
            Id(x => x.CountryId).GeneratedBy.Identity().Column("CountryId");
            Map(x => x.CountryName).Column("CountryName").Not.Nullable().Length(50);
            Map(x => x.CallingCode).Column("CallingCode").Not.Nullable().Length(10);
            Map(x => x.AgeStd).Column("AgeStd").Not.Nullable();
            Map(x => x.Currency).Column("Currency").Not.Nullable().Length(20);
            Map(x => x.CurrencyCode).Column("CurrencyCode").Not.Nullable().Length(10);
            Map(x => x.Symbol).Column("Symbol").Not.Nullable().Length(10);
            Map(x => x.TimeZone).Column("TimeZone").Not.Nullable();
            Map(x => x.FinancialYearStart).Column("FinancialYearStart").Not.Nullable().Length(50);
            Map(x => x.FinancialYearEnd).Column("FinancialYearEnd").Not.Nullable().Length(50);
            Map(x => x.Status).Column("Status").Not.Nullable().Length(10);
            HasMany(x => x.States).KeyColumn("CountryId");
                //.Cascade.SaveUpdate()
                //.Inverse();
        }
    }
}
