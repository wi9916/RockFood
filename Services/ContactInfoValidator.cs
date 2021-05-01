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
        private readonly static string paternPhone = @"(^\+\d{3}\(\d{2}\)\d{3}\s\d{2}\s\d{2}$)|"+
                    @"(^\+380\d{9}$)|(^0\d{9}$)|(^0\d{2}\s\d{3}\s\d{2}\s\d{2}$)";

        private readonly static string paternAddress = @"(^\w{1,}\s\w{1,}[,]\s\w{1,}\.\s\d{1,}[,]\s\w{1,}\.\s\d{1,}$)|" +
                    @"(^\w{1,}\s\w{1,}\.\s\w{1,}\.\d{1,}[,]\s\w{1,}\.\d{1,}$)|(^\w{1,}\.\w{1,}\.\w{1,}((\.)|(\s))\d{1,}$)|" + 
                    @"(^\w{1,}\.\w{1,}\.\w{1,}((\.)|(\s))\d{1,}[,]\s?\w{1,}\s?\.?\d{1,})";

        public static bool CheckAddress(string address)
        {
            if (!Regex.IsMatch(address, paternAddress, RegexOptions.IgnoreCase))
                return false;
            return true;
        }

        public static bool CheckPhone(string phoneNumber)
        {
            if(!Regex.IsMatch(phoneNumber, paternPhone, RegexOptions.IgnoreCase))
                return false;

            return true;
        }
    }
}
