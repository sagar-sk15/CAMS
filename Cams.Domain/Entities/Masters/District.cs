using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Masters;
using AutoMapper;

namespace Cams.Domain.Entities.Masters
{
    public class District : EntityBase<int>
    {
        #region Constructor
        public District() 
        {
            CitiesOrVillages = new List<CityVillage>();
        }
        #endregion

        #region Properties
        public virtual int DistrictId { get; set; }
        public virtual string DistrictName { get; set; }
        public virtual State StateOfDistrict { get; set; }
        public virtual IList<CityVillage> CitiesOrVillages { get; set; }
        #endregion 


        #region methods
        public override void Validate()
        {
        }
               
        #endregion 
    }
}
