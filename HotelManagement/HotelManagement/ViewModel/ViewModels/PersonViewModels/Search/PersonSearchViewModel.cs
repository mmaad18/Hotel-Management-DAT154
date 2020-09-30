using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HotelManagement.DAL.Repositorys.Guests;
using HotelManagement.Entities.Persons;
using HotelManagement.Reception.Messages.Update;

namespace HotelManagement.Reception.ViewModel.ViewModels.PersonViewModels.Search
{
    public class PersonSearchViewModel<T>: ViewModelBase where T: Person 
    {
        private string _searchText;
        private T _selectedPerson;
        private ICollectionView _persons;
        private ObservableCollection<T> _personCollection;
        public IGuestRepository GuestRepository { get; set; }

        public ObservableCollection<T> PersonCollection
        {
            get { return _personCollection; }
            set { _personCollection = value;
                RaisePropertyChanged(); }
        }

        public ICollectionView Persons
        {
            get { return _persons; }
            set { _persons = value; RaisePropertyChanged();}
        }

        public T SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                RaisePropertyChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                
                _searchText = value;
                RaisePropertyChanged();
                Persons.Refresh();
            }
        }

        public PersonSearchViewModel(IGuestRepository guestRepository )
        {
            GuestRepository = guestRepository;
            
        }

        public void UpdateCollection(List<T> personList)
        {
            PersonCollection = new ObservableCollection<T>(personList);
            Persons = CollectionViewSource.GetDefaultView(PersonCollection);
            Persons.Filter = CustomerFilter;
        }

        private bool CustomerFilter(object item)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                return true;
            }

            T person = item as T;
            return person.FirstName.ToLower().Contains(SearchText.ToLower());
        }
    }
}
