using System;
using System.Windows;

namespace Agerfor.Controlers
{
    class ActeProgrammeController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterActeProgramme(string NumActe, string DateActe, string DateEnrgActe, string DatePubliActe, string Conservation, decimal FraisEnrg, string RefProgramme, string NomProjet
            )
        {
            try
            {
                msh.ExecuteQuery("insert into acteprogramme values('" + NumActe + "','" + DateActe + "','" + DateEnrgActe + "','" + DatePubliActe + "','" + Conservation + "','" + FraisEnrg + "','"+RefProgramme+"','"+NomProjet+"')");
                MessageBox.Show("L'Acte à était bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était ajouté");
            }
        }
        public void EditerActe(string NumActe, string DateActe, string DateEnrgActe, string DatePubliActe, string Conservation, decimal FraisEnrg, string RefProgramme, string NomProjet, string tempNumActeProgramme)
        {
            try
            {
                msh.ExecuteQuery("update acteprogramme set NumActe='" + NumActe + "',DateActe='" + DateActe + "',DateEnrgActe='" + DateEnrgActe + "',DatePubliActe='" + DatePubliActe + "',Conservation='" + Conservation + "', FraisEnrg='"+FraisEnrg+ "',RefProgramme='" + RefProgramme+ "',NomProjet='"+NomProjet+"' where RefProgramme='" + RefProgramme + "' and acteprogramme.NumActe='" + tempNumActeProgramme + "'");
                MessageBox.Show("L'Acte à était bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était modifié");
            }
        }
        public void SupprimerActe(string NumActe)
        {
            try
            {
                msh.ExecuteQuery("delete from acteprogramme where NumActe = '" + NumActe + "'");
                MessageBox.Show("L'Acte à était bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était supprimé");
            }
        }
        public void SupprimerActeFromProjet(string RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from acteprogramme where RefProjet = '" + RefProjet + "'");
                MessageBox.Show("L'Acte à était bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était supprimé");
            }
        }
    }
}

