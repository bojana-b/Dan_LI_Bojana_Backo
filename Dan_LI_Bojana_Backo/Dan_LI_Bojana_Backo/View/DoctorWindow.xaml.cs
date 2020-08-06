using Dan_LI_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_LI_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = new DoctorWindowViewModel(this);
        }
    }
}
