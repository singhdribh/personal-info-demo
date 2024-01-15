using PersonalInfomrationProject.Base;
using System;

namespace PersonalInfomrationProject.Models
{
    public class PersonalInformationModel : BaseViewModel
    {
        public PersonalInformationModel(string gender, string language)
        {
            Gender=gender;
            Language=language;
        }
        public string Id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { Set(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        } 
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        } 
        
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { Set(ref _gender, value); }
        }
        
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { Set(ref _phone, value); }
        } 
        
        private string _language;
        public string Language
        {
            get { return _language; }
            set { Set(ref _language, value); }
        }

        private DateTime _dob;
        public DateTime Dob
        {
            get { return _dob; }
            set { Set(ref _dob, value); }
        }

    }
}
