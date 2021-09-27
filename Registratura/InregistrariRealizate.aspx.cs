﻿using System;
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
    public partial class About : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();


                string queryp = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura";
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


                string queryp = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura";
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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
