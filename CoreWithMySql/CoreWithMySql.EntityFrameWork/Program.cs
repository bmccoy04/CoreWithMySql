using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreWithMySql.EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IEnumerable<TestTable> tables = new List<TestTable>();
            var now = DateTime.Now;
            for (int i = 0; i <= 1000; i++){
				using (var context = new MyContext())
				{
					tables = context.TestTable.AsNoTracking().ToList();
				}   
            }
            var fin = DateTime.Now;
            var diff = fin - now;
            Console.WriteLine($"Time elapsed: {diff.TotalSeconds}");
            //tables.ToList().ForEach(x => Console.WriteLine($"{x.Name} and {x.Url}"));
        }
    }


	public class TestTable
	{
        [Key]
        public int Id 
        {
            get;
            set;
        }
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


    public class MyContext : DbContext
    {
        public DbSet<TestTable> TestTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=192.168.7.100;Database=Test;UserId=TestUser;Pwd=tstUserAccount;");
    }
}
