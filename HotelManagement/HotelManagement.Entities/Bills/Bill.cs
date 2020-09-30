using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Entities.Bills.States;
using HotelManagement.Entities.Entity;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.StateFactory;

namespace HotelManagement.Entities.Bills
{
    public class Bill : IEntity, INotifyPropertyChanged
    {
        public DateTime OrderedDate { get; set; }
        public DateTime PayedDate { get; set; }
        public double Amount { get; set; }

        public string StateString { get; private set; } = "UnsettledBill";

        [NotMapped]
        public BillState State
        {
            get => RoomStateFactory.GetBillState(StateString);
            set => StateString = value.GetType().Name;
        }

        public int RecieptId { get; set; }
        public virtual Reciept Reciept { get; set; }
        public int Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}