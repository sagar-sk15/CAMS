using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Masters;
using AutoMapper;

namespace Cams.Domain.Entities.Masters
{
    public class CityVillage : EntityBase<int>
    {
        #region Constructor
        public CityVillage() 
        {
            Addresses = new List<Address>();
        }
        #endregion 

        #region properties
        public virtual int CityVillageId { get; set; }
        public virtual string Name { get; set; }
        public virtual Common.CityVillageType CityOrVillage { get; set; }
        public virtual string STDCode { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual Nullable<int> BaseCityVillageId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual District DistrictOfCityVillage { get; set; }

        public virtual IList<Address> Addresses { get; set; }
        #endregion 


        #region Methods
        public override void Validate()
        {
        }

        public static bool IsDirty(CityVillageDto cvNewValues, CityVillageDto cvDBValues) 
        {
            bool isDirty = false;
            if (cvNewValues.CityVillageId == cvDBValues.CityVillageId)
            {
                if (cvNewValues.Name != null)
                {
                    if (cvNewValues.Name != cvDBValues.Name)
                        isDirty = true;
                    else if (cvNewValues.STDCode != cvDBValues.STDCode)
                        isDirty = true;
                    else if (cvNewValues.CityOrVillage != cvDBValues.CityOrVillage)
                        isDirty = true;
                    else if (cvNewValues.DistrictOfCityVillage.DistrictId != cvDBValues.DistrictOfCityVillage.DistrictId)
                        isDirty = true;
                    else if (cvNewValues.DistrictOfCityVillage.StateOfDistrict.StateId != cvDBValues.DistrictOfCityVillage.StateOfDistrict.StateId)
                        isDirty = true;
                }
            }
            return isDirty;
        }

        //public static CityVillageDto  CityVillageToCityVillageDto (CityVillage cityVillage)
        //{
        //    CityVillageDto cityVillageDto = Mapper.Map<CityVillage, CityVillageDto> (cityVillage);
        //    cityVillageDto.DistrictOfCityVillage = District.DistrictToDistrictDto(cityVillage.DistrictOfCityVillage);
        //    return cityVillageDto;
        //}

        //public static CityVillage CityVillageDtoToCityVillage(CityVillageDto cityvillageDto)
        //{
        //    CityVillage cityvillage = Mapper.Map<CityVillageDto, CityVillage>(cityvillageDto);
        //    //cityvillage.DistrictOfCityVillage = District.
        //    return cityvillage;
        //}
        #endregion 

    }
}
