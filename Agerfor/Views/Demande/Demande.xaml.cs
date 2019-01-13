using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;

namespace Agerfor.Views.Demande
{
    /// <summary>
    /// Interaction logic for Demande.xaml
    /// </summary>
    public partial class Demande : Page
    {

        MySqlHelper msh = new MySqlHelper();
        string tempNumDemande = "";
        string Query = "";
        string tempStatutDemande = "";
        public Demande(string Query)
        {
            InitializeComponent();
            this.Query = Query;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query == "")
            {
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);
            }
            else
            {
                msh.LoadData(Query, dataGridView2);
            }


        }


        private void BtnAfficherDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDemande AD = new AddDemande(tempNumDemande);
                AD.BtnModifier.Visibility = Visibility.Collapsed;
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectioner une demande");
            }


        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempNumDemande = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
                DataGridCellInfo cell7 = dataGridView2.SelectedCells[7];
                tempStatutDemande = ((TextBlock)cell7.Column.GetCellContent(cell7.Item)).Text;
                if (tempStatutDemande == "En cours")
                {
                    BtnAccepterDemande.IsEnabled = BtnAnnulerDemande.IsEnabled = BtnRefuserDemande.IsEnabled = true;
                }
                else
                {
                    BtnAccepterDemande.IsEnabled = BtnAnnulerDemande.IsEnabled = BtnRefuserDemande.IsEnabled = false;
                }
            }
            catch (Exception)
            {
            }
        }
        /*
    private void BtnModifierDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDemande AD = new AddDemande(tempNumDemande);
                AD.inputTypeDemande.IsEnabled = AD.inputMotifDemande.IsEnabled = AD.inputStatutDemande.IsEnabled = true;
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectioner une demande");
            }
        }
        */
        private void BnSupprimerDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DemandeController DC = new DemandeController();
                DC.supprimerDemande(tempNumDemande);
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);
            }
            catch (Exception)
            {

            }


        }

        private void BtnAccepterDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DemandeController DC = new DemandeController();
                DC.accepterDemande(tempNumDemande);
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);

            }
            catch (Exception)
            {

            }
        }

        private void BtnRefuserDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DemandeController DC = new DemandeController();
                DC.RefuserDemande(tempNumDemande);
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);

            }
            catch (Exception)
            {

            }
        }

        private void BtnAnnulerDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DemandeController DC = new DemandeController();
                DC.AnnulerDemande(tempNumDemande);
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);

            }
            catch (Exception)
            {

            }
        }

        private void BtnRecherche_Click(object sender, RoutedEventArgs e)
        {
            if (inputTypeDemande.SelectedIndex == 4 && inputStatutDemande.SelectedIndex == 4 || inputTypeDemande.SelectedIndex == -1 && inputStatutDemande.SelectedIndex == -1)
            {

                if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
                else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient ");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
                else if (inputrecherche.Text == "*")
                {
                    Demande D = new Demande("");
                    D.inputrecherche.Text = "*";
                    this.NavigationService.Navigate(D);
                }
                else
                {
                    MessageBox.Show("La recherche ne peut pas etre effectuer");
                }
            }

            else if (inputTypeDemande.SelectedIndex == 4 && inputStatutDemande.SelectedIndex != 4 || inputTypeDemande.SelectedIndex == -1 && inputStatutDemande.SelectedIndex != 4)
            {
                if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and StatutDemande='" + inputStatutDemande.Text + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
                else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and StatutDemande='" + inputStatutDemande.Text + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
            }

            else if (inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex == 4 || inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex == -1)
            {
                if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
                else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
            }

            else if (inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex != 4)
            {

                if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                {
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and StatutDemande='" + inputStatutDemande + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
                else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                {
                   
                    Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and StatutDemande='" + inputStatutDemande.Text + "'");
                    D.inputrecherche.Text = inputrecherche.Text;
                    D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                    this.NavigationService.Navigate(D);
                }
            }
            if (inputDateDemandeFrom.Text != "" && inputDateDemandeTo.Text != "")
            {
                if (inputTypeDemande.SelectedIndex == 4 && inputStatutDemande.SelectedIndex == 4 || inputTypeDemande.SelectedIndex == -1 && inputStatutDemande.SelectedIndex == -1)
                {

                    if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                    else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "' ");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                    else if (inputrecherche.Text == "*")
                    {
                        Demande D = new Demande("select * from demande,client where DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "' and demande.RefClient=Client.NumClient and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        this.NavigationService.Navigate(D);
                    }
                    else
                    {
                        MessageBox.Show("La recherche ne peut pas etre effectuer");
                    }
                }


                else if (inputTypeDemande.SelectedIndex == 4 && inputStatutDemande.SelectedIndex != 4 || inputTypeDemande.SelectedIndex == -1 && inputStatutDemande.SelectedIndex != 4)
                {
                    if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and StatutDemande='" + inputStatutDemande.Text + "' and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                    else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and StatutDemande='" + inputStatutDemande.Text + "' DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                }

                else if (inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex == 4 || inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex == -1)
                {
                    if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                    else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                }

                else if (inputTypeDemande.SelectedIndex != 4 && inputStatutDemande.SelectedIndex != 4)
                {

                    if (inputrecherche.Text != "" && inputrecherche.Text != "*" && SelectTypeRecherche.Text != "")
                    {
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and StatutDemande='" + inputStatutDemande + "' and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                    else if (inputrecherche.Text == "" && SelectTypeRecherche.Text != "")
                    {
                      
                        Demande D = new Demande("select * from demande,client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%' and demande.RefClient=client.NumClient and TypeDemande='" + inputTypeDemande.Text + "' and StatutDemande='" + inputStatutDemande.Text + "'and DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "'");
                        D.inputrecherche.Text = inputrecherche.Text;
                        D.SelectTypeRecherche.Text = SelectTypeRecherche.Text;
                        this.NavigationService.Navigate(D);
                    }
                }
            }
        }

        private void BtnRechercheDate_Click(object sender, RoutedEventArgs e)
        {
            Demande D = new Demande("Select * from demande,client where DateDemande BETWEEN '" + inputDateDemandeFrom.Text + "' and '" + inputDateDemandeTo.Text + "' and demande.RefClient=client.NumClient");
            this.NavigationService.Navigate(D);
        }
    }
}
          