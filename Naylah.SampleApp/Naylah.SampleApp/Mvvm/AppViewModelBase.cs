using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naylah.SampleApp.Mvvm
{
    public class AppViewModelBase : ViewModelBase
    {
        public new INavigationService NavigationService { get { return App.CurrentApp.NavigationService; } }


    }
}
