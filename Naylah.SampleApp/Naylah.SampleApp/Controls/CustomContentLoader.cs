using Naylah.SampleApp.Mvvm;
using Naylah.Xamarin.Controls.Customizations;
using Naylah.Xamarin.Controls.Entrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Controls
{
    public class CustomContentLoader : ContentLoader
    {

        public AppViewModelBase Vm => (AppViewModelBase)BindingContext;

        public CustomContentLoader()
        {
            HideNavigationBar = true;
            HandlePageBack = true;

            SetBinding(IsLoadingProperty, Binding.Create<AppViewModelBase>(vm => vm.IsBusy));

            var activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, Binding.Create<AppViewModelBase>(vm => vm.IsBusy));
            activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, Binding.Create<AppViewModelBase>(vm => vm.IsBusy));

            var entry = new Label();
            entry.Text = "Carregando...";
            entry.HorizontalTextAlignment = TextAlignment.Center;

            var stackLayout = new StackLayout()
            {
                Spacing = 10,
                Padding = 8,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            stackLayout.Children.Add(activityIndicator);
            stackLayout.Children.Add(entry);

            LoadingContent = stackLayout;



        }

    }
}
