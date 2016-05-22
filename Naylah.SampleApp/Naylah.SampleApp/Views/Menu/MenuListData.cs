using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naylah.SampleApp.Views.Menu
{
    public class MenuListData
    {

        //public static List<NavMenuItem> TopItems { get; set; }
        //public static List<NavMenuItem> BottomItems { get; set; }

        public static NavMenuItem Dashboard { get; }
        //public static NavMenuItem Settings { get; }

        static MenuListData()
        {

            Dashboard =
                new NavMenuItem()
                {
                    Title = "Menu Inicial",
                    //Icon = "ic_home",
                    TargetType = typeof(DashboardPage),
                };

            //TopItems = new List<NavMenuItem>()
            //{
            //    Dashboard,
            //};

            //BottomItems = new List<NavMenuItem>()
            //{
            //    Settings
            //};

        }

    }
}
