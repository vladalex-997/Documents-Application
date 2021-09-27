using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;

namespace Registratura
{
    public partial class Login : System.Web.UI.Page
    {
       bool verifmail;
        // bool verifpass;
        int nummail;
        int numpass;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!statusaute)
            //{
            //    statuslogin.Text = "Autentificare esuata. Incercati din nou";
            //}
             verifmail = false;
            //// bool verifpass = false;
             nummail = 0;
             numpass = 0;
            //tbxNumeUtilizator.Text = "completati aici utilizator";
            //tbxParola.Text = "completati aici parola";
            HttpCookie cooku = new HttpCookie("dateutilizator");
            cooku.Expires = DateTime.Now.AddDays(1);
            cooku.Value ="";
            Response.Cookies.Add(cooku);

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
             try { 
            Response.Cookies["dateutilizator"].Expires = DateTime.Now.AddDays(-1D);
            verifmail = false;
            //// bool verifpass = false;
            nummail = 0;
            numpass = 0;






            DataBase databaseObject = new DataBase();

           

            string queryuser = "SELECT * from Useri where Email ='" + tbxEmail.Text + "'";


            SqlCommand myCommanduser = new SqlCommand(queryuser, databaseObject.myConnection);

            databaseObject.OpenConnection();

            SqlDataAdapter dauser = new SqlDataAdapter(myCommanduser);
            DataTable dtuser = new DataTable();
            dauser.Fill(dtuser);
            foreach (DataRow row in dtuser.Rows)
            {
                nummail++;
            }



            databaseObject.CloseConnection();

            if (nummail == 1)
            {
                verifmail = true;
                    string StatusUser="";
                    string querystatus = "SELECT StatusUser from Useri where Email='"+tbxEmail.Text+"'";

                    SqlCommand myCommandstatususer = new SqlCommand(querystatus, databaseObject.myConnection);

                    databaseObject.OpenConnection();

                    SqlDataReader re = myCommandstatususer.ExecuteReader();
                    if (re.HasRows)
                    {
                        while(re.Read())
                        {
                            StatusUser = re[0].ToString();
                        }
                    }
                    re.Close();

                    databaseObject.CloseConnection();

                    if (StatusUser == "Activ")
                    {

                        string querypass = "SELECT * from Useri where Email='" + tbxEmail.Text + "' AND Parola='" + tbxParola.Text + "'";

                        databaseObject.OpenConnection();



                        SqlCommand myCommandpass = new SqlCommand(querypass, databaseObject.myConnection);
                        SqlDataAdapter dapass = new SqlDataAdapter(myCommandpass);
                        DataTable dtpa = new DataTable();
                        dapass.Fill(dtpa);
                        foreach (DataRow row in dtpa.Rows)
                        {
                            numpass++;
                        }

                        databaseObject.CloseConnection();

                        if (numpass == 1)
                        {
                            verifmail = true;
                        }
                        else
                        {
                            verifmail = false;
                        }

                        if (verifmail == true)
                        {
                            //GetPrivilage g = new GetPrivilage();
                            //string tempo = g.GetRights(tbxNumeUtilizator.Text);
                            //string script = "alert(\""+tempo+"\");";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                            //string script = "alert(\"Autentificare reusita!\");";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            string queryutilizator = "Select NumeUtilizator from Useri where Email='" + tbxEmail + "'";

                            SqlCommand myCommandutilizator = new SqlCommand(queryutilizator, databaseObject.myConnection);

                            databaseObject.OpenConnection();
                            string temporary = (string)myCommanduser.ExecuteScalar().ToString();

                            databaseObject.CloseConnection();


                            HttpCookie cooku = new HttpCookie("dateutilizator");
                            cooku.Expires = DateTime.Now.AddDays(1);
                            cooku.Value = temporary;
                            Response.Cookies.Add(cooku);

                            //FormsAuthentication.SetAuthCookie(tbxNumeUtilizator.Text, false);


                            Session["login"] = temporary;

                            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            //1,
                            //tbxNumeUtilizator.Text,
                            //DateTime.Now,
                            //DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationSettings.AppSettings["SessionExpiry"])), // value of time out property
                            //false, // Value of IsPersistent property!!!
                            //String.Empty,
                            //FormsAuthentication.FormsCookiePath);

                            GetPassword p = new GetPassword();
                            string val = (p.GetPasswordCheck(temporary));
                            if (val == "1")
                            {
                                Response.Redirect("~/InregistrareDocumente.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/SchimbareParola.aspx");
                            }
                            ////now encrypt the auth-ticket
                            //string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                            ////now save the ticket to a cookie
                            //HttpCookie authCookie = new HttpCookie(
                            //            FormsAuthentication.FormsCookieName,
                            //            encryptedTicket);
                            ////authCookie.Expires = expires;

                            ////feed the cookie to the browser
                            //HttpContext.Current.Response.Cookies.Add(authCookie);
                            //FormsAuthentication.SetAuthCookie(tbxNumeUtilizator.Text, false);


                            //FormsAuthentication.RedirectFromLoginPage(tbxNumeUtilizator.Text, true);
                            //menulogin.Visible = false;
                        }
                        else
                        {
                            //string script = "alert(\"Mail sau parola gresite!\");";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                            //Response.Write("NU");
                            //    //string script = "alert(\"Autentificare nereusita!\");";
                            //    // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            //    //statuslogin.Text = "Autentificare esuata. Incercati din nou";
                            //    //statusaute = false;
                        }

                    }
                    else if(StatusUser=="Inactiv")
                    {
                        string script = "alert(\"Utilizatorul este inactiv!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        string script = "alert(\"Utilizatorul nu are status corect!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }

              

                    
                }
                

            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la autentificare!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}