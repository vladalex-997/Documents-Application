using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Registratura
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // tbxDatastop.Text= DateTime.Today.ToString("yyyy-MM-dd");
           // tbxDatastart.Text ="";
        }

        protected void btnCautare_Click(object sender, EventArgs e)
        {
            try
            {
                string temporole, tempnume, tempid;
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetPrivilage g = new GetPrivilage();
                GetIdUser i = new GetIdUser();
                temporole = g.GetRights(tempnume);
                tempid = i.GetUser(tempnume);

                if(temporole=="Admin")
                {

                    DataBase databaseObject = new DataBase();


                    string DenumireDocument = tbxDenumireDocument.Text;
                    string DestinatieDocument = tbxDestinatieDocument.Text;
                    string ProvenientaDocument = tbxProvenientaDocument.Text;
                    string TipDocument = tbxTipDocument.Text;
                    //var DataStart = tbxDatastart.Text;
                    //var DataStop = tbxDatastop.Text;

                    //var cultureinfo = new CultureInfo("en-US");

                    //var tempista = DateTime.ParseExact(DataStart, "yyyy-MM-dd", cultureinfo);
                    //var tempisto = DateTime.ParseExact(DataStop, "yyyy-MM-dd", cultureinfo);
                    //var comparstart1 = tempista.ToString("MM/dd/yyyy");
                    //var comparstop1 = tempisto.ToString("MM/dd/yyyy");
                    //var comparstart = DateTime.ParseExact(comparstart1,"MM/dd/yyyy",cultureinfo);
                    //var comparstop = DateTime.ParseExact(comparstop1,"MM/dd/yyyy", cultureinfo);




                    //var bla1 = DateTime.ParseExact(DataStart,"yyyy-mm-dd",CultureInfo.InvariantCulture);
                    //var bla2 = DateTime.ParseExact(DataStop, "yyyy-mm-dd", CultureInfo.InvariantCulture);


                    string tempoid = "";
                    tempoid = Request.Cookies["dateutilizator"].Value;
                    GetIdUser id = new GetIdUser();
                    tempoid = id.GetUser(tempoid);
                    // int idint = int.Parse(tempoid);

                    //string querydef = "SELECT DenumireDocument,ProvenientaDocument,DestinatieDocument,DataInregistrarii from InregistrariRegistratura";

                    var v1 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument == "");
                    var v2 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument != "");
                    var v3 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument == "");
                    var v4 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument != "");
                    var v5 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument == "");
                    var v6 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument != "");
                    var v7 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument == "");
                    var v8 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument != "");
                    var v9 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument == "");
                    var v10 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument != "");
                    var v11 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument == "");
                    var v12 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument != "");
                    var v13 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument == "");
                    var v14 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument != "");
                    var v15 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument == "");
                    var v16 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument != "");


                    string queryfin = "";

                    if (v1)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura ";
                            

                    }
                    else if (v2)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE TipDocument LIKE '%" + TipDocument + "%'";

                    }

                    else if (v3)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' ";
                           


                        //string script = "alert(\"Ramura 3!\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else if (v4)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                          "WHERE ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                          "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v5)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DestinatieDocument LIKE '%" + DestinatieDocument + "%'";


                    }
                    else if (v6)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v7)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +


                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if (v8)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +


                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                            "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v9)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%'";


                    }
                    else if (v10)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                          "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                          "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v11)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if (v12)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                         "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                         "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                         "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v13)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%'";
                    }
                    else if (v14)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v15)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if (v16)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE DenumireDocument LIKE '%" + DenumireDocument + "%' " +


                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura ";
                           
                    }




                    // try
                    // {

                    databaseObject.OpenConnection();

                    SqlCommand myquerytab = new SqlCommand(queryfin, databaseObject.myConnection);

                    SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                    DataTable dttab = new DataTable();
                    DataSet ds = new DataSet();
                    daquery.Fill(dttab);
                    daquery.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();


                    // }
                    // catch(Exception)
                    // {
                    //    string script = "alert(\"Eroare Cautare Nereusita!\");";
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    //}

                    databaseObject.CloseConnection();

                }


            
                else
                {

                    DataBase databaseObject = new DataBase();


                    string DenumireDocument = tbxDenumireDocument.Text;
                    string DestinatieDocument = tbxDestinatieDocument.Text;
                    string ProvenientaDocument = tbxProvenientaDocument.Text;
                    string TipDocument = tbxTipDocument.Text;
                    //var DataStart = tbxDatastart.Text;
                    //var DataStop = tbxDatastop.Text;

                    //var cultureinfo = new CultureInfo("en-US");

                    //var tempista = DateTime.ParseExact(DataStart, "yyyy-MM-dd", cultureinfo);
                    //var tempisto = DateTime.ParseExact(DataStop, "yyyy-MM-dd", cultureinfo);
                    //var comparstart1 = tempista.ToString("MM/dd/yyyy");
                    //var comparstop1 = tempisto.ToString("MM/dd/yyyy");
                    //var comparstart = DateTime.ParseExact(comparstart1,"MM/dd/yyyy",cultureinfo);
                    //var comparstop = DateTime.ParseExact(comparstop1,"MM/dd/yyyy", cultureinfo);




                    //var bla1 = DateTime.ParseExact(DataStart,"yyyy-mm-dd",CultureInfo.InvariantCulture);
                    //var bla2 = DateTime.ParseExact(DataStop, "yyyy-mm-dd", CultureInfo.InvariantCulture);


                    string tempoid = "";
                    tempoid = Request.Cookies["dateutilizator"].Value;
                    GetIdUser id = new GetIdUser();
                    tempoid = id.GetUser(tempoid);
                    // int idint = int.Parse(tempoid);

                    //string querydef = "SELECT DenumireDocument,ProvenientaDocument,DestinatieDocument,DataInregistrarii from InregistrariRegistratura";

                    var v1 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument == "");
                    var v2 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument != "");
                    var v3 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument == "");
                    var v4 = (DenumireDocument == "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument != "");
                    var v5 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument == "");
                    var v6 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument != "");
                    var v7 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument == "");
                    var v8 = (DenumireDocument == "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument != "");
                    var v9 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument == "");
                    var v10 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument == "" && TipDocument != "");
                    var v11 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument == "");
                    var v12 = (DenumireDocument != "" && DestinatieDocument == "" && ProvenientaDocument != "" && TipDocument != "");
                    var v13 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument == "");
                    var v14 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument == "" && TipDocument != "");
                    var v15 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument == "");
                    var v16 = (DenumireDocument != "" && DestinatieDocument != "" && ProvenientaDocument != "" && TipDocument != "");


                    string queryfin = "";

                    if (v1)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "'";

                    }
                    else if (v2)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND TipDocument LIKE '%" +TipDocument + "%'";
                    }

                    else if (v3)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE IdUser ='" + tempoid + "' " +
                           "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";

                        //string script = "alert(\"Ramura 3!\");";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else if (v4)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                          "WHERE IdUser ='" + tempoid + "' " +
                          "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                          "AND TipDocument LIKE '%" + TipDocument + "%'";
                          
                    }

                    else if (v5)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%'";
                    }
                    else if (v6)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE IdUser ='" + tempoid + "' " +
                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v7)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if (v8)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE IdUser ='" + tempoid + "' " +
                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v9)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DenumireDocument LIKE '%" + DenumireDocument + "%'";
                    }
                    else if (v10)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                        "WHERE IdUser ='" + tempoid + "' " +
                        "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                        "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v11)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if(v12)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                         "WHERE IdUser ='" + tempoid + "' " +
                         "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                         "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                         "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v13)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%'";
                    }
                    else if (v14)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE IdUser ='" + tempoid + "' " +
                           "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else if (v15)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "' " +
                            "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                            "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                            "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%'";
                    }
                    else if (v16)
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                           "WHERE IdUser ='" + tempoid + "' " +
                           "AND DenumireDocument LIKE '%" + DenumireDocument + "%' " +
                           "AND DestinatieDocument LIKE '%" + DestinatieDocument + "%' " +
                           "AND ProvenientaDocument LIKE '%" + ProvenientaDocument + "%' " +
                           "AND TipDocument LIKE '%" + TipDocument + "%'";
                    }

                    else
                    {
                        queryfin = "SELECT NumarIntrareDocument,IdUser,DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,NumeFisier,TipDocument from InregistrariRegistratura " +
                            "WHERE IdUser ='" + tempoid + "'";
                    }




                    // try
                    // {

                    databaseObject.OpenConnection();

                    SqlCommand myquerytab = new SqlCommand(queryfin, databaseObject.myConnection);

                    SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
                    DataTable dttab = new DataTable();
                    DataSet ds = new DataSet();
                    daquery.Fill(dttab);
                    daquery.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();


                    // }
                    // catch(Exception)
                    // {
                    //    string script = "alert(\"Eroare Cautare Nereusita!\");";
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    //}

                    databaseObject.CloseConnection();

                }

    
            }
            catch(Exception)
            {
                string script = "alert(\"Eroare Cautare Nereusita!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }

        protected void btnDescarcare_Click(object sender, EventArgs e)
        {

            try
            {
                string temporole, tempnume, tempid, tempgrup;
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetPrivilage g = new GetPrivilage();
                GetIdUser i = new GetIdUser();
                GetUserGrup gru = new GetUserGrup();
                temporole = g.GetRights(tempnume);
                tempid = i.GetUser(tempnume);
                tempgrup = gru.GetGrup(tempnume);

                byte[] bytes;
                string fileName, contentType;

                if (temporole == "Admin")
                {

                    if (int.TryParse(tbxDocumentdescarcat.Text, out int docu))
                    {
                        DataBase databaseObject = new DataBase();
                        databaseObject.OpenConnection();
                        string querydownload = "SELECT NumeFisier,TipFisier,DataFisier from InregistrariRegistratura " +
                            "WHERE NumarIntrareDocument=@NumarIntrare";
                        SqlCommand myCommand = new SqlCommand(querydownload, databaseObject.myConnection);
                        myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxDocumentdescarcat.Text));
                        using (SqlDataReader sdr = myCommand.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["DataFisier"];
                            contentType = sdr["TipFisier"].ToString();
                            fileName = sdr["NumeFisier"].ToString();
                        }
                        databaseObject.CloseConnection();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = contentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();


                    }
                    else
                    {
                        string script = "alert(\"Introduceti numarul documentului!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }

                }

                else
                {


                    if (int.TryParse(tbxDocumentdescarcat.Text, out int docu))
                    {
                        DataBase databaseObject = new DataBase();
                        databaseObject.OpenConnection();
                        string querydownload = "SELECT I.NumeFisier,I.TipFisier,I.DataFisier from Useri as U FULL JOIN InregistrariRegistratura as I ON U.IdUser=I.IdUser " +
                            "WHERE NumarIntrareDocument=@NumarIntrare AND Grup=@Grup";
                        SqlCommand myCommand = new SqlCommand(querydownload, databaseObject.myConnection);
                        myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxDocumentdescarcat.Text));
                        myCommand.Parameters.AddWithValue("@Grup", tempgrup);
                        using (SqlDataReader sdr = myCommand.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["DataFisier"];
                            contentType = sdr["TipFisier"].ToString();
                            fileName = sdr["NumeFisier"].ToString();
                        }
                        databaseObject.CloseConnection();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = contentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();


                    }
                    else
                    {
                        string script = "alert(\"Introduceti numarul documentului corect!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }

                }


            }
            catch (Exception)
            {
                string script = "alert(\"Eroare la descarcarea fisierului!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

        }
    }
}