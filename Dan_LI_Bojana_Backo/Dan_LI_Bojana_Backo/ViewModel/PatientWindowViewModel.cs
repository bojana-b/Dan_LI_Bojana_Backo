using Dan_LI_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LI_Bojana_Backo.ViewModel
{
    class PatientWindowViewModel : ViewModelBase
    {
        PatientWindow patientWindow;

        public PatientWindowViewModel(PatientWindow patientWindowOpen)
        {
            patientWindow = patientWindowOpen;
        }
    }
}
