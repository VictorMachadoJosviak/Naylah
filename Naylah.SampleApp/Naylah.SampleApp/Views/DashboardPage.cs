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


            var litersTotal = new EntryBase()
            {
                Placeholder = "Total de litros",
            };
            litersTotal.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "N"
                }
            );
            litersTotal.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<DashboardViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var button = new Button()
            {
                Text = "Another page",
            };

            button.Clicked += (s, e) => { Vm.NavigateToAnotherPageWithParameter("dqw"); };

            var content = new StackLayout()
            {
                Children =
                {
                    button
                }
            };


            var root = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    litersTotal,
                    new EntryBase { Placeholder = "dqwdq"},
                    //activityIndicator,
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
