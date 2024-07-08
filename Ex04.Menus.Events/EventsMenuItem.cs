using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{

    public class EventsMenuItem
    {
        private readonly string r_Title;
        private EventsMenuItem m_Parent;
        private List<EventsMenuItem> m_SubMenuItems;
        private event Action m_Action;

        public string Title
        {
            get { return r_Title; }
        }

        public List<EventsMenuItem> SubMenuItems
        {
            get { return m_SubMenuItems; }
        }

        public Action Action
        {
            get { return m_Action; }
        }

        public EventsMenuItem Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }

        public EventsMenuItem(string i_Title, Action i_Action)
        {
            r_Title = i_Title;
            m_Action += i_Action;
            m_SubMenuItems = new List<EventsMenuItem>();
        }

        public EventsMenuItem(string i_Title)
        {
            r_Title = i_Title;
            m_Action = null;
            m_SubMenuItems = new List<EventsMenuItem>();
        }

        public void AddSubMenuItem(EventsMenuItem i_SubMenuItem)
        {
            m_SubMenuItems.Add(i_SubMenuItem);
            i_SubMenuItem.Parent = this;
        }

        public void DisplayMenu()
        {
            string backOrExitStr = string.Empty;

            Console.Clear();
            Console.WriteLine(string.Format(@"**{0}**
-----------------------", this.Title));
            for (int i = 0; i < m_SubMenuItems.Count; i++)
            {
                Console.WriteLine(string.Format("{0} -> {1}", i + 1, m_SubMenuItems[i].Title));
            }

            backOrExitStr = getBackOrExit();
            Console.WriteLine(string.Format(@"0 -> {0}
-----------------------
Enter your request: (1 to {1} or press '0' to {0})", backOrExitStr, m_SubMenuItems.Count));
        }

        private string getBackOrExit()
        {
            return (isItemMainMenu() ? "Exit" : "Back");
        }

        private bool isItemMainMenu()
        {
            return m_Parent == null;
        }

        public void Execute()
        {
            Action?.Invoke();
        }
    }
}
