using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Naylah.Xamarin.Controls.Pickers;

namespace Naylah.Xamarin.iOS.Renderers
{
    public class PickerRenderer : ViewRenderer<Picker, UITextField>
    {
        UIPickerView _picker;
        UIColor _defaultTextColor;

        IElementController ElementController => Element as IElementController;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            if (e.OldElement != null)
                ((ObservableCollection<string>)e.OldElement.Items).CollectionChanged -= RowsCollectionChanged;

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var entry = new NoCaretField { BorderStyle = UITextBorderStyle.RoundedRect };

                    if (e.NewElement as BindablePicker != null)
                    {
                        if (((BindablePicker)e.NewElement).FloatLabeledStyle)
                        {
                            entry.BorderStyle = UITextBorderStyle.None;
                        }
                    }

                    entry.Started += OnStarted;
                    entry.Ended += OnEnded;

                    _picker = new UIPickerView();

                    var width = UIScreen.MainScreen.Bounds.Width;
                    var toolbar = new UIToolbar(new CGRect(0, 0, width, 44)) { BarStyle = UIBarStyle.Default, Translucent = true };
                    var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                    var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (o, a) =>
                    {
                        var s = (PickerSource)_picker.Model;
                        if (s.SelectedIndex == -1 && Element.Items != null && Element.Items.Count > 0)
                            UpdatePickerSelectedIndex(0);
                        UpdatePickerFromModel(s);
                        entry.ResignFirstResponder();
                    });

                    toolbar.SetItems(new[] { spacer, doneButton }, false);

                    entry.InputView = _picker;
                    entry.InputAccessoryView = toolbar;

                    _defaultTextColor = entry.TextColor;

                    SetNativeControl(entry);
                }

                _picker.Model = new PickerSource(this);

                UpdatePicker();
                UpdateTextColor();

                ((ObservableCollection<string>)e.NewElement.Items).CollectionChanged += RowsCollectionChanged;
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Picker.TitleProperty.PropertyName)
                UpdatePicker();
            if (e.PropertyName == Picker.SelectedIndexProperty.PropertyName)
                UpdatePicker();
            if (e.PropertyName == Picker.TextColorProperty.PropertyName || e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
                UpdateTextColor();
        }

        void OnEnded(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
        }

        void OnStarted(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, true);
        }

        void RowsCollectionChanged(object sender, EventArgs e)
        {
            UpdatePicker();
        }

        void UpdatePicker()
        {
            var selectedIndex = Element.SelectedIndex;
            var items = Element.Items;
            Control.Placeholder = Element.Title;
            var oldText = Control.Text;
            Control.Text = selectedIndex == -1 || items == null ? "" : items[selectedIndex];
            UpdatePickerNativeSize(oldText);
            _picker.ReloadAllComponents();
            if (items == null || items.Count == 0)
                return;

            UpdatePickerSelectedIndex(selectedIndex);
        }

        void UpdatePickerFromModel(PickerSource s)
        {
            if (Element != null)
            {
                var oldText = Control.Text;
                ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, s.SelectedIndex);
                Control.Text = s.SelectedItem;
                UpdatePickerNativeSize(oldText);
            }
        }

        void UpdatePickerNativeSize(string oldText)
        {
            if (oldText != Control.Text)
                ((IVisualElementController)Element).NativeSizeChanged();
        }

        void UpdatePickerSelectedIndex(int formsIndex)
        {
            var source = (PickerSource)_picker.Model;
            source.SelectedIndex = formsIndex;
            source.SelectedItem = formsIndex >= 0 ? Element.Items[formsIndex] : null;
            _picker.Select(Math.Max(formsIndex, 0), 0, true);
        }

        void UpdateTextColor()
        {
            var textColor = Element.TextColor;

            if (ColorIsDefault(textColor) || !Element.IsEnabled)
                Control.TextColor = _defaultTextColor;
            else
                Control.TextColor = textColor.ToUIColor();
        }

        class PickerSource : UIPickerViewModel
        {
            readonly PickerRenderer _renderer;

            public PickerSource(PickerRenderer model)
            {
                _renderer = model;
            }

            public int SelectedIndex { get; internal set; }

            public string SelectedItem { get; internal set; }

            public override nint GetComponentCount(UIPickerView picker)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return _renderer.Element.Items != null ? _renderer.Element.Items.Count : 0;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                return _renderer.Element.Items[(int)row];
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                if (_renderer.Element.Items.Count == 0)
                {
                    SelectedItem = null;
                    SelectedIndex = -1;
                }
                else
                {
                    SelectedItem = _renderer.Element.Items[(int)row];
                    SelectedIndex = (int)row;
                }

                var bindablePicker = _renderer.Element as BindablePicker;
                if ((bindablePicker == null) || (bindablePicker.SyncronizationType == BindablePicker.PickerSyncronizationType.Scrolling))
                {
                    _renderer.UpdatePickerFromModel(this);
                }

            }
        }

        public bool ColorIsDefault(Color color)
        {
            //Gambi... :( 
            //https://github.com/xamarin/Xamarin.Forms/blob/2d9288eee6e6f197364a64308183725e7bd561f9/Xamarin.Forms.Core/Color.cs

            var col = new Color();
            return (color == col);
        }
    }

    internal class ObservableList<T> : ObservableCollection<T>
    {
        // There's lots of special-casing optimizations that could be done here
        // but right now this is only being used for tests.

        public void AddRange(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");

            List<T> items = range.ToList();
            int index = Items.Count;
            foreach (T item in items)
                Items.Add(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, index));
        }

        public void InsertRange(int index, IEnumerable<T> range)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("index");
            if (range == null)
                throw new ArgumentNullException("range");

            int originalIndex = index;

            List<T> items = range.ToList();
            foreach (T item in items)
                Items.Insert(index++, item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, originalIndex));
        }

        public void Move(int oldIndex, int newIndex, int count)
        {
            if (oldIndex < 0 || oldIndex + count > Count)
                throw new ArgumentOutOfRangeException("oldIndex");
            if (newIndex < 0 || newIndex + count > Count)
                throw new ArgumentOutOfRangeException("newIndex");

            var items = new List<T>(count);
            for (var i = 0; i < count; i++)
            {
                T item = Items[oldIndex];
                items.Add(item);
                Items.RemoveAt(oldIndex);
            }

            int index = newIndex;
            if (newIndex > oldIndex)
                index -= items.Count - 1;

            for (var i = 0; i < items.Count; i++)
                Items.Insert(index + i, items[i]);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, items, newIndex, oldIndex));
        }

        public void RemoveAt(int index, int count)
        {
            if (index < 0 || index + count > Count)
                throw new ArgumentOutOfRangeException("index");

            T[] items = Items.Skip(index).Take(count).ToArray();
            for (int i = index; i < count; i++)
                Items.RemoveAt(i);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items, index));
        }

        public void RemoveRange(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");

            List<T> items = range.ToList();
            foreach (T item in items)
                Items.Remove(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, items));
        }

        public void ReplaceRange(int startIndex, IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            T[] ritems = items.ToArray();

            if (startIndex < 0 || startIndex + ritems.Length > Count)
                throw new ArgumentOutOfRangeException("startIndex");

            var oldItems = new T[ritems.Length];
            for (var i = 0; i < ritems.Length; i++)
            {
                oldItems[i] = Items[i + startIndex];
                Items[i + startIndex] = ritems[i];
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, ritems, oldItems, startIndex));
        }

       
       

    }

    internal class NoCaretField : UITextField
    {
        public NoCaretField() : base(new RectangleF())
        {
        }
        public override CGRect GetCaretRectForPosition(UITextPosition position)
        {
            return base.GetCaretRectForPosition(position);
        }

      
    }
}
