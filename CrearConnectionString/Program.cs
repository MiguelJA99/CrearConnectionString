using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola mundo");

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "JAMX-LP-055";
            connectionStringBuilder.InitialCatalog = "Northwind_Mart";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs= connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Dim_Cliente";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
                reader.Close();
            }

                Console.ReadLine();
        }
    }
}
