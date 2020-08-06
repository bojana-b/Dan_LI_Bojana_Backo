using Dan_LI_Bojana_Backo.Command;
using Dan_LI_Bojana_Backo.HelperMetods;
using Dan_LI_Bojana_Backo.Services;
using Dan_LI_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dan_LI_Bojana_Backo.ViewModel
{
    class PatientRegistrationViewModel : ViewModelBase
    {
        PatientRegistration patientRegistration;
        ServicePatient servicePatient;

        public PatientRegistrationViewModel(PatientRegistration patientRegistrationOpen)
        {
            patientRegistration = patientRegistrationOpen;
            servicePatient = new ServicePatient();
            Patient = new tblPatient();
        }
        #region Properties
        private tblPatient patient;
        public tblPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
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
                if (!JMBGValidation.IsValid(Patient.JMBG))
                {
                    MessageBox.Show("JMBG is not valid");
                    return;
                }
                string password = (obj as PasswordBox).Password;
                Patient.UserPassword = password;
                LoginScreen login = new LoginScreen();
                servicePatient.AddPatient(Patient);
                patientRegistration.Close();
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
            if (String.IsNullOrEmpty(Patient.FirstName) || String.IsNullOrEmpty(Patient.LastName)
                || String.IsNullOrEmpty(Patient.JMBG) || String.IsNullOrEmpty(Patient.HealthIsuranceNumber)
                || String.IsNullOrEmpty(Patient.Username) || obj as PasswordBox == null)
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
                patientRegistration.Close();
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
