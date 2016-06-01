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
            Title = "Entry";
            BindingContext = new EntryDemoViewModel(); //Replace with your mvvm logic,DI, Locator, etc...

            #region Numeric
            var numericEntry = new EntryBase()
            {
                Placeholder = "Total de litros"
            };
            numericEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "N"
                }
            );
            numericEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericEntryFloat = new FloatLabeledEntry()
            {
                Placeholder = "Total de litros"
            };
            numericEntryFloat.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "N"
                }
            );
            numericEntryFloat.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericEntryLight = new EntryBase()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericEntryLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "N"
                }
            );
            numericEntryLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericEntryFloatLight = new FloatLabeledEntry()
            {
                Theme = Xamarin.Controls.Style.BasicTheme.Light,
                Placeholder = "Total de litros"
            };
            numericEntryFloatLight.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "N"
                }
            );
            numericEntryFloatLight.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numeric = new StackLayout()
            {
                Padding = 8,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    numericEntry,
                    numericEntryFloat,
                    numericEntryLight,
                    numericEntryFloatLight
                }
            };

            var numericPage = new ContentPage
            {
                Content = numeric,
                Title = "Numeric entry"
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
                Spacing = 10,
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

            Children.Add(numericPage);
            Children.Add(entryPage);
        }
    }
}
