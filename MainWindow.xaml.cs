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
using System.Data.SqlClient;
using System.Data;
using Stopwatch0005.Data;

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

                string cn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mrtn1\\source\\repos\\Stopwatch0005\\Data\\StopW_DB.mdf;Integrated Security=True";
                SqlConnection cconn = new SqlConnection(cn);
                cconn.Open();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 1 * FROM Time_Tracker", cconn);
                adapter.Fill(table);

                SqlCommand cmd_Command = new SqlCommand("INSERT INTO Time_Tracker([Elapsed_Time]) VALUES ('" + this.lbE.Content.ToString() + "')", cconn);

                cmd_Command.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully!");
                cconn.Close();
            }

            isRunning = false;

            watch.Reset();
        }
    }
}
