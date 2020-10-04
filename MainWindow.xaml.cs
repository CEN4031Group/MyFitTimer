using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;
using System.Timers;
//using System.Timers.Timer;
using System.IO;

namespace Stopwatch0005
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Stopwatch watch;
        bool isRunning;
        private System.Timers.Timer timer;

        public MainWindow()
        {
            InitializeComponent();

            watch = new Stopwatch();
            timer = new System.Timers.Timer(100);
            timer.Elapsed += OnTimerElapse;
        }

        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>      
                lbS.Content = watch.Elapsed.ToString(@"hh\:mm\:ss"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            watch.Start();
            timer.Start();
            isRunning = true;
        }

        private void Stop_Timer_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning)
            {
                watch.Stop();
                timer.Stop();
                lbE.Content = watch.Elapsed.ToString(@"hh\:mm\:ss");
                lstBxElapsed.Items.Add(watch.Elapsed.ToString(@"hh\:mm\:ss"));
            }

            watch.Reset();
            isRunning = false;
        }
    }
}
