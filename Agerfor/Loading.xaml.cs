using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Agerfor
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        private System.Timers.Timer timer;
        public Loading()
        {

            InitializeComponent();
           
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Start();

        }
        private void dt_Tick(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            dt.Stop();

            this.Close();
        }

       
        }
    }

