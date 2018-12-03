using System;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows;
using Notifications.Wpf;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using System.Threading;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for AddProgramme.xaml
    /// </summary>
    public partial class AddProgramme : Page
    {
        ProgrammeController PC = new ProgrammeController();
        string RefProgramme = "";

        private readonly NotificationManager _notificationManager = new NotificationManager();
        private readonly Random _random = new Random();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddProgramme(string refprogramme)
        {
            this.RefProgramme = refprogramme;
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            msh.FillDropDownList("select NatureProgramme from natureprogramme", inputNatureProgramme, "NatureProgramme");
            msh.FillDropDownList("select NomDaira from daira",inputDairaProgramme, "NomDaira");
            
 
            var timer = new System.Timers.Timer { Interval = 3000 };
            timer.Start();
            if (refprogramme != "")
            {
                string query = "select * from programme where RefProgramme =" + refprogramme;
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;

                con = new MySqlConnection(Database.ConnectionString);
                con.Open();
                cmd = new MySqlCommand(query);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                bool oneTime = true;
                while (rdr.Read())
                {

                    if (oneTime)
                    {
                        inputRefProgramme.Text = rdr["RefProgramme"].ToString();
                        inputNomProgramme.Text = rdr["NomProgramme"].ToString();
                        inputSiteProgramme.Text = rdr["Site"].ToString();
                        inputDairaProgramme.Text = rdr["Daira"].ToString();
                        inputCommuneProgramme.Text = rdr["Commune"].ToString();
                        inputNatureProgramme.Text = rdr["NatureProgramme"].ToString();
                        inputTypeProgramme.Text = rdr["TypeProgramme"].ToString();
                        inputNombredebien.Text = rdr["NombreBiens"].ToString();
                        inputSuperficie.Text = rdr["Superficie"].ToString();

                      
                        oneTime = false;
                    }
                }
            }
        }
            

        private void inputNatureProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                inputTypeProgramme.Items.Clear();
                msh.FillDropDownList("select TypeProgramme from typeprogramme where typeprogramme.NatureProgramme='" + inputNatureProgramme.SelectedValue.ToString() + "'", inputTypeProgramme, "TypeProgramme");
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
               if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled  = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local"|| inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }



            }
            catch (Exception)
            { }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {/*
            string tempnumlotir = inputNumLotir.Text;
            if (tempnumlotir == "")
            {
                var content = new NotificationContent { Title = "Permis de lotir n'existe pas", Message = "veuillez ajouter un permis de lotir!", Type=NotificationType.Warning };
                var clickContent = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content, "WindowArea", onClick: () => _notificationManager.Show(clickContent));

                var content2 = new NotificationContent { Title = "Permis de lotir existe", Message = "veuillez ajouter un permis de lotir!", Type = NotificationType.Error };
                var clickContent2 = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content2, "WindowArea2", onClick: () => _notificationManager.Show(clickContent2));
            }
            */
            
            
              /*  if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local" || inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }
                 else
                 {*/
                     PermiLotir.IsEnabled = Permisconstruire.IsEnabled = false;
                     BtnCahiercharge.IsEnabled = BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                 

            
        }

       

        private void BtnCahiercharge_Click(object sender, RoutedEventArgs e)
        {
            CahierCharge cahiercharge = new CahierCharge();
            DialogHost.Show(cahiercharge);
        }

        private void BtnEDD_Click(object sender, RoutedEventArgs e)
        {
            EDD EDD = new EDD();
            DialogHost.Show(EDD);
        }

        private void BtnConvention_Click(object sender, RoutedEventArgs e)
        {
            Convention convention = new Convention();
            DialogHost.Show(convention);
        }

        private void inputDairaProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            inputCommuneProgramme.Items.Clear();
            msh.FillDropDownList("select NomCommune from commune,daira where NomDaira='" + inputDairaProgramme.SelectedItem.ToString() + "'and daira.IdDaira=commune.IdDaira", inputCommuneProgramme, "NomCommune");
        }

        private void BtnAjouterProgramme_Click(object sender, RoutedEventArgs e)
        {
            PC.AjouterProgramme(inputRefProgramme.Text, inputNomProgramme.Text, inputSiteProgramme.Text, inputDairaProgramme.Text, inputCommuneProgramme.Text, inputNatureProgramme.Text, inputTypeProgramme.Text, inputNombredebien.Text, decimal.Parse(inputSuperficie.Text));
        }
    }
    }


