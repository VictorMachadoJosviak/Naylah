using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Naylah.SampleApp.UWP
{
    public sealed partial class MainPage
    {
        public SampleApp.App CurrentApp { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();

            CurrentApp = new SampleApp.App();
            LoadApplication(CurrentApp);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!CurrentApp.Initialized)
            {
                await CurrentApp.InitializeApp();
            }
        }
    }
}
