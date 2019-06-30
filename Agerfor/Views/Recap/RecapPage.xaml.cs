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
using Agerfor.Views.Recap.Recette;


namespace Agerfor.Views.Recap
{
    /// <summary>
    /// Interaction logic for RecapPage.xaml
    /// </summary>
    public partial class RecapPage : Page
    {
        public RecapPage()
        {
            InitializeComponent();
        }

        private void BtnRecap_Click(object sender, RoutedEventArgs e)
        {
           Recette.Recette R = new Recette.Recette();

            R.ShowInTaskbar = false;
            R.Owner = Application.Current.Windows[0];
            R.Show();

        }
    }
}
