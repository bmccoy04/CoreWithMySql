using MySql.Data.MySqlClient;
using System;

namespace CoreWithMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new MySqlConnection("");
            Console.WriteLine("HEllow againa");
            Console.WriteLine("Hello World!");
        }
    }

    class AppDb : IDisposable
    {
        public MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection("");
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
