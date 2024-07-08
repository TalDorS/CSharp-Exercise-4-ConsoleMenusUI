using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class InterfaceActions
    {
        public class ShowVersion : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                Console.WriteLine("App Version: 23.2.4.9805");
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class CountCapitals : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                string sentence = string.Empty;
                int capitalCounter = 0;

                Console.Write("Please enter your sentence: ");
                sentence = Console.ReadLine();
                foreach (char character in sentence)
                {
                    if (char.IsUpper(character))
                    {
                        capitalCounter++;
                    }
                }

                Console.WriteLine(String.Format("There are {0} capital letters in your sentence.", capitalCounter));
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class ShowDate : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class ShowTime : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                Console.WriteLine(String.Format("Current Time: {0}", DateTime.Now.ToLongTimeString()));
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }
        public static class WaitForUserToPressKeyToContinue
        {
            public static void PromptToPressKey()
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}
