using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.DesignationServiceReference;
using System.Web.Mvc;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class DesignationModel
    {
        public List<DesignationDto> designations;
        public string Prefix { get; set; }
        public string CBPCtrlUserDesignationList { get; set; }
        public string DDLDesignations { get; set; }
        public int SelectedId { get; set; }
        public string CBPCtrlPopupAddDesignation { get; set; }
        public string PopupctrlAddDesignation { get; set; }
        public string HiddenTextboxName { get; set; }
        public string ppUserDesignation { get; set; }
        public string userDesignationSavebutton { get; set; }
        public string HiddenAddedValue { get; set; }
        public string HiddenAddedValueTextBoxName { get; set; }

        public DesignationModel(string prefix)
        {
            Prefix = prefix;
            designations = GetDesignations();
            CBPCtrlUserDesignationList = Prefix + "CBPCtrlUserDesignationList";
            DDLDesignations = Prefix + "DDLDesignations";
            CBPCtrlPopupAddDesignation = Prefix + "CBPCtrlPopupAddDesignation";
            PopupctrlAddDesignation = Prefix + "PopupctrlAddDesignation";
            HiddenTextboxName = prefix + "SelectedDesignation";
            ppUserDesignation = Prefix + "ppUserDesignation";
            userDesignationSavebutton = Prefix + "userDesignationSavebutton";
            HiddenAddedValueTextBoxName = Prefix + "HiddenAddedValueTextBox";
            SelectedId = 0;
        }

        public static List<DesignationDto> GetDesignations()
        {
            DesignationServiceReference.DesignationServiceClient Designationclient = new DesignationServiceClient();
            List<DesignationDto> Designationdto = Designationclient.FindAll().Entities.ToList();
            Designationclient.Close();
            Designationdto.Insert(0, new DesignationDto() { DesignationId = 0, DesignationName = "[Select]" });
            return Designationdto;
        }        
    }
}