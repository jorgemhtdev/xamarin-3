namespace AutofacDemo.Converters
{
    using Model;
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;

            switch (menuItemType)
            {
                case MenuItemType.Home:
                    return "ic_home.png";
                case MenuItemType.MyProfile:
                    return "ic_profile.png";
                case MenuItemType.Logout:
                    return "ic_logout.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
