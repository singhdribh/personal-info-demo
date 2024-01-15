using PersonalInfomrationProject.Base;
using PersonalInfomrationProject.Data.Repositories;
using PersonalInfomrationProject.Helpers.Validators;
using PersonalInfomrationProject.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PersonalInfomrationProject
{
    public class MainWindowViewModel : BaseViewModel
    {
        readonly IPersonalInformationRepository _informationRepository;
        public MainWindowViewModel(IPersonalInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;

            personalInformationList = new ObservableCollection<PersonalInformationModel>();
            Languages = new ObservableCollection<string>()
            {
               "English","Panjabi","Hindi"
            };
            personalInformation = new PersonalInformationModel("MALE", Languages[0]);
            personalInformation.Dob = DateTime.Now.AddYears(-18);
            LoadData();
        }

        private async void LoadData()
        {
            var personalRecords = await _informationRepository.GetAllAsync();
            personalInformationList = personalRecords.ToObservableCollection();
        }

        private PersonalInformationModel _personalInformation;
        public PersonalInformationModel personalInformation
        {
            get { return _personalInformation; }
            set { Set(ref _personalInformation, value); }
        }


        private ObservableCollection<PersonalInformationModel> _personalInformationList;
        public ObservableCollection<PersonalInformationModel> personalInformationList
        {
            get { return _personalInformationList; }
            set { Set(ref _personalInformationList, value); }
        }

        private ObservableCollection<string> _languages;
        public ObservableCollection<string> Languages
        {
            get { return _languages; }
            set { Set(ref _languages, value); }
        }

        public ICommand GenderCommand => new RelayCommand<string>(GenderCommandExecute);

        private void GenderCommandExecute(string value)
        {
            personalInformation.Gender = value;
        }

        public ICommand SaveCommand => new RelayCommand(SaveCommandExecute);

        private async void SaveCommandExecute()
        {
            if (!isValid())
            {
                return;
            }
            await _informationRepository.SaveInfo(personalInformation);
            CleanCommandExecute();
        }
        public ICommand CleanCommand => new RelayCommand(CleanCommandExecute);

        private void CleanCommandExecute()
        {
            personalInformation = new PersonalInformationModel("MALE", Languages[0]);
            personalInformation.Dob = DateTime.Now.AddYears(-18);
            LoadData();
        }
        public ICommand DeleteCommand => new RelayCommand(DeleteCommandExecute);

        private async void DeleteCommandExecute()
        {
            if(string.IsNullOrEmpty(personalInformation.Id))
            {
                MessageBox.Show("Please select detail first", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = MessageBox.Show("Do you want to delete record", "Question?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.No)
            {
                return;
            }
           await _informationRepository.DeleteAsync(personalInformation.Id);
            CleanCommandExecute();
        }

        public void SelectedItem(PersonalInformationModel model)
        {

            personalInformation = new PersonalInformationModel(model.Gender, model.Language)
            {
                Dob = model.Dob,
                Email = model.Email,
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                Phone = model.Phone
            };
        }

        private bool isValid()
        {
            if (string.IsNullOrEmpty(personalInformation.FirstName))
            {
                MessageBox.Show("Please enter first name","Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (personalInformation.FirstName.Length < 2)
            {
                MessageBox.Show("Minimum 2 characters required for first name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(personalInformation.LastName))
            {
                MessageBox.Show("Please enter last name","Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (personalInformation.LastName.Length < 2)
            {
                MessageBox.Show("Minimum 2 characters required for last name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(personalInformation.Dob.isAgeLessThan18())
            {
                MessageBox.Show("Minimum age 18 is required", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            if (string.IsNullOrEmpty(personalInformation.Email))
            {
                MessageBox.Show("Please enter email", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!personalInformation.Email.IsValidEmailAddress())
            {
                MessageBox.Show("Please enter valid email", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(personalInformation.Phone))
            {
                MessageBox.Show("Please enter Phone number", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!personalInformation.Phone.IsValidUsNumber())
            {
                MessageBox.Show("Please enter valid Phone number as us format (123) 456-7890", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(personalInformation.Language))
            {
                MessageBox.Show("Please select a language", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

          

            return true;
        }
    }
}
