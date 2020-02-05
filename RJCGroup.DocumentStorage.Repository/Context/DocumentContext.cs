using Microsoft.EntityFrameworkCore;
using RJCGroup.DocumentStorage.Repository.Entities;

namespace RJCGroup.DocumentStorage.Repository.Context
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {

        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentContent> DocumentContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: We can seed some data here


            //base.OnModelCreating(modelBuilder);
        }
    }
}
