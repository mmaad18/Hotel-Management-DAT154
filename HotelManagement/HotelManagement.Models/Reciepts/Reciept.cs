using System;
using System.Collections.ObjectModel;
using System.Linq;
using HotelManagement.Models.Entity;
using HotelManagement.Models.Persons.Guests;
using HotelManagement.Models.Reciepts.Bills;
using HotelManagement.Models.Reciepts.Bills.BillTypes;
using HotelManagement.Models.Reciepts.Bills.States;
using HotelManagement.Models.Reciepts.States;

namespace HotelManagement.Models.Reciepts
{

    public class Reciept : IEntity
    {
        private Reciept()
        {
            //For Entity Framework
        }
        public Reciept(Guest guest, DateTime from, DateTime to)
        {
            this.Guest = guest;
            Guest.Reciepts.Add(this);
            StayedToDate = to;
            StayedFromDate = from;
            State = new UnsettledReciept(this);
            Bills = new ObservableCollection<Bill>();
        }

        public Reciept(Guest guest, DateTime from, DateTime to, RoomBill roomBill) :this(guest,from,to)
        {
            AddBill(roomBill);
        }

        public int Id { get; set; }
        public DateTime StayedFromDate { get; set; }
        public DateTime StayedToDate { get; set; }
        public int StayDuration => (StayedFromDate - StayedToDate).Days;
        public DateTime SettledDate { get; protected internal set; }

        public double RemainingAmount
        {
            get { return Bills.Where(x=>x.State.GetType() == typeof(UnsettledBill)).Sum(x=> x.Amount); }
            
        }

        public double TotalAmmount
        {
            get { return Bills.Sum(x=> x.Amount); }
            
        }

        public Guest Guest { get; set; }
        public RecieptState State { get; set; }
        public ObservableCollection<Bill> Bills;

        public void SettleReciept()
        {
            State.SettleReciept();
        }

        public void AddBill(Bill bill)
        {
            State.AddBill(bill);
        }
    }
}
