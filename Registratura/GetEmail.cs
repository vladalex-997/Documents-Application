using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Registratura
{
    public class GetEmail
    {
        public string GetMail(string inputuser)
        {
            string temporary = "";
            DataBase databaseObject = new DataBase();
            string queryuser = "SELECT Email from Useri where NumeUtilizator ='" + inputuser + "'";


            SqlCommand myCommanduser = new SqlCommand(queryuser, databaseObject.myConnection);

            databaseObject.OpenConnection();
            temporary = (string)myCommanduser.ExecuteScalar().ToString();

            databaseObject.CloseConnection();

            return temporary;
        }
    }
}