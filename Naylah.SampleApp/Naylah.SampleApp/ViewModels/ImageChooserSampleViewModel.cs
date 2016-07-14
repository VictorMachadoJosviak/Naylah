using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;
using Naylah.Xamarin.Controls.Choosers;
using PCLStorage;

namespace Naylah.SampleApp.ViewModels
{
    public class ImageChooserSampleViewModel : AppViewModelBase
    {

        private string _imageSourceAsString;

        public string ImageSourceAsString
        {
            get { return _imageSourceAsString; }
            set { Set(ref _imageSourceAsString, value); }
        }

        private int _imageWidthRequested;

        public int ImageWidthRequested
        {
            get { return _imageWidthRequested; }
            set { Set(ref _imageWidthRequested, value); }
        }


        private int _imageHeightRequested;

        public int ImageHeightRequested
        {
            get { return _imageHeightRequested; }
            set { Set(ref _imageHeightRequested, value); }
        }





        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (mode == NavigationMode.New)
            {
                await LoadData();
            }
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;

                ImageWidthRequested = 512;
                ImageHeightRequested = 512;

                ImageSourceAsString = "https://raw.githubusercontent.com/NaylahProject/Naylah.Toolkit.UWP/master/NaylahLogo.png";

            }
            catch (Exception)
            {
            }
            finally
            {
                IsBusy = true;
            }
        }

        public  async Task ChooseImage()
        {
            var imgChooser =

                ImageChooser.CreateImageChooser(
                    new ImageChooser.ImageChooserOptions()
                    {
                        Title = "Image Chooser",
                        ActualImageUri = new Uri(ImageSourceAsString),
                        SelectionButtonText = "Select",
                        SizeRequested = new global::Xamarin.Forms.Size(ImageWidthRequested, ImageHeightRequested),
                        DoneSelectionAction = GetDoneeee,
                        ExceptionOccurredAction = Sadddd
                    });

            await NavigationService.NavigateAsync(
                imgChooser, null, true);
        }

        private async Task GetDoneeee(IFile arg)
        {
            ImageSourceAsString = arg.Path;

            await NavigationService.GoBack();
        }

        private void Sadddd(Exception obj)
        {

        }
    }
}
