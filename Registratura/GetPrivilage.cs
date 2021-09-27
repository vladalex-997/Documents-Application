using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace Registratura
{
    public class GetPrivilage
    {
        public string GetRights(string inputuser)
        {
            DataBase databaseObject = new DataBase();
            string temporary = "";
            string queryuser = "SELECT Acces from Useri where NumeUtilizator ='" +inputuser+ "'";


            SqlCommand myCommanduser = new SqlCommand(queryuser, databaseObject.myConnection);

            databaseObject.OpenConnection();
            temporary = (string)myCommanduser.ExecuteScalar();

            databaseObject.CloseConnection();

            return temporary;
        }
    }
}