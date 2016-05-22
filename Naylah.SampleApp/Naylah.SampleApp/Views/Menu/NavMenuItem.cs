using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views.Menu
{
    public class NavMenuItem : MenuItem
    {

        public string Title { get; set; }

        public Type TargetType { get; set; }

    }
}
