using System;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using Agerfor.Controlers;
using System.Threading;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Notifications.Wpf;
using MaterialDesignThemes.Wpf;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for AddProgramme.xaml
    /// </summary>
    public partial class AddProgramme : Page
    {
        private readonly NotificationManager _notificationManager = new NotificationManager();
        private readonly Random _random = new Random();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddProgramme()
        {
            InitializeComponent();
            msh.FillDropDownList("select NatureProgramme from natureprogramme", inputNatureProgramme, "NatureProgramme");
            var timer = new System.Timers.Timer { Interval = 3000 }; 
            timer.Start();
        }

        private void inputNatureProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                inputTypeProgramme.Items.Clear();
                msh.FillDropDownList("select TypeProgramme from typeprogramme where typeprogramme.NatureProgramme='" + inputNatureProgramme.SelectedValue.ToString() + "'", inputTypeProgramme, "TypeProgramme");
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
    }
    }


