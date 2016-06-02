using Naylah.SampleApp.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naylah.SampleApp.ViewModels
{
    public class EntryDemoViewModel : AppViewModelBase
    {
        private double _someDouble;
        public double SomeDouble
        {
            get { return _someDouble; }
            set { Set(ref _someDouble, value); }
        }

        private string _darkEntry;
        public string DarkEntry
        {
            get { return _darkEntry; }
            set { Set(ref _darkEntry, value); }
        }

        private string _lightEntry;
        public string LightEntry
        {
            get { return _lightEntry; }
            set { Set(ref _lightEntry, value); }
        }


        private int _someInteger;
        public int SomeInteger
        {
            get { return _someInteger; }
            set { _someInteger = value; }
        }

    }
}
