using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SampleApplication.Model;
using SampleApplication.DataAccess;
using System.Windows.Input;
using SampleApplication.Properties;
using System.Collections.ObjectModel;

namespace SampleApplication.ViewModel
{
    public class SearchContactsViewModel : WorkspaceViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        
        #region Fields

        readonly Contact _contact;
        readonly ContactRepository _contactRepository;
        bool _isSelected;
        RelayCommand _searchCommand;

        #endregion // Fields

        #region Constructor

        public SearchContactsViewModel(Contact contact, ContactRepository contactRepository)
        {
            base.DisplayName = Resources.SearchContactsViewModel_DisplayName;
            if (contact == null)
                throw new ArgumentNullException("contact");

            if (contactRepository == null)
                throw new ArgumentNullException("contactRepository");

            _contact = contact;
            _contactRepository = contactRepository;
        
        }

        #endregion // Constructor

        #region Contacts Properties

        public string Email
        {
            get { return _contact.Email; }
            set
            {
                if (value == _contact.Email)
                    return;

                _contact.Email = value;

                base.OnPropertyChanged("Email");
            }
        }

        public string FirstName
        {
            get { return _contact.FirstName; }
            set
            {
                if (value == _contact.FirstName)
                    return;

                _contact.FirstName = value;

                base.OnPropertyChanged("FirstName");
            }
        }

      
        public string LastName
        {
            get { return _contact.LastName; }
            set
            {
                if (value == _contact.LastName)
                    return;

                _contact.LastName = value;

                base.OnPropertyChanged("LastName");
            }
        }

        public string PhoneNumber
        {
            get { return _contact.PhoneNumber; }
            set
            {
                if (value == _contact.PhoneNumber)
                    return;

                _contact.PhoneNumber = value;

                base.OnPropertyChanged("PhoneNumber");
            }
        }

        #endregion // Contacts Properties

        #region Presentation Properties



       

        /// <summary>
        /// Gets/sets whether this Contacts is selected in the UI.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Returns a command that saves the Contacts.
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(
                        param => this.Search()
                        
                        );
                }
                return _searchCommand;
            }
        }

        #endregion // Presentation Properties
        public ObservableCollection<ContactViewModel> AllContacts { get; private set; }
        #region Public Methods

        /// <summary>
        /// Saves the Contacts to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Search()
        {
            string searchLastName= string.Empty;
            string searchPhoneNumber = string.Empty;

            if (!string.IsNullOrEmpty(this.LastName) || !string.IsNullOrEmpty(this.PhoneNumber))
            {
                if (!string.IsNullOrEmpty(this.LastName))
                {
                     searchLastName = this.LastName.ToLower();
                }

                if (!string.IsNullOrEmpty(this.PhoneNumber))
                {
                     searchPhoneNumber = this.PhoneNumber.ToLower();
                }

                List<ContactViewModel> all =
               (from cont in _contactRepository.GetContacts()
                select new ContactViewModel(cont, _contactRepository)).ToList();
                this.AllContacts = new ObservableCollection<ContactViewModel>(all);

                foreach (ContactViewModel cvm in AllContacts)
                {
                    if (cvm.LastName.ToLower().Contains(searchLastName) || cvm.PhoneNumber.ToLower().Contains(searchPhoneNumber))
                    {

                    }
                }
               
            }
           
            
            base.OnPropertyChanged("DisplayName");
        }

        #endregion // Public Methods

    

      
   


        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (_contact as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                error = (_contact as IDataErrorInfo)[propertyName];

                // Dirty the commands registered with CommandManager,
                // such as our Save command, so that they are queried
                // to see if they can execute now.
                CommandManager.InvalidateRequerySuggested();

                return error;
            }
        }

       

        #endregion // IDataErrorInfo Members
     
    }
}
