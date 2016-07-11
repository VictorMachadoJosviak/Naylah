using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Util;

namespace Naylah.Xamarin.Android.Extras
{
    
    public class CustomEditText : EditText
    {


        public CustomEditText(Context context) : base(context)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected CustomEditText(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override IInputConnection OnCreateInputConnection(EditorInfo outAttrs)
        {
            //var inputConnection = base.OnCreateInputConnection(outAttrs);

            //var inputConnectionWrapper = new CustomInputConnectionWrapper(inputConnection, false);

            //return inputConnectionWrapper;

            var inputConnection = new CustomInputConnection(this, false);

            outAttrs.InputType = this.InputType;

            return inputConnection;

        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            bool v = base.OnKeyDown(keyCode, e);
            return v;
        }


    }


    public class CustomInputConnection : BaseInputConnection
    {
        public CustomInputConnection(View targetView, bool fullEditor) : base(targetView, fullEditor)
        {
        }

        protected CustomInputConnection(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool SendKeyEvent(KeyEvent e)
        {
            bool v = base.SendKeyEvent(e);
            return v;


        }

        public override bool DeleteSurroundingText(int beforeLength, int afterLength)
        {
            base.SendKeyEvent(new KeyEvent(KeyEventActions.Down, Keycode.Back));
            return false;
            //return base.DeleteSurroundingText(beforeLength, afterLength);
        }


    };

    public class CustomInputConnectionWrapper : InputConnectionWrapper
    {
        public CustomInputConnectionWrapper(IInputConnection target, bool mutable) : base(target, mutable)
        {
        }

        protected CustomInputConnectionWrapper(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override bool SendKeyEvent(KeyEvent e)
        {
            try
            {
                bool v = base.SendKeyEvent(e);
                return v;
            }
            catch (Exception)
            {
                return false;
            }


        }

        public override bool DeleteSurroundingText(int beforeLength, int afterLength)
        {
            base.SendKeyEvent(new KeyEvent(KeyEventActions.Down, Keycode.Back));
            return false;
            //return base.DeleteSurroundingText(beforeLength, afterLength);
        }

        
    }
}