using System;
using System.Globalization;
using System.Windows.Data;

namespace RadioTrainingCreator.GUI.Converter
{
    public class NavigationItemSelectedConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] == null || value[1] == null)
                return false;

            return value[0] == value[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
