using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            Regex regex = new Regex("^\\d+$");
            Match match = regex.Match(number);
            if (match.Success)
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }

        public string Browse(string url)
        {
            if (!url.Any(c => char.IsDigit(c)))
            {
                return $"Browsing: {url}!";
            }
            else
            {
                return "Invalid URL!";
            }
        }
    }
}
