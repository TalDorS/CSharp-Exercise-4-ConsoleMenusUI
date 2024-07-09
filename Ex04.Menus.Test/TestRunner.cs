using Ex04.Menus.Events;
using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex04.Menus.Test.InterfaceActions;



namespace Ex04.Menus.Test
{
    public class TestRunner
    {
        public static void RunTest()
        {
            InterfaceMainMenu interfaceMainMenu = initializeAndGetInterfaceMainMenu();
            EventsMainMenu eventsMainMenu = initializeAndGetEventsMainMenu();
            interfaceMainMenu.Show();
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

        private static InterfaceMainMenu initializeAndGetInterfaceMainMenu() 
        {
            InterfaceMainMenu InterfaceMainMenu = new InterfaceMainMenu("Interface Main Menu");
            // Version and capitals item and its sub items
            InterfaceSubMenu versionAndCapitalsItem = new InterfaceSubMenu("Version and Capitals");
            InterfaceActionMenuItem actionItemShowVersion = new InterfaceActionMenuItem("Show Version", new ShowVersion());
            InterfaceActionMenuItem countCapitalsItem = new InterfaceActionMenuItem("Count Capitals", new CountCapitals());
            // show date/time item and its sub items
            InterfaceSubMenu dateTimeItem = new InterfaceSubMenu("Show Date/Time");
            InterfaceActionMenuItem actionItemShowTime = new InterfaceActionMenuItem("Show Time", new ShowTime());
            InterfaceActionMenuItem actionItemShowDate = new InterfaceActionMenuItem("Show Date", new ShowDate());
            // Add items to their menus
            versionAndCapitalsItem.AddSubMenuItem(actionItemShowVersion);
            versionAndCapitalsItem.AddSubMenuItem(countCapitalsItem);
            dateTimeItem.AddSubMenuItem(actionItemShowTime);
            dateTimeItem.AddSubMenuItem(actionItemShowDate);
            InterfaceMainMenu.AddMainMenuItem(versionAndCapitalsItem);
            InterfaceMainMenu.AddMainMenuItem(dateTimeItem);

            return InterfaceMainMenu;
        }
    }
}
