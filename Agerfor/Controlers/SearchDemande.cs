using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Agerfor.Controlers
{
    class SearchDemande
    {
        public string AdvencedSearchGetQuery(TextBox CodeDemande, TextBox CodeClient, TextBox NomClient, TextBox NumCni, ComboBox StatutDemande, ComboBox NatureDemande, ComboBox TypeDemande, DatePicker DateFrom, DatePicker DateTo)
        {
            int i;
            int j;
            
            string query = "select NumDemande,DateDemande,date_format(DateDemande,'%d/%m/%Y') AS DATED,NumClient,RefClient,Motif,NatureDemande,TypeDemande,StatutDemande,Nom,Prenom,Cni,DateNaissance,LieuNaissance from demande,client where ";
            string query2 = "client.NumClient = demande.RefClient";

            string[] AttributTextBox = new string[4];
            AttributTextBox[0] = "NumDemande";
            AttributTextBox[1] = "RefClient";
            AttributTextBox[2] = "Nom";
            AttributTextBox[3] = "Cni";



            TextBox[] Demande = new TextBox[4];
            Demande[0] = CodeDemande;
            Demande[1] = CodeClient;
            Demande[2] = NomClient;
            Demande[3] = NumCni;

            for (i = 0; i < AttributTextBox.Length; i++)
            {
                if (Demande[i].Text != "")
                {
                    query = query + "" + AttributTextBox[i] + "=" + "'" + Demande[i].Text + "'" + " And ";
                }
            }

            string[] AttributComboBox = new string[3];

            AttributComboBox[0] = "StatutDemande";
            AttributComboBox[1] = "NatureDemande";
            AttributComboBox[2] = "TypeDemande";


            ComboBox[] Demande2 = new ComboBox[3];
            Demande2[0] = StatutDemande;
            Demande2[1] = NatureDemande;
            Demande2[2] = TypeDemande;



            for (j = 0; j < AttributComboBox.Length; j++)
            {
                if (Demande2[j].SelectedIndex!=-1)
                {
                    query = query + "" + AttributComboBox[j] + "=" + "'" + Demande2[j].SelectedItem.ToString() + "'" + " And ";
                }

            }

            string[] AttributDatePicker = new string[1];
            AttributDatePicker[0] = "DateDemande";

            DatePicker[] Demande3 = new DatePicker[2];
            Demande3[0] = DateFrom;
            Demande3[1] = DateTo;


            if (Demande3[0].Text != "" && Demande3[1].Text!="")
                {
                    query = query + "" + AttributDatePicker[0]+ " " + "BETWEEN" +" "+  "STR_TO_DATE('" + Demande3[0].Text + "','%d/%m/%Y')" + " And " + "STR_TO_DATE('" + Demande3[1].Text + "', '%d/%m/%Y')" + " And ";
                }

            query = query + query2;
            Clipboard.SetText(query);
            return query;
        }
    }
}
