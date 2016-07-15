using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;
using Naylah.SampleApp.Views;
using Naylah.Xamarin.Controls.Choosers;
using PCLStorage;

namespace Naylah.SampleApp.ViewModels
{
    public class DashboardViewModel : AppViewModelBase
    {

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;

                await Task.Delay(1000);
            }
            catch (Exception)
            {
                //DialogService.Sh/....
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task NavigateToEntryPage()
        {
            await NavigationService.NavigateAsync(new EntryDemoPage(), null, true);
        }

        public async Task NavigateToAnotherPageWithParameter(string v)
        {
            await NavigationService.NavigateAsync(new AnotherPage(), v, true);
        }

        public async Task NavigateToImagePickerControl()
        {
            await NavigationService.NavigateAsync(new ImageChooserDemoPage(), null, true);
        }

        public async Task NavigateToPickersDemo()
        {
            await NavigationService.NavigateAsync(new PickersDemoPage(), null, true);
        }


    }
}
