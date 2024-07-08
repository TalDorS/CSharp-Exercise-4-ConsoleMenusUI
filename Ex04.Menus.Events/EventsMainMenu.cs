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
        private EventsMenuItem m_MainMenuItem;
        private const int k_GoBackOrExitChoice = 0;

        public EventsMainMenu(string i_Title)
        {
            m_MainMenuItem = new EventsMenuItem(i_Title);
        }

        public void AddMenuItem(EventsMenuItem i_MenuItem)
        {
            m_MainMenuItem.AddSubMenuItem(i_MenuItem);
        }

        public void Show()
        {
            while (m_MainMenuItem != null)
            {
                m_MainMenuItem.DisplayMenu();
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

                if(m_MainMenuItem != null)
                {
                    m_MainMenuItem.Execute();
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
                m_MainMenuItem = m_MainMenuItem.Parent;
            }
            else
            {
                if(userInput >= 0 && (userInput - 1) < m_MainMenuItem.SubMenuItems.Count)
                {
                    nextItem = m_MainMenuItem.SubMenuItems[userInput - 1];
                    if (nextItem.SubMenuItems.Count != 0)
                    {
                        m_MainMenuItem = nextItem;
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
                    throw new ValueOutOfRangeException(0, m_MainMenuItem.SubMenuItems.Count);
                }
            }
        }
    }
}
