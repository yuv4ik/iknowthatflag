using System;
using System.Globalization;
using Xamarin.Forms;

namespace IKnowThatFlag.Converters
{
    public class TimeSpanToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeSpan = (TimeSpan)value;
            if (timeSpan.Minutes >= 1)
                return $"{timeSpan.Minutes} min. {timeSpan.Seconds} sec";
            else
                return $"{timeSpan.Seconds} sec.";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
