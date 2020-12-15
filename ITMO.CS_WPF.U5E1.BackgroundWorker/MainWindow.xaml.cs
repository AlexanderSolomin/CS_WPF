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
using System.ComponentModel;
using System.Threading;

namespace ITMO.CS_WPF.U5E1.BackgroundWorker
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void UpdateDelegate(int i);
        System.ComponentModel.BackgroundWorker aWorker = new System.ComponentModel.BackgroundWorker();
        System.ComponentModel.BackgroundWorker bWorker = new System.ComponentModel.BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
            aWorker.WorkerSupportsCancellation = true;
            aWorker.DoWork += Worker_DoWork;
            aWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            bWorker.WorkerSupportsCancellation = true;
            bWorker.DoWork += Worker_DoWork;
            bWorker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aWorker.RunWorkerAsync();
            
        }
        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker = (System.ComponentModel.BackgroundWorker)sender;
            for (int i = 0; i <= 50; i++)
            {
                for (int j = 1; j <= 10000000; j++)
                { }
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                UpdateDelegate update = new UpdateDelegate(UpdateLabel);
                label1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, update, i);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.ComponentModel.BackgroundWorker worker = (System.ComponentModel.BackgroundWorker)sender;
            if (!(e.Cancelled))
                label2.Content = "Run Completed";
            else
                label2.Content = "Run Cancelled";
        }

        private void UpdateLabel(int i)
        {
            label1.Content = "Cycles: " + i.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bWorker.RunWorkerAsync();
        }
        void Test()
        {

        }
    }
}
