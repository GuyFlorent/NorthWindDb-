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

        public void INSERTCustomurs(string CustomerID,String CompanyName, String ContactName)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Customers (CustomerID,CompanyName,ContactName) VALUES (@CustomerID,@CompanyName,@ContactName)";
            
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.ExecuteNonQuery();
            
            this.deconnecter();


        }



        public void GetCustomrByID(string table, string ID)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM " + table + " WHERE CustomerID = @CustomerID";

            cmd.Parameters.AddWithValue("@CustomerID", ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(reader.GetOrdinal("CustomerID")) + " " + reader.GetString(reader.GetOrdinal("ContactName")) + " " +
                  reader.GetString(reader.GetOrdinal("ContactName")) + " " + reader.GetString(reader.GetOrdinal("ContactTitle")) + " " + reader.GetString(reader.GetOrdinal("Address")));


            }
            this.deconnecter();


        }

        public List<Customers> GetCustomerByCountry(string table, string Country)
        {
            this.connecter();
            
            List<Customers> liste = new List<Customers>();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM " + table + " WHERE Country = @Country";

            cmd.Parameters.AddWithValue("@Country", Country);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 1;
            while (reader.Read())
            {
                Customers customer = new Customers();
                customer.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                customer.ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                customer.ContactName = reader.GetString(reader.GetOrdinal("ContactName"));
                Console.WriteLine(i+" "+ customer.CustomerID + " " + customer.ContactTitle +
                  " " + customer.ContactName);
                liste.Add(customer);
                i++;
            } return liste;
            this.deconnecter();


        }

        public void UpdateCity(string newCity, string CustomerID)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE Customers SET City = @City WHERE CustomerId = @CustomerId";

            cmd.Parameters.AddWithValue("@City", newCity);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.ExecuteNonQuery();

            this.deconnecter();


        }

        public void DeleteCustomerByName(string name)
        {
            this.connecter();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Customers WHERE ContactName = @ContactName";

            
            cmd.Parameters.AddWithValue("@ContactName", name);
            cmd.ExecuteNonQuery();

            this.deconnecter();


        }


    }
}
