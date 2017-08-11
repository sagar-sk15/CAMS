using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Web.MVCRazor.StatesMasterServiceReference;
using Cams.Web.MVCRazor.DistrictServiceReference;
using Cams.Web.MVCRazor.CityVillageServiceReference;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class StateDistrictCityControlNamesModel
    {
        #region Properties
        public string ControlNamePrefix { get; set; }
        public string StateComboName{ get; set; }
        public string StateLabelName { get; set; }
        public string DistrictComboName{ get; set; }
        public string DistrictCallBackPanelName { get; set; }
        public string PlacesComboName { get; set; }
        public string PlacesLabelName { get; set; }
        public string PlacesCallBackPanelName { get; set; }
        public string AddPlacesPopupName { get; set; }
        public string AddPlacesPopupCallBackPanelName { get; set; }
        public string AddPlacesPopupCountryTextBoxName { get; set; }
        public string AddPlacesPopupStateTextBoxName { get; set; }
        public string AddPlacesPopupDistrictTextBoxName { get; set; }
        public string AddPlacesPopupCityVillageRadioButtonName { get; set; }
        public string AddPlacesPopupPlaceTextBoxName { get; set; }
        public string AddPlacesPopupCountryCodeTextBoxName { get; set; }
        public string AddPlacesPopupSTDCodeTextBoxName { get; set; }
        public string AddPlacesPopupSaveButtonName{ get; set; }
        public string LeftLabelsClassName { get; set; }
        public System.Web.UI.WebControls.Unit DropDownWidth { get; set; }
        public string HiddenFieldForCityVillage { get; set; }
        public string HiddenFieldForState { get; set; }
        public string HiddenFieldForDistrict { get; set; }
        public int HiddenFieldForCityVillageValue { get; set; }
        public int HiddenFieldForStateValue { get; set; }
        public int HiddenFieldForDistrictValue { get; set; }
        #endregion

        #region Constructor
        public StateDistrictCityControlNamesModel(string prefixControlNamesWith)
        {
            ControlNamePrefix = prefixControlNamesWith;
            StateComboName = prefixControlNamesWith + "cmbStates";
            DistrictComboName = prefixControlNamesWith + "cmbDistricts";
            DistrictCallBackPanelName = prefixControlNamesWith + "cbpDistricts";
            PlacesCallBackPanelName = prefixControlNamesWith + "cbpPlaces";
            PlacesComboName = prefixControlNamesWith + "cmbCityVillage";
            AddPlacesPopupName = prefixControlNamesWith+ "AddCityVillageModal";
            AddPlacesPopupCallBackPanelName = prefixControlNamesWith + "callbackpanelAddCity";
            AddPlacesPopupCountryTextBoxName = prefixControlNamesWith + "ppCountry";
            AddPlacesPopupStateTextBoxName = prefixControlNamesWith+ "ppStateUT";
            AddPlacesPopupDistrictTextBoxName = prefixControlNamesWith + "ppDistricts";
            AddPlacesPopupCityVillageRadioButtonName = prefixControlNamesWith+"ppCityVillage";
            AddPlacesPopupPlaceTextBoxName = prefixControlNamesWith + "ppPlace";
            AddPlacesPopupCountryCodeTextBoxName = prefixControlNamesWith + "ppCountryCode";
            AddPlacesPopupSTDCodeTextBoxName = prefixControlNamesWith + "ppSTDCode";
            AddPlacesPopupSaveButtonName = prefixControlNamesWith + "ppAddCitySavebutton";
            StateLabelName  = prefixControlNamesWith + "lblState";
            PlacesLabelName = prefixControlNamesWith + "lblPlaces";
            LeftLabelsClassName = "width110";
            DropDownWidth = 200;
            HiddenFieldForCityVillage = prefixControlNamesWith + "hdnCityVillage";
            HiddenFieldForState = prefixControlNamesWith + "hdnState";
            HiddenFieldForDistrict= prefixControlNamesWith + "hdnDistrict";
            HiddenFieldForCityVillageValue = 0;
            HiddenFieldForStateValue = 0;
            HiddenFieldForDistrictValue = 0;
        }
        #endregion

        #region Static Methods
        public static List<StateDto> GetStatesFromDB()
        {
            StatesMasterServiceReference.IStateService client = new StateServiceClient();
            Query query = new Query();

            OrderByClause orderByRegionType = new OrderByClause();
            orderByRegionType.PropertyName = Constants.REGIONTYPE;
            orderByRegionType.Desc = true;
            query.AddOrderByField(orderByRegionType);

            OrderByClause orderByRegionName = new OrderByClause();
            orderByRegionName.PropertyName = Constants.REGIONNAME;
            orderByRegionName.Desc = false;
            query.AddOrderByField(orderByRegionName);

            var stateDtos = client.FindAll();
            List<StateDto> stateList = stateDtos.Entities.ToList();
            stateList.Insert(0, new StateDto
            {
                RegionName = "[Select]",
                RegionType = "State/UT",
                StateId = 0
            });

            return stateList;
        }

        public static List<DistrictDto> GetDistricts(int state)
        {
            Query query = new Query();
            Criterion criteriaState = new Criterion("st.StateId", state, CriteriaOperator.Equal);
            query.Add(criteriaState);
            query.AddAlias(new Alias("st", "StateOfDistrict"));
            DistrictServiceReference.IDistrictService client = new DistrictServiceClient();
            var districts = client.FindByQuery(query);
            List<DistrictDto> districtList = new List<DistrictDto>();
            districtList = districts.Entities.ToList();
            districtList.Insert(0, new DistrictDto
            {
                DistrictId = 0,
                DistrictName = "[Select]"
            });
            return districtList;
        }

        public static List<CityVillageDto> GetPlaces(int district)
        {
            Query query = new Query();
            Criterion criteriaState = new Criterion("st.DistrictId" , district, CriteriaOperator.Equal);
            query.Add(criteriaState);
            query.AddAlias(new Alias("st", "DistrictOfCityVillage"));

            CityVillageServiceReference.ICityVillageService client = new CityVillageServiceClient();
            var cityVillage = client.FindByQuery(query);
            List<CityVillageDto> cityVillageList = new List<CityVillageDto>();
            cityVillageList = cityVillage.Entities.ToList();
            cityVillageList.Insert(0, new CityVillageDto
            {
                CityVillageId = 0,
                CityOrVillage = CityVillageType.City,
                Name = "[Select]"
            });
            return cityVillageList;
        }
        #endregion

    }
}