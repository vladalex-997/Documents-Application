using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Registratura
{
     public class DataBase
    {
        public string connectionString;
        public SqlConnection myConnection;
        public DataBase()
        {
            connectionString= ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            // connectionString = "Data Source=VLADRO;Initial Catalog=proiectRegistratura;Integrated Security=True;";
            // connectionString = "Data Source=VLADRO;Initial Catalog=inregistrari;Integrated Security=True;";
            myConnection = new SqlConnection(connectionString);


        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
                
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
               
            }
        }



    }
}