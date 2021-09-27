using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;


namespace Registratura
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime currenttime = DateTime.Now;
            string currenttimestring;
            currenttimestring = currenttime.ToString();
            labelDataCalen.Text = currenttimestring;
            string temporole, tempnume;
            tempnume = Request.Cookies["dateutilizator"].Value;
            GetPrivilage g = new GetPrivilage();
            temporole = g.GetRights(tempnume);
            if(temporole=="Admin")
            {
                btnStergere.Visible = true;
            }
            else
            {
                btnStergere.Visible = false;
            }
            
        }

        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }

        protected void btnInregistrare_Click(object sender, EventArgs e)
        {
            

             try
            {
                DataBase databaseObject = new DataBase();
                databaseObject.OpenConnection();

                //string Dat = "Jan 3, 2009";
                // var DataInregistrarii = DateTime.Parse(Dat);
                //string DataInregistrarii = "Jan 3, 2010";



                //Stringuri de test
                /*
                string NumarDataDocument = "gfgf";
                 string DenumireDocument = "dfdfdf";
                 string ProvenientaDocument = "klklkl";
                 string DestinatieDocument = "fgfg";
                 string InregistratDe = "fgfgfgkjk";

                */

                string TipDocument = DropDownList1.SelectedValue;
                //Stringuri din TextBox
                var DataInregistrarii = DateTime.Now;
            string NumarDataDocument = tbxNumar_Data.Text;
            string DenumireDocument = tbxDenumire.Text;
            string ProvenientaDocument = tbxProvenienta.Text;
            string DestinatieDocument = tbxDestinatieDoc.Text;

            string InregistratDe = Request.Cookies["dateutilizator"].Value;

                if (TipDocument=="Va rugam selectati"||string.IsNullOrEmpty(DenumireDocument)||string.IsNullOrEmpty(ProvenientaDocument)||string.IsNullOrEmpty(DestinatieDocument)||string.IsNullOrEmpty(InregistratDe))
                {
                    string scriptnoti = "alert(\"Completati toate campurile!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
                }

                else
                {
                    string tempoid = "";
                    tempoid = Request.Cookies["dateutilizator"].Value;
                    GetIdUser id = new GetIdUser();
                    tempoid = id.GetUser(tempoid);



                    string query = "INSERT into InregistrariRegistratura (DataInregistrarii,NumarDataDocument,DenumireDocument,ProvenientaDocument,DestinatieDocument,InregistratDe,IdUser,TipDocument) VALUES (@DataInregistrarii,@NumarDataDocument,@DenumireDocument,@ProvenientaDocument,@DestinatieDocument,@InregistratDe,@IdUser,@TipDocument)";
                    SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



                    myCommand.Parameters.AddWithValue("@DataInregistrarii", DataInregistrarii);
                    myCommand.Parameters.AddWithValue("@NumarDataDocument", NumarDataDocument);
                    myCommand.Parameters.AddWithValue("@DenumireDocument", DenumireDocument);
                    myCommand.Parameters.AddWithValue("@ProvenientaDocument", ProvenientaDocument);
                    myCommand.Parameters.AddWithValue("@DestinatieDocument", DestinatieDocument);
                    myCommand.Parameters.AddWithValue("@InregistratDe", InregistratDe);
                    myCommand.Parameters.AddWithValue("@IdUser", tempoid);
                    myCommand.Parameters.AddWithValue("@TipDocument", TipDocument);

                    var result = myCommand.ExecuteNonQuery();

                    string temporary = "";
                    string queryinregistrare = "SELECT NumarIntrareDocument from InregistrariRegistratura where DenumireDocument ='" + tbxDenumire.Text + "' AND NumarDataDocument ='" + tbxNumar_Data.Text + "' AND ProvenientaDocument ='"+tbxProvenienta.Text+"' AND DestinatieDocument ='"+tbxDestinatieDoc.Text+"'";


                    SqlCommand myCommandinregistrare = new SqlCommand(queryinregistrare, databaseObject.myConnection);

                    databaseObject.OpenConnection();
                    temporary = (string)myCommandinregistrare.ExecuteScalar().ToString();
                    databaseObject.CloseConnection();

                    string script = "alert(\"Inregistrare Reusita! Numarul de inregistrare este: " + temporary + "\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    ultimdocument.Text = temporary;
                    tbxDenumire.Text = "";
                    tbxDestinatieDoc.Text = "";
                    tbxNumar_Data.Text = "";
                    tbxProvenienta.Text = "";
                    DropDownList1.SelectedIndex = -1;
                }
                databaseObject.CloseConnection();
            }
             catch(Exception)
             {
               string script = "alert(\"Inregistrare Nereusita!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
               
             }
            
            
            /*
             
            //Select numar de inregistrari
             
            int numarinregistrari = 0;
            string queryp = "SELECT * from InregistrariRegistratura";
            SqlCommand myquerytab = new SqlCommand(queryp, databaseObject.myConnection);

            SqlDataAdapter daquery = new SqlDataAdapter(myquerytab);
            DataTable dttab = new DataTable();
            daquery.Fill(dttab);

            foreach (DataRow row in dttab.Rows)
            {
                numarinregistrari++;
            }

            string rez = numarinregistrari.ToString();
            // MessageBox(InregistrareDocumente, rez);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('"+rez+"')", true);

            */
            
            //myCommand.Dispose();
          

           
        }
        protected void btnTestareConexiune_Click(object sender, EventArgs e)
        {
            DataBase databaseObject = new DataBase();

            try
            {
                databaseObject.OpenConnection();
                string script = "alert(\"Conexiune reusita cu baza de date!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                databaseObject.CloseConnection();

            }
            catch (Exception)
            {
                string script = "alert(\"Conexiune nereusita cu baza de date!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btnIncarcare_Click(object sender, EventArgs e)
        {
            try
            {
                string temporole, tempnume,tempid;
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetPrivilage g = new GetPrivilage();
                GetIdUser i = new GetIdUser();
                temporole = g.GetRights(tempnume);
                tempid = i.GetUser(tempnume);

                if (temporole == "Admin")
                {

                    if (FileUpload1.HasFile && int.TryParse(tbxdocumentincarcat.Text, out int docu))
                    {
                        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string contentType = FileUpload1.PostedFile.ContentType;
                        using (Stream fs = FileUpload1.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                DataBase databaseObject = new DataBase();
                                databaseObject.OpenConnection();
                                string queryupdate = "UPDATE InregistrariRegistratura " +
                                    "SET NumeFisier=@filename , TipFisier=@contenttype , DataFisier=@bytes " +
                                    "WHERE NumarIntrareDocument=@NumarIntrare";

                                SqlCommand myCommand = new SqlCommand(queryupdate, databaseObject.myConnection);

                                myCommand.Parameters.AddWithValue("@filename", filename);
                                myCommand.Parameters.AddWithValue("@contenttype", contentType);
                                myCommand.Parameters.AddWithValue("@bytes", bytes);
                                myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxdocumentincarcat.Text));


                                var result = myCommand.ExecuteNonQuery();
                                databaseObject.CloseConnection();
                                string script = "alert(\"Fisierul a fost incarcat!\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                tbxdocumentincarcat.Text = "";

                            }
                        }

                    }
                    else
                    {
                        string script = "alert(\"Selectati un fisier pentru upload si introduceti numarul documentului!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    }
                }

                else
                {


                    if (FileUpload1.HasFile && int.TryParse(tbxdocumentincarcat.Text, out int docu))
                    {
                        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string contentType = FileUpload1.PostedFile.ContentType;
                        using (Stream fs = FileUpload1.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                DataBase databaseObject = new DataBase();
                                databaseObject.OpenConnection();
                                string queryupdate = "UPDATE InregistrariRegistratura " +
                                    "SET NumeFisier=@filename , TipFisier=@contenttype , DataFisier=@bytes " +
                                    "WHERE NumarIntrareDocument=@NumarIntrare AND IdUser=@IdUser";

                                SqlCommand myCommand = new SqlCommand(queryupdate, databaseObject.myConnection);

                                myCommand.Parameters.AddWithValue("@filename", filename);
                                myCommand.Parameters.AddWithValue("@contenttype", contentType);
                                myCommand.Parameters.AddWithValue("@bytes", bytes);
                                myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxdocumentincarcat.Text));
                                myCommand.Parameters.AddWithValue("@IdUser",tempid);


                                var result = myCommand.ExecuteNonQuery();
                                databaseObject.CloseConnection();

                                

                                if (result!=0)
                                {
                                    string script = "alert(\"Fisierul a fost incarcat!\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                }
                                else
                                {
                                    string script = "alert(\"Nu aveti voie sa incarcati documente la inregistrari ce nu va apartin!\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                }
                                tbxdocumentincarcat.Text = "";
                               
                            }
                        }

                    }
                    else
                    {
                        string script = "alert(\"Selectati un fisier pentru upload si introduceti numarul documentului corect!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    }
                }

           
            }
            catch(Exception)
            {
                string script = "alert(\"Eroare la incarcare fisier!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string temporole, tempnume, tempid,tempgrup;
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetPrivilage g = new GetPrivilage();
                GetIdUser i = new GetIdUser();
                GetUserGrup gru = new GetUserGrup();
                temporole = g.GetRights(tempnume);
                tempid = i.GetUser(tempnume);
                tempgrup = gru.GetGrup(tempnume);

                byte[] bytes;
                string fileName, contentType;

                if(temporole=="Admin")
                {

                    if (int.TryParse(tbxdocumentincarcat.Text, out int docu))
                    {
                        DataBase databaseObject = new DataBase();
                        databaseObject.OpenConnection();
                        string querydownload = "SELECT NumeFisier,TipFisier,DataFisier from InregistrariRegistratura " +
                            "WHERE NumarIntrareDocument=@NumarIntrare";
                        SqlCommand myCommand = new SqlCommand(querydownload, databaseObject.myConnection);
                        myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxdocumentincarcat.Text));
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


                    if (int.TryParse(tbxdocumentincarcat.Text, out int docu))
                    {
                        DataBase databaseObject = new DataBase();
                        databaseObject.OpenConnection();
                        string querydownload = "SELECT I.NumeFisier,I.TipFisier,I.DataFisier from Useri as U FULL JOIN InregistrariRegistratura as I ON U.IdUser=I.IdUser " +
                            "WHERE NumarIntrareDocument=@NumarIntrare AND Grup=@Grup";
                        SqlCommand myCommand = new SqlCommand(querydownload, databaseObject.myConnection);
                        myCommand.Parameters.AddWithValue("@NumarIntrare", int.Parse(tbxdocumentincarcat.Text));
                        myCommand.Parameters.AddWithValue("@Grup",tempgrup);
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
            catch(Exception)
            {
                string script = "alert(\"Eroare la descarcarea fisierului!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnStergere_Click(object sender, EventArgs e)
        {


            try
            {

                string temporole, tempnume;
                tempnume = Request.Cookies["dateutilizator"].Value;
                GetPrivilage g = new GetPrivilage();
                temporole = g.GetRights(tempnume);
                if(temporole=="Admin")
                {
                    DataBase databaseObject = new DataBase();
                    databaseObject.OpenConnection();
                    if(int.TryParse(tbxdocumentincarcat.Text, out int docu))
                    {
                        string query = "DELETE from InregistrariRegistratura WHERE NumarIntrareDocument=@documentincarcat";
                        SqlCommand myCommand = new SqlCommand(query, databaseObject.myConnection);



                        myCommand.Parameters.AddWithValue("@documentincarcat", int.Parse(tbxdocumentincarcat.Text));
                        var result = myCommand.ExecuteNonQuery();
                        string scriptnoti = "alert(\"Stergere document reusita!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptnoti, true);
                        tbxdocumentincarcat.Text = "";
                    }
                    else
                    {
                        string script = "alert(\"Introduceti numarul documentului corect!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    databaseObject.CloseConnection();

                }
                else
                {
                    string script = "alert(\"Nu ai drepturi la acest buton!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }


            }
            catch(Exception)
            {
                string script = "alert(\"Eroare la stergerea fisierului!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }


        }

        
    }
}