using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities.Bills.BillTypes;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms.RoomTypes;

using HotelManagement.Reception.Services.DataService.Reciept;

namespace HotelManagement.Reception.Design.Reciepts
{
    public class DesignRecieptDataService: IRecieptDataService
    {
        public List<Reciept> Reciepts { get; set; }

        public DesignRecieptDataService()
        {
            //Guest guest = new Guest("Sondre","Fingann", "98848184", DateTime.Now, "sf", "blobl");
            //var room = new DoubleRoom("D14");
            Reciepts = new List<Reciept>();
            //Reciepts.Add(new Reciept(guest,DateTime.Now.AddDays(-2),DateTime.Now.AddDays(3) ,new RoomBill(room,1400)));
        }

        public void GetReciepts(Action<List<Reciept>, Exception> callback)
        {
            throw new NotImplementedException();
        }


        public void GetReciepts(Action callback)
        {
            throw new NotImplementedException();
        }

      
    }
}
