using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelManagement.UWP.Entities.Persons;
using HotelManagement.UWP.Entities.Rooms;

namespace HotelManagement.UWP.Entities.Display
{
    public class RoomServiceDisplay: INotifyPropertyChanged
    {
        private int _id;
        private string _type;
        private DateTime _datePerformed;
        private DateTime _ordered;
        private Room _room;
        private Employee _employee;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged();

            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                NotifyPropertyChanged();

            }
        }

        public DateTime DatePerformed
        {
            get { return _datePerformed; }
            set
            {
                _datePerformed = value;
                NotifyPropertyChanged();

            }
        }

        public DateTime Ordered
        {
            get { return _ordered; }
            set
            {
                _ordered = value;
                NotifyPropertyChanged();

            }
        }

        public Room Room
        {
            get { return _room; }
            set
            {
                _room = value;
                NotifyPropertyChanged();

            }
        }

        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
