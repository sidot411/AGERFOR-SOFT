using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Agerfor.Controlers
{
    class SearchProgramme
    {
        public string AdvencedSearchGetQuery(TextBox CodeProjet, TextBox NomProjet, TextBox CodeProgramme, TextBox NomProgramme, ComboBox Daira, ComboBox Commune, ComboBox NatureProgramme, ComboBox TypeProgramme)
        {
            int i;
            int j;
            int k;
         

            string query = "select NomProjet,RefProgramme,programme.RefProjet,NomProgramme,programme.Site,programme.Daira,programme.Commune,NatureProgramme,TypeProgramme,NombreBiens,programme.Superficie,TypeVente,CoutFoncier,TVA,CoutFoncierTTC,PrixM2 from programme,projet where ";
            string query2 = "programme.RefProjet = projet.RefProjet";

            string[] AttributTextBox = new string[2];
            AttributTextBox[0] = "programme.RefProjet";
            AttributTextBox[1] = "RefProgramme";
           

            TextBox[] prg = new TextBox[2];
            prg[0] = CodeProjet;
            prg[1] = CodeProgramme;


            for (i = 0; i < AttributTextBox.Length; i++)
            {
                if (prg[i].Text != "")
                {
                    query = query + "" + AttributTextBox[i] + "=" + "'" + prg[i].Text + "'" + " And ";
                }
            }

            string[] AttributTextBox2 = new string[2];
            AttributTextBox2[0] = "NomProjet";
            AttributTextBox2[1] = "NomProgramme";


            TextBox[] prg3 = new TextBox[2];
            prg3[0] = NomProjet;
            prg3[1] = NomProgramme;
  

            for (k = 0; k < AttributTextBox2.Length; k++)
            {
                if (prg3[k].Text != "")
                {
                    query = query + "" + AttributTextBox2[k] + " LIKE " + "'" + prg3[k].Text +"%"+ "'" + " And ";
                }
            }

            string[] AttributComboBox = new string[4];

            AttributComboBox[0] = "programme.Daira";
            AttributComboBox[1] = "programme.Commune";
            AttributComboBox[2] = "NatureProgramme";
            AttributComboBox[3] = "TypeProgramme";

            ComboBox[] prg2 = new ComboBox[4];
            prg2[0] = Daira;
            prg2[1] = Commune;
            prg2[2] = NatureProgramme;
            prg2[3] = TypeProgramme;


            for (j = 0; j < AttributComboBox.Length; j++)
            {
                if (prg2[j].Text!="")
                {
                    query = query + "" + AttributComboBox[j] + "=" + "'" + prg2[j].Text + "'" + " And ";
                }

            }

            query = query + query2;
            Clipboard.SetText(query);
            return query;
        }

    }
}
