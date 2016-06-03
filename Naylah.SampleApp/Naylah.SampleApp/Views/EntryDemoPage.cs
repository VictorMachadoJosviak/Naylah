using Naylah.SampleApp.Controls;
using Naylah.SampleApp.ViewModels;
using Naylah.Xamarin.Behaviors;
using Naylah.Xamarin.Controls.Entrys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views
{
    public class EntryDemoPage : TabbedPage
    {
        public EntryDemoPage()
        {
            Title = "Numeric Entry Double";
            BindingContext = new EntryDemoViewModel(); //Replace with your mvvm logic,DI, Locator, etc...

            #region Numeric Double
            var numericDoubleEntry = new EntryBase()
            {
                Placeholder = "Total de litros"
            };
            numericDoubleEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                }
            );
            numericDoubleEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericDoubleEntryFloat = new FloatLabeledEntry()
            {
                Placeholder = "Total de litros"
            };
            numericDoubleEntryFloat.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                }
            );
            numericDoubleEntryFloat.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericDoubleEntryLight = new EntryBase()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericDoubleEntryLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                }
            );
            numericDoubleEntryLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericDoubleEntryFloatLight = new FloatLabeledEntry()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericDoubleEntryFloatLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                }
            );
            numericDoubleEntryFloatLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericDouble = new StackLayout()
            {
                Padding = 8,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    numericDoubleEntry,
                    numericDoubleEntryFloat,
                    numericDoubleEntryLight,
                    numericDoubleEntryFloatLight
                }
            };

            var numericDoublePage = new ContentPage
            {
                Content = numericDouble,
                Title = "Entry double"
            };
            #endregion

            #region Numeric Double
            var numericIntegerEntry = new EntryBase()
            {
                Placeholder = "Total de litros"
            };
            numericIntegerEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "000",
                    NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            numericIntegerEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));

            var numericIntegerEntryFloat = new FloatLabeledEntry()
            {
                Placeholder = "Total de litros"
            };
            numericIntegerEntryFloat.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "000",
                    NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            numericIntegerEntryFloat.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));

            var numericIntegerEntryLight = new EntryBase()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericIntegerEntryLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "000",
                    NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            numericIntegerEntryLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));

            var numericIntegerEntryFloatLight = new FloatLabeledEntry()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericIntegerEntryFloatLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "000",
                    NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            numericIntegerEntryFloatLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));

            var numericInteger = new StackLayout()
            {
                Padding = 8,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    numericIntegerEntry,
                    numericIntegerEntryFloat,
                    numericIntegerEntryLight,
                    numericIntegerEntryFloatLight
                }
            };

            var numericIntegerPage = new ContentPage
            {
                Content = numericInteger,
                Title = "Entry integer"
            };
            #endregion

            #region Entry
            var darkEntry = new EntryBase { Placeholder = "Dark Entry" };
            darkEntry.SetBinding(Entry.TextProperty, Binding.Create<EntryDemoViewModel>(o => o.DarkEntry, BindingMode.TwoWay));

            var darkEntryFloat = new FloatLabeledEntry { Placeholder = "Dark FloatLabeled" };
            darkEntryFloat.SetBinding(Entry.TextProperty, Binding.Create<EntryDemoViewModel>(o => o.DarkEntry, BindingMode.TwoWay));

            var lightEntry = new EntryBase { Placeholder = "Light Entry", Theme = Xamarin.Controls.Style.BasicTheme.Light };
            lightEntry.SetBinding(Entry.TextProperty, Binding.Create<EntryDemoViewModel>(o => o.LightEntry, BindingMode.TwoWay));

            var lightEntryFloat = new FloatLabeledEntry { Placeholder = "Light FloatLabeled", Theme = Xamarin.Controls.Style.BasicTheme.Light };
            lightEntryFloat.SetBinding(Entry.TextProperty, Binding.Create<EntryDemoViewModel>(o => o.LightEntry, BindingMode.TwoWay));

            var entry = new StackLayout()
            {
                Padding = 8,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    darkEntry,
                    darkEntryFloat,
                    lightEntry,
                    lightEntryFloat
                }
            };

            var entryPage = new ContentPage
            {
                Content = entry,
                Title = "Text entry"
            };
            #endregion

            Children.Add(numericDoublePage);
            Children.Add(numericIntegerPage);
            Children.Add(entryPage);
        }
    }
}
