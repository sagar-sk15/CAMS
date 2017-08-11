using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using System.Web.Mvc;
using Cams.Common.Dto.Address;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class AddressReadOnlyViewModel
    {
        #region Constructor
        public AddressReadOnlyViewModel(string prefix)
        {
            Prefix = prefix;
            NoOfCharsPerLine = 30;
            // Apply multiple classes seperated with a space
            LeftLabelsClassName = "width110";
            ValueLabelsClassName = "noIndentUL non-editable-txt";
            OuterULClassName = "reset onecolfield";
            TextForAddressLabelOnLeft = "Address";
            Address = new AddressDto
            {
                CityVillage = new Common.Dto.Masters.CityVillageDto
                {
                    DistrictOfCityVillage = new Common.Dto.Masters.DistrictDto
                    {
                        StateOfDistrict = new Common.Dto.Masters.StateDto { 
                            StateInCountry = new Common.Dto.Masters.CountryDto()
                        }
                    }
                }
            };
        }
        #endregion

        #region Properties
        public string Prefix { get; set; }
        public int NoOfCharsPerLine{ get; set; }
        public string LeftLabelsClassName { get; set; }
        public string ValueLabelsClassName { get; set; }
        public string OuterULClassName { get; set; }
        public string TextForAddressLabelOnLeft{ get; set; }    
        public AddressDto Address;
        #endregion

        #region 

        public void SetAddress(AddressDto address)
        {            
            Address = Helper.GetInitializedAddressObject(address);
        }

        #endregion

    }
}