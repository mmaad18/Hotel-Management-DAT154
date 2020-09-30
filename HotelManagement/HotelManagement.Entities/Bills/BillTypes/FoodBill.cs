using System.ComponentModel;

namespace HotelManagement.Entities.Bills.BillTypes
{
    public class FoodBill: Bill, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string DishDishName { get; set; }
    }
}
