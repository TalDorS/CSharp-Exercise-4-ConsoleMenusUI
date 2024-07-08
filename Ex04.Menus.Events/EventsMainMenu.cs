using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex04.Menus.Events.EventsMenuItem;

namespace Ex04.Menus.Events
{
    public class EventsMainMenu
    {
        private EventsMenuItem m_CurrentMenuItem;
        private const int k_GoBackOrExitChoice = 0;

        public EventsMainMenu(string i_Title)
        {
            m_CurrentMenuItem = new EventsMenuItem(i_Title);
        }

        public void AddMenuItem(EventsMenuItem i_MenuItem)
        {
            m_CurrentMenuItem.AddSubMenuItem(i_MenuItem);
        }

        public void Show()
        {
            while (m_CurrentMenuItem != null)
            {
                m_CurrentMenuItem.DisplayMenu();
                try
                {
                    getMenuItemFromUser();
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("{0}", e.Message));
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }

                if(m_CurrentMenuItem != null)
                {
                    m_CurrentMenuItem.Execute();
                }
            }
        }

        private void getMenuItemFromUser()
        {
            string input = Console.ReadLine();
            bool isSuccesfulParsing = int.TryParse(input, out int userInput);
            EventsMenuItem nextItem = null;

            if (!isSuccesfulParsing)
            {
                throw new FormatException("Invalid input, the input must be a number.");
            }

            if (userInput == k_GoBackOrExitChoice) 
            {
                m_CurrentMenuItem = m_CurrentMenuItem.Parent;
            }
            else
            {
                if(userInput >= 0 && (userInput - 1) < m_CurrentMenuItem.SubMenuItems.Count)
                {
                    nextItem = m_CurrentMenuItem.SubMenuItems[userInput - 1];
                    if (nextItem.SubMenuItems.Count != 0)
                    {
                        m_CurrentMenuItem = nextItem;
                    }
                    else
                    {
                        Console.Clear();
                        nextItem.Execute();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_CurrentMenuItem.SubMenuItems.Count);
                }
            }
        }
    }
}
