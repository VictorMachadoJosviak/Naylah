using Naylah.Xamarin.Controls.Pages;
using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views
{
    public class SplashPage : ContentPageBase
    {
        public SplashPage()
        {

            NavigationPage.SetHasNavigationBar(this, false);

            BackgroundColor = StyleKit.Current.WindowColor;

            Content = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new ActivityIndicator() {IsEnabled = true, IsRunning =true },
                    new Label() {Text = "this is a splash screen to load things", TextColor = Color.White }
                }
            };

        }
    }
}
