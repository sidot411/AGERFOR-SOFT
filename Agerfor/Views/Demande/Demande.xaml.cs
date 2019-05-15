using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Agerfor.Controlers;
using Agerfor.DemandeReporting;

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
        string tempNumClient = "";
        public Demande(string Query)
        {
            InitializeComponent();
            this.Query = Query;
            msh.FillDropDownList("select Nature from naturedemande", inputNatureDemande, "Nature");
            msh.FillDropDownList("select Statut from demandestatut", inputstatut, "Statut");
            msh.FillDropDownList("select Type from typedemande", inputTypeDemande, "Type");
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query == "")
            {
                msh.LoadData("select NumDemande,date_format(DateDemande,'%d/%m/%Y') AS DATED,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);
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
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Veuillez sélectioner une demande");
            }


        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempNumDemande = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
                DataGridCellInfo cell2 = dataGridView2.SelectedCells[2];
                tempNumClient = ((TextBlock)cell2.Column.GetCellContent(cell2.Item)).Text;
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
                if (System.Windows.MessageBox.Show("Voulez-vous attacher un reçu a cette demande", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                }
                else
                {

                    SelectFile(tempNumDemande);
                 
                }


            }
            catch (Exception)
            {

            }
        }

        public void SelectFile(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + tempNumClient + @"\Demandes\" + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectory2(tempNumClient + "/" + "Demandes" + "/" + theDirectory + "/");
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
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
/*
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
                    System.Windows.MessageBox.Show("La recherche ne peut pas etre effectuer");
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
                        System.Windows.MessageBox.Show("La recherche ne peut pas etre effectuer");
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
        }*/

      

        private void inputCodeDemande_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande,inputCodeClient,inputNomClient,inputCni,inputstatut,inputNatureDemande,inputTypeDemande,inputDateFrom,inputDateTo), dataGridView2);

        }

        private void inputCodeClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);

        }

        private void inputNomClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);

        }

        private void inputCni_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);
        }

        private void inputNatureDemande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);
        }

        private void inputstatut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);

        }

        private void inputTypeDemande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);

        }

        private void inputDateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);

        }

        private void inputDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            msh.LoadData(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo), dataGridView2);
        }

        private void BtnImprimeRecherche_Click(object sender, RoutedEventArgs e)
        {
            SearchDemande SD = new SearchDemande();
            ListeD LD = new ListeD(SD.AdvencedSearchGetQuery(inputCodeDemande, inputCodeClient, inputNomClient, inputCni, inputstatut, inputNatureDemande, inputTypeDemande, inputDateFrom, inputDateTo));
            LD.Show();
        }
    }
}
          