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
using Agerfor.Views;

namespace Agerfor.Views.Setting
{
    /// <summary>
    /// Interaction logic for SettingUserControl.xaml
    /// </summary>
    public partial class SettingUserControl : UserControl
    {
        public SettingUserControl()
        {
            InitializeComponent();
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new SocieteInformation());
            title.Text = "Information Société";
        }

        private void BtnSocieteInformation_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new SocieteInformation());
            title.Text = "Information Société";
        }

        private void BtnDatabase_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Database());
            title.Text = "base de donnée";

        }
    }
}
