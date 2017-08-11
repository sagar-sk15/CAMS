using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;
using System.Security.Cryptography;
using Cams.Common.Configuration;
using Cams.Common.Dto.User;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;

namespace Cams.Common
{
    public static class Helper
    {
        private static int MaxLength = 12;
        private static int MinLength = 6;

        private static string PasswordAlphaNumeric = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
        private static string PasswordNonAlphanumeric = "~!*@#$%^&-_=+\'/?.><";

        //public static string GetResourceValue(string key)
        //{
        //    string value = string.Empty;
        //    try
        //    {                
        //        Assembly assembly = Assembly.Load(ApplicationSettingsFactory.ErrorMessageResourceFileName);
        //        ResourceManager resourceManager = new ResourceManager(ApplicationSettingsFactory.ErrorMessageResourceFileName, assembly);
        //        CultureInfo currentculture = Thread.CurrentThread.CurrentCulture;
        //        value = resourceManager.GetString(key, currentculture);
        //        if (!string.IsNullOrEmpty(value))
        //            return value;
        //        else
        //            return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public static string Encode(string sData)
        {

            byte[] encData_byte = new byte[sData.Length];

            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);

            string encodedData = Convert.ToBase64String(encData_byte);

            return encodedData;
        }

        public static string Decode(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(sData);

            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

            char[] decoded_char = new char[charCount];

            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

            string result = new String(decoded_char);

            return result;
        }
        
        public static string GeneratePassword()
        {
            char[][] charGroups = new char[][] 
            {
              PasswordAlphaNumeric.ToCharArray(),
               PasswordNonAlphanumeric.ToCharArray()
            };

            int[] charsLeftInGroup = new int[charGroups.Length];
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            int[] LeftGroupsOrder = new int[charGroups.Length];
            for (int i = 0; i < LeftGroupsOrder.Length; i++)
                LeftGroupsOrder[i] = i;

            // Random number generator to use a real seed
            byte[] RandomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(RandomBytes);
            int Seed = (RandomBytes[0] & 0x7f) << 24 |
                        RandomBytes[1] << 16 |
                        RandomBytes[2] << 8 |
                        RandomBytes[3];

            Random random = new Random(Seed);
            char[] Password = null;
            Password = new char[random.Next(MinLength, MaxLength + 1)];

            int NextCharIndex;
            int NextGroupIndex;
            int NextLeftGroupsOrderIndex;
            int LastCharIndex;
            int LastLeftGroupsOrderIndex = LeftGroupsOrder.Length - 1;

            for (int i = 0; i < Password.Length; i++)
            {
                if (LastLeftGroupsOrderIndex == 0)
                    NextLeftGroupsOrderIndex = 0;
                else
                    NextLeftGroupsOrderIndex = random.Next(0,
                                                         LastLeftGroupsOrderIndex);
                NextGroupIndex = LeftGroupsOrder[NextLeftGroupsOrderIndex];
                LastCharIndex = charsLeftInGroup[NextGroupIndex] - 1;
                if (LastCharIndex == 0)
                    NextCharIndex = 0;
                else
                    NextCharIndex = random.Next(0, LastCharIndex + 1);
                Password[i] = charGroups[NextGroupIndex][NextCharIndex];
 
                // If we processed the last character in this group, start over.
                if (LastCharIndex == 0)
                    charsLeftInGroup[NextGroupIndex] =
                                              charGroups[NextGroupIndex].Length;
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (LastCharIndex != NextCharIndex)
                    {
                        char temp = charGroups[NextGroupIndex][LastCharIndex];
                        charGroups[NextGroupIndex][LastCharIndex] =
                                    charGroups[NextGroupIndex][NextCharIndex];
                        charGroups[NextGroupIndex][NextCharIndex] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[NextGroupIndex]--;
                }

                // If we processed the last group, start all over.
                if (LastLeftGroupsOrderIndex == 0)
                    LastLeftGroupsOrderIndex = LeftGroupsOrder.Length - 1;
                else
                {
                    if (LastLeftGroupsOrderIndex != NextLeftGroupsOrderIndex)
                    {
                        int temp = LeftGroupsOrder[LastLeftGroupsOrderIndex];
                        LeftGroupsOrder[LastLeftGroupsOrderIndex] =
                                    LeftGroupsOrder[NextLeftGroupsOrderIndex];
                        LeftGroupsOrder[NextLeftGroupsOrderIndex] = temp;
                    }
                    LastLeftGroupsOrderIndex--;
                }
            }
            return new string(Password);
        }

        public static DateTime SetDefaultDate()
        {
            DateTime datetime = Convert.ToDateTime("1/1/1753");
            return datetime;
        }

