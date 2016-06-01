using Naylah.Xamarin.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.Xamarin.Controls.Customizations
{

    [ContentProperty(nameof(Content))]
    public class ContentLoader : ContentView
    {

        private StackLayout defaultLoadingContent;
        private ActivityIndicator activityIndicator;


        public new static BindableProperty ContentProperty =
            BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentLoader), default(View));

        public new View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static BindableProperty LoadingContentProperty =
            BindableProperty.Create(nameof(LoadingContent), typeof(View), typeof(ContentLoader), default(View));


        public View LoadingContent
        {
            get { return (View)GetValue(LoadingContentProperty); }
            set { SetValue(LoadingContentProperty, value); }
        }

        public static BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(ContentLoader), default(bool));

        public ContentLoader()
        {
            PropertyChanged += ContentLoader_PropertyChanged;
            CreateDefaultLoading();
        }

        private void ContentLoader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (
                (e.PropertyName == nameof(LoadingContent)
                ||
                (e.PropertyName == nameof(Content))
                ||
                (e.PropertyName == nameof(IsLoading))
                )
                )
            {
                AdjustContent();
            }

        }

        private void AdjustContent()
        {

            try
            {
                PropertyChanged -= ContentLoader_PropertyChanged;

                base.Content = IsLoading ? LoadingContent : Content;

                if (LoadingContent == defaultLoadingContent)
                {
                    activityIndicator.IsVisible = IsLoading;
                    activityIndicator.IsRunning = IsLoading;
                    LoadingContent.IsVisible = IsLoading;
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                PropertyChanged += ContentLoader_PropertyChanged;
            }
            

        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }




        public void CreateDefaultLoading()
        {
            defaultLoadingContent = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            activityIndicator = new ActivityIndicator();

            defaultLoadingContent.Children.Add(activityIndicator);

            LoadingContent = defaultLoadingContent;

        }
    }
}
