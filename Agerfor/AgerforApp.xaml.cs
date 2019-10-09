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
using Agerfor.Views.Demande;
using Agerfor.Views.Projet;
using Agerfor.Views.Programme;
using Agerfor.Views.Setting;
using System.Windows.Forms;
using MaterialDesignThemes.Wpf;
using Agerfor.Views.Attribution;
using Agerfor.Views.Payement;
using Agerfor.Views.Recap;

namespace Agerfor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tempSprojet;
        string tempSprogramme;
        string tempSclient;
        string tempSdemande;
        string tempSattribution;
        string tempSpayement;
        string tempSremboursement;
        string tempSparametre;
        string tempuserrole;
        string tempdivision;

        bool isFullScreen = false;
        public MainWindow(string tempSprojet,string tempSprogramme,
        string tempSclient,
        string tempSdemande,
        string tempSattribution,
        string tempSpayement,
        string tempSremboursement,
        string tempSparametre,
        string tempuserrole,
        string tempdivision)

        {
            InitializeComponent();
            this.tempSprojet = tempSprojet;
            this.tempSprogramme = tempSprogramme;
            this.tempSclient = tempSclient;
            this.tempSdemande = tempSdemande;
            this.tempSattribution = tempSattribution;
            this.tempSpayement = tempSpayement;
            this.tempSremboursement = tempSremboursement;
            this.tempSparametre = tempSparametre;
            this.tempuserrole = tempuserrole;
            
            this.WindowState = WindowState.Normal;
            this.Width = 1366;
            this.Height = 730;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 0) - (windowHeight / 0);

            if(tempSprojet == "True")
            {
                BtnProjet.IsEnabled = true;
            }
            else
            {
                BtnProjet.IsEnabled = false;
            }

            if (tempSprogramme == "True")
            {
                BtnProgramme.IsEnabled = true;
            }
            else
            {
                BtnProgramme.IsEnabled = false;
            }
            if (tempSclient == "True")
            {
                BtnClient.IsEnabled = true;
            }
            else
            {
                BtnClient.IsEnabled = false;
            }
            if (tempSdemande == "True")
            {
                BtnDemande.IsEnabled = true;
            }
            else
            {
                BtnDemande.IsEnabled = false;
            }
            if (tempSattribution == "True")
            {
                BtnAttribution.IsEnabled = true;
            }
            else
            {
                BtnAttribution.IsEnabled = false;
            }
            if (tempSpayement == "True")
            {
                BtnVerssement.IsEnabled = true;
            }
            else
            {
                BtnVerssement.IsEnabled = false;
            }
            if (tempSremboursement == "True")
            {
                BtnRembourssement.IsEnabled = true;
            }
            else
            {
                BtnRembourssement.IsEnabled = false;
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
         
            BtnClient.BorderThickness = BtnDemande.BorderThickness = BtnProgramme.BorderThickness = BtnProjet.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness=BtnVerssement.BorderThickness = BtnAttribution.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
        }


        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (isFullScreen)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1366;
                this.Height = 730;
                double windowWidth = this.Width;
                double windowHeight = this.Height;
                double screenWidth = SystemParameters.PrimaryScreenWidth;
                double screenHeight = SystemParameters.PrimaryScreenHeight;
                this.Left = (screenWidth / 2) - (windowWidth / 2);
                this.Top = (screenHeight / 0) - (windowHeight / 0);
                
                
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
            BtnDemande.BorderThickness = BtnProjet.BorderThickness = BtnProgramme.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnVerssement.BorderThickness = BtnAttribution.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnClient.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Client(""));
            currentWindow.Text = "Clients";
            

            
        }

        private void BtnDemande_Click(object sender, RoutedEventArgs e)
        {
            BtnClient.BorderThickness = BtnProjet.BorderThickness = BtnProgramme.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnVerssement.BorderThickness = BtnAttribution.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnDemande.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Demande(""));
            currentWindow.Text = "Demande";

        }

        private void BtnProjet_Click(object sender, RoutedEventArgs e)
        {
            
                BtnClient.BorderThickness = BtnDemande.BorderThickness = BtnProgramme.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnVerssement.BorderThickness = BtnAttribution.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
                BtnProjet.BorderThickness = new Thickness(5, 0, 0, 0);
                Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                Frame.Navigate(new Projet("",tempuserrole));
                currentWindow.Text = "Projet";
           
        }

        private void BtnProgramme_Click(object sender, RoutedEventArgs e)
        {
            BtnClient.BorderThickness = BtnDemande.BorderThickness = BtnProjet.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnVerssement.BorderThickness = BtnAttribution.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnProgramme.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Programme(""));
            currentWindow.Text = "Programe";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Réglage_Click(object sender, RoutedEventArgs e)
        {
            SettingUserControl SUC = new SettingUserControl();
            DialogHost.Show(SUC);
        }

        private void BtnAttribution_Click(object sender, RoutedEventArgs e)
        {

            BtnClient.BorderThickness = BtnDemande.BorderThickness = BtnProjet.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnVerssement.BorderThickness = BtnProgramme.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnAttribution.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Attribution(""));
            currentWindow.Text = "Attribution";
        }

        private void BtnVerssement_Click(object sender, RoutedEventArgs e)
        {

            BtnClient.BorderThickness = BtnDemande.BorderThickness = BtnProjet.BorderThickness = BtnTableauDeBord.BorderThickness = BtnRecapulatif.BorderThickness = BtnRembourssement.BorderThickness = BtnAttribution.BorderThickness = BtnProgramme.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnVerssement.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new Payement(User.Text,ID.Text));
            currentWindow.Text = "Payement";
        }

        private void BtnRecapulatif_Click(object sender, RoutedEventArgs e)
        {

            BtnClient.BorderThickness = BtnVerssement.BorderThickness = BtnDemande.BorderThickness = BtnProjet.BorderThickness = BtnTableauDeBord.BorderThickness  = BtnRembourssement.BorderThickness = BtnAttribution.BorderThickness = BtnProgramme.BorderThickness = BtnCloture.BorderThickness = new Thickness(0, 0, 0, 0);
            BtnRecapulatif.BorderThickness = new Thickness(5, 0, 0, 0);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            Frame.Navigate(new RecapPage());
            currentWindow.Text = "Recap";
        }

        private void Deconexion_Click(object sender, RoutedEventArgs e)
        {
           
            Login LG = new Login();
            LG.Show();
            this.Close();
        }
    }
}
