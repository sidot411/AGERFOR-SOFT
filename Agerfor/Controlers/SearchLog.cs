using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Agerfor.Controlers
{
    class SearchLog
    {
        public string AdvencedSearchGetQuery(TextBox NumLot, TextBox Bloc, TextBox Niveau, TextBox NbrPiece,ComboBox NumIlot, ComboBox EtatBien,TextBox SurHMin,TextBox SurHMax,TextBox SurUMin , TextBox SurUMax,  int CodeProjet, int CodeProgramme, int NumEDD, string TypeBien)
        {
            int i;
            int j;
            int k;
            string query = "select * from biens where ";
            string query2 = "RefProjet='"+CodeProjet+"' And RefProgramme='"+CodeProgramme+"' And NumEDD='"+NumEDD+ "' And TypeBien='"+TypeBien+"'";

            string[] AttributTexteBox = new string[4];

            AttributTexteBox[0] = "Numlot";
            AttributTexteBox[1] = "NumBloc";
            AttributTexteBox[2] = "Niveau";
            AttributTexteBox[3] = "NbrPiece";

            TextBox[] log = new TextBox[4];
            log[0] = NumLot;
            log[1] = Bloc;
            log[2] = Niveau;
            log[3] = NbrPiece;

            for(i=0;i< AttributTexteBox.Length;i++)
            {
                if(log[i].Text!="")
                {
                    query = query +""+ AttributTexteBox[i] + "=" + "'"+ log[i].Text +"'"+ " And ";  
                }
            }

            string[] AttributComboBox = new string[2];

            AttributComboBox[0] = "NumIlot";
            AttributComboBox[1] = "Etat";
       
            ComboBox[] log2 = new ComboBox[2];
            log2[0] = NumIlot;
            log2[1] = EtatBien;

            for(j=0;j<AttributComboBox.Length;j++)
            {
                if (log2[j].Text != "")
                {
                    query = query + "" + AttributComboBox[j] + "=" + "'" + log2[j].Text + "'" + " And ";
                }

            }
            
            string[] Surf = new string[2];

            Surf[0] = "SurH";
            Surf[1] = "SurU";

            TextBox[] Sur = new TextBox[4];
            Sur[0] = SurHMin;
            Sur[1] = SurHMax;
            Sur[2] = SurUMin;
            Sur[3] = SurUMax;

            for (k = 0; k < Surf.Length;k++)
            {
                if (k==0 && Sur[0].Text != "0" && Sur[1].Text !="0")
                {
                    query = query + "" + Surf[k] + " Between " + "'" + Sur[0].Text + "'" + " And " + "'" + Sur[1].Text + "'"+" And ";
                }

                if (k == 1 && Sur[2].Text != "0" && Sur[3].Text != "0")
                {
                    query = query + "" + Surf[k] + " Between " + "'" + Sur[2].Text + "'" + " And " + "'" + Sur[3].Text + "'" + " And ";
                }



            }
            
            query = query + query2;
            return query;
        }
    }
}

