using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApplication.DataAccess;
using SampleApplication.Properties;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace SampleApplication.ViewModel
{
   public  class AllContactsViewModel : WorkspaceViewModel
    {
        #region Fields

        readonly ContactRepository _contactRepository;

        #endregion // Fields

        #region Constructor

        public AllContactsViewModel(ContactRepository contactRepository)
        {
            if (contactRepository == null)
                throw new ArgumentNullException("contactRepository");

            base.DisplayName = Resources.AllContactsViewModel_DisplayName;

            _contactRepository = contactRepository;

            // Subscribe for notifications of when a new Contacts is saved.
            _contactRepository.ContactAdded += this.OnContactAddedToRepository;

            // Populate the AllContacts collection with ContactsViewModels.
            this.CreateAllContacts();
        }

        void CreateAllContacts()
        {
            List<ContactViewModel> all =
                (from cont in _contactRepository.GetContacts()
                 select new ContactViewModel(cont, _contactRepository)).ToList();

          

            this.AllContacts = new ObservableCollection<ContactViewModel>(all);
          
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Returns a collection of all the ContactsViewModel objects.
        /// </summary>
        public ObservableCollection<ContactViewModel> AllContacts { get; private set; }

       

        #endregion // Public Interface

        #region  Base Class Overrides

        protected override void OnDispose()
        {
            foreach (ContactViewModel custVM in this.AllContacts)
                custVM.Dispose();

            this.AllContacts.Clear();
        
            _contactRepository.ContactAdded -= this.OnContactAddedToRepository;
        }

        #endregion // Base Class Overrides

     
     

        void OnContactAddedToRepository(object sender, ContactAddedEventArgs e)
        {
            var viewModel = new ContactViewModel(e.NewContact, _contactRepository);
            this.AllContacts.Add(viewModel);
        }

    }
}
