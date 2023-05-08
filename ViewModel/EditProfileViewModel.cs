﻿using UTSLostAndFound.Model;
using System.Windows.Input;

namespace UTSLostAndFound.ViewModel
{
    public class EditProfileViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get; private set; }

        public string StudentID { get; set; }
        public string Password { get; set; }

        public EditProfileViewModel()
        {
            CommandInit();
        }

        private void CommandInit()
        {
            SaveCommand = new Command(SaveProfile);
        }

        private void SaveProfile()
        {
            // Perform save profile logic here
            // For example, update the profile information in the database

            // After saving, navigate back to the profile page
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
