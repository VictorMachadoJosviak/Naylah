using Naylah.Xamarin.Services.NavigationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naylah.SampleApp.Mvvm
{
    public abstract class ViewModelBase :
         GalaSoft.MvvmLight.ViewModelBase, INavigable
    {

        public virtual INavigationService NavigationService { get; }
        //public virtual IDialogServiceExt DialogService { get; private set; }


        public virtual async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
        }

        public virtual async Task OnNavigatedFromAsync()
        {
        }

        public virtual async Task OnNavigatingToAsync(object parameter, NavigationMode mode)
        {
        }

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { Set(ref _isBusy, value); } }
    }
}
