using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Db_Context : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GenericRepository;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
