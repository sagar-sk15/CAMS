using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.ClientRegistration;
using Cams.Web.MVCRazor.BankBranchServiceReference;
using Cams.Web.MVCRazor.BankServiceReference;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public class ClientSubscriptionPaymentDetailsModel : ClientSubscriptionPaymentDetailsDto
    {
        public ClientSubscriptionPaymentDetailsModel()
        {
            IsRTGS = true;
            HiddenFieldForChequeBankBranch = StaticHiddenFieldForChequeBankBranch;
            HiddenFieldForDDBankBranch = StaticHiddenFieldForDDBankBranch;
            HiddenFieldForOnlineBankBranch = StaticHiddenFieldForOnlineBankBranch;
        }

        public static IList<BankBranchDto> GetAllBankandBranche()
        {
            BankBranchServiceReference.BankBranchServiceClient bankBranchServiceClient = new BankBranchServiceClient();
            BankBranchDtoList = bankBranchServiceClient.FindAll().Entities.ToList();
            BankBranchDtoList.Insert(0, new BankBranchDto
                                            {
                                                BranchId = 0,
                                                Name ="",
                                                BranchOfBank = new BankDto
                                                                   {
                                                                       
                                                                       BankName = "[Select]"
                                                                   }

                                            });
            return BankBranchDtoList;
        }

        [Required]
        public override decimal Amount { get; set; }

        [Required]
        public override string ChequeDDTransationNo { get; set; }

        [Required]
        public override System.Nullable<System.DateTime> ChequeDDTransactionDate { get; set; }

        [Required]
        public override Nullable<DateTime> ChequeDDClearanceDates { get; set; }

        public decimal TDS { get; set; }
        public string AdditionalInfo { get; set; }

        public string TransactionType { get; set; }
        public static IList<BankBranchDto> BankBranchDtoList { get; set; }

        public string ChequeDDTransactionDateString { get; set; }
        public string ChequeClearanceDateString { get; set; } 
        public decimal CashAmount { get; set; }
        public decimal ChequeAmount { get; set; }
        public decimal DDAmount { get; set; }
        public decimal OnlineAmount { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }

        public int HiddenFieldForChequeBankBranch { get; set; }
        public int HiddenFieldForDDBankBranch { get; set; }
        public int HiddenFieldForOnlineBankBranch { get; set; }
        
        public static int StaticHiddenFieldForChequeBankBranch { get; set; }
        public static int StaticHiddenFieldForDDBankBranch { get; set; }
        public static int StaticHiddenFieldForOnlineBankBranch { get; set; }
    }
}
