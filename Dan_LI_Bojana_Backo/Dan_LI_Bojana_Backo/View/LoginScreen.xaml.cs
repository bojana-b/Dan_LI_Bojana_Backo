using Dan_LI_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_LI_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            this.DataContext = new LoginScreenViewModel(this);
        }
    }
}
