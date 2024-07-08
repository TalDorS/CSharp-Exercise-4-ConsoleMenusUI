using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class EventsActions
    {
        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 24.2.4.9504");
        }

        public static void CountCapitals()
        {
            string sentence = string.Empty;
            int capitalCounter = 0;

            Console.Write("Enter a sentence: ");
            sentence = Console.ReadLine();
            foreach (char character in sentence)
            {
                if (char.IsUpper(character))
                {
                    capitalCounter++;
                }
            }

            Console.WriteLine(String.Format("There are {0} capital letters in your sentence.", capitalCounter));
        }

        public static void ShowTime()
        {
            Console.WriteLine(String.Format("Current Time: {0}", DateTime.Now.ToLongTimeString()));
        }

        public static void ShowDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
        }
    }
}
