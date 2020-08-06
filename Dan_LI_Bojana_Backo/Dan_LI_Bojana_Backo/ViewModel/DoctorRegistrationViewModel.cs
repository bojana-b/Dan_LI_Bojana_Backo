using Dan_LI_Bojana_Backo.Command;
using Dan_LI_Bojana_Backo.HelperMetods;
using Dan_LI_Bojana_Backo.Services;
using Dan_LI_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_LI_Bojana_Backo.ViewModel
{
    class DoctorRegistrationViewModel : ViewModelBase
    {
        DoctorRegistration doctorRegistration;
        ServiceDoctor serviceDoctor;

        public DoctorRegistrationViewModel(DoctorRegistration doctorRegistrationOpen)
        {
            doctorRegistration = doctorRegistrationOpen;
            serviceDoctor = new ServiceDoctor();
            Doctor = new tblDoctor();
        }

        #region Properties
        private tblDoctor doctor;
        public tblDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
        #endregion 

        #region Commands
        // Save Button
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }
        private void SaveExecute(object obj)
        {
            try
            {
                if (!JMBGValidation.IsValid(Doctor.JMBG))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }
                string password = (obj as PasswordBox).Password;
                Doctor.UserPassword = password;
                LoginScreen login = new LoginScreen();
                serviceDoctor.AddDoctor(Doctor);
                doctorRegistration.Close();
                MessageBox.Show("Account created!");
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if(String.IsNullOrEmpty(Doctor.FirstName) || String.IsNullOrEmpty(Doctor.LastName)
                || String.IsNullOrEmpty(Doctor.JMBG) || String.IsNullOrEmpty(Doctor.BankAccount)
                || String.IsNullOrEmpty(Doctor.Username) || obj as PasswordBox == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Cancel Button
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }
        private void CancelExecute()
        {
            try
            {
                LoginScreen login = new LoginScreen();
                doctorRegistration.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
