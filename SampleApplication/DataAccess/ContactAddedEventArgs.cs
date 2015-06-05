using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApplication.Model;

namespace SampleApplication.DataAccess
{
    public class ContactAddedEventArgs : EventArgs
    {
        public ContactAddedEventArgs(Contact newContact)
        {
            this.NewContact = newContact;
        }

        public Contact NewContact { get; private set; }

    }
}
