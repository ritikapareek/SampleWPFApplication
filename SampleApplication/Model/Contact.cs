using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using SampleApplication.Properties;

namespace SampleApplication.Model
{
   public class Contact : IDataErrorInfo
    {

        #region Creation

        public static Contact CreateNewContacts()
        {
            return new Contact ();
        }

        public static Contact SearchAllContacts()
        {
            return new Contact();
        }

        public static Contact CreateContact(
            string PhoneNumber,
            string firstName,
            string lastName,
            string email)
        {
            return new Contact
            {
                PhoneNumber = PhoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }

        public Contact()
        {
        }

        #endregion // Creation

        #region State Properties

        /// <summary>
        /// Gets/sets the e-mail address for the Contacts.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets/sets the Contacts's first name.  If this Contacts is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string FirstName { get; set; }

      

        /// <summary>
        /// Gets/sets the Contacts's last name.  If this Contacts is a 
        /// company, this value is not set.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Returns the total amount of money spent by the Contacts.
        /// </summary>
        public string PhoneNumber { get;  set; }

        #endregion // State Properties

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        public bool IsValidSearch
        {
            get
            {
                foreach (string property in ValidatedPropertiesForSearch)
                    if (GetValidationErrorForSearch(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "Email", 
            "FirstName", 
            "LastName",
            "PhoneNumber",
        };

        static readonly string[] ValidatedPropertiesForSearch = 
        { 
           
            "LastName",
          
        };

        string GetValidationErrorForSearch(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {

                case "LastName":
                    error = this.ValidateLastName();
                    break;


                default:

                    break;
            }

            return error;
        }

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Email":
                    error = this.ValidateEmail();
                    break;

                case "FirstName":
                    error = this.ValidateFirstName();
                    break;

                case "LastName":
                    error = this.ValidateLastName();
                    break;

                case "PhoneNumber":
                    error = this.ValidatePhoneNumber();
                    break;

                default:
                   
                    break;
            }

            return error;
        }

        string ValidateEmail()
        {
            if (IsStringMissing(this.Email))
            {
                return Resources.Contacts_Error_MissingEmail;
            }
            else if (!IsValidEmailAddress(this.Email))
            {
                return Resources.Contacts_Error_InvalidEmail;
            }
            return null;
        }

       //Implement this
        string ValidatePhoneNumber()
        {

            if (IsStringMissing(this.PhoneNumber))
            {
                return Resources.Contacts_Error_MissingPhoneNumber;
            }
            else if (!IsValidPhoneNumber(this.PhoneNumber))
            {
                return Resources.Contacts_Error_InvalidPhoneNumber;
            }
            return null;
        }
        string ValidateFirstName()
        {
            if (IsStringMissing(this.FirstName))
            {
                return Resources.Contacts_Error_MissingFirstName;
            }
            return null;
        }

        string ValidateLastName()
        {

            if (IsStringMissing(this.LastName))
            {
                return Resources.Contacts_Error_MissingLastName;
            }
            return null;
           
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            //Using regex 
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (IsStringMissing(phoneNumber))
                return false;

            //Using regex 
           // string pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            string pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, pattern, RegexOptions.IgnoreCase);
        }

        #endregion // Validation
    }
}
