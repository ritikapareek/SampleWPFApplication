using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using SampleApplication.Properties;
using SampleApplication.DataAccess;
using System.Collections.Specialized;
using SampleApplication.Model;
using System.ComponentModel;
using System.Windows.Data;

namespace SampleApplication.ViewModel
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;
        readonly ContactRepository _contactRepository;
        ObservableCollection<WorkspaceViewModel> _Description;

        #endregion // Fields

        #region Constructor

        public MainWindowViewModel(string ContactsDataFile)
        {
            base.DisplayName = Resources.MainWindowViewModel_DisplayName;

            _contactRepository = new ContactRepository(ContactsDataFile);
        }

        #endregion // Constructor

        #region Commands

        /// <summary>
        /// Returns a read-only list of commands 
        /// that the UI can display and execute.
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _commands;
            }
        }

        List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    Resources.MainWindowViewModel_Command_ViewAllContacts,
                    new RelayCommand(param => this.ShowAllContacts())),

                new CommandViewModel(
                    Resources.MainWindowViewModel_Command_CreateNewContacts,
                    new RelayCommand(param => this.CreateNewContacts())),

                new CommandViewModel(
                Resources.MainWindowViewModel_Command_SearchAllContacts,
                new RelayCommand(param => this.SearchAllContacts()))
            };
        }

        #endregion // Commands

        #region Description

        /// <summary>
        /// Returns the collection of available Description to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Description
        {
            get
            {
                if (_Description == null)
                {
                    _Description = new ObservableCollection<WorkspaceViewModel>();
                    _Description.CollectionChanged += this.OnDescriptionChanged;
                }
                return _Description;
            }
        }

        void OnDescriptionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Description.Remove(workspace);
        }

        #endregion // Description

        #region Private Helpers

        void CreateNewContacts()
        {
            Contact newContacts = Contact.CreateNewContacts();
            ContactViewModel workspace = new ContactViewModel(newContacts, _contactRepository);
            this.Description.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void ShowAllContacts()
        {
            AllContactsViewModel workspace =
                this.Description.FirstOrDefault(vm => vm is AllContactsViewModel)
                as AllContactsViewModel;

            if (workspace == null)
            {
                workspace = new AllContactsViewModel(_contactRepository);
                this.Description.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        void SearchAllContacts()
        {
            Contact newContacts = Contact.CreateNewContacts();
            SearchContactsViewModel workspace = new SearchContactsViewModel(newContacts, _contactRepository);
            this.Description.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
          

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Description);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion // Private Helpers
    }
}
