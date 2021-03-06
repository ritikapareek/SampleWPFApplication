﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Resources;
using System.Windows;
using System.IO;
using SampleApplication.Model;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;

namespace SampleApplication.DataAccess
{
    public class ContactRepository
    { 
        #region Fields

        readonly List<Contact> _contacts;
        string path = "Data/contacts.xml";

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of Contacts.
        /// </summary>
        /// <param name="ContactsDataFile">The relative path to an XML resource file that contains Contacts data.</param>
        public ContactRepository(string contactDataFile)
        {
            _contacts = LoadContacts(contactDataFile);
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Raised when a Contacts is placed into the repository.
        /// </summary>
        public event EventHandler<ContactAddedEventArgs> ContactAdded;

        /// <summary>
        /// Places the specified Contacts into the repository.
        /// If the Contacts is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            if (!_contacts.Contains(contact))
            {
                _contacts.Add(contact);

                if (this.ContactAdded != null)
                    this.ContactAdded(this, new ContactAddedEventArgs(contact));
            }
        }

        /// <summary>
        /// Returns true if the specified Contacts exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException("contact");

            return _contacts.Contains(contact);
        }

        /// <summary>
        /// Returns a shallow-copied list of all Contacts in the repository.
        /// </summary>
        public List<Contact> GetContacts()
        {
            return new List<Contact>(_contacts);
        }

        #endregion // Public Interface

        #region Private Helpers

        /// <summary>
        /// Load contacts from the xml file.
        /// </summary>
        /// <param name="contactDataFile"></param>
        /// <returns></returns>
        static List<Contact> LoadContacts(string contactDataFile)
        {
          //Reading xml file to load the contacts.
            using (Stream stream = GetResourceStream(contactDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from contactElem in XDocument.Load(xmlRdr).Element("contacts").Elements("contact")
                     select Contact.CreateContact(
                        (string)contactElem.Attribute("phoneNumber"),
                        (string)contactElem.Attribute("firstName"),
                        (string)contactElem.Attribute("lastName"),
                        (string)contactElem.Attribute("email")
                         )).ToList();
        }
        

        /// <summary>
        /// Write the contacts to a different xml file present in debug folder.
        /// </summary>
        /// <param name="newContacts"></param>
        public void WriteToXML(Contact newContacts)
        {
          
            XDocument doc = XDocument.Load(path);
           
            XElement school = doc.Element("contacts");
            school.Add(new XElement("contact", new XAttribute("lastName", newContacts.LastName),
                       new XAttribute("firstName", newContacts.FirstName),
                       new XAttribute("email", newContacts.Email),
                       new XAttribute("phoneNumber", newContacts.PhoneNumber)));
                     
            doc.Save(path);
        }

        /// <summary>
        /// For Getting Resource stream
        /// </summary>
        /// <param name="resourceFile"></param>
        /// <returns></returns>
        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion // Private Helpers
    }
}