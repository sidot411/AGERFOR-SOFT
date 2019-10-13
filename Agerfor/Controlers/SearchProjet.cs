using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Agerfor.Controlers
{
    class SearchProjet
    {
        public string AdvencedSearchGetQuery(TextBox CodeProjet, TextBox NomProjetMaitre, TextBox NomProjet, TextBox AnneePublication,ComboBox wilaya, ComboBox Daira, ComboBox Commune)
        {
            int i;
            int j;
            int k;

            string query = "select *,Date_Format(DatePubliActe,'%d/%m/%y') AS DatePubli  from projet,projetmaitre,acteprojet where ";
            string query2 = "projet.ProjetMaitre = projetmaitre.NomProjetM";

            string[] AttributTextBox = new string[2];
            AttributTextBox[0] = "projet.RefProjet";
            AttributTextBox[1] = "YEAR(DatePubliActe)";

            TextBox[] Projet = new TextBox[2];
            Projet[0] = CodeProjet;
            Projet[1] = AnneePublication;

            for (i = 0; i < AttributTextBox.Length; i++)
            {
                if (Projet[i].Text != "")
                {
                    query = query + "" + AttributTextBox[i] + "=" + "'" + Projet[i].Text + "'" + " and ";
                }

            }

            string[] AttributTextBox2 = new string[2];
            AttributTextBox2[0] = "NomProjet";
            AttributTextBox2[1] = "ProjetMaitre";

            TextBox[] NProjet = new TextBox[2];
            NProjet[0] = NomProjet;
            NProjet[1] = NomProjetMaitre;


            for (j = 0; j < AttributTextBox2.Length; j++)
            {
                if (NProjet[j].Text != "")
                {
                    query = query + "" + AttributTextBox2[j] + " LIKE " + "'" + NProjet[j].Text + "%" + "'" + " and ";
                }
            }


            string[] AttributComboBox = new string[3];
            AttributComboBox[0] = "Wilaya";
            AttributComboBox[1] = "Daira";
            AttributComboBox[2] = "Commune";

            ComboBox[] LocProjet = new ComboBox[3];

            LocProjet[0] = wilaya;
            LocProjet[1] = Daira;
            LocProjet[2] = Commune;

            for (k = 0; k < AttributComboBox.Length; k++)
            {
                if (LocProjet[k].Text != "")
                {
                    query = query + "" + AttributComboBox[k] + "=" + "'" + LocProjet[k].Text + "'" + " and ";
                }
            }

            query = query + query2;
            //Clipboard.SetText(query);
            return query;
        }
    }
}
