using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public static class ContactInfoValidator
    {
        private readonly static string patternPhone = @"^\+?\d{2}?\d\(?(\d{2})|(\s)\)?\d{3}\s?\d{2}\s?\d{2}";

        private readonly static string patternAddress = @"[А-я]{1,}((\s)|(\.))[А-я]{1,}((\,)|(\.))\s?[А-я]{1,}((\,)|(\.)|(\s))\s?\d{1,}((\,\s?[А-я]{1,}\.?\s?\d{1,})|(\b))";

        public static bool CheckAddress(string address)
        {         
            return Regex.IsMatch(address, patternAddress, RegexOptions.IgnoreCase);
        }

        public static bool CheckPhone(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, patternPhone, RegexOptions.IgnoreCase);
        }
    }
}
