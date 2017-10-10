using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    internal class Program
    {
        public static void Main()
        {
            var conn = new System.Data.SqlClient.SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                var prod = new Product { Name = reader["Name"].ToString() };
                products.Add(prod);
            }
            conn.Dispose();
            Console.WriteLine("Products Loaded!");
            foreach (var t in products)
            {
                Console.WriteLine(t.Name);
            }
        }
    }
    public class Product
    {
        public string Name
        {
            get;
            set;
        }
    }
}
