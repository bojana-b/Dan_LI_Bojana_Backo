using Dan_LI_Bojana_Backo.Command;
using Dan_LI_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dan_LI_Bojana_Backo.ViewModel
{
    class SignupViewModel : ViewModelBase
    {
        Signup signup;

        public SignupViewModel(Signup signupOpen)
        {
            signup = signupOpen;
        }

        #region Command
        // Signup Doctor button
        private ICommand signupDoctor;
        public ICommand SignupDoctor
        {
            get
            {
                if (signupDoctor == null)
                {
                    signupDoctor = new RelayCommand(param => SignupDoctorExecute(), param => CanSignupDoctorExecute());
                }
                return signupDoctor;
            }
        }
        private void SignupDoctorExecute()
        {
            try
            {
                DoctorRegistration doctorRegistration = new DoctorRegistration();
                signup.Close();
                doctorRegistration.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSignupDoctorExecute()
        {
            return true;
        }
        // Signup Patient button
        private ICommand signupPatient;
        public ICommand SignupPatient
        {
            get
            {
                if (signupPatient == null)
                {
                    signupPatient = new RelayCommand(param => SignupPatientExecute(), param => CanSignupPatientExecute());
                }
                return signupPatient;
            }
        }
        private void SignupPatientExecute()
        {
            try
            {
                PatientRegistration patientRegistration = new PatientRegistration();
                signup.Close();
                patientRegistration.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSignupPatientExecute()
        {
            return true;
        }
        #endregion
    }
}
