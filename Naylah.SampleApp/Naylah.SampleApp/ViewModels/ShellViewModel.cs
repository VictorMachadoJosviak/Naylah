using Naylah.SampleApp.Mvvm;
using Naylah.SampleApp.Views.Menu;
using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.ViewModels
{
    public class ShellViewModel : AppViewModelBase
    {
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            await NavigateToSelectedMenuItem(MenuListData.Dashboard);

        }

        public async Task NavigateToSelectedMenuItem(NavMenuItem navMenuItem)
        {


            if (navMenuItem == null)
                return;

            try
            {
                Page displayPage = (Page)Activator.CreateInstance(navMenuItem.TargetType);

                if (navMenuItem == MenuListData.Dashboard)
                {
                    await NavigationService.NavigateSetRootAsync(displayPage, null, true);
                }
                else
                {
                    await NavigationService.ClearHistory();
                    await NavigationService.NavigateAsync(displayPage, null, true);
                }

                displayPage.Title = navMenuItem.Title;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "Erro " + ex.Message, "OK");
            }
            finally
            {
            }
        }
    }
}
