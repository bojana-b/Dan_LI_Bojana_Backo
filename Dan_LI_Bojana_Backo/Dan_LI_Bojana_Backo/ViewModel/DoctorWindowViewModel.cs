using Dan_LI_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LI_Bojana_Backo.ViewModel
{
    class DoctorWindowViewModel : ViewModelBase
    {
        DoctorWindow doctorWindow;

        public DoctorWindowViewModel(DoctorWindow doctorWindowOpen)
        {
            doctorWindow = doctorWindowOpen;
        }
    }
}
