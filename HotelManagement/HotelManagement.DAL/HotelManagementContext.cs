using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Persons;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.RoomServices;

namespace HotelManagement.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HotelManagementContext : DbContext
    {
        // Your context has been configured to use a 'HotelManagementContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HotelManagement.DAL.HotelManagementContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HotelManagementContext' 
        // connection string in the application configuration file.
        public HotelManagementContext()
            : base("name=HotelManagementContext")
        {
            Database.SetInitializer(new HotelManagementDBInitializer());
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            //modelBuilder.Entity<Reciept>()
            //    .HasMany(reciept => reciept.Bills)
            //    .WithRequired(bill => bill.Reciept);

            //modelBuilder.Entity<Room>()
            //    .HasOptional(x => x.Guest)
            //    .WithMany(x => x.BookedRooms);



           

            //modelBuilder.Entity<Guest>()
            //    .HasMany(guest => guest.BookedRooms).WithOptional(x => x.Guest);

            //modelBuilder.Entity<Bill>()
            //    .HasRequired(bill => bill.Reciept)
            //    .WithMany(reciept => reciept.Bills);


            //modelBuilder.Entity<Room>()
            //    .HasOptional(f => f.State)
            //    .WithRequired(s => s.Room);

            //modelBuilder.Entity<Reciept>()
            //    .HasOptional(f => f.State)
            //    .WithRequired(s => s.Reciept);

        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Reciept> Reciepts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<RoomService> RoomServices { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}