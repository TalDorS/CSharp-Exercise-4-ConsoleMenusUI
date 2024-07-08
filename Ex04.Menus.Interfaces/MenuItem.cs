using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem 
    {
        private readonly string r_Title;
        private MenuItem m_Parent = null;

        public string Title
        {
            get
            {
                return r_Title;
            }
        }
        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }
        public MenuItem Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public bool IsMainMenu()
        {
            return m_Parent == null;
        }

        internal bool IsActionMenuItem()
        {
            return this is ActionMenuItem;
        }
        internal abstract void ExecuteOnClick();
    }
}
