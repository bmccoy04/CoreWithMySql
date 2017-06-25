using System;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;

namespace CoreWithMySql.Dapper
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<TestTable> testTables = new List<TestTable>();
			var now = DateTime.Now;

            for (int i = 0; i <= 1000; i++)
            {

                using (var connection = new MySqlConnection("Server=192.168.7.100;Database=Test;UserId=TestUser;Pwd=tstUserAccount;"))
                {

                    testTables = connection.Query<TestTable>("Select * from TestTable");

                }
            }

			var fin = DateTime.Now;
			var diff = fin - now;
			Console.WriteLine($"Time elapsed: {diff.TotalSeconds}");

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