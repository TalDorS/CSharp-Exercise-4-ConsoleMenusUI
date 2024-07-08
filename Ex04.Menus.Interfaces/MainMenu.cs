using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const int k_GoBackOrExit = 0;
        private SubMenu m_MainMenu;

        public MainMenu(string i_ItemTitle)
        {
            m_MainMenu = new SubMenu(i_ItemTitle);
        }

        public void AddMainMenuItem(MenuItem i_MenuItem)
        {
            m_MainMenu.AddSubMenuItem(i_MenuItem);
        }

        private bool isUserInputInRange(int i_Input, MenuItem i_MenuItem)
        {
            return (i_Input >= 0 && i_Input <= (i_MenuItem as SubMenu).NumOfSubItems);
        }

        public void Show()
        {
            MenuItem currentMenuItem = m_MainMenu;
            while (currentMenuItem != null)
            {
                currentMenuItem.ExecuteOnClick();
                goBackIfAction(ref currentMenuItem);

                try
                {
                    updateMenuItemsFromUser(ref currentMenuItem);
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    promptUserToPressEnterToContinue();
                }
                catch (FormatException fromatException)
                {
                    Console.WriteLine(fromatException.Message);
                    promptUserToPressEnterToContinue();
                }
            }
        }
        private void goBackIfAction(ref MenuItem i_CurrentMenuItem)
        {
            if (i_CurrentMenuItem.IsActionMenuItem())
            {
                goBack(ref i_CurrentMenuItem);
                i_CurrentMenuItem.ExecuteOnClick();
            }
        }

        private void goBack(ref MenuItem i_CurrentMenuItem)
        {
            i_CurrentMenuItem = i_CurrentMenuItem.Parent;
        }

        private void updateMenuItemsFromUser(ref MenuItem i_CurrentMenuItem)
        {
            Console.WriteLine("Enter your request: (1-{0} or press '0' to {1})", (i_CurrentMenuItem as SubMenu).NumOfSubItems, (i_CurrentMenuItem as SubMenu).getLastMenuOption());

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (!isUserInputInRange(userInput, i_CurrentMenuItem))
                {
                    throw new ValueOutOfRangeException(0,2);
                }

                if (userInput == k_GoBackOrExit)
                {
                    goBack(ref i_CurrentMenuItem);
                }
                else
                {
                    goToUserChoice(ref i_CurrentMenuItem, userInput);
                }
            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }

        private void goToUserChoice(ref MenuItem i_CurrentMenuItem, int i_UserInput)
        {
            if (i_CurrentMenuItem is SubMenu)
            {
                i_CurrentMenuItem = (i_CurrentMenuItem as SubMenu).getMenuItemByIndex(i_UserInput);
            }
        }

        private void promptUserToPressEnterToContinue()
        {
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
