using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class InterfaceMenuItem 
    {
        private readonly string r_Title;
        private InterfaceMenuItem m_Parent = null;

        public string Title
        {
            get
            {
                return r_Title;
            }
        }

        public InterfaceMenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public InterfaceMenuItem Parent
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
            return this is InterfaceActionMenuItem;
        }

        internal abstract void ExecuteOnClick();
    }
}
