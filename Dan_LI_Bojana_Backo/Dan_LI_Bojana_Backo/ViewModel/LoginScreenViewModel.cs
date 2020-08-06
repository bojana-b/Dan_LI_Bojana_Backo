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
    class LoginScreenViewModel : ViewModelBase
    {
        LoginScreen loginScreen;
        ServiceDoctor serviceDoctor;
        ServicePatient servicePatient;

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;

            Doctor = new tblDoctor();
            serviceDoctor = new ServiceDoctor();
            servicePatient = new ServicePatient();
        }

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

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }
        #region Commands
        // Submit button
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;

                if (serviceDoctor.IsUser(UserName))
                {
                    Doctor = serviceDoctor.FindDoctor(UserName);
                    if (SecurePasswordHasher.Verify(password, Doctor.UserPassword))
                    {
                        DoctorWindow doctorWindow = new DoctorWindow();
                        loginScreen.Close();
                        doctorWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!");
                    }
                }
                else if (servicePatient.IsUser(UserName))
                {
                    Patient = servicePatient.FindPatient(UserName);
                    if (SecurePasswordHasher.Verify(password, Patient.UserPassword))
                    {
                        PatientWindow patientWindow = new PatientWindow();
                        loginScreen.Close();
                        patientWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong usename or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }
        // Signup button
        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if(signUp == null)
                {
                    signUp = new RelayCommand(param => SignupExecute(), param => CanCreateSigunExecute());
                }
                return signUp;
            }
        }
        private void SignupExecute()
        {
            try
            {
                Signup signup = new Signup();
                loginScreen.Close();
                signup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateSigunExecute()
        {
            return true;
        }
        #endregion
    }
}
