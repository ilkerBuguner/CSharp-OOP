using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            bool isValidURL = true;

            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    isValidURL = false;
                }
            }

            if (isValidURL)
            {
                return $"Browsing: {url}!";
            }

            return "Invalid URL!";
        }

        public string Call(string number)
        {
            bool isValidNum = true;

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    isValidNum = false;
                }
            }

            if (isValidNum)
            {
                return $"Calling... {number}";
            }

            return "Invalid number!";
        }

    }
}
