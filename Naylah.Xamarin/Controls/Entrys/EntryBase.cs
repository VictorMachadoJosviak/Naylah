using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.Xamarin.Controls.Entrys
{
    public class EntryBase : Entry
    {

        public Dictionary<string, object> CustomProperties { get; private set; }


        public BasicTheme Theme
        {
            get { return (BasicTheme)CustomProperties["Naylah.Internal.Theme"]; }
            set { CustomProperties["Naylah.Internal.Theme"] = value; }
        }


        public EntryBase()
        {
            CustomProperties = new Dictionary<string, object>();
        }

    }

}
