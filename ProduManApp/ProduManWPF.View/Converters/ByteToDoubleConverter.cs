using System;
using System.Globalization;
using System.Windows.Data;

namespace ProduManWPF.View;

public class ByteToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)(byte)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (byte)(double)value;
    }
}