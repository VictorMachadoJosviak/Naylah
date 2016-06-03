using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using Naylah.Xamarin.Controls.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Naylah.SampleApp.Views.Menu
{
    public class MenuPage : ContentPage
    {
        public MenuPage()
        {
            Title = "Some";
            CreateLayout();
        }

        #region UI

        public ListView _menuListViewTop;
        public ListView _menuListViewBottom;

        void CreateLayout()
        {
            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "Icon");
            cell.SetBinding(ImageCell.TextColorProperty, "TextColor");
            cell.SetBinding(ImageCell.DetailColorProperty, "DescriptionColor");

            int MenuItemsHeight = 48;

            int TopMenuItemsHeightRequest = (MenuItemsHeight + 2) * MenuListData.TopItems.Count;
            int BottomMenuItemsHeightRequest = (MenuItemsHeight + 2) * MenuListData.BottomItems.Count;

            #region Account

            var userImage = new CachedImage()
            {
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 64,
                WidthRequest = 64,
                DownsampleToViewSize = true,
                DownsampleUseDipUnits = true,
                TransparencyEnabled = true,
                Aspect = Aspect.AspectFill,
                CacheDuration = TimeSpan.FromDays(30),
                RetryCount = 3,
                RetryDelay = 500,
                LoadingPlaceholder = "icon",
                ErrorPlaceholder = "icon",
                Transformations = new List<FFImageLoading.Work.ITransformation> {
                    new CircleTransformation(0, "#e5e5e5")
                }
            };
            //userImage.SetBinding(CachedImage.SourceProperty,
            //    Binding.Create<MenuViewModel>(vm => vm.CurrentUser.ImageUri, BindingMode.Default, new ImageToPlaceholderConverter()));

            var userFullName = new Label
            {
                TextColor = Color.White,
                FontSize = 16,
                Text = "Full name"
            };
            //userFullName.SetBinding(Label.TextProperty, Binding.Create<MenuViewModel>(vm => vm.CurrentUser.FullName));

            var userEmail = new Label
            {
                TextColor = Color.White,
                FontSize = 14,
                Text = "Email"
            };
            //userEmail.SetBinding(Label.TextProperty, Binding.Create<MenuViewModel>(vm => vm.CurrentUser.UserName));

            #endregion

            var _menuImage = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
            };

            var accountDetails = new StackLayout
            {
                Padding = 0,
                Children =
                {
                    userImage,
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Spacing = 0,
                        Children =
                        {
                            userFullName,
                            userEmail
                        }
                    }
                }
            };
            AbsoluteLayout.SetLayoutBounds(accountDetails, new Rectangle(.07, .75, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(accountDetails, AbsoluteLayoutFlags.PositionProportional);

            var _imageLayout = new AbsoluteLayout
            {
                BackgroundColor = StyleKit.Current.WindowColor,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 185,
                Children =
                {
                    _menuImage,
                    accountDetails
                }
            };
            AbsoluteLayout.SetLayoutBounds(_imageLayout, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(_imageLayout, AbsoluteLayoutFlags.PositionProportional);


            MenusItemTapped += MenuListViewItemTapped;

            _menuListViewTop = new ListView
            {
                ItemsSource = MenuListData.TopItems,
                ItemTemplate = cell,
                SeparatorVisibility = SeparatorVisibility.None,
                SeparatorColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                HeightRequest = TopMenuItemsHeightRequest,
                RowHeight = MenuItemsHeight
            };
            _menuListViewTop.ItemTapped += (s, i) => { MenusItemTapped?.Invoke(s, i); };

            _menuListViewBottom = new ListView
            {
                ItemsSource = MenuListData.BottomItems,
                ItemTemplate = cell,
                SeparatorVisibility = SeparatorVisibility.None,
                SeparatorColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                HeightRequest = BottomMenuItemsHeightRequest,
                RowHeight = MenuItemsHeight
            };
            _menuListViewBottom.ItemTapped += (s, i) => { MenusItemTapped?.Invoke(s, i); };


            var _mainLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = TopMenuItemsHeightRequest,
                Children = {
                    _menuListViewTop
                }
            };

            var _bottomLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HeightRequest = BottomMenuItemsHeightRequest,
                Children = {
                    _menuListViewBottom
                }
            };

            var _rootLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Children =
                {
                    _imageLayout,
                    _mainLayout,
                    _bottomLayout
                }
            };

            Content = _rootLayout;
        }

        public void SelectByPage(Page page)
        {
            _menuListViewTop.SelectedItem = null;
            _menuListViewBottom.SelectedItem = null;

            _menuListViewTop.SelectedItem = MenuListData.TopItems.Where(x => x.TargetType == page.GetType()).FirstOrDefault();
            _menuListViewBottom.SelectedItem = MenuListData.BottomItems.Where(x => x.TargetType == page.GetType()).FirstOrDefault();
        }

        public event EventHandler<ItemTappedEventArgs> MenusItemTapped;
        private void MenuListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_menuListViewTop != null)
            {
                _menuListViewTop.SelectedItem = null;
            }

            if (_menuListViewBottom != null)
            {
                _menuListViewBottom.SelectedItem = null;
            }
        }
        #endregion
    }
}
