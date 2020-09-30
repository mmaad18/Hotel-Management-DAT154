using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.Rooms;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;
using HotelManagement.Reception.Messages.Update;

namespace HotelManagement.Reception.ViewModel.ViewModels.RoomViewModels
{
    public class RoomSearchViewModel : ViewModelBase
    {
        private ICollectionView _rooms;
        private string _searchText;
        private Room _selectedRoom;

        public RoomSearchViewModel(Type type, IRoomRepository roomRepository)
        {
            RoomRepository = roomRepository;
            UpdateReceieptsView(type);
            Messenger.Default.Register<UpdateRoomMessage>(this, x => UpdateReceieptsView(type));
        }

        public ObservableCollection<Room> RoomCollection { get; set; }
        public IRoomRepository RoomRepository { get; set; }


        public ICollectionView Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                RaisePropertyChanged();
            }
        }

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                RaisePropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                RaisePropertyChanged();
                Rooms.Refresh();
            }
        }

        private void UpdateReceieptsView(Type type)
        {
            if (type == typeof(Room))
                RoomCollection = new ObservableCollection<Room>(RoomRepository.GetAll().ToList());
            else
                RoomCollection = new ObservableCollection<Room>(RoomRepository.GetRoomsOfType(type));
            Rooms = CollectionViewSource.GetDefaultView(RoomCollection);
            Rooms.Filter = CustomerFilter;
        }

        private bool CustomerFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            var room = item as Room;
            if (room.State.GetType() == typeof(OccupiedState))
                if (room.Guest.FullName.ToLower().Contains(SearchText.ToLower()))
                    return true;

            if (room.RoomNumber.ToLower().Contains(SearchText.ToLower()))
                return true;
            return false;
        }
    }
}