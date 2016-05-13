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
            get
            {
                object o = null;
                CustomProperties.TryGetValue("Naylah.Internal.Theme", out o);
                if (o != null)
                {
                    return (BasicTheme)o;
                }

                return default(BasicTheme);
            }
            set
            {
                CustomProperties["Naylah.Internal.Theme"] = value;
            }
        }


        public EntryBase()
        {
            CustomProperties = new Dictionary<string, object>();
        }

    }

}
