using FFImageLoading.Forms;
using Naylah.Xamarin.Common;
using Naylah.Xamarin.Controls.Customizations;
using Naylah.Xamarin.Controls.Pages;
using Naylah.Xamarin.Controls.Style;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;
using System.IO;
using System.Net.Http;
using PCLStorage;

namespace Naylah.Xamarin.Controls.Choosers
{
    public class ImageChooser : ContentPageBase
    {
        public ImageChooserOptions ImageChooserOptionsData { get; set; }
        public MediaFile CurrentMediaFile { get; private set; }

        Button doneSelectionButton;
        CachedImage image;

        ContentView topContentView;
        ContentView centerContentView;
        ContentView bottomContentView;
        private ContentLoader contentLoader;

        public ImageChooser()
        {
            BindingContext = "";

            IsLoading = true;

            CreateUI();

        }

        private void CreateUI()
        {

            Grid grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star)  },
                    new RowDefinition { Height = GridLength.Auto },

                },
                ColumnSpacing = 0,
                RowSpacing = 0
            };

            topContentView = new ContentView();
            centerContentView = new ContentView();
            bottomContentView = new ContentView() { HeightRequest = 60 };

            if (BootStrapper.CurrentApp.StyleKit != null)
            {
                topContentView.BackgroundColor = BootStrapper.CurrentApp.StyleKit.PrimaryColor;
                bottomContentView.BackgroundColor = BootStrapper.CurrentApp.StyleKit.PrimaryColor;
            }

            grid.Children.Add(topContentView, 0, 0);
            grid.Children.Add(centerContentView, 0, 1);
            grid.Children.Add(bottomContentView, 0, 2);

         

            var takePictureFromLibraryButton = new Button()
            {
                Image = "ic_photo_size_select_actual_white",
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0,
            };

            takePictureFromLibraryButton.Clicked += TakePictureFromLibraryButton_Clicked;

            var takePictureFromCameraButton = new Button()
            {
                Image = "ic_photo_camera_white",
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0,
            };
            takePictureFromCameraButton.Clicked += TakePictureFromCameraButton_Clicked;

            var topContentViewStackLayout = new StackLayout()
            {
                Padding = new Thickness(12, 6, 12, 6),
                Spacing = 12,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children =
                {
                    takePictureFromCameraButton,
                    takePictureFromLibraryButton,
                }
            };

            var topContentViewStackLayoutScrollView = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = topContentViewStackLayout
            };

            topContentView.Content = topContentViewStackLayoutScrollView;

            doneSelectionButton = new Button()
            {
                Image = "ic_done_white",
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderWidth = 0,
            };
            doneSelectionButton.Clicked += DoneSelectionButton_Clicked;

            if (BootStrapper.CurrentApp.StyleKit != null)
            {
                doneSelectionButton.TextColor = BootStrapper.CurrentApp.StyleKit.SecondaryTextColor;
            }

            bottomContentView.Content = doneSelectionButton;

            contentLoader = new ContentLoader();
            contentLoader.Content = grid;

            PropertyChanged += ImageChooser_PropertyChanged;
            OnPropertyChanged(nameof(IsLoading));

            this.Content = contentLoader;

        }

        private void ImageChooser_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsLoading))
            {
                contentLoader.IsLoading = IsLoading;
            }
        }

        private async void DoneSelectionButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }

                IsLoading = true;



            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void TakePictureFromLibraryButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (IsLoading)
                {
                    return;
                }

                IsLoading = true;

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    //Do something
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file != null)
                {
                    image.Source = global::Xamarin.Forms.ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }

            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void TakePictureFromCameraButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (IsLoading)
                {
                    return;
                }

                IsLoading = true;

                await CrossMedia.Current.Initialize();

                if (((!CrossMedia.Current.IsCameraAvailable)) || (!CrossMedia.Current.IsTakePhotoSupported))
                {
                    //Do something
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    Directory = "TempSelection",
                    SaveToAlbum = false,
                    Name = Guid.NewGuid().ToString() + ".png"
                });

                if (file != null)
                {
                    image.Source = global::Xamarin.Forms.ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                IsLoading = false;
            }

        }

        private void ApplyOptions(ImageChooserOptions imageChooserOptions)
        {
            ImageChooserOptionsData = imageChooserOptions;

            Title = ImageChooserOptionsData.Title;
            doneSelectionButton.Text = ImageChooserOptionsData.SelectionButtonText;

            LoadImageFromUri(ImageChooserOptionsData.ActualImageUri);

        }

        private async Task LoadImageFromUri(Uri actualImageUri)
        {
            image = new CachedImage();
            centerContentView.Content = image;

            var wc = new HttpClient();
            var response = await wc.GetAsync(actualImageUri.ToString());

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("TempSelection",
                CreationCollisionOption.OpenIfExists);

            IFile file = await folder.CreateFileAsync(Guid.NewGuid().ToString()+".png",
                CreationCollisionOption.ReplaceExisting);

            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                byte[] imageBuffer = await response.Content.ReadAsByteArrayAsync();
                await fileHandler.WriteAsync(imageBuffer, 0, imageBuffer.Length);
            }

            image.Source = ImageSource.FromFile(file.Path);

            IsLoading = false;

        }



        public static ImageChooser CreateImageChooser(
            ImageChooserOptions imageChooserOptions
            )
        {
            var imageChooser = new ImageChooser();
            imageChooser.ApplyOptions(imageChooserOptions);
            return imageChooser;
        }



        public class ImageChooserOptions
        {
            public string Title { get; set; } = "Image chooser";

            public string SelectionButtonText { get; set; } = "Select";


            public Uri ActualImageUri { get; set; }

            public Size? SizeRequested { get; set; }

        }
    }


}
