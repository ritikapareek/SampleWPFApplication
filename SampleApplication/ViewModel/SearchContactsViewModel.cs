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
using SampleApplication.View;

namespace SampleApplication.ViewModel
{
    public class SearchContactsViewModel : WorkspaceViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        
        #region Fields

        readonly Contact _contact;
        ContactViewModel _cvm;
        readonly ContactRepository _contactRepository;
        readonly List<Contact> _lstSearchedContacts = new List<Contact>();
        List<ContactViewModel> displaySearch = new List<ContactViewModel>();
        //bool _isSelected;
        RelayCommand _searchCommand;
        ContactRepository contactSearchRepository;
        bool _isFound = false;
        #endregion // Fields

        #region Constructor
        public SearchContactsViewModel()
        { }
        public SearchContactsViewModel(Contact contact,ref ContactViewModel cvm, ContactRepository contactRepository)
        {
            base.DisplayName = Resources.SearchContactsViewModel_DisplayName;
            if (contact == null)
                throw new ArgumentNullException("contact");

            if (contactRepository == null)
                throw new ArgumentNullException("contactRepository");

            _contact = contact;
            _contactRepository = contactRepository;
           cvm = this._cvm;
        }

        #endregion // Constructor

        #region Contacts Properties




        /// <summary>
        /// Gets/sets whether this Contacts is selected in the UI.
        /// </summary>
        public bool IsFound
        {
            get { return _isFound; }
            set
            {
                if (value == _isFound)
                    return;

                _isFound = value;

                base.OnPropertyChanged("IsFound");
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

     
        #endregion // Contacts Properties

        #region Presentation Properties



       


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
                        param => this.Search(),
                        param => this.CanSearch
                        
                        );
                }
                return _searchCommand;
            }
        }

        /// <summary>
        /// Returns true if the Contacts is valid and can be saved.
        /// </summary>
        bool CanSearch
        {
            get { return _contact.IsValidSearch; }
        }

        #endregion // Presentation Properties
        public ObservableCollection<ContactViewModel> AllContacts { get; private set; }
        #region Public Methods

        /// <summary>
        /// Saves the Contacts to the repository.  This method is invoked by the SeacrhCommand.
        /// </summary>
        public void Search()
        {
            if (!_contact.IsValidSearch)
                throw new InvalidOperationException(Resources.ContactViewModel_Exception_CannotSearch);

            _isFound = false;
            OnPropertyChanged("IsFound");
            string searchLastName= string.Empty;
           

            if (!string.IsNullOrEmpty(this.LastName))
            {
                searchLastName = this.LastName.ToLower();
               

                List<ContactViewModel> all =
               (from cont in _contactRepository.GetContacts()
                select new ContactViewModel(cont, _contactRepository)).ToList();
                this.AllContacts = new ObservableCollection<ContactViewModel>(all);

                Contact contact = new Contact();
               
                
                foreach (ContactViewModel cvmTemp in AllContacts)
                {
                    if (cvmTemp.LastName.ToLower().Contains(searchLastName))
                    {
                        displaySearch.Add(cvmTemp);
                        contact.FirstName = cvmTemp.FirstName;
                        contact.LastName = cvmTemp.LastName;
                        contact.Email = cvmTemp.Email;
                        contact.PhoneNumber = cvmTemp.PhoneNumber;

                        _lstSearchedContacts.Add(contact);
                        _isFound = true;
                       
                       
                    }

                  
                   
                   
                }


               
            }


            base.OnPropertyChanged("isFound");
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


        //#region IDataErrorInfo Members

        //string IDataErrorInfo.Error { get { return null; } }

        //string IDataErrorInfo.this[string propertyName]
        //{
        //    get { return this.GetValidationError(propertyName); }
        //}

        //#endregion // IDataErrorInfo Members
    }
}
