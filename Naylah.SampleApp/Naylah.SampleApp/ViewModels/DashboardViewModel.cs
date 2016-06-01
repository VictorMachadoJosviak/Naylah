using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;
using Naylah.SampleApp.Views;

namespace Naylah.SampleApp.ViewModels
{
    public class DashboardViewModel : AppViewModelBase
    {
        private double _someDouble;

        public double SomeDouble
        {
            get { return _someDouble; }
            set { Set(ref _someDouble, value); }
        }



        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;

                await Task.Delay(3000);
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

        public async Task NavigateToAnotherPageWithParameter(string v)
        {
            await NavigationService.NavigateAsync(new AnotherPage(), v, true);
        }
    }
}
