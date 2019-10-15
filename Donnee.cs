using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb
{
    class Donnee
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        //SqlDataAdapter da = new SqlDataAdapter();
        
        // DataSet ds = new DataSet();


        public void connecter()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = "Server=localhost\\sqlexpress01;Initial Catalog=NorthWind;Integrated Security=true";

                conn.Open();
            }
        }

        public void deconnecter()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public SqlDataReader remplir(string table, string value)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT TOP 20 * FROM " + table+ " WHERE Country = @Country";
          
            cmd.Parameters.AddWithValue("@Country", value);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
            this.deconnecter();

            
        }

        public SqlDataReader Procedure(String A)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "CustOrderHist";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", A);
            SqlDataReader reader1 = cmd.ExecuteReader();
            return reader1;
            this.deconnecter();


        }
    }
}
