using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace Registratura
{
    public partial class SchimbareParola : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tempmail, tempnume;
            tempnume = Request.Cookies["dateutilizator"].Value;
            GetEmail m = new GetEmail();
            tempmail = m.GetMail(tempnume);
            tbxEmail.Text = tempmail;
        }

        protected void btnSchimbare_Click(object sender, EventArgs e)
        {
            try
            {
                


                string Email = tbxEmail.Text;
                string ParolaNoua1 = tbxparola1.Text;
                string ParolaNoua2 = tbxparola2.Text;
                if (Email != "" && ParolaNoua1 != "" && ParolaNoua2 != ""&& ParolaNoua1==ParolaNoua2)
                {

                    DataBase databaseObject = new DataBase();
                    databaseObject.OpenConnection();

                    string queryupdate = "UPDATE Useri" +
                        " SET Parola=@parola , Passwordcheck=@check"+
                        " WHERE Email=@email";
                    SqlCommand myCommand = new SqlCommand(queryupdate, databaseObject.myConnection);

                    myCommand.Parameters.AddWithValue("@parola", ParolaNoua2);
                    myCommand.Parameters.AddWithValue("@check", 1);
                    myCommand.Parameters.AddWithValue("@email", Email);
                    var result = myCommand.ExecuteNonQuery();

                    databaseObject.CloseConnection();

                   string script = "alert(\"Parola a fost schimbata!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                
                    
                    Response.Cookies["dateutilizator"].Expires = DateTime.Now.AddDays(-1D);
                    Session.Abandon();
                    Session.Clear();
                    Response.Cookies.Clear();
                    FormsAuthentication.SignOut();
                    HttpCookie cooku = new HttpCookie("dateutilizator");
                    // IsPersistent = false;
                    cooku.Expires = DateTime.Now.AddDays(1);
                    cooku.Value = "";
                    Response.Cookies.Add(cooku);

                    Response.Redirect("~/Login.aspx");
                
            }
                else
                {
                    string script = "alert(\"Completati toate campurile corect!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la schimbare parola!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
           }
        }
    }
}