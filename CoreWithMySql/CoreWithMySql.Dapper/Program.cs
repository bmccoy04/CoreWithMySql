using System;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

namespace CoreWithMySql.Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new MySqlConnection("Server=192.168.7.100;Database=Test;UserId=;Pwd=;");

            var testTables = connection.Query<TestTable>("Select * from TestTable");

            connection.Close();

            testTables.ToList().ForEach(x => Console.WriteLine($"{x.Name} and {x.Url}"));
            Console.WriteLine("Hello World!");
        }
    }

    class TestTable
    {
        public string Name
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }    
}