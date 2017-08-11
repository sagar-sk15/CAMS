using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cams.Domain.Entities.Users
{
    public class EmailValidationSpecification
    {
        public bool IsSatisfiedBy(string email)
        {
            Regex emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            return emailregex.IsMatch(email);
        }
    }
}
