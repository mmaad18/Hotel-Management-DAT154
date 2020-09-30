using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.General;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Persons.Guests;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Reception.Messages.Update;

namespace HotelManagement.Reception.ViewModel.ViewModels.RecieptViewModels
{
    public class RecieptSearchViewModel : ViewModelBase
    {
        private ICollectionView _reciepts;
        private string _searchText;
        private Reciept _selectedReciept;


        private ObservableCollection<Bill> _selectedRecieptBills;

        public RecieptSearchViewModel(IHotelRepository hotelRepository)
        {
            HotelRepository = hotelRepository;

            UpdateRecieptsView();
            Messenger.Default.Register<UpdateReciptMessage>(this, x => UpdateRecieptsView());
            Messenger.Default.Register<UpdateBillMessage>(this, x => UpdateBillView());
        }

        public IHotelRepository HotelRepository { get; set; }
        public ObservableCollection<Reciept> RecieptCollection { get; set; }

        public ICollectionView Reciepts
        {
            get => _reciepts;
            set
            {
                _reciepts = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Bill> SelectedRecieptBills
        {
            get => _selectedRecieptBills;
            set
            {
                _selectedRecieptBills = value;
                RaisePropertyChanged();
            }
        }

        public Reciept SelectedReciept
        {
            get => _selectedReciept;
            set
            {
                _selectedReciept = value;
                if (_selectedReciept != null)
                    SelectedRecieptBills =
                        new ObservableCollection<Bill>(
                            HotelRepository.Bills.FindBy(x => x.RecieptId == _selectedReciept.Id));
            }
        }
        
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                RaisePropertyChanged();
                Reciepts.Refresh();
            }
        }

        public void UpdateRecieptsView()
        {
            RecieptCollection = new ObservableCollection<Reciept>(HotelRepository.Reciepts.GetAll());


            var orderByDescending = RecieptCollection.OrderByDescending(reciept => reciept.StayedToDate);
            Reciepts = CollectionViewSource.GetDefaultView(orderByDescending);
            Reciepts.Filter = CustomerFilter;
        }

        public void UpdateBillView()
        {
            if (SelectedReciept != null)
                SelectedRecieptBills =
                    new ObservableCollection<Bill>(
                        HotelRepository.Bills.FindBy(x => x.RecieptId == SelectedReciept.Id));
        }

        private bool CustomerFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            var room = item as Reciept;
            return room.Guest.FullName.ToLower().Contains(SearchText.ToLower());
        }
    }
}