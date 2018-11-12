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
using Agerfor.Views.Clients;

namespace Agerfor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFullScreen = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (isFullScreen)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1366;
                this.Height = 740;
                double windowWidth = this.Width;
                double windowHeight = this.Height;
                double screenWidth = SystemParameters.PrimaryScreenWidth;
                double screenHeight = SystemParameters.PrimaryScreenHeight;
                this.Left = (screenWidth / 2) - (windowWidth / 2);
                this.Top = (screenHeight / 2) - (windowHeight / 2);
                ScreenSize.Content = "Plein écran";
                isFullScreen = false;
            }
            else
            {
                this.Left = 0;
                this.Top = 0;
                this.WindowState = WindowState.Maximized;
                ScreenSize.Content = "Écran standard";
                isFullScreen = true;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Client());
            currentWindow.Text = "Clients";
            

            
        }
    }
}
