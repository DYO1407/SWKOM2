using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using System.Reflection.Metadata;

namespace DataAccess.Sql

{
    public class AppDbContext  : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Correspondent>? Correspondents { get; set; }
        public DbSet<Entities.Document>? Documents { get; set; }
        public DbSet<DocumentType>? DocumentTypes { get; set; }
        public DbSet<DocumentTag>? DocumentTags { get; set; }

        public DbSet<User>? Users{ get; set; }

    }
}