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
    public partial class AdaugareUtilizatori : System.Web.UI.Page
    {
        int nummail;
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.ListBox1.SelectedIndex = 0;
        }

        protected void btnInregistrare_Click(object sender, EventArgs e)
        {
            
            try
            {
                nummail = 0;
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();
                string Email = tbxEmail.Text;
                string NumeUtilizator = tbxNumeUtilizator.Text;
                string Parola = tbxParola.Text;
                string Acces = ListBox1.SelectedValue;
                string Grup = DropDownListGrup.SelectedValue;
                if(Grup=="Va rugam selectati"||string.IsNullOrEmpty(NumeUtilizator)||string.IsNullOrEmpty(Parola)||string.IsNullOrEmpty(Email)||ListBox1.SelectedIndex==-1)
                {
                    string scriptnoti = "alert(\"Completati toate campurile!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
                }
                else
                {
                    string queryexistamail = "SELECT * from Useri where Email='"+Email+"'";
                    databaseObject.OpenConnection();

                    SqlCommand myCommanduserexistamail = new SqlCommand(queryexistamail, databaseObject.myConnection);

                    databaseObject.OpenConnection();

                    SqlDataAdapter dauser = new SqlDataAdapter(myCommanduserexistamail);
                    DataTable dtuser = new DataTable();
                    dauser.Fill(dtuser);
                    foreach (DataRow row in dtuser.Rows)
                    {
                        nummail++;
                    }

                    if (nummail != 0)
                    {

                        string scriptnotiexistamail = "alert(\"Exista deja un utilizator cu acest mail!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnotiexistamail, true);

                    }

                    else
                    {


                        string query = "INSERT INTO Useri(NumeUtilizator,Parola,Acces,Email,Grup) VALUES(@NumeUtilizator,@Parola,@Acces,@Email,@Grup)";
                        SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



                        myCommand.Parameters.AddWithValue("@NumeUtilizator", NumeUtilizator);
                        myCommand.Parameters.AddWithValue("@Parola", Parola);
                        myCommand.Parameters.AddWithValue("@Acces", Acces);
                        myCommand.Parameters.AddWithValue("@Email", Email);
                        myCommand.Parameters.AddWithValue("@Grup", Grup);

                        var result = myCommand.ExecuteNonQuery();
                        string scriptnoti = "alert(\"Inregistrare utilizator reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);

                        tbxEmail.Text = "";
                        tbxNumeUtilizator.Text = "";
                        tbxParola.Text = "";
                        ListBox1.SelectedIndex = -1;
                        DropDownListGrup.SelectedIndex = -1;

                    }

                    databaseObject.CloseConnection();


                }
                databaseObject.CloseConnection();
            }
            catch(Exception)
            {
                string scriptnoti = "alert(\"Inregistrare utilizator nereusita!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
            }
        }

        protected void btnStergere_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();
                string EmailSters = tbxEmailSters.Text;
                if(string.IsNullOrEmpty(EmailSters))
                {
                    string scriptnoti = "alert(\"Completati campul Email de sters!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);

                }
                else
                {
                    string tempmail, tempnume;
                    tempnume = Request.Cookies["dateutilizator"].Value;
                    //if (temporole != null) { }
                    GetEmail g = new GetEmail();
                    tempmail = g.GetMail(tempnume);

                    if (EmailSters != tempmail)
                    {
                        string query = "DELETE from Useri WHERE Email=@Email";
                        SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



                        myCommand.Parameters.AddWithValue("@Email", EmailSters);
                        var result = myCommand.ExecuteNonQuery();
                        string scriptnoti = "alert(\"Stergere utilizator reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
                        tbxEmailSters.Text = "";
                    }
                    else
                    {
                        string scriptnotio = "alert(\"Nu puteti sterge userul curent logat!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnotio, true);
                    }
                    
                }
                databaseObject.CloseConnection();

            }
            catch(Exception)
            {
                string scriptnoti = "alert(\"Stergere utilizator nereusita!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataBase databaseObject = new DataBase();
            //    databaseObject.OpenConnection();
            //    string EmailSters = tbxEmailSters.Text;
            //    if (string.IsNullOrEmpty(EmailSters)||ListBox2.SelectedIndex==-1)
            //    {
            //        string scriptnoti = "alert(\"Completati campul Email de sters/update si Acces!\");";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);

            //    }
            //    else
            //    {
            //        string query = "UPDATE Useri SET Acces=@Acces WHERE Email=@Email";
            //        SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



            //        myCommand.Parameters.AddWithValue("@Email", EmailSters);

            //        myCommand.Parameters.AddWithValue("@Acces", ListBox2.SelectedValue);
            //        var result = myCommand.ExecuteNonQuery();
            //        string scriptnoti = "alert(\"Update utilizator reusit!\");";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
            //        tbxEmailSters.Text = "";
            //        ListBox2.SelectedIndex = -1;
            //    }
            //    databaseObject.CloseConnection();
            //}
            //catch (Exception)
            //{
            //    string scriptnoti = "alert(\"Update utilizator nereusit!\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
            //}
        }
    }
}