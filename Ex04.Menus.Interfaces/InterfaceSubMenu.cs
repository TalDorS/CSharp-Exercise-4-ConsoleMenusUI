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

        internal override void MenuExecuteHandler()
        {
            Console.Clear();
            ShowSubMenu();
        }

        private void showSubMenuItem()
        {
            int index = 0;

            foreach (InterfaceMenuItem MenuItem in r_SubMenu)
            {
                index++;
                Console.WriteLine("{0} -> {1}", index, MenuItem.Title);
            }
        }

        public void ShowSubMenu()
        {
            string lastMenuOption = GetLastMenuOption();

            Console.WriteLine(string.Format(@"**{0}**
-----------------------", Title));
            showSubMenuItem();
            Console.WriteLine(string.Format(@"0 -> {0}
-----------------------", lastMenuOption));
        }

        public InterfaceMenuItem GetMenuItemByIndex(int i_Index)
        {
            return r_SubMenu[i_Index - 1];
        }

        public string GetLastMenuOption()
        {            
            return (IsMainMenu() ? "Exit" : "Back");
        }
    }
}
