using Naylah.Xamarin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.Xamarin.Controls.Style
{
    public class StyleKit
    {
        public static StyleKit Current = BootStrapper.CurrentApp.StyleKit;

        public string Name { get; set; }

        public BasicTheme Theme { get; set; } = BasicTheme.Light;

        public Color PrimaryColor { get; set; }
        public Color PrimaryDarkColor { get; set; }
        public Color PrimaryLightColor { get; set; }

        public Color SecondaryColor { get; set; }
        public Color SecondaryDarkColor { get; set; }

        public Color AccentColor { get; set; }

        public Color BackgroundColor { get; set; }
        public Color BackgroundDarkColor { get; set; }

        public Color PrimaryTextColor { get; set; }
        public Color SecondaryTextColor { get; set; }

        public Color WindowColor { get; set; }
        public Color DividerColor { get; set; }


        public Action Customizations;

    }
}
