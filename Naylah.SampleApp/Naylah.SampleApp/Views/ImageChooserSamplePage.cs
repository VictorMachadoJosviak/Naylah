using FFImageLoading.Forms;
using Naylah.SampleApp.ViewModels;
using Naylah.Xamarin.Behaviors;
using Naylah.Xamarin.Controls.Entrys;
using Naylah.Xamarin.Controls.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views
{
    public class ImageChooserSamplePage : ContentPageBase
    {
        public ImageChooserSampleViewModel Vm => (ImageChooserSampleViewModel)this.BindingContext;

        public ImageChooserSamplePage()
        {
            BindingContext = new ImageChooserSampleViewModel();
            CreateUI();
        }

        private void CreateUI()
        {
            Title = "Image Chooser Sample";

            var stackLayout = new StackLayout();

            var imageWidthEntry = new FloatLabeledEntry()
            {
                Placeholder = "Requested Width"
            };
            imageWidthEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "N0",
                    //NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            imageWidthEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty, Binding.Create<ImageChooserSampleViewModel>(vm => vm.ImageWidthRequested, BindingMode.TwoWay));

            var imageHeightEntry = new FloatLabeledEntry()
            {
                Placeholder = "Requested Height"
            };
            imageHeightEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "N0",
                    //NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            imageHeightEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty, Binding.Create<ImageChooserSampleViewModel>(vm => vm.ImageHeightRequested, BindingMode.TwoWay));

            var image = new CachedImage()
            {

            };
            image.SetBinding(CachedImage.SourceProperty, Binding.Create<ImageChooserSampleViewModel>(vm => vm.ImageSourceAsString));

            stackLayout.Spacing = 12;
            stackLayout.Padding = 12;

            stackLayout.Children.Add(image);
            stackLayout.Children.Add(imageWidthEntry);
            stackLayout.Children.Add(imageHeightEntry);

            var chooseImageButton = new Button() { Text = "Open Image Chooser" };
            chooseImageButton.Clicked += async (s, e) => { await Vm.ChooseImage(); };

            stackLayout.Children.Add(chooseImageButton);

            var scroviewer = new ScrollView() { Content = stackLayout };
            Content = scroviewer;
        }
    }
}
