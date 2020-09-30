using System.ComponentModel;

namespace HotelManagement.Entities.Bills.BillTypes
{
    public class CleaningBill: Bill, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
