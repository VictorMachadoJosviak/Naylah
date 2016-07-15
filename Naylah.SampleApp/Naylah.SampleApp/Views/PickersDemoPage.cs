using Naylah.SampleApp.ViewModels;
using Naylah.Xamarin.Controls.Customizations;
using Naylah.Xamarin.Controls.Pages;
using Naylah.Xamarin.Controls.Pickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Naylah.SampleApp.ViewModels.PickersDemoViewModel;

namespace Naylah.SampleApp.Views
{
    public class PickersDemoPage : ContentPageBase
    {
        public PickersDemoViewModel Vm => (PickersDemoViewModel)BindingContext;

        public PickersDemoPage()
        {
            BindingContext = new PickersDemoViewModel();

            CreateUI();

        }

        private void CreateUI()
        {

            var personSelectedLabel = new Label().AsCustomHeadered();
            personSelectedLabel.Content.SetBinding(Label.TextProperty, Binding.Create<PickersDemoViewModel>(vm => vm.SelectedPerson.Name));
            personSelectedLabel.Header.Text = "Selected Person";

            var bindablePicker = new BindablePicker();
            bindablePicker.Title = "Bindable Picker";
            bindablePicker.SetBinding(BindablePicker.ItemsSourceProperty, Binding.Create<PickersDemoViewModel>(vm => vm.PersonsList));
            bindablePicker.SetBinding(BindablePicker.SelectedItemProperty, Binding.Create<PickersDemoViewModel>(vm => vm.SelectedPerson, BindingMode.TwoWay));
            bindablePicker.SourceItemLabelConverter = PersonLabelConverter;
            bindablePicker.SyncronizationType = BindablePicker.PickerSyncronizationType.SelectedOrDone;
            bindablePicker.FloatLabeledStyle = true;

            var stackLayout = new StackLayout() { Spacing = 12, Padding = 12};
            stackLayout.Children.Add(personSelectedLabel);
            stackLayout.Children.Add(bindablePicker);

            Content = stackLayout;



        }

        private string PersonLabelConverter(object arg)
        {
            var person = arg as Person;

            if (person != null)
            {
                return person.Name;
            }

            return ":(";
        }
    }
}
