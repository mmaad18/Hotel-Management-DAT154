using System.ComponentModel;

namespace HotelManagement.Entities.Bills.BillTypes
{
    public class RoomBill: Bill, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
