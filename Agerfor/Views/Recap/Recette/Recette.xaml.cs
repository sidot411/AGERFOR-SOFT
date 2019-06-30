using Agerfor.Controlers;
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
using System.Windows.Shapes;
using Agerfor.RecapPayementReporting;



namespace Agerfor.Views.Recap.Recette
{
    /// <summary>
    /// Interaction logic for Recette.xaml
    /// </summary>
    public partial class Recette : Window
    {
        MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        public Recette()
        {
            InitializeComponent();
            msh.FillDropDownList("select NomProgramme from programme", inputProgramme, "NomProgramme");
            
        }

        private void BtnImprimerRapport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(inputProgramme.SelectedItem.ToString());
            RecapPayementViwer RPV = new RecapPayementViwer(inputProgramme.SelectedItem.ToString());
            RPV.Show();
        }
    }
}
