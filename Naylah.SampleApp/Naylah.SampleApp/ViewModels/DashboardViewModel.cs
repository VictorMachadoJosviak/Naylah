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
            var imgChooser =

                ImageChooser.CreateImageChooser(
                    new ImageChooser.ImageChooserOptions()
                    {
                        Title = "Image Chooser T",
                        ActualImageUri = new Uri("https://raw.githubusercontent.com/NaylahProject/Naylah.Toolkit.UWP/master/NaylahLogo.png"),
                        SelectionButtonText = "Select T",
                        SizeRequested = new global::Xamarin.Forms.Size(200, 200),
                        DoneSelectionAction = GetDoneeee,
                        ExceptionOccurredAction = Sadddd
                    });

            await NavigationService.NavigateAsync(
                imgChooser, null, true);
        }

        private async Task GetDoneeee(IFile arg)
        {
            await Task.Delay(5000);

            await NavigationService.GoBack();
        }

        private void Sadddd(Exception obj)
        {
            
        }
    }
}
