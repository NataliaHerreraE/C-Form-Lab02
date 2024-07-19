using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part_II.VALIDATION
{
    public class Validator
    {
        public static bool IsValidId(string id)
        {
            return (Regex.IsMatch(id, @"^\d+$"));
        }
        public static bool IsValidPassword(string password)
        {
            if (password.Length == 0 || password.Length > 20)
            {
                return false;
            }
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                {
                    hasUpperCase = true;
                }
                if (Char.IsLower(password[i]))
                {
                    hasLowerCase = true;
                }
                if (Char.IsDigit(password[i]))
                {
                    hasDigit = true;
                }
                if (Char.IsSymbol(password[i]) || Char.IsPunctuation(password[i]))
                {
                    hasSpecialChar = true;
                }
            }
            if (hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar)
            {
                return true;
            }
            return false;

        }
    }
}
