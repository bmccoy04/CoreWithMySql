using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace CoreWithMySql
{
    class Program
    {
        private static DbDataReader reader;

        static void Main(string[] args)
        {
            var connection = new MySqlConnection("");

            var command = connection.CreateCommand() as MySqlCommand;
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            
            command.CommandText = @"Select * from TestTable";
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            var testTables = new System.Collections.Generic.List<TestTable>();
			using (reader)
			{
				while (reader.Read())
				{
					testTables.Add(new TestTable()
					{
						Name = reader.GetFieldValue<string>(1),
						Url = reader.GetFieldValue<string>(2)
					});
				}
                
            }

            connection.Dispose();
            testTables.ForEach(x => Console.WriteLine($"{x.Name} and {x.Url}"));
            Console.WriteLine("HEllow againa");
            Console.WriteLine("Hello World!");
        }
    }

    class TestTable{
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
