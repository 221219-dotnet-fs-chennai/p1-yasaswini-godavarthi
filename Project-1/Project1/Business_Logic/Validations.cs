using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class Validations
    {
        public static string IsValidEmailId(string str)
        {

            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!Regex.IsMatch(str, pattern))
            {
                throw new Exception("Email is not correct");
            }
            else
            {
                return str;
            }
        }

        public static string IsValidPassword(string str)
        {
            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            if (!Regex.IsMatch(str, pattern))
            {
                 throw new Exception("Password pattern is not correct");
            }
            else
            {
                return str;
            }
        }



        public static string IsValidMobileNumber(string str)
    {
        string pattern = @"^\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}$";
        if (!Regex.IsMatch(str, pattern))
        {
                throw new Exception("Mobile number is not correct");
            }
        else
        {
            return str;
        }
    }

    }
}
