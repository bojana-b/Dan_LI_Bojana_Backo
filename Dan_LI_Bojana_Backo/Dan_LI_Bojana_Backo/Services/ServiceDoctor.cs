using Dan_LI_Bojana_Backo.HelperMetods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LI_Bojana_Backo.Services
{
    class ServiceDoctor
    {
        // Method that add doctor to database
        public void AddDoctor(tblDoctor doctor)
        {
            try
            {
                using (MedicalDBEntities context = new MedicalDBEntities())
                {
                    tblDoctor newDoctor = new tblDoctor();
                    newDoctor.FirstName = doctor.FirstName;
                    newDoctor.LastName = doctor.LastName;
                    newDoctor.JMBG = doctor.JMBG;
                    newDoctor.BankAccount = doctor.BankAccount;
                    newDoctor.Username = doctor.Username;
                    newDoctor.UserPassword = SecurePasswordHasher.Hash(doctor.UserPassword);

                    context.tblDoctors.Add(newDoctor);
                    context.SaveChanges();
                    doctor.DoctorID = newDoctor.DoctorID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
