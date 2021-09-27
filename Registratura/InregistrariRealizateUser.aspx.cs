using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Registratura
{
    public partial class InregistrariRealizateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();

                string tempnume = "";
                string tempgrup = "";
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetUserGrup gr = new GetUserGrup();
                tempgrup = gr.GetGrup(tempnume);

                string queryp = "SELECT I.NumarIntrareDocument,I.IdUser,I.DataInregistrarii,I.NumarDataDocument,I.DenumireDocument,I.ProvenientaDocument,I.DestinatieDocument,I.InregistratDe,I.NumeFisier,I.TipDocument from Useri as U FULL JOIN InregistrariRegistratura as I ON U.IdUser=I.IdUser WHERE Grup ='" + tempgrup + "'";
                SqlCommand myquerytab = new SqlCommand(queryp, databaseObject.myConnection);

                SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                DataTable dttab = new DataTable();
                DataSet ds = new DataSet();
                daquery.Fill(dttab);
                daquery.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();




                //myCommand.Dispose();
                databaseObject.CloseConnection();
            }
            catch(Exception)
            {
                string script = "alert(\"Eroare la incarcare rezultate!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();

                string tempnume = "";
                string tempgrup = "";
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetUserGrup gr = new GetUserGrup();
                tempgrup = gr.GetGrup(tempnume);

                string queryp = "SELECT I.NumarIntrareDocument,I.IdUser,I.DataInregistrarii,I.NumarDataDocument,I.DenumireDocument,I.ProvenientaDocument,I.DestinatieDocument,I.InregistratDe,I.NumeFisier,I.TipDocument from Useri as U FULL OUTER JOIN InregistrariRegistratura as I ON U.IdUser=I.IdUser WHERE Grup ='" + tempgrup + "'";
                SqlCommand myquerytab = new SqlCommand(queryp, databaseObject.myConnection);

                SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                DataTable dttab = new DataTable();
                DataSet ds = new DataSet();
                daquery.Fill(dttab);
                daquery.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();




                //myCommand.Dispose();
                databaseObject.CloseConnection();
            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la incarcare rezultate!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}