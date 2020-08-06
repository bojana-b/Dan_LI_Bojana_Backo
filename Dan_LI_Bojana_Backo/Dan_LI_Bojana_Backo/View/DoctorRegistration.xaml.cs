using Dan_LI_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_LI_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for DoctorRegistration.xaml
    /// </summary>
    public partial class DoctorRegistration : Window
    {
        public DoctorRegistration()
        {
            InitializeComponent();
            this.DataContext = new DoctorRegistrationViewModel(this);
        }
    }
}
