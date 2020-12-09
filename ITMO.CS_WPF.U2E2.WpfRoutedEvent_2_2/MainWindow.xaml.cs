using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITMO.CS_WPF.U2E2.WpfRoutedEvent_2_2
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
        private void StackPanel_Click_1(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            double a = Double.Parse(textBox.Text);
            switch (feSource.Name)
            {
                case "butAdd":
                    a += a;
                    break;
                case "butMult":
                    a *= a;
                    break;
            }
            e.Handled = true;
            textBox.Text = String.Format("{0:#.##}", a);
        }
    }
}
