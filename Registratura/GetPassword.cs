using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Registratura
{
    public class GetPassword
    {
        public string GetPasswordCheck(string inputuser)
        {
            string temporary = "";
            DataBase databaseObject = new DataBase();
            string queryuser = "SELECT Passwordcheck from Useri where NumeUtilizator ='" + inputuser + "'";


            SqlCommand myCommanduser = new SqlCommand(queryuser, databaseObject.myConnection);

            databaseObject.OpenConnection();
            temporary = (string)myCommanduser.ExecuteScalar().ToString();

            databaseObject.CloseConnection();

            return temporary;
        }
    }
}