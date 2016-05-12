using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.Xamarin.Controls.Customizations
{
    public abstract class HeaderedLayout : StackLayout
    {
        public static BindableProperty ThemeProperty =
            BindableProperty.Create(nameof(Theme), typeof(BasicTheme), typeof(HeaderedLayout), default(BasicTheme));

        public BasicTheme Theme
        {
            get { return (BasicTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }



        public string Placeholder
        {
            get { return Header.Text; }
            set { Header.Text = value; }
        }

        public Label Header { get; private set; }
        public StackLayout HeaderLayout { get; private set; }

        public virtual View Content { get; set; }

        public HeaderedLayout()
        {
            Header = new Label();
            HeaderLayout = new StackLayout();

            Header.TextColor = Theme == BasicTheme.Dark ? Color.Black : Color.White;

            if (Device.OS == TargetPlatform.iOS)
            {
                Header.FontSize = 11;
                Header.FontAttributes = FontAttributes.Bold;
                Spacing = 0;
            }
            else
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    Header.FontSize = 12;
                    HeaderLayout.Padding = new Thickness(4, 0, 0, 0);
                    Header.TextColor = Color.FromHex("#666666");
                    Spacing = 0;
                }
            }

            HeaderLayout.Children.Add(Header);
            Children.Add(HeaderLayout);
        }
    }

    public class CustomHeaderedLayout : HeaderedLayout
    {

        public CustomHeaderedLayout(View view) : base()
        {
            Content = view;
            Children.Add(view);
        }
    }

    public static class CustomHeaderedLayoutExtensions
    {
        public static CustomHeaderedLayout AsCustomHeadered(this View view)
        {
            return new CustomHeaderedLayout(view);
        }

    }

}
