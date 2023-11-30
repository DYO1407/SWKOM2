using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;


namespace DataAccess.Sql

{
    public class AppDbContext  : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Correspondent> Correspondents { get; set; }

    }
}