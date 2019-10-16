using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SqlConnection s = new SqlConnection("Server=localhost\\sqlexpress01;Initial Catalog=NorthWind;Integrated Security=true");
            s.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 20 * FROM Customers WHERE Country = @Country", s);
            cmd.Parameters.AddWithValue("@Country", "France");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(reader.GetOrdinal("Country")));
            }*/

            /* Donnee d = new Donnee();
             SqlDataReader reader = d.remplir("Customers", "France");

             while (reader.Read())
             {
                 Console.WriteLine(reader.GetString(reader.GetOrdinal("ContactName"))+" " + reader.GetString(reader.GetOrdinal("ContactName")));
             }*/

            Donnee d = new Donnee();
            /*SqlDataReader reader = d.Procedure("BLONP");

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(reader.GetOrdinal("ProductName")) + " " + reader.GetInt32(reader.GetOrdinal("Total")));

               
            }
            //Console.ReadKey();*/


            // d.INSERTCustomurs("AAAAA","DORANCO", "GUY");


            List<Customers> cust = d.GetCustomerByCountry("Customers", "USA");
            var liste = cust;
            //lorsque tu mets f.cpntactName c'est que tu veux mettre ordre juste sur le nom
            var ordreDESC = liste.OrderByDescending(f => f.ContactName);
            foreach (var n in ordreDESC)
            {
                //on peut tout afficher
                Console.WriteLine(n.ContactName+" "+n.Address);
            }
        }
    }
}
