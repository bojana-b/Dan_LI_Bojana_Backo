using Dan_LI_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_LI_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for PatientRegistration.xaml
    /// </summary>
    public partial class PatientRegistration : Window
    {
        public PatientRegistration()
        {
            InitializeComponent();
            this.DataContext = new PatientRegistrationViewModel(this);
        }
    }
}
