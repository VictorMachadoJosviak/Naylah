using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;

namespace Naylah.SampleApp.ViewModels
{
    public class AnotherViewModel : AppViewModelBase
    {
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            LoadData(parameter as string);
        }

        public override async Task OnNavigatingToAsync(object parameter, NavigationMode mode)
        {
        }

        private async Task LoadData(string s)
        {
        }
    }
}
