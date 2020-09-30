using System.ComponentModel;

namespace HotelManagement.Entities.Bills.BillTypes
{
    public class MiscBill: Bill, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ItemName { get; set; }
    }
}
