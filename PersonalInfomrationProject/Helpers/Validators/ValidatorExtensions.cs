using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalInfomrationProject.Helpers.Validators
{
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        public static bool IsValidUsNumber(this string s)
        {
            Regex regex = new Regex(@"^(\([0-9]{3}\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$");
            return regex.IsMatch(s);
        }

       public static bool isAgeLessThan18(this DateTime dob)
        {
            var todayDate = DateTime.Now;
            return ((todayDate.Year - dob.Year - 1) +
                (((todayDate.Month > dob.Month) ||
                ((todayDate.Month == dob.Month) && (todayDate.Day >= dob.Day))) ? 1 : 0))<18;
        }
    }
}
