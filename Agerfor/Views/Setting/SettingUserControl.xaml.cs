using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Agerfor.Views.Setting.referentiel;
using DbConnection.Models;


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
            Frame.Navigate(new BDD());
            title.Text = "base de donnée";

        }

        private void Btnreferentiel_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Ref());
            title.Text = "Référentiel";
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Agerfor.Views.Setting.UserRole.UserRole(""));
            title.Text = "Utilisateurs";
            
        }
    }
}
