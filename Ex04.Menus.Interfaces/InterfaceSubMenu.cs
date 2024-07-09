using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class InterfaceSubMenu: InterfaceMenuItem
    {
        private readonly List<InterfaceMenuItem> r_SubMenu;

        public List<InterfaceMenuItem> SubMenu
        {
            get
            {
                return r_SubMenu;
            }
        }

        public InterfaceSubMenu(string i_Title) : base(i_Title)
        {
            r_SubMenu = new List<InterfaceMenuItem>();
        }

        public void AddSubMenuItem(InterfaceMenuItem i_MenuItem)
        {
            i_MenuItem.Parent = this;
            r_SubMenu.Add(i_MenuItem);
        }

        internal override void ExecuteOnClick()
        {
            Console.Clear();
            showSubMenu();
        }

        private int showSubMenuItem(int i_Index)
        {
            foreach (InterfaceMenuItem item in r_SubMenu)
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

        public InterfaceMenuItem getMenuItemByIndex(int index)
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
