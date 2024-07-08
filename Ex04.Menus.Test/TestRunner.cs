using Ex04.Menus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex04.Menus.Events.EventsMainMenu;
using static Ex04.Menus.Events.EventsMenuItem;

namespace Ex04.Menus.Test
{
    public class TestRunner
    {
        public static void RunTest()
        {
            EventsMainMenu eventsMainMenu = initializeAndGetEventsMainMenu();

            eventsMainMenu.Show();
        }

        private static EventsMainMenu initializeAndGetEventsMainMenu()
        {
            EventsMainMenu eventsMainMenu = new EventsMainMenu("Events Main Menu");
            // Version and capitals item and its sub items
            EventsMenuItem versionAndCapitalsItem = new EventsMenuItem("Version and Capitals");
            EventsMenuItem showVersionItem = new EventsMenuItem("Show Version", EventsActions.ShowVersion);
            EventsMenuItem countCapitalsItem = new EventsMenuItem("Count Capitals", EventsActions.CountCapitals);
            // show date/time item and its sub items
            EventsMenuItem dateTimeItem = new EventsMenuItem("Show Date/Time");
            EventsMenuItem showTimeItem = new EventsMenuItem("Show Time", EventsActions.ShowTime);
            EventsMenuItem showDateItem = new EventsMenuItem("Show Date", EventsActions.ShowDate);

            // Add items to their menus
            versionAndCapitalsItem.AddSubMenuItem(showVersionItem);
            versionAndCapitalsItem.AddSubMenuItem(countCapitalsItem);
            dateTimeItem.AddSubMenuItem(showTimeItem);
            dateTimeItem.AddSubMenuItem(showDateItem);
            eventsMainMenu.AddMenuItem(versionAndCapitalsItem);
            eventsMainMenu.AddMenuItem(dateTimeItem);

            return eventsMainMenu;
        }
    }
}
