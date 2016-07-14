using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Naylah.Xamarin.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var element = Element as Page;
            if (element == null) { return; }

            var navctrl = this.ViewController.NavigationController;
            if (navctrl == null) { return; }

            navctrl.InteractivePopGestureRecognizer.Enabled = !element.SendBackButtonPressed();

        }
    }
}
