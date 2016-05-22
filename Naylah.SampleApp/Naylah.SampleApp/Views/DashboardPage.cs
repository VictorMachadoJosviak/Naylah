using Naylah.SampleApp.ViewModels;
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

            var activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, Binding.Create<DashboardViewModel>(vm => vm.IsBusy));

            var button = new Button()
            {
                Text = "Another page",
            };

            button.Clicked += (s, e) => { Vm.NavigateToAnotherPageWithParameter("sss"); };

            var content = new StackLayout()
            {
                Children =
                {
                    button
                }
            };


            Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    activityIndicator,
                    content
                }
            };
        }
    }
}
