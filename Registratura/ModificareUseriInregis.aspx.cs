using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Registratura
{
    public partial class ModificareUseriInregis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificare_Click(object sender, EventArgs e)
        {

            try
            {
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();

                string NumarDatadoc = tbxNumarDataDocument.Text; ;
                string Denumiredoc = tbxDenumireDocument.Text;
                string Proveniendoc = tbxProvenientaDocument.Text;
                string Destinatiedoc = tbxDestinatieDocument.Text;
                string TipDocumentdoc = ListBoxTip.SelectedValue;
               // int NumarDocument;

                if(int.TryParse(tbxNumarIntrareDocument.Text, out int docu))
                {
                    if (string.IsNullOrEmpty(Denumiredoc) || string.IsNullOrEmpty(Proveniendoc) || string.IsNullOrEmpty(Destinatiedoc) || string.IsNullOrEmpty(TipDocumentdoc))
                    {
                        string script = "alert(\"Completati toate campurile obligatorii!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        string query = "UPDATE InregistrariRegistratura SET NumarDataDocument=@NumarData,DenumireDocument=@Denumire,ProvenientaDocument=@Provenienta,DestinatieDocument=@Destinatie,TipDocument=@Tip " +
                            "WHERE NumarIntrareDocument=@Numarintrare";
                        SqlCommand mycommand = new SqlCommand(query, databaseObject.myConnection);
                        mycommand.Parameters.AddWithValue("@NumarData",NumarDatadoc);
                        mycommand.Parameters.AddWithValue("@Denumire", Denumiredoc);
                        mycommand.Parameters.AddWithValue("@Provenienta", Proveniendoc);
                        mycommand.Parameters.AddWithValue("@Destinatie", Destinatiedoc);
                        mycommand.Parameters.AddWithValue("@Tip", TipDocumentdoc);
                        mycommand.Parameters.AddWithValue("@Numarintrare", int.Parse(tbxNumarIntrareDocument.Text));

                        var result = mycommand.ExecuteNonQuery();

                        string script = "alert(\"Modificare document reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        tbxNumarIntrareDocument.Text = "";
                        tbxNumarDataDocument.Text = "";
                        tbxDenumireDocument.Text = "";
                        tbxDestinatieDocument.Text = "";
                        tbxProvenientaDocument.Text = "";
                        ListBoxTip.SelectedIndex = -1;
                    }
                }
                else
                {
                    string script = "alert(\"Introduceti Numar Intrare Document valid!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

                

                databaseObject.CloseConnection();
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare modificare document!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnAutocompleteDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string Numarintrare = tbxNumarIntrareDocument.Text;
                if(int.TryParse(Numarintrare,out int docu))
                {
                    int Numarint = int.Parse(Numarintrare);
                    DataBase databaseObject = new DataBase();
                    string query = "SELECT NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,TipDocument from InregistrariRegistratura " +
                        "WHERE NumarIntrareDocument=@NumarIntrareDocument";
                    SqlCommand mycommand = new SqlCommand(query,databaseObject.myConnection);
                    mycommand.Parameters.AddWithValue("@NumarIntrareDocument",Numarint);

                    databaseObject.OpenConnection();
                    string NumarDatadocread = "";
                    string Denumiredocread = "";
                    string Proveniendocread = "";
                    string Destinatiedocread = "";
                    string TipDocumentdocread = "";

                    SqlDataReader re = mycommand.ExecuteReader();
                    if (re.HasRows) 
                    {
                     
                        while (re.Read())
                        {
                             NumarDatadocread = re[0].ToString();
                             Denumiredocread = re[1].ToString();
                             Proveniendocread = re[2].ToString();
                             Destinatiedocread = re[3].ToString();
                             TipDocumentdocread = re[4].ToString();
                        }
                        tbxNumarDataDocument.Text = NumarDatadocread;
                        tbxDenumireDocument.Text = Denumiredocread;
                        tbxProvenientaDocument.Text = Proveniendocread;
                        tbxDestinatieDocument.Text = Destinatiedocread;
                        if (TipDocumentdocread == "Intrare")
                        {
                            ListBoxTip.SelectedIndex = 0;
                        }
                        else if(TipDocumentdocread=="Iesire")
                        {
                            ListBoxTip.SelectedIndex = 1;
                        }
                        else
                        {
                            ListBoxTip.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        string script = "alert(\"Nu exista document cu acel numar de intrare!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    re.Close();

                    databaseObject.CloseConnection();

                }
                else
                {
                    string script = "alert(\"Completati campul autocomplete corect!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

            }
            catch (Exception)
            {
                string script = "alert(\"Eroare Autocomplete!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnAutocompleteUser_Click(object sender, EventArgs e)
        {

            try
            {
                string Email = tbxEmail.Text;
                if (!string.IsNullOrEmpty(Email))
                {
                    
                    DataBase databaseObject = new DataBase();
                    string query = "SELECT Email,NumeUtilizator,Parola,Acces,Passwordcheck,Grup,StatusUser from Useri " +
                        "WHERE Email=@Email";
                    SqlCommand mycommand = new SqlCommand(query, databaseObject.myConnection);
                    mycommand.Parameters.AddWithValue("@Email", Email);

                    databaseObject.OpenConnection();
                    string Emailread = "";
                    string NumeUtilizatorread = "";
                    string Parolaread = "";
                    string Accesread = "";
                    string Passwordcheckread = "";
                    string Grupread = "";
                    string Statusread = "";

                    SqlDataReader re = mycommand.ExecuteReader();
                    if (re.HasRows)
                    {

                        while (re.Read())
                        {
                            Emailread = re[0].ToString();
                            NumeUtilizatorread = re[1].ToString();
                            Parolaread = re[2].ToString();
                            Accesread = re[3].ToString();
                            Passwordcheckread = re[4].ToString();
                            Grupread = re[5].ToString();
                            Statusread = re[6].ToString();

                        }
                        tbxEmail.Text = Emailread;
                        tbxNumeUtilizator.Text = NumeUtilizatorread;
                        tbxParola.Text = Parolaread;
                        
                        if (Accesread == "Admin")
                        {
                            ListBoxAcces.SelectedIndex = 1;
                        }
                        else if (Accesread == "User")
                        {
                            ListBoxAcces.SelectedIndex = 0;
                        }
                        else
                        {
                            ListBoxAcces.SelectedIndex = -1;
                        }
                        if (int.Parse(Passwordcheckread) == 1)
                        {
                            ListBoxReinitilizare.SelectedIndex = 0;
                        }
                        else if(int.Parse(Passwordcheckread) == 0)
                        {
                            ListBoxReinitilizare.SelectedIndex = 1;
                        }
                        else
                        {
                            ListBoxReinitilizare.SelectedIndex = -1;
                        }

                        if (Grupread == "Financiar")
                        {
                            DropDownListGrup.SelectedIndex = 1;
                        }
                        else if (Grupread=="Logistica")
                        {
                            DropDownListGrup.SelectedIndex = 2;
                        }
                        else if (Grupread == "HR")
                        {
                            DropDownListGrup.SelectedIndex = 3;
                        }
                        else if (Grupread == "HSE")
                        {
                            DropDownListGrup.SelectedIndex = 4;
                        }
                        else if (Grupread == "Purchasing")
                        {
                            DropDownListGrup.SelectedIndex = 5;
                        }
                        else if (Grupread == "Admini")
                        {
                            DropDownListGrup.SelectedIndex = 6;
                        }
                        else
                        {
                            DropDownListGrup.SelectedIndex = -1;
                        }
                        if (Statusread == "Activ")
                        {
                            ListBoxStatus.SelectedIndex = 0;
                        }
                        else if (Statusread == "Inactiv")
                        {
                            ListBoxStatus.SelectedIndex = 1;
                        }
                        else
                        {
                            ListBoxStatus.SelectedIndex = -1;
                        }

                    }
                    else
                    {
                        string script = "alert(\"Nu exista user cu acest mail!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    re.Close();

                    databaseObject.CloseConnection();

                }
                else
                {
                    string script = "alert(\"Completati campul de autocomplete!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

            }
            catch (Exception)
            {
                string script = "alert(\"Eroare Autocomplete!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void btnModificareUser_Click(object sender, EventArgs e)
        {
            try
            {
                
                string Email = tbxEmail.Text;
                string Parola = tbxParola.Text;
                string NumeUtilizator = tbxNumeUtilizator.Text;
                string Acces = ListBoxAcces.SelectedValue;
                string PassCheck = ListBoxReinitilizare.SelectedValue;
                string Grup = DropDownListGrup.SelectedValue;
                string StatusUser = ListBoxStatus.SelectedValue;
                int valoarepasscheck;
                if (PassCheck == "Efectuat")
                {
                    valoarepasscheck = 1;
                }
                else if(PassCheck=="Neefectuat")
                {
                    valoarepasscheck = 0;
                }
                else
                {
                    valoarepasscheck = 0;
                }
               

                string tempmail, tempnume;
                tempnume = Request.Cookies["dateutilizator"].Value;
                //if (temporole != null) { }
                GetEmail g = new GetEmail();
                tempmail = g.GetMail(tempnume);
                if (tempmail == Email || tempnume == NumeUtilizator)
                {
                    string script = "alert(\"Nu puteti modifica userul logat!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    if (string.IsNullOrEmpty(StatusUser)||Grup=="Va rugam selectati"||string.IsNullOrEmpty(Email)|| string.IsNullOrEmpty(NumeUtilizator)|| string.IsNullOrEmpty(Parola)|| string.IsNullOrEmpty(Acces)|| string.IsNullOrEmpty(PassCheck))
                    {
                        string script = "alert(\"Completati toate campurile obligatorii!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        DataBase databaseObject = new DataBase();
                        databaseObject.OpenConnection();
                        string query = "UPDATE Useri SET NumeUtilizator=@Numeutil,Parola=@Parola,Acces=@Acces,Email=@Email,Passwordcheck=@Passwordcheck,Grup=@Grup,StatusUser=@StatusUser " +
                            "WHERE Email=@Email";
                        SqlCommand mycommand = new SqlCommand(query, databaseObject.myConnection);
                        mycommand.Parameters.AddWithValue("@Numeutil", NumeUtilizator);
                        mycommand.Parameters.AddWithValue("@Parola", Parola);
                        mycommand.Parameters.AddWithValue("@Acces", Acces);
                        mycommand.Parameters.AddWithValue("@Email", Email);
                        mycommand.Parameters.AddWithValue("@Passwordcheck", valoarepasscheck);
                        mycommand.Parameters.AddWithValue("@Grup", Grup);
                        mycommand.Parameters.AddWithValue("@StatusUser", StatusUser);


                        var result = mycommand.ExecuteNonQuery();

                        databaseObject.CloseConnection();

                        string script = "alert(\"Modificare utilizator reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        tbxEmail.Text = "";
                        tbxNumeUtilizator.Text = "";
                        tbxParola.Text = "";
                        ListBoxAcces.SelectedIndex = -1;
                        ListBoxReinitilizare.SelectedIndex = -1;
                        DropDownListGrup.SelectedIndex = -1;
                        ListBoxStatus.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare modificare utilizator!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}