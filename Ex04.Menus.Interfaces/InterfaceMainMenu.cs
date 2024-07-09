﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class InterfaceMainMenu
    {
        private const int k_GoBackOrExit = 0;
        private InterfaceSubMenu m_MainMenu;

        public InterfaceMainMenu(string i_Title)
        {
            m_MainMenu = new InterfaceSubMenu(i_Title);
        }

        public void AddMainMenuItem(InterfaceMenuItem i_MenuItem)
        {
            m_MainMenu.AddSubMenuItem(i_MenuItem);
        }

        private bool isUserInputInRange(int i_InputFromUser, InterfaceMenuItem i_MenuItem)
        {
            return (i_InputFromUser >= 0 && i_InputFromUser <= (i_MenuItem as InterfaceSubMenu).SubMenu.Count);
        }

        public void Show()
        {
            InterfaceMenuItem currentMenuItem = m_MainMenu;

            while (currentMenuItem != null)
            {
                currentMenuItem.MenuExecuteHandler();
                goBackIfAction(ref currentMenuItem);
                try
                {
                    updateMenuItemsFromUser(ref currentMenuItem);
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    promptUserToPressKeyToContinue();
                }
                catch (FormatException fromatException)
                {
                    Console.WriteLine(fromatException.Message);
                    promptUserToPressKeyToContinue();
                }
            }
        }
        private void goBackIfAction(ref InterfaceMenuItem i_CurrentMenuItem)
        {
            if (i_CurrentMenuItem.IsActionMenuItem())
            {
                goBack(ref i_CurrentMenuItem);
                i_CurrentMenuItem.MenuExecuteHandler();
            }
        }

        private void goBack(ref InterfaceMenuItem i_CurrentMenuItem)
        {
            i_CurrentMenuItem = i_CurrentMenuItem.Parent;
        }

        private void updateMenuItemsFromUser(ref InterfaceMenuItem i_CurrentMenuItem)
        {
            Console.WriteLine("Enter your request: (1-{0} or press '0' to {1})", (i_CurrentMenuItem as InterfaceSubMenu).SubMenu.Count, (i_CurrentMenuItem as InterfaceSubMenu).GetLastMenuOption());
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (!isUserInputInRange(userInput, i_CurrentMenuItem))
                {
                    throw new ValueOutOfRangeException(0, (i_CurrentMenuItem as InterfaceSubMenu).SubMenu.Count);
                }

                if (userInput == k_GoBackOrExit)
                {
                    goBack(ref i_CurrentMenuItem);
                }
                else
                {
                    Console.Clear();
                    goToUserChoice(ref i_CurrentMenuItem, userInput);
                }
            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }

        private void goToUserChoice(ref InterfaceMenuItem i_CurrentMenuItem, int i_UserInput)
        {
            if (i_CurrentMenuItem is InterfaceSubMenu)
            {
                i_CurrentMenuItem = (i_CurrentMenuItem as InterfaceSubMenu).GetMenuItemByIndex(i_UserInput);
            }
        }

        private void promptUserToPressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
