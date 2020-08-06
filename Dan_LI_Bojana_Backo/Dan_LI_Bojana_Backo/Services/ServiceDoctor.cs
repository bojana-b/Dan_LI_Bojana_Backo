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
        // Method that reads all doctors from database
        public List<tblDoctor> GetAllOrders()
        {
            try
            {
                using (MedicalDBEntities context = new MedicalDBEntities())
                {
                    List<tblDoctor> list = new List<tblDoctor>();
                    list = (from x in context.tblDoctors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Methot to check if doctors username exists in database
        public bool IsUser(string username)
        {
            try
            {
                using (MedicalDBEntities context = new MedicalDBEntities())
                {
                    tblDoctor doctor = (from e in context.tblDoctors where e.Username == username select e).First();

                    if (doctor == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public tblDoctor FindDoctor(string username)
        {
            try
            {
                using (MedicalDBEntities context = new MedicalDBEntities())
                {
                    tblDoctor doctor = (from e in context.tblDoctors where e.Username == username select e).First();
                    return doctor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
