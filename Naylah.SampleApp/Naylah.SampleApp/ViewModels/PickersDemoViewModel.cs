using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Naylah.Xamarin.Services.NavigationService;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace Naylah.SampleApp.ViewModels
{
    public class PickersDemoViewModel : AppViewModelBase
    {

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { Set(ref _selectedPerson, value); }
        }




        private ObservableCollection<Person> _personsList;

        public ObservableCollection<Person> PersonsList
        {
            get { return _personsList; }
            set { Set(ref _personsList, value); }
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
            SelectedPerson = null;

            var personsList = new ObservableCollection<Person>();
            personsList.Add(new Person() { Name = "Peter" });
            personsList.Add(new Person() { Name = "Joana" });
            personsList.Add(new Person() { Name = "Naylah" });

            PersonsList = personsList;

            SelectedPerson = PersonsList[1];

        }

        public PickersDemoViewModel()
        {

        }


        public class Person : ObservableObject
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { Set(ref _name, value); }
            }

        }
        
    }
    
}
