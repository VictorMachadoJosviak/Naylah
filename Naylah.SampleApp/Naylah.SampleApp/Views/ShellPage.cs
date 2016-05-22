using Naylah.SampleApp.ViewModels;
using Naylah.SampleApp.Views.Menu;
using Naylah.Xamarin.Controls.Pages;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views
{
    public class ShellPage : MasterDetailNavigationPage
    {
        public ShellViewModel Vm => this.BindingContext as ShellViewModel;
        public ShellPage()
        {
            BindingContext = new ShellViewModel(); //Replace.....


            ((NavigationPage)Detail).BarBackgroundColor = Color.Red;//StyleKit.Primary;
            ((NavigationPage)Detail).BarTextColor = Color.White;

            var btGoTODash = new Button() { Text = "NavigateToDashboard"};
            btGoTODash.Clicked += (s, e) => { Vm.NavigateToSelectedMenuItem(MenuListData.Dashboard); };

            Master = new ContentPage() { Title = "This is the menu", BackgroundColor = Color.Gray, Content = new StackLayout() { Children = { btGoTODash }, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center } };

            IsGestureEnabled = true;

        }

        public void NavigationService_Navigating(object sender, EventArgs e)
        {
            try
            {
                IsPresented = false;
            }
            catch (Exception)
            {
            }

        }

        public void NavigationService_Navigated(object sender, EventArgs e)
        {
            try
            {
                //MasterAsMenuPage.SelectByPage(Vm.NavigationService.CurrentPage);
            }
            catch (Exception)
            {
            }

        }
    }

  
}
