using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionMenuItem : MenuItem
    {
        private readonly IMenuObserver r_Observer;

        public ActionMenuItem(string i_Title, IMenuObserver i_MenuObserver)
           : base(i_Title)
        {
            r_Observer = i_MenuObserver;
        }
        internal override void ExecuteOnClick()
        {
            if (r_Observer != null)
            {
                r_Observer.ActivateUserChoice();
            }
        }
    }
}
