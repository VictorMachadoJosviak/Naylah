using Naylah.SampleApp.ViewModels;
using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naylah.SampleApp.Views
{
    public class AnotherPage : ContentPageBase
    {
        public AnotherPage()
        {
            BindingContext = new AnotherViewModel();

        }
    }
}
