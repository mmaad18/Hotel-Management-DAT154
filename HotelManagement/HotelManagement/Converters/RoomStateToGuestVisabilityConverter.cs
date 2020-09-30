using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using HotelManagement.Entities.Rooms.States;

namespace HotelManagement.Reception.Converters
{
    public class RoomStateToGuestVisabilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visibility= false;
            if (value == null)
            {
                return null;
            }
            var state = value as RoomState;
            if (state.GetType() ==typeof(OccupiedState))
            {
                visibility = true;
            }

            return (visibility ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
