using System.Windows;

namespace ITMO.CS_WPF.U4E1.UserIn1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your name is " + txtFirstName.Text + " " + txtLastName.Text + "and your email address is " + txtEmail.Text);
        }
    }
}
