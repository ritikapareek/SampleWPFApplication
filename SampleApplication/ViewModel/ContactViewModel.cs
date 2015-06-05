using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SampleApplication.Model;
using SampleApplication.DataAccess;
using System.Windows.Input;
using SampleApplication.Properties;

namespace SampleApplication.ViewModel
{
    public class ContactViewModel : WorkspaceViewModel, INotifyPropertyChanged,IDataErrorInfo
    {
        
        #region Fields

        readonly Contact _contact;
        readonly ContactRepository _contactRepository;
        bool _isSelected;
        RelayCommand _saveCommand;

        #endregion // Fields

        #region Constructor

        public ContactViewModel(Contact contact, ContactRepository contactRepository)
        {
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



        public override string DisplayName
        {
            get
            {
                if (this.IsNewContact)
                {
                    return Resources.ContactViewModel_DisplayName;
                }
               
                else
                {
                    return String.Format("{0}, {1}", _contact.LastName, _contact.FirstName);
                }
            }
        }

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
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        #endregion // Presentation Properties

        #region Public Methods

        /// <summary>
        /// Saves the Contacts to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save()
        {
            if (!_contact.IsValid)
                throw new InvalidOperationException(Resources.ContactViewModel_Exception_CannotSave);

            if (this.IsNewContact)
                _contactRepository.AddContact(_contact);
            
            base.OnPropertyChanged("DisplayName");
        }

        #endregion // Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this Contacts was created by the user and it has not yet
        /// been saved to the Contacts repository.
        /// </summary>
        bool IsNewContact
        {
            get { return !_contactRepository.ContainsContact(_contact); }
        }

        /// <summary>
        /// Returns true if the Contacts is valid and can be saved.
        /// </summary>
        bool CanSave
        {
            get { return _contact.IsValid; }
        }

        #endregion // Private Helpers


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
