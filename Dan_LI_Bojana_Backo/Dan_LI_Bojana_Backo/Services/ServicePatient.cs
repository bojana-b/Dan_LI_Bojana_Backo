using Dan_LI_Bojana_Backo.HelperMetods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LI_Bojana_Backo.Services
{
    class ServicePatient
    {
        // Method that add patient to database
        public void AddPatient(tblPatient patient)
        {
            try
            {
                using (MedicalDBEntities context = new MedicalDBEntities())
                {
                    tblPatient newPatient = new tblPatient();
                    newPatient.FirstName = patient.FirstName;
                    newPatient.LastName = patient.LastName;
                    newPatient.JMBG = patient.JMBG;
                    newPatient.HealthIsuranceNumber = patient.HealthIsuranceNumber;
                    newPatient.Username = patient.Username;
                    newPatient.UserPassword = SecurePasswordHasher.Hash(patient.UserPassword);
                    //newPatient.DoctorID = 0;

                    context.tblPatients.Add(newPatient);
                    context.SaveChanges();
                    patient.PatientID = newPatient.PatientID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
