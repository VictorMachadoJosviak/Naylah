using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Styles
{
    public class DefaultAppStyleKit : StyleKit
    {
        public DefaultAppStyleKit()
        {
            PrimaryColor = Color.FromHex("#9C27B0");
            PrimaryDarkColor = Color.FromHex("#7B1FA2");
            PrimaryLightColor = Color.FromHex("#E1BEE7");
            SecondaryColor = Color.FromHex("#9C27B0");
            SecondaryDarkColor = Color.FromHex("#7B1FA2");
            AccentColor = Color.FromHex("#FF4081");
            PrimaryTextColor = Color.FromHex("#212121");
            SecondaryTextColor = Color.FromHex("#ffffff");
            DividerColor = Color.FromHex("#B6B6B6");
            WindowColor = PrimaryDarkColor;
        }
    }


}
