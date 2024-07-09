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
                EventsActions.ShowVersion();
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class CountCapitals : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                EventsActions.CountCapitals();
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class ShowDate : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                EventsActions.ShowDate();
                WaitForUserToPressKeyToContinue.PromptToPressKey();
            }
        }

        public class ShowTime : IMenuObserver
        {
            public void ActivateUserChoice()
            {
                EventsActions.ShowTime();
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
