using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.BankBranchServiceReference;
using Cams.Web.MVCRazor.Models.ClientRegistration;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientAccountController
    {
        #region Add/Remove PaymentDetails
        public ActionResult AddRemovePaymentDetails()
        {
            IList<ClientSubscriptionPaymentDetailsModel> paymentDetailsModel = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                paymentDetailsModel = (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                string delPaymentDetailsIndex = RemovePaymentDetails();

                if (string.IsNullOrEmpty(delPaymentDetailsIndex))
                {
                    var res = Request.Params["DXCallbackArgument"].Split('|').ToArray();
                    string paymentType = "";
                    if (res.Count() != 0)
                    {
                        if (res[0].Contains("cheque"))
                            paymentType = res.First().Replace("c0:cheque", "cheque");

                        if (res[0].Contains("online"))
                            paymentType = res.First().Replace("c0:online", "online");

                        if (res[0].Contains("dd"))
                            paymentType = res.First().Replace("c0:dd", "dd");

                        paymentType = paymentType.TrimEnd(';');

                        switch (paymentType)
                        {
                            case "cheque":
                                paymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.Cheque,HiddenFieldForChequeBankBranch = 0});
                                break;
                            case "online":
                                paymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.Online ,HiddenFieldForOnlineBankBranch = 0});
                                break;
                            case "dd":
                                paymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.DD,HiddenFieldForDDBankBranch = 0});
                                break;
                        }
                    }
                }
                else
                {
                    paymentDetailsModel.RemoveAt(Convert.ToInt32(delPaymentDetailsIndex));
                }
            }
            return PartialView("CBPPaymentDetails", paymentDetailsModel);
        }

        private string RemovePaymentDetails()
        {
            var res = Request.Params["DXCallbackArgument"].Split('|').ToArray().Where(x => x.Contains("RemovePayment"));
            string delPaymentDetailsIndex = "";
            if (res.Count() != 0)
            {
                delPaymentDetailsIndex = res.First().Replace("c0:RemovePayment", "");
                delPaymentDetailsIndex = delPaymentDetailsIndex.TrimEnd(';');
            }
            return delPaymentDetailsIndex;
        }
        #endregion

        #region UpdatePaymentDetails

        #region UpdateChequePaymentDetails
        public ActionResult UpdateChequePaymentDetailsInModel(string chequeType, string chequeNo, string chequeDate, string clearanceDate, string drawnOn, decimal amount, int modelNo)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel chequePaymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(modelNo);
                if (chequeType == "RTGS")
                {
                    chequePaymentDetailsModel.IsRTGS = true;
                    chequePaymentDetailsModel.IsStandardCheque = false;
                }
                else
                {
                    chequePaymentDetailsModel.IsStandardCheque = true;
                    chequePaymentDetailsModel.IsRTGS = false;
                }

                chequePaymentDetailsModel.ChequeDDTransationNo = chequeNo;

                chequeDate = chequeDate.Replace('-', '/');
                chequePaymentDetailsModel.ChequeDDTransactionDate = DateTime.ParseExact(chequeDate,"dd/MM/yyyy",null);
                clearanceDate = clearanceDate.Replace('-', '/');
                chequePaymentDetailsModel.ChequeDDClearanceDates = DateTime.ParseExact(clearanceDate, "dd/MM/yyyy", null);

                chequePaymentDetailsModel.ChequeAmount = amount;
                chequePaymentDetailsModel.Amount = chequePaymentDetailsModel.ChequeAmount;
                chequePaymentDetailsModel.BankBranch = new BankBranchDto();
                chequePaymentDetailsModel.BankBranch.BranchId = Convert.ToInt32(drawnOn);
                ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForChequeBankBranch = Convert.ToInt32(drawnOn);
                chequePaymentDetailsModel.HiddenFieldForChequeBankBranch =
                    ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForChequeBankBranch;
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }
        #endregion

        #region UpdateOnlinePaymentDetails
        public ActionResult UpdateOnlinePaymentDetailsInModel(string onlineTransactionType, string onlineTransactionNo, string onlineTransDate, string bank, decimal amount, int modelNo)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel onlinePaymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(modelNo);
                if (onlineTransactionType == "RTGS")
                {
                    onlinePaymentDetailsModel.IsRTGS = true;
                    onlinePaymentDetailsModel.IsNEFT = false;
                }
                else
                {
                    onlinePaymentDetailsModel.IsNEFT = true;
                    onlinePaymentDetailsModel.IsRTGS = false;
                }

                onlinePaymentDetailsModel.ChequeDDTransationNo = onlineTransactionNo;

                onlineTransDate = onlineTransDate.Replace('-', '/');
                onlinePaymentDetailsModel.ChequeDDTransactionDate = DateTime.ParseExact(onlineTransDate, "dd/MM/yyyy", null);

                onlinePaymentDetailsModel.OnlineAmount = amount;
                onlinePaymentDetailsModel.Amount = onlinePaymentDetailsModel.OnlineAmount;
                onlinePaymentDetailsModel.BankBranch = new BankBranchDto();
                onlinePaymentDetailsModel.BankBranch.BranchId = Convert.ToInt32(bank);
                ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForOnlineBankBranch = Convert.ToInt32(bank);
                onlinePaymentDetailsModel.HiddenFieldForOnlineBankBranch =
                    ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForOnlineBankBranch;
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }
        #endregion

        #region UpdateDDPaymentDetailsInModel
        public ActionResult UpdateDDPaymentDetailsInModel(string ddNo, string ddDate, string bank, decimal amount, int modelNo)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel ddPaymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(modelNo);

                ddPaymentDetailsModel.ChequeDDTransationNo = ddNo;

                ddDate = ddDate.Replace('-', '/');
                ddPaymentDetailsModel.ChequeDDTransactionDate = DateTime.ParseExact(ddDate, "dd/MM/yyyy", null);

                ddPaymentDetailsModel.DDAmount = amount;
                ddPaymentDetailsModel.Amount = ddPaymentDetailsModel.DDAmount;
                ddPaymentDetailsModel.BankBranch = new BankBranchDto();
                ddPaymentDetailsModel.BankBranch.BranchId = Convert.ToInt32(bank);
                ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForDDBankBranch = Convert.ToInt32(bank);
                ddPaymentDetailsModel.HiddenFieldForDDBankBranch =
                    ClientSubscriptionPaymentDetailsModel.StaticHiddenFieldForDDBankBranch;
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }
        #endregion

        #region UpdateCashPaymentDetailsInModel
        public ActionResult UpdateCashPaymentDetailsInModel(decimal amount)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel cashPaymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(0);
                cashPaymentDetailsModel.CashAmount = amount;
                cashPaymentDetailsModel.Amount = cashPaymentDetailsModel.CashAmount;
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }
        #endregion

        #region Update AdditionalInfo and TDS field
        public ActionResult UpdateAdditionalFieldInModel(string additionalInfo)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel paymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(0);
                paymentDetailsModel.AdditionalInfo = additionalInfo;               
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }


        public ActionResult UpdateTDSFieldInModel(decimal tds)
        {
            IList<ClientSubscriptionPaymentDetailsModel> clientSubscriptionPaymentDetailsModelList = null;
            if (Session["ClientSubscriptionPaymentDetailsModel"] != null)
            {
                clientSubscriptionPaymentDetailsModelList =
                (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                ClientSubscriptionPaymentDetailsModel paymentDetailsModel = clientSubscriptionPaymentDetailsModelList.ElementAt(0);
                paymentDetailsModel.TDS = tds;
            }
            Session["ClientSubscriptionPaymentDetailsModel"] = clientSubscriptionPaymentDetailsModelList;
            return PartialView("CBPPaymentDetails", clientSubscriptionPaymentDetailsModelList);
        }
        #endregion
        #endregion

        #region Commented Code
        ////function to check wheather chequeDate is greater than 6 months from current date
        //public bool CheckChequeDate(string chequeDate)
        //{
        //    DateTime chequeDDTransactionDate;
        //    double totalDays;
        //    bool isChequeDateGreaterThanSixMonths=false;
        //    if(!string.IsNullOrEmpty(chequeDate))
        //    {
        //        DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
        //        dateTimeFormatInfo.ShortDatePattern = "dd-MM-yyyy";
        //        dateTimeFormatInfo.DateSeparator = "-";
        //        chequeDDTransactionDate = Convert.ToDateTime(chequeDate, dateTimeFormatInfo);
        //        totalDays = chequeDDTransactionDate.Subtract(DateTime.Now).TotalDays;
        //        if(totalDays >90)
        //        {
        //            isChequeDateGreaterThanSixMonths = true;
        //        }
        //    }
        //    return isChequeDateGreaterThanSixMonths;
        //}
        #endregion

        #region SearchBankandBranch
        public ActionResult SearchBankandBranch()
        {
            bool flag = false;
            string bankName = Request.Params["bankName"];
            string bankBranch = Request.Params["bankBranch"];
            string place = Request.Params["place"];
            string IFSCCode = Request.Params["IFSCCode"];
            string MICRCode = Request.Params["MICRCode"];
            string SWIFTCode = Request.Params["SWIFTCode"];
            BankBranchServiceReference.BankBranchServiceClient bankBranchServiceClient = new BankBranchServiceClient();
            IList<BankBranchDto> bankBranchDtoList = null;
            Query query = new Query();
            if (!string.IsNullOrEmpty(bankName))
            {
                flag = true;
                Criterion criterionBankName = new Criterion("BranchBank.BankName", bankName, CriteriaOperator.Equal);
                query.AddAlias(new Alias("BranchBank", "BranchOfBank"));
                query.Add(criterionBankName);
            }
            if (!string.IsNullOrEmpty(bankBranch))
            {
                flag = true;
                Criterion criterionBranchName = new Criterion("Name", bankBranch, CriteriaOperator.Equal);
                query.Add(criterionBranchName);
            }
            if (!string.IsNullOrEmpty(place))
            {
                flag = true;
                Criterion criterionplace = new Criterion("cv.Name", place, CriteriaOperator.Equal);
                query.AddAlias(new Alias("ba", "BranchAddress"));
                query.AddAlias(new Alias("cv", "ba.CityVillage"));
                query.Add(criterionplace);
            }
            if (!string.IsNullOrEmpty(IFSCCode))
            {
                flag = true;
                Criterion criterionIFSCCode = new Criterion("IFSCCode", IFSCCode, CriteriaOperator.Equal);
                query.Add(criterionIFSCCode);
            }
            if (!string.IsNullOrEmpty(MICRCode))
            {
                flag = true;
                Criterion criterionMICRCode = new Criterion("MICRCode", MICRCode, CriteriaOperator.Equal);
                query.Add(criterionMICRCode);
            }
            if (!string.IsNullOrEmpty(SWIFTCode))
            {
                flag = true;
                Criterion criterionSWIFTCode = new Criterion("SWIFTCode", SWIFTCode, CriteriaOperator.Equal);
                query.Add(criterionSWIFTCode);
            }
            if (flag)
            {
                query.QueryOperator = QueryOperator.And;
                bankBranchDtoList = bankBranchServiceClient.FindByQuery(query).Entities;
                bankBranchServiceClient.Close();
                ViewData["SearchBank"] = bankBranchDtoList;
            }
            else
                ViewData["SearchBank"] = null;
            return PartialView("CBPPopupSearchBankBranchGrid", ViewData["SearchBank"]);
        }
        #endregion
    }
}