        public static Age CalculateAge(DateTime DOB)
        {
            int ageYears, ageMonths;

            DateTime now = DateTime.Now;
            ageYears = now.Year - DOB.Year;
            ageMonths = now.Month - DOB.Month;
            ageMonths = (ageMonths == 1 && now.Day < DOB.Day) ? --ageMonths : ageMonths;
            if (now.Month < DOB.Month || (now.Month == DOB.Month && now.Day < DOB.Day))
            {
                --ageYears;
                ageMonths = ageMonths < 0 ? 12 + ageMonths : ageMonths;
                ageMonths = ageMonths == 0 && now.Day < DOB.Day ? 11 : ageMonths;
            }
            return new Age(ageYears, ageMonths);
        }

        

        public static bool IsCAIdNotNull(UserDto User)
        {
            try
            {
                return (User.CAId != null) ? ((User.CAId != 0) ? true : false) : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int? GetCAIdOfUser(UserDto User)
        {
            try
            {
                if (User.CAId == null || User.CAId == 0)
                    return null;
                else
                    return User.UserOfClient.CAId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetDisplayClientID(int SerialNo, string PrefixString, System.DateTime CreatedDate)
        {
            //string[] name = PrefixString.Split(' ');
            //string displayName = "";
            //foreach (string s in name)
            //{
            //    if (s.Substring(0, 1) != "&")
            //    {
            //        displayName += s.Substring(0, 1);
            //    }
            //    if (displayName.Length == 3)
            //        break;
            //}
            string displayId = PrefixString + " " + CreatedDate.ToString("dd") + " " +
                     MonthInRoman(CreatedDate.Month) + " " + CreatedDate.ToString("yy") + " " +
                     SerialNo.ToString("#000");

            return displayId;
        }

        public static string GetClientAdminUserName(int SerialNo, string PrefixString, System.DateTime CreatedDate)
        {
            string adminUserName = PrefixString + CreatedDate.ToString("dd") +
                     MonthInRoman(CreatedDate.Month) + CreatedDate.ToString("yy") + 
                     SerialNo.ToString("#000");

            return adminUserName;
        }

        public static string MonthInRoman(int month)
        {
            string romanMonth = "";
            switch (month)
            {
                case 1: romanMonth = "I"; break;
                case 2: romanMonth = "II"; break;
                case 3: romanMonth = "III"; break;
                case 4: romanMonth = "IV"; break;
                case 5: romanMonth = "V"; break;
                case 6: romanMonth = "VI"; break;
                case 7: romanMonth = "VII"; break;
                case 8: romanMonth = "VII"; break;
                case 9: romanMonth = "IX"; break;
                case 10: romanMonth = "X"; break;
                case 11: romanMonth = "XI"; break;
                case 12: romanMonth = "XII"; break;
            }
            return romanMonth;
        }

        public static string GetMobileNoFromContacts(IList<ContactDetailsDto> contacts)
        {
            ContactDetailsDto contact=new ContactDetailsDto();
            IEnumerable<ContactDetailsDto> mobileContact = contacts.Where(x => x.ContactNoType == ContactType.MobileNo);
            if (mobileContact.Count() > 0)
            {
                contact = mobileContact.FirstOrDefault();
            }
            if (String.IsNullOrEmpty(contact.ContactNo))
                contact.ContactNo = string.Empty;
            return contact.ContactNo;
        }

        public static AddressDto GetInitializedAddressObject(AddressDto address)
        {
            AddressDto newAddress = new AddressDto();
            if (address != null)
            {
                newAddress = address;
            }
            if (newAddress.CityVillage == null)
            {
                newAddress.CityVillage = new Common.Dto.Masters.CityVillageDto
                {
                    DistrictOfCityVillage = new Common.Dto.Masters.DistrictDto
                    {
                        StateOfDistrict = new Common.Dto.Masters.StateDto
                        {
                            StateInCountry = new Common.Dto.Masters.CountryDto()
                        }
                    }
                };
            }
            else if (newAddress.CityVillage.DistrictOfCityVillage == null)
            {
                newAddress.CityVillage.DistrictOfCityVillage = new Common.Dto.Masters.DistrictDto
                {
                    StateOfDistrict = new Common.Dto.Masters.StateDto
                    {
                        StateInCountry = new Common.Dto.Masters.CountryDto()
                    }
                };
            }
            else if (newAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict == null)
            {
                newAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict = new Common.Dto.Masters.StateDto
                {
                    StateInCountry = new Common.Dto.Masters.CountryDto()
                };
            }
            return newAddress;
        }
    }

    public class Age
    {
        public int Years {get; set;}
        public int Months {get; set;}
        public Age(int years, int months) 
        {
            Years = years; 
            Months = months;
        }
    }
}
