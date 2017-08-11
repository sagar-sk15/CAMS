using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class BankBranchListModel : BankBranchDto
    {
        public BankBranchListModel()
        {
            BankBranchList = new List<BankBranchDto>();
            BankList = new List<BankDto>();
        }
        public IList<BankBranchDto> BankBranchList;
        public IList<BankDto> BankList;
    }
}