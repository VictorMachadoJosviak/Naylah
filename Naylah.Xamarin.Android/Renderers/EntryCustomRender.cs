
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Naylah.Xamarin.Android.Extras;
using Naylah.Xamarin.Behaviors;
using Naylah.Xamarin.Controls.Entrys;
using Naylah.Xamarin.Controls.Style;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;


public class EntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<EntryBase, Android.Views.View>
{

    public bool IsNumeric => Element.Behaviors.Where(x => x.GetType() == typeof(NumericEntryBehavior)).Any();

    private string ActualTextGambi;

    private TextInputLayout _nativeView;

    private TextInputLayout NativeView
    {
        get { return _nativeView ?? (_nativeView = InitializeNativeView()); }
    }

    protected override void OnElementChanged(ElementChangedEventArgs<EntryBase> e)
    {
        base.OnElementChanged(e);

        if (e.OldElement == null)
        {
            SetNativeControl(CreateNativeControl());
            ConfigureControl();
        }

    }


    private void ConfigureControl()
    {
        SetText();
        SetHintText();
        SetTextColor();
        SetIsPassword();
        SetIsEnabled();
        SetIsNumeric();
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);

        if
            (
            (e.PropertyName == Entry.PlaceholderProperty.PropertyName)
            ||
            (e.PropertyName == Entry.PlaceholderColorProperty.PropertyName)
            )
        {
            SetHintText();
        }

        if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
        {
            SetIsPassword();
        }

        if (e.PropertyName == Entry.TextProperty.PropertyName)
        {
            SetText();
        }

        if (e.PropertyName == Entry.IsEnabledProperty.PropertyName)
        {
            SetIsEnabled();
        }


    }

    private void SetText()
    {
        NativeView.EditText.Text = Element.Text;
    }

    private void SetIsPassword()
    {
        NativeView.EditText.InputType = Element.IsPassword ? InputTypes.TextVariationPassword | InputTypes.ClassText : NativeView.EditText.InputType;
    }

    private void SetHintText()
    {
        NativeView.Hint = Element.Placeholder;

        if (Element.Theme == BasicTheme.Dark)
        {
            NativeView.EditText.SetHintTextColor(Color.Black.ToAndroid());
        }
        else
        {
            NativeView.EditText.SetHintTextColor(Color.White.ToAndroid());
        }

    }

    private void SetTextColor()
    {
        if (Element.Theme == BasicTheme.Dark)
        {
            NativeView.EditText.SetTextColor(Color.Black.ToAndroid());
        }
        else
        {
            NativeView.EditText.SetTextColor(Color.White.ToAndroid());
        }
    }



    private void SetIsEnabled()
    {
        NativeView.EditText.Enabled = Element.IsEnabled;
    }


    private TextInputLayout InitializeNativeView()
    {

        var view = FindViewById<TextInputLayout>(Naylah.Xamarin.Android.Resource.Id.textInputLayout);

        view.EditText.TextChanged += EditTextOnTextChanged;
        view.EditText.FocusChange += EditText_FocusChange;

        return view;
    }

    private void EditText_FocusChange(object sender, FocusChangeEventArgs e)
    {
        Element.Text = ActualTextGambi;
    }

    private void EditTextOnTextChanged(object sender, Android.Text.TextChangedEventArgs e)
    {
        ActualTextGambi = e.Text.ToString();
    }

    protected override Android.Views.View CreateNativeControl()
    {

        if (Element.Theme == BasicTheme.Dark)
        {
            if (IsNumeric)
            {
                return LayoutInflater.From(Context).Inflate(Naylah.Xamarin.Android.Resource.Layout.HandleCustomTextInputLayout, null);

            }
            else
            {
                return LayoutInflater.From(Context).Inflate(Naylah.Xamarin.Android.Resource.Layout.TextInputLayout, null);
            }

        }
        else
        {
            if (Element.Behaviors.Where(x => x.GetType() == typeof(NumericEntryBehavior)).Any())
            {
                return LayoutInflater.From(Context).Inflate(Naylah.Xamarin.Android.Resource.Layout.HandleCustomTextInputLayoutLigh, null);

            }
            else
            {
                return LayoutInflater.From(Context).Inflate(Naylah.Xamarin.Android.Resource.Layout.TextInputLayoutLight, null);
            }

        }

    }

    protected void SetIsNumeric()
    {
        try
        {

            var numericBehavior = Element.Behaviors.Where(x => x.GetType() == typeof(NumericEntryBehavior)).FirstOrDefault() as NumericEntryBehavior;

            if (numericBehavior != null)
            {
                NativeView.EditText.KeyListener = new NumericEntryBehaviorListener(numericBehavior);
            }


        }
        catch (System.Exception)
        {
        }


    }
}

public class CTextKeyListener : BaseKeyListener
{
    public override InputTypes InputType
    {
        get
        {
            return InputTypes.ClassText;
        }
    }

    public override bool OnKeyDown(Android.Views.View view, IEditable content, [GeneratedEnum] Keycode keyCode, KeyEvent e)
    {
        return true;
    }
}

