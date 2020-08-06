using Dan_LI_Bojana_Backo.Command;
using Dan_LI_Bojana_Backo.Services;
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
    class PatientWindowViewModel : ViewModelBase
    {
        PatientWindow patientWindow;
        ServiceDoctor serviceDoctor;

        public PatientWindowViewModel(PatientWindow patientWindowOpen)
        {
            patientWindow = patientWindowOpen;
            serviceDoctor = new ServiceDoctor();
            DoctorList = serviceDoctor.GetAllDoctors();
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

        private List<tblDoctor> doctorList;
        public List<tblDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
            }
        }
        #endregion 
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
                patientWindow.Close();
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
    }
}
