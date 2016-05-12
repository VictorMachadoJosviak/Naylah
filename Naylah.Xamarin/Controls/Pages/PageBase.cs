using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.Xamarin.Controls.Pages
{
    public class PageBase : Page
    {
        public bool? HandleBack { get; set; } = false;

        protected override bool OnBackButtonPressed()
        {
            return HandleBack != null ? HandleBack.Value : false;
        }

    }

    public class ContentPageBase : ContentPage
    {
        public bool? HandleBack { get; set; } = false;

        protected override bool OnBackButtonPressed()
        {
            return HandleBack != null ? HandleBack.Value : false;
        }

    }

    public class TabbedPageBase : TabbedPage
    {
        public bool? HandleBack { get; set; } = false;

        protected override bool OnBackButtonPressed()
        {
            return HandleBack != null ? HandleBack.Value : false;
        }

    }
}
