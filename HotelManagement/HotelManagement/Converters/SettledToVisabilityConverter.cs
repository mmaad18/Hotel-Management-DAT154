using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using HotelManagement.Entities.Bills.States;
using HotelManagement.Entities.Reciepts.States;

namespace HotelManagement.Reception.Converters
{
    public class SettledToVisabilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if ((value is SettledBill))
            {
                return Visibility.Visible;
            }
            if ((value is SettledReciept))
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
