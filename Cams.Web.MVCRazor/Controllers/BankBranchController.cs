using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common.Dto.ClientMasters;
using Cams.Web.MVCRazor.Models.Shared;
using Cams.Common.Dto.User;
using Cams.Common;
using Cams.Common.Querying;
using DevExpress.Web.Mvc;
using Cams.Common.Dto.Masters;
using Cams.Web.MVCRazor.BankBranchServiceReference;
using Cams.Web.MVCRazor.BankServiceReference;
using Cams.Common.Message;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.UI.WebControls;
using Cams.Common.Dto;
using System.Globalization;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class BankBranchController : CommonController
    {
        public static string FormMode;
        public static Nullable<int> Id;
        public static int Bankid;
        BankBranchServiceReference.BankBranchServiceClient Branchclient = null;
        BankServiceReference.BankServiceClient Bankclient = null;

        [CamsAuthorize(Roles = Constants.BANKNBRANCH, Permissions = CamsAuthorizeAttribute.RolePermission.Add)] 
        public ActionResult AddBankBranchIndex()
        {
            BankBranchModel bankBranchModel = new BankBranchModel();
            Bankid = 0;
            Id = null;
            string mode = Request.QueryString["mode"] != null ? Request.QueryString["mode"].ToString() : string.Empty;
            var BranchId = Request.QueryString["branchid"] != null ? Request.QueryString["branchid"] : null;
            Bankid = Request.QueryString["bankid"] != null ? Convert.ToInt32(Request.QueryString["bankid"]) : 0;
            
            try
            {
                Branchclient = new BankBranchServiceClient();
                if (mode == "edit")
                {
                    BankBranchDto BBDto = Branchclient.GetById(BranchId != null ? Convert.ToInt32(BranchId) : 0);
                    FormMode = mode;
                    Id = BBDto.BranchId;
                    bankBranchModel.BranchId = BBDto.BranchId;
                    bankBranchModel.BaseBranchId = BBDto.BaseBranchId;
                    bankBranchModel.BranchAddress = BBDto.BranchAddress;
                    bankBranchModel.BranchContactNos = BBDto.BranchContactNos;
                    bankBranchModel.BranchOfBank = BBDto.BranchOfBank;
                    Bankid = BBDto.BranchOfBank.BankId;
                    bankBranchModel.CAId = BBDto.CAId;
                    bankBranchModel.Email1 = BBDto.Email1;
                    bankBranchModel.Email2 = BBDto.Email2;

                    bankBranchModel.FullDayBreakFrom = BBDto.FullDayBreakFrom;
                    bankBranchModel.FullDayBreakTo = BBDto.FullDayBreakTo;
                    bankBranchModel.FullDayTimeFrom = BBDto.FullDayTimeFrom;
                    bankBranchModel.FullDayTimeTo = BBDto.FullDayTimeTo;
                    bankBranchModel.HalfDayBreakFrom = BBDto.HalfDayBreakFrom;
                    bankBranchModel.HalfDayBreakTo = BBDto.HalfDayBreakTo;
                    bankBranchModel.HalfDayTimeFrom = BBDto.HalfDayTimeFrom;
                    bankBranchModel.HalfDayTimeTo = BBDto.HalfDayTimeTo;

                    bankBranchModel.IFSCCode = BBDto.IFSCCode;
                    bankBranchModel.MICRCode = BBDto.MICRCode;
                    bankBranchModel.Name = BBDto.Name;
                    bankBranchModel.SWIFTCode = BBDto.SWIFTCode;
                    bankBranchModel.WeeklyHalfDay = BBDto.WeeklyHalfDay;
                    bankBranchModel.WeeklyOffDay = BBDto.WeeklyOffDay;
                    bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForCityVillageValue = BBDto.BranchAddress.CityVillage.CityVillageId;
                    bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForDistrictValue= BBDto.BranchAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                    bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForStateValue = BBDto.BranchAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;

                    if(bankBranchModel.BranchContactNos==null || bankBranchModel.BranchContactNos.Count==0)
                        bankBranchModel.BranchContactNos = new List<ContactDetailsDto>();
                }
                SetBanksListToViewData();
                ViewData["SelectedBank"] = bankBranchModel.BranchOfBank != null ? ((List<BankDto>)ViewData["BankList"]).FindIndex(FindBank) : 0;
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (Branchclient != null)
                    Branchclient.Close();
            }
            
            return View("AckAndClientCommonViews\\AddBankBranch", bankBranchModel);
        }

        [CamsAuthorize(Roles = Constants.BANKNBRANCH, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]        
        public ActionResult AddBankBranch([ModelBinder(typeof(DevExpressEditorsBinder))]BankBranchModel bankBranchModel)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            

            BankBranchDto bankBranchDto = new BankBranchDto();

            try
            {

                Bankid = 0;
                if(EditorExtension.GetValue<object>("cmbBank") != null) 
                {
                    Bankid = EditorExtension.GetValue<int>("cmbBank");
                }
                bankBranchModel.BranchOfBank = new BankDto { BankId = Bankid };
                if (bankBranchModel.BranchAddress != null)
                {
                    if (ComboBoxExtension.GetValue<object>("cmbCityVillage") != null)
                    {
                        int cityVillageID = ComboBoxExtension.GetValue<int>("cmbCityVillage");

                        bankBranchModel.BranchAddress.CityVillage = new CityVillageDto
                        {
                            CityVillageId = cityVillageID,
                        };
                    }
                }
                
                if (DateEditExtension.GetValue<object>("teFullDayFrom") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teFullDayFrom");
                    bankBranchModel.FullDayTimeFrom = bankBranchDto.FullDayTimeFrom = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teFullDayTo") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teFullDayTo");
                    bankBranchModel.FullDayTimeTo = bankBranchDto.FullDayTimeTo = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teFullDayBreakFrom") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teFullDayBreakFrom");
                    bankBranchModel.FullDayBreakFrom = bankBranchDto.FullDayBreakFrom = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teFullDayBreakTo") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teFullDayBreakTo");
                    bankBranchModel.FullDayBreakTo = bankBranchDto.FullDayBreakTo = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teHalfDayFrom") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teHalfDayFrom");
                    bankBranchModel.HalfDayTimeFrom = bankBranchDto.HalfDayTimeFrom = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teHalfDayTo") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teHalfDayTo");
                    bankBranchModel.HalfDayTimeTo = bankBranchDto.HalfDayTimeTo = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teHalfDayBreakFrom") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teHalfDayBreakFrom");
                    bankBranchModel.HalfDayBreakFrom = bankBranchDto.HalfDayBreakFrom = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }
                if (DateEditExtension.GetValue<object>("teHalfDayBreakTo") != null)
                {
                    DateTime dt = DateEditExtension.GetValue<DateTime>("teHalfDayBreakTo");
                    bankBranchModel.HalfDayBreakTo = bankBranchDto.HalfDayBreakTo = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                }

                bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForCityVillageValue =
                    !String.IsNullOrEmpty(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.PlacesComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.PlacesComboName + "_VI"]) : 0;
                bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForDistrictValue =
                    !String.IsNullOrEmpty(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.DistrictComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.DistrictComboName + "_VI"]) : 0;
                bankBranchModel.StateDistrictPlacesControlNames.HiddenFieldForStateValue =
                    !String.IsNullOrEmpty(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.StateComboName + "_VI"]) ?
                    Convert.ToInt32(Request.Params[bankBranchModel.StateDistrictPlacesControlNames.StateComboName + "_VI"]) : 0;

                CheckForValidation(bankBranchModel);

                if (ModelState.IsValid)
                {
                    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];

                    if (bankBranchModel.BranchContactNos != null)
                    {
                        IList<ContactDetailsDto> NullContacts = bankBranchModel.BranchContactNos.Where(x => x.ContactNo == null).ToList();
                        if (NullContacts != null)
                        {
                            foreach (ContactDetailsDto contact in NullContacts)
                            {
                                bankBranchModel.BranchContactNos.Remove(contact);
                            }
                        }
                    }
                    bankBranchDto.BranchContactNos = bankBranchModel.BranchContactNos;
                    bankBranchDto.BranchAddress = bankBranchModel.BranchAddress;
                    bankBranchDto.BranchOfBank = bankBranchModel.BranchOfBank;

                    bankBranchDto.CAId = Helper.GetCAIdOfUser(currentUserDto);
                    bankBranchDto.Name = bankBranchModel.Name;
                    bankBranchDto.Email1 = bankBranchModel.Email1;
                    bankBranchDto.Email2 = bankBranchModel.Email2;

                    bankBranchDto.SWIFTCode = bankBranchModel.SWIFTCode;
                    bankBranchDto.MICRCode = bankBranchModel.MICRCode;
                    bankBranchDto.IFSCCode = bankBranchModel.IFSCCode;


                    bankBranchDto.ModifiedBy = currentUserDto.UserId;
                    bankBranchDto.BranchOfBank.CreatedBy = currentUserDto.UserId;
                    bankBranchDto.BranchOfBank.ModifiedBy = currentUserDto.UserId;

                    
                    if (bankBranchDto.BranchContactNos != null && bankBranchDto.BranchContactNos.Count == 1)
                    {
                        if (bankBranchDto.BranchContactNos[0].ContactNo == null)
                        {
                            bankBranchDto.BranchContactNos.RemoveAt(0);
                        }
                    }

                    if (bankBranchModel.WeeklyOffDay != null)
                    {
                        bankBranchDto.WeeklyOffDay = new Common.Dto.WeeklyOffDaysDto
                        {
                            WeeklyOffDayId = bankBranchModel.WeeklyOffDay.WeeklyOffDayId,
                            IsSunday = bankBranchModel.WeeklyOffDay.IsSunday,
                            IsMonday = bankBranchModel.WeeklyOffDay.IsMonday,
                            IsTuesday = bankBranchModel.WeeklyOffDay.IsTuesday,
                            IsWednesday = bankBranchModel.WeeklyOffDay.IsWednesday,
                            IsThursday = bankBranchModel.WeeklyOffDay.IsThursday,
                            IsFriday = bankBranchModel.WeeklyOffDay.IsFriday,
                            IsSaturday = bankBranchModel.WeeklyOffDay.IsSaturday
                        };
                    }

                    if (bankBranchModel.WeeklyHalfDay != null)
                    {
                        bankBranchDto.WeeklyHalfDay = new Common.Dto.WeeklyHalfDayDto
                        {
                            WeeklyHalfDayId = bankBranchModel.WeeklyHalfDay.WeeklyHalfDayId,
                            IsSunday = bankBranchModel.WeeklyHalfDay.IsSunday,
                            IsMonday = bankBranchModel.WeeklyHalfDay.IsMonday,
                            IsTuesday = bankBranchModel.WeeklyHalfDay.IsTuesday,
                            IsWednesday = bankBranchModel.WeeklyHalfDay.IsWednesday,
                            IsThursday = bankBranchModel.WeeklyHalfDay.IsThursday,
                            IsFriday = bankBranchModel.WeeklyHalfDay.IsFriday,
                            IsSaturday = bankBranchModel.WeeklyHalfDay.IsSaturday
                        };
                    }

                    bool CreateBranchFlag = false;
                    if (Helper.IsCAIdNotNull(currentUserDto) && bankBranchModel.CAId == null && bankBranchModel.BaseBranchId == null)
                    {
                        if (Id != null && Id != 0)
                            bankBranchDto.BaseBranchId = Convert.ToInt32(Id);
                        CreateBranchFlag = true;
                    }
                    else
                    {
                        bankBranchDto.BaseBranchId = bankBranchModel.BaseBranchId;
                    }

                    Branchclient = new BankBranchServiceClient();
                    if (FormMode == "edit" && !CreateBranchFlag)
                    {
                        if (Id != null && Id != 0)
                            bankBranchDto.BranchId = Convert.ToInt32(Id);
                        bankBranchDto = Branchclient.Update(bankBranchDto,currentUserDto.UserName);
                    }
                    else
                    {
                        bankBranchDto.CreatedBy = currentUserDto.UserId;
                        bankBranchDto = Branchclient.Create(bankBranchDto,currentUserDto.UserName);
                    }
                    if (bankBranchDto.Response.HasWarning)
                    {
                        ViewData["Error"] = string.Format(ErrorAndValidationMessages.BBRAddFailed, bankBranchModel.Name, bankBranchModel.BranchOfBank.BankName);
                    }
                    else
                    {
                        if (FormMode == "edit")
                            TempData["Success"] = string.Format(ClientResources.BankBranchUpdated, bankBranchDto.Name, bankBranchDto.BranchOfBank.BankName);
                        else
                            TempData["Success"] = string.Format(ClientResources.BankBranchAdded, bankBranchDto.Name, bankBranchDto.BranchOfBank.BankName);
                        FormMode = string.Empty;
                        return RedirectToAction("BankBranchListIndex", "BankBranch");
                    }
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (Branchclient != null && Branchclient.State == System.ServiceModel.CommunicationState.Opened)
                    Branchclient.Close();
            }
            SetBanksListToViewData();
            ViewData["SelectedBank"] = Bankid != 0 ? ((List<BankDto>)ViewData["BankList"]).FindIndex(FindBank) : 0;
            return View("AckAndClientCommonViews\\AddBankBranch", bankBranchModel);
        }
                
        public ActionResult AddNewBank(BankBranchListModel model)
        {
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            BankDto bankdto = new BankDto();
            bankdto.BankName = Request.Params["txtppBankName"].ToString().Trim();
            bankdto.Alias = Request.Params["txtppAlias"].ToString().Trim();
            bankdto.URL = Request.Params["txtppURL"].ToString().Trim();
            if (currentUserDto.UserOfClient != null)
            {
                if (Helper.IsCAIdNotNull(currentUserDto))
                    bankdto.CAId = Helper.GetCAIdOfUser(currentUserDto);
            }
            bankdto.CreatedBy = currentUserDto.UserId;
            bankdto.ModifiedBy = currentUserDto.UserId;
            Bankclient = new BankServiceClient();
            bankdto = Bankclient.Create(bankdto,currentUserDto.UserName);

            if (bankdto.Response.HasWarning)
            {
                TempData["AddBankError"] = string.Empty;
                foreach (BusinessWarning bw in bankdto.Response.BusinessWarnings)
                {
                    if (bw.Message == Constants.BRBANKNAMEVALIDATION)
                    {
                        TempData["AddBankError"] += ErrorAndValidationMessages.BRBankNameValidation + "<br />";
                    }
                }
            }

            return PartialView("CallbackPopupAddBank");
        }
                
        public void SetBanksListToViewData()
        {
            List<BankDto> Banks = GetBankList1();
            Banks.Insert(0, new BankDto() { BankId = 0, BankName = "[Select]" });
            ViewData["BankList"] = Banks;
 
            return;
        }
                
        public ActionResult GetBanksView(BankBranchModel bankBranchModel)
        {
            SetBanksListToViewData();
            return PartialView("Banks");
        }
                
        public List<BankDto> GetBankList1()
        {
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            Query query = new Query();

            if (Helper.IsCAIdNotNull(currentUserDto))
                query.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(currentUserDto));

            if (Helper.IsCAIdNotNull(currentUserDto))
            {
                Criterion criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(currentUserDto), CriteriaOperator.Equal);
                query.Add(criteriaCAId);
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                query.Add(criteriaCAIdNULL);
                query.QueryOperator = QueryOperator.Or;
            }
            else
            {
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                query.Add(criteriaCAIdNULL);
                query.QueryOperator = QueryOperator.And;
            }
            Bankclient = new BankServiceClient();
            var Banks = Bankclient.FindByQuery(query);
            Bankclient.Close();
            return Banks.Entities.ToList();
        }

        private void CheckForValidation(BankBranchModel bankBranchModel)
        {
            if (String.IsNullOrEmpty(bankBranchModel.BranchAddress.PIN))
                ModelState.AddModelError("errpin", ErrorAndValidationMessages.BBErrorRequiredPIN);
            else
            {
                if (!Regex.IsMatch(bankBranchModel.BranchAddress.PIN, Constants.REGEXPIN))
                    ModelState.AddModelError("errpin", ErrorAndValidationMessages.BBErrorRegExPIN);
            }

            int bank = ComboBoxExtension.GetValue<object>("cmbBank") != null ? ComboBoxExtension.GetValue<int>("cmbBank") : 0;
            if (bank == 0)
                ModelState.AddModelError("errbank", ErrorAndValidationMessages.BBErrorRequiredBank);

            if (String.IsNullOrEmpty(ComboBoxExtension.GetValue<object>("cmbCityVillage") != null ? ComboBoxExtension.GetValue<int>("cmbCityVillage").ToString() : null))
                ModelState.AddModelError("errcity", ErrorAndValidationMessages.BBErrorRequiredCityVillage);

            if (String.IsNullOrEmpty(bankBranchModel.BranchAddress.AddressLine1))
                ModelState.AddModelError("erradd", ErrorAndValidationMessages.BBErrorRequiredAddressLine1);

            if (bankBranchModel.BranchContactNos != null && bankBranchModel.BranchContactNos.Count > 0)
            {
                foreach (ContactDetailsDto cddto in bankBranchModel.BranchContactNos)
                {
                    if (!String.IsNullOrEmpty(cddto.ContactNo))
                    {
                        if (!Regex.IsMatch(cddto.ContactNo, @"\d{5,15}"))
                        {
                            ModelState.AddModelError("errcontact", ErrorAndValidationMessages.BBErrorRegExContactNo);
                            break;
                        }
                        if (!Regex.IsMatch(cddto.STDCode, @"\d{3,5}"))
                        {
                            ModelState.AddModelError("errcontact", ErrorAndValidationMessages.BBErrorRegExSTDCode);
                            break;
                        }
                    }
                }
            }
        }

        private static bool FindBank(BankDto bkdto)
        {
            if (bkdto.BankId == Bankid)
            {
                Bankid = 0;
                return true;
            }
            else
                return false;
        }

        #region commented code tried jquery autocomplete
        //public ActionResult SearchBanks(string q)
        //{
        //    UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
        //    Query query = new Query();
        //    Criterion criteriaCAId = new Criterion(Constants.CAID, currentUserDto.CAId, CriteriaOperator.Equal);
        //    query.Add(criteriaCAId);
        //    Criterion criteriaCAIdNull = new Criterion(Constants.CAID, currentUserDto.CAId, CriteriaOperator.IsNullOrZero);
        //    query.Add(criteriaCAIdNull);
        //    query.QueryOperator = QueryOperator.Or;
        //    Query query1 = new Query();

        //    Criterion crSearch = new Criterion("BankName", q, CriteriaOperator.Equal);
        //    query1.AddSubQuery(query);

        //    BankServiceReference.IBankService BankClient = new BankServiceReference.BankServiceClient();
        //    var Banks = BankClient.FindByQuery(query1);
        //    //var content = Banks.Entities.ToDictionary(x=>x.BankId.ToString(),x=>x.BankName);

        //    var content = Banks.Entities
        //                            .Select(p => p.BankName)
        //                            .Aggregate("", (allNames, nextName) => allNames + "\n" + nextName);

        //    return Content(content);
        //}
        #endregion
    }
}
