using Naylah.SampleApp.Controls;
using Naylah.SampleApp.ViewModels;
using Naylah.Xamarin.Behaviors;
using Naylah.Xamarin.Controls.Customizations;
using Naylah.Xamarin.Controls.Entrys;
using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views
{
    public class DashboardPage : ContentPageBase
    {

        DashboardViewModel Vm => BindingContext as DashboardViewModel;

        public DashboardPage()
        {
            BindingContext = new DashboardViewModel(); //Replace with your mvvm logic,DI, Locator, etc...
            Vm.IsBusy = true;

            var button = new Button()
            {
                Text = "Another page",
            };

            button.Clicked += async (s, e) => { await Vm.NavigateToAnotherPageWithParameter("dqw"); };

            var button2 = new Button()
            {
                Text = "Entry page",
            };

            button2.Clicked += async (s, e) => { await Vm.NavigateToEntryPage(); };

            var content = new StackLayout()
            {
                Children =
                {
                    button,
                    button2
                }
            };

            var root = new StackLayout()
            {
                Padding = 8,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    content
                }
            };

            var content2 = new CustomContentLoader()
            {
                Content = root
            };

            Content = content2;

        }
    }
}
