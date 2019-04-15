using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agerfor.Controlers
{
    class SearchProgramme
    {
        public string AdvencedSearchGetQuery(TextBox CodeProjet, TextBox NomProjet, TextBox CodeProgramme, TextBox NomProgramme, ComboBox Daira, ComboBox Commune, ComboBox NatureProgramme, ComboBox TypeProgramme)
        {
            int i;
            int j;
   
            string query = "select * from programme where ";

            string[] AttributTextBox = new string[4];
            AttributTextBox[0] = "RefProjet";
            AttributTextBox[1] = "NomProjet";
            AttributTextBox[2] = "RefProgramme";
            AttributTextBox[3] = "NomProgramme";

            TextBox[] prg = new TextBox[4];
            prg[0] = CodeProjet;
            prg[1] = NomProjet;
            prg[2] = CodeProgramme;
            prg[3] = NomProgramme;

            for (i = 0; i < AttributTextBox.Length; i++)
            {
                if (prg[i].Text != "")
                {
                    query = query + "" + AttributTextBox[i] + "=" + "'" + prg[i].Text + "'" + " And ";
                }
            }

            string[] AttributComboBox = new string[4];

            AttributComboBox[0] = "Daira";
            AttributComboBox[1] = "Commune";
            AttributComboBox[2] = "NatureProgramme";
            AttributComboBox[3] = "TypeProgramme";

            ComboBox[] prg2 = new ComboBox[4];
            prg2[0] = Daira;
            prg2[1] = Commune;
            prg2[2] = NatureProgramme;
            prg2[3] = TypeProgramme;


            for (j = 0; j < AttributComboBox.Length; j++)
            {
                if (prg2[j].Text != "")
                {
                    query = query + "" + AttributComboBox[j] + "=" + "'" + prg2[j].Text + "'" + " And ";
                }

            }
        
            query = query.Remove(query.Length - 4);
            return query;
        }

    }
}
