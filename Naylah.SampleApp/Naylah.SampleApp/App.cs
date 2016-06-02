using Naylah.SampleApp.Styles;
using Naylah.SampleApp.Views;
using Naylah.SampleApp.Views.Menu;
using Naylah.Xamarin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp
{
    public class App : BootStrapper
    {
        public static App CurrentApp { get; private set; }

        public App()
        {
            CurrentApp = this;
            StyleKit = new DefaultAppStyleKit();

            ConfigurePrelaunchPhase();
        }

        public void ConfigurePrelaunchPhase()
        {
            NavigationServiceFactory(new NavigationPage(new SplashPage()));
        }

        public void ConfigureAppPhase()
        {
            var shellPage = new ShellPage();
            NavigationServiceFactory(shellPage);

            NavigationService.Navigating += shellPage.NavigationService_Navigating;
            NavigationService.Navigated += shellPage.NavigationService_Navigated;

            
            //shellPage.Vm.NavigateToSelectedMenuItem(MenuListData.Dashboard); //Replace with better logic...
        }

        public override async Task InitializeApp()
        {
            await base.InitializeApp();
            await LoadApp();
        }

        public override async Task LoadApp()
        {
            //var appExtensionVm = Resolve<AppExtensionViewModel>();
            //await appExtensionVm.LoadApp();

            await Task.Delay(3000); //Some load

            ConfigureAppPhase();
            //await NavigationService.NavigateAsync(new AnotherPage(), null, false);
        }

        //public override INavigationService NavigationServiceFactory(MasterDetailPage page)
        //{
        //    Resolve<IDialogServiceExt>().Initialize(page);
        //    return base.NavigationServiceFactory(page);
        //}

        //public override INavigationService NavigationServiceFactory(NavigationPage page)
        //{
        //    Resolve<IDialogServiceExt>().Initialize(page);
        //    return base.NavigationServiceFactory(page);
        //}

        //public static T Resolve<T>()
        //{
        //    try
        //    {
        //        return ViewModelLocator.ServiceLocatorInstance.GetInstance<T>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
