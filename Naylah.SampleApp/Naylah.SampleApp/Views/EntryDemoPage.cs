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
            Title = "Entry demo page";
            BindingContext = new EntryDemoViewModel(); //Replace with your mvvm logic,DI, Locator, etc...

            #region Numeric Double
            var numericDoubleBahaviorLabel = new Label()
            {
                Text = "The numeric behavior allows: Two-way binding with double and integer values. Custom formats. Handles user/keyboard input. Optional validation custom validation..."
            };

            var numericDoubleEntry = new EntryBase()
            {
                Placeholder = "Some placeholder text with C format"
            };
            numericDoubleEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "C"
                }
            );
            numericDoubleEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));

            var numericDoubleEntryFloat = new FloatLabeledEntry()
            {
                Placeholder = "Some placeholder text with C format"
            };
            numericDoubleEntryFloat.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Double,
                    NumericFormat = "C"
                }
            );
            numericDoubleEntryFloat.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeDouble, BindingMode.TwoWay));


            var numericDouble = new StackLayout()
            {
                Padding = 8,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    numericDoubleBahaviorLabel,
                    numericDoubleEntry,
                    numericDoubleEntryFloat
                }
            };

            var numericDoublePage = new ContentPage
            {
                Content = numericDouble,
                Title = "Entry double"
            };
            #endregion

            #region Numeric Integer

            var numericIntegerBahaviorLabel = new Label()
            {
                Text = "The numeric behavior allows: Two-way binding with double and integer values. Custom formats. Handles user/keyboard input. Optional validation custom validation..."
            };

            var numericIntegerEntry = new EntryBase()
            {
                Placeholder = "Numeric behavior with int and N0 format"
            };
            numericIntegerEntry.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "N0",
                    //NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );
            numericIntegerEntry.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));

            var numericIntegerEntryFloat = new FloatLabeledEntry()
            {
                Placeholder = "Numeric behavior with int and N0 format"
            };
            numericIntegerEntryFloat.AddNumericEntryBehavior(
                new NumericEntryBehavior()
                {
                    NumericType = NumericEntryBehavior.NumericEntryBehaviorType.Integer,
                    NumericFormat = "N0",
                    //NumericValidation = (numberWanted) => { return numberWanted <= 500; }
                }
            );

            numericIntegerEntryFloat.GetNumericEntryBehavior().SetBinding(NumericEntryBehavior.NumericValueProperty,
                Binding.Create<EntryDemoViewModel>(o => o.SomeInteger, BindingMode.TwoWay));


            var numericInteger = new StackLayout()
            {
                Padding = 8,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    numericIntegerBahaviorLabel,
                    numericIntegerEntry,
                    numericIntegerEntryFloat,
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
                     new StackLayout()
                        {
                        Padding = 8,
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        BackgroundColor = Color.White,
                        Children =
                            {
                            darkEntry,
                            darkEntryFloat,
                            }
                        },

                    new StackLayout()
                        {
                        Padding = 8,
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        BackgroundColor = Color.Black,
                        Children =
                            {
                            lightEntry,
                            lightEntryFloat
                            }
                        }

                }
            };

            var entryPage = new ContentPage
            {
                Content = entry,
                Title = "Text entry"
            };
            #endregion

            Children.Add(entryPage);
            Children.Add(numericDoublePage);
            Children.Add(numericIntegerPage);

        }
    }
}
