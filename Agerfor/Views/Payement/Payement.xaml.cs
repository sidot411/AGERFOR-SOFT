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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for Payement.xaml
    /// </summary>
    public partial class Payement : Page
    {
        int tempNumPayement;
        string id;
        string username;
        MySqlHelper msh = new MySqlHelper();
        public Payement(string username,string id)
        {
            InitializeComponent();
            this.id = id;
            this.username = username;
            
            msh.LoadData("select * from payement", dataGridView2);
        }

        private void BtnAfficherpayement_Click(object sender, RoutedEventArgs e)
        {
            AddPayement AP = new AddPayement(tempNumPayement,id,username);
            this.NavigationService.Navigate(AP);
        }

        private void BtnAddPayement_Click(object sender, RoutedEventArgs e)
        {
            AddPayement AP = new AddPayement(tempNumPayement, id, username);
            this.NavigationService.Navigate(AP);
        }

        private void BtnModifierpayement_Click(object sender, RoutedEventArgs e)
        {
            AddPayement AP = new AddPayement(tempNumPayement, id, username );
            this.NavigationService.Navigate(AP);
        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
            tempNumPayement = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

        }
    }
}
