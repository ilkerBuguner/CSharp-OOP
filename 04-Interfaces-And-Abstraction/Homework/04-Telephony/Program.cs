using System;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            Smartphone s = new Smartphone();
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                Console.WriteLine(s.Call(phoneNumbers[i]));
            }

            string[] urls = Console.ReadLine().Split();

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine(s.Browse(urls[i]));
            }
        }
    }
}
