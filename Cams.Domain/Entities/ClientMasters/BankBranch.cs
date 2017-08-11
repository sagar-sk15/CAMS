using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.ClientMasters
{
    public class BankBranch:EntityBase<int>
    {
        #region Constructor
        public BankBranch()
        {
            BranchContactNos = new List<ContactDetails>();
            BranchOfClientSubscriptionPayment = new List<ClientSubscriptionPaymentDetails>();
            BranchOfClientPartner = new List<ClientPartnerBankDetails>();
        }
        #endregion

        #region properties
        public virtual int BranchId { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        //public virtual Client Client { get; set; }

        public virtual string IFSCCode { get; set; }
        public virtual string MICRCode { get; set; }
        public virtual string SWIFTCode { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }        
        public virtual Nullable<TimeSpan> FullDayTimeFrom { get; set; }
        public virtual Nullable<TimeSpan> FullDayTimeTo { get; set; }
        public virtual Nullable<TimeSpan> HalfDayTimeFrom { get; set; }
        public virtual Nullable<TimeSpan> HalfDayTimeTo { get; set; }
        public virtual Nullable<TimeSpan> FullDayBreakFrom { get; set; }
        public virtual Nullable<TimeSpan> FullDayBreakTo { get; set; }
        public virtual Nullable<TimeSpan> HalfDayBreakFrom { get; set; }
        public virtual Nullable<TimeSpan> HalfDayBreakTo { get; set; }
        public virtual Nullable<int> BaseBranchId { get; set; } 
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
       
        public virtual Bank BranchOfBank { get; set; } 
        public virtual Address BranchAddress { get; set; }
        public virtual WeeklyHalfDay WeeklyHalfDay { get; set; }
        public virtual WeeklyOffDays WeeklyOffDay { get; set; }
        public virtual IList<ContactDetails> BranchContactNos { get; set; }
        public virtual IList<ClientSubscriptionPaymentDetails> BranchOfClientSubscriptionPayment { get; set; }
        public virtual IList<ClientPartnerBankDetails> BranchOfClientPartner { get; set; }
                     
        #endregion

        #region Methods
        public override void Validate()
        {
            return;
        }

        public static bool IsDirty(BankBranchDto branchNewValues, BankBranchDto branchDBValues) 
        {
            bool isDirty = false;
            if (branchNewValues.BranchId == branchDBValues.BranchId)
            {
                if (branchNewValues.Name != null)
                {
                    // Branch
                    if (branchNewValues.Name != branchDBValues.Name)
                        isDirty = true;
                    else if (branchNewValues.IFSCCode != branchDBValues.IFSCCode)
                        isDirty = true;
                    else if (branchNewValues.MICRCode != branchDBValues.MICRCode)
                        isDirty = true;
                    else if (branchNewValues.SWIFTCode != branchDBValues.SWIFTCode)
                        isDirty = true;
                    else if (branchNewValues.Email1 != branchDBValues.Email1)
                        isDirty = true;
                    else if (branchNewValues.Email2 != branchDBValues.Email2)
                        isDirty = true;
                    else if (branchNewValues.FullDayTimeFrom != branchDBValues.FullDayTimeFrom)
                        isDirty = true;
                    else if (branchNewValues.FullDayTimeTo != branchDBValues.FullDayTimeTo)
                        isDirty = true;
                    else if (branchNewValues.FullDayBreakFrom != branchDBValues.FullDayBreakFrom)
                        isDirty = true;
                    else if (branchNewValues.FullDayBreakTo != branchDBValues.FullDayBreakTo)
                        isDirty = true;
                    else if (branchNewValues.HalfDayTimeFrom != branchDBValues.HalfDayTimeFrom)
                        isDirty = true;
                    else if (branchNewValues.HalfDayTimeTo != branchDBValues.HalfDayTimeTo)
                        isDirty = true;
                    else if (branchNewValues.HalfDayBreakFrom != branchDBValues.HalfDayBreakFrom)
                        isDirty = true;
                    else if (branchNewValues.HalfDayBreakTo != branchDBValues.HalfDayBreakTo)
                        isDirty = true;
                    // Bank
                    else if (branchNewValues.BranchOfBank.BankId != branchDBValues.BranchOfBank.BankId)
                        isDirty = true;
                    // Branch Address
                    else if (branchNewValues.BranchAddress.AddressLine1 != branchDBValues.BranchAddress.AddressLine1)
                        isDirty = true;
                    else if (branchNewValues.BranchAddress.AddressLine2 != branchDBValues.BranchAddress.AddressLine2)
                        isDirty = true;
                    else if (branchNewValues.BranchAddress.PIN != branchDBValues.BranchAddress.PIN)
                        isDirty = true;
                    else if (branchNewValues.BranchAddress.CityVillage.CityVillageId != branchDBValues.BranchAddress.CityVillage.CityVillageId)
                        isDirty = true;
                    // Branch Weekly halfDay
                    else if (branchNewValues.WeeklyHalfDay.IsMonday != branchDBValues.WeeklyHalfDay.IsMonday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsTuesday != branchDBValues.WeeklyHalfDay.IsTuesday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsWednesday != branchDBValues.WeeklyHalfDay.IsWednesday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsThursday != branchDBValues.WeeklyHalfDay.IsThursday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsFriday != branchDBValues.WeeklyHalfDay.IsFriday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsSaturday != branchDBValues.WeeklyHalfDay.IsSaturday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyHalfDay.IsSunday != branchDBValues.WeeklyHalfDay.IsSunday)
                        isDirty = true;
                    // Branch Weekly Offday
                    else if (branchNewValues.WeeklyOffDay.IsMonday != branchDBValues.WeeklyOffDay.IsMonday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsTuesday != branchDBValues.WeeklyOffDay.IsTuesday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsWednesday != branchDBValues.WeeklyOffDay.IsWednesday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsThursday != branchDBValues.WeeklyOffDay.IsThursday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsFriday != branchDBValues.WeeklyOffDay.IsFriday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsSaturday != branchDBValues.WeeklyOffDay.IsSaturday)
                        isDirty = true;
                    else if (branchNewValues.WeeklyOffDay.IsSunday != branchDBValues.WeeklyOffDay.IsSunday)
                        isDirty = true;
                    // Branch Contact Details
                    else if (branchNewValues.BranchContactNos != null && branchDBValues.BranchContactNos != null)
                    {
                        foreach(ContactDetailsDto NewContact in branchNewValues.BranchContactNos)
                        {
                            foreach(ContactDetailsDto DBContact in branchDBValues.BranchContactNos)
                            {
                                if (NewContact.ContactNo != DBContact.ContactNo)
                                    isDirty = true;
                                else if (NewContact.ContactNoType != DBContact.ContactNoType)
                                    isDirty = true;
                                else if (NewContact.CountryCallingCode != DBContact.CountryCallingCode)
                                    isDirty = true;
                                else if (NewContact.STDCode != DBContact.STDCode)
                                    isDirty = true;
                            }
                        }
                    }
                }
            }
            return isDirty;
        }
        #endregion
    }
}
