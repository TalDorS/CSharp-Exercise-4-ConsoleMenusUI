using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu: MenuItem
    {
        private readonly List<MenuItem> r_SubMenu;
        private int m_NumOfSubItems;

        public int NumOfSubItems
        {
            get
            {
                return m_NumOfSubItems;
            }
            private set
            {
                m_NumOfSubItems = value;
            }
        }

        public SubMenu(string i_Title) : base(i_Title)
        {
            r_SubMenu = new List<MenuItem>();
            m_NumOfSubItems = 0;
        }

        public void AddSubMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.Parent = this;
            r_SubMenu.Add(i_MenuItem);
            m_NumOfSubItems++;
        }

        internal override void ExecuteOnClick()
        {
            Console.Clear();
            showSubMenu();
        }
        private int showSubMenuItem(int i_Index)
        {
            foreach (MenuItem item in r_SubMenu)
            {
                i_Index++;
                Console.WriteLine("{0} -> {1}", i_Index, item.Title);
            }

            return i_Index;
        }
        public void showSubMenu()
        {
            string lastMenuOption = getLastMenuOption();
            int menuOptionIndex = 0;

            Console.WriteLine("**{0}**", Title);
            Console.WriteLine("-----------------------");
            menuOptionIndex = showSubMenuItem(menuOptionIndex);
            Console.WriteLine("0 -> {0}", lastMenuOption);
            Console.Write(Environment.NewLine);
        }

        public MenuItem getMenuItemByIndex(int index)
        {
            return r_SubMenu[index - 1];
        }

        public string getLastMenuOption()
        {
            string lastMenuOption;
            if (IsMainMenu())
            {
                lastMenuOption = "Exit";
            }
            else
            {
                lastMenuOption = "Back";
            }
            
            return lastMenuOption;
        }

    }
}
