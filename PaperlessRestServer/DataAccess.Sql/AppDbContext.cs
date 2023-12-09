
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Document = DataAccess.Entities.Document;

namespace DataAccess.Sql

{
    public class AppDbContext  : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>? options) : base(options) { }

        public DbSet<Correspondent> Correspondents { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentTag> DocumentTags { get; set; }    

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<User> Users { get; set; }
     

    }
}