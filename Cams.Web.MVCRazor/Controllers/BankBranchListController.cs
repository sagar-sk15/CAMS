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
using Cams.Web.MVCRazor.BankServiceReference;
using Cams.Web.MVCRazor.BankBranchServiceReference;
using System.Globalization;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class BankBranchController : CommonController
    {
        //private static BankServiceReference.IBankService BankClient;
        //private static BankBranchServiceReference.IBankBranchService BankBranchClient;

        [CamsAuthorize(Roles = Constants.BANKNBRANCH, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult BankBranchListIndex()
        {
            BankBranchListModel model = new BankBranchListModel();
            Bankid = 0;
            FormMode = string.Empty;
            try
            {
                model.BankList = GetBankList();
                model.BranchOfBank = model.BankList.Count > 0 ? model.BankList.FirstOrDefault() : null;
                int bnkid = model.BranchOfBank.BankId;
                ViewData["BankBranchListGrid"] = GetBankBranchList(bnkid);
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            return View("AckAndClientCommonViews\\BankBranchList", model);
        }
                
        public ActionResult BankBranchListGridView(BankBranchListModel model)
        {
            int BankId = Request.Params["BankId"] != null ? Convert.ToInt32(Request.Params["BankId"]) : 0;
            model.BankBranchList = GetBankBranchList(BankId);
            ViewData["BankBranchListGrid"] = model.BankBranchList;
            return PartialView("AckAndClientCommonViews\\BankBranchGrid", ViewData["BankBranchListGrid"]);
        }
                
        public ActionResult GetBankBranchListOnBankId(BankBranchListModel model)
        {
            int BankId = Request.Params["BankId"] != null ? Convert.ToInt32(Request.Params["BankId"]) : 0;
            model.BankBranchList = GetBankBranchList(BankId);
            ViewData["BankBranchListGrid"] = model.BankBranchList;
            return PartialView("AckAndClientCommonViews\\BankBranchListGridViewPanel", model.BankBranchList);
        }
                
        public ActionResult GetBanks(BankBranchListModel model)
        {
            model.BankList = GetBankList();
            return PartialView("AckAndClientCommonViews\\BankBranchCombo", model);
        }

        public List<BankDto> GetBankList()
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

        public List<BankBranchDto> GetBankBranchList(int BankId)
        {
            UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
            Query subquery1 = new Query();
            if (Helper.IsCAIdNotNull(currentUserDto))
            {
                Criterion criteriaCAId = new Criterion(Constants.CAID, Helper.GetCAIdOfUser(currentUserDto), CriteriaOperator.Equal);
                subquery1.Add(criteriaCAId);
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                subquery1.Add(criteriaCAIdNULL);
                subquery1.QueryOperator = QueryOperator.Or;
            }
            else
            {
                Criterion criteriaCAIdNULL = new Criterion(Constants.CAID, null, CriteriaOperator.IsNullOrZero);
                subquery1.Add(criteriaCAIdNULL);
            }

            Query query = new Query();
            if (Helper.IsCAIdNotNull(currentUserDto))
                query.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(currentUserDto));
            Criterion criteriaBankId = new Criterion("banks.BankId", BankId, CriteriaOperator.Equal);
            query.Add(criteriaBankId);
            query.AddAlias(new Alias("banks", "BranchOfBank"));
            query.QueryOperator = QueryOperator.And;
            query.AddSubQuery(subquery1);

            Branchclient = new BankBranchServiceClient();
            var BankBranches = Branchclient.FindByQuery(query);
            Branchclient.Close();
            return BankBranches.Entities.ToList();
        }

        [CamsAuthorize(Roles = Constants.BANKNBRANCH, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult GetBankBranchView()
        {
            BankBranchModel model = new BankBranchModel();
            var BranchId = Request.QueryString["branchid"];
            try
            {
                Branchclient = new BankBranchServiceClient();
                BankBranchDto BBDto = Branchclient.GetById(BranchId != null ? Convert.ToInt32(BranchId) : 0);
                model.BranchId = BBDto.BranchId;
                model.BaseBranchId = BBDto.BaseBranchId;
                model.BranchAddress = BBDto.BranchAddress;
                model.BranchContactNos = BBDto.BranchContactNos;
                model.BranchOfBank = BBDto.BranchOfBank;
                model.CAId = BBDto.CAId;
                model.Email1 = BBDto.Email1;
                model.Email2 = BBDto.Email2;

                model.FullDayBreakFromString = BBDto.FullDayBreakFrom != null ? DateTime.ParseExact(BBDto.FullDayBreakFrom.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.FullDayBreakFrom.Value.ToString(@"hh")) < 12 ? BBDto.FullDayBreakFrom.Value.ToString(@"hh\:mm") + Space + AM : BBDto.FullDayBreakFrom.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.FullDayBreakToString = BBDto.FullDayBreakTo != null ? DateTime.ParseExact(BBDto.FullDayBreakTo.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";// Convert.ToInt32(BBDto.FullDayBreakTo.Value.ToString(@"hh")) < 12 ? BBDto.FullDayBreakTo.Value.ToString(@"hh\:mm") + Space + AM : BBDto.FullDayBreakTo.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.FullDayTimeFromString = BBDto.FullDayTimeFrom != null ? DateTime.ParseExact(BBDto.FullDayTimeFrom.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.FullDayTimeFrom.Value.ToString(@"hh")) < 12 ? BBDto.FullDayTimeFrom.Value.ToString(@"hh\:mm") + Space + AM : BBDto.FullDayTimeFrom.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.FullDayTimeToString = BBDto.FullDayTimeTo != null ? DateTime.ParseExact(BBDto.FullDayTimeTo.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.FullDayTimeTo.Value.ToString(@"hh")) < 12 ? BBDto.FullDayTimeTo.Value.ToString(@"hh\:mm") + Space + AM : BBDto.FullDayTimeTo.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.HalfDayBreakFromString = BBDto.HalfDayBreakFrom != null ? DateTime.ParseExact(BBDto.HalfDayBreakFrom.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.HalfDayBreakFrom.Value.ToString(@"hh")) < 12 ? BBDto.HalfDayBreakFrom.Value.ToString(@"hh\:mm") + Space + AM : BBDto.HalfDayBreakFrom.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.HalfDayBreakToString = BBDto.HalfDayBreakTo != null ? DateTime.ParseExact(BBDto.HalfDayBreakTo.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.HalfDayBreakTo.Value.ToString(@"hh")) < 12 ? BBDto.HalfDayBreakTo.Value.ToString(@"hh\:mm") + Space + AM : BBDto.HalfDayBreakTo.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.HalfDayTimeFromString = BBDto.HalfDayTimeFrom != null ? DateTime.ParseExact(BBDto.HalfDayTimeFrom.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.HalfDayTimeFrom.Value.ToString(@"hh")) < 12 ? BBDto.HalfDayTimeFrom.Value.ToString(@"hh\:mm") + Space + AM : BBDto.HalfDayTimeFrom.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";
                model.HalfDayTimeToString = BBDto.HalfDayTimeTo != null ? DateTime.ParseExact(BBDto.HalfDayTimeTo.Value.ToString(@"hh\:mm"), "HH:mm", null).ToString("hh:mm tt", CultureInfo.GetCultureInfo("en-US")) : "00:00 AM";//Convert.ToInt32(BBDto.HalfDayTimeTo.Value.ToString(@"hh")) < 12 ? BBDto.HalfDayTimeTo.Value.ToString(@"hh\:mm") + Space + AM : BBDto.HalfDayTimeTo.Value.ToString(@"hh\:mm") + Space + PM : "00:00 AM";

                model.IFSCCode = BBDto.IFSCCode;
                model.MICRCode = BBDto.MICRCode;
                model.Name = BBDto.Name;
                model.SWIFTCode = BBDto.SWIFTCode;
                model.WeeklyHalfDay = BBDto.WeeklyHalfDay;
                model.WeeklyOffDay = BBDto.WeeklyOffDay;
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
            return View("AckAndClientCommonViews\\BankBranchView", model);

        }
    }
}
