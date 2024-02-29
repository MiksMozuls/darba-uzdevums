using DarbaUzdevumaProjekts.Domain;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography.X509Certificates;

namespace DarbaUzdevumaProjekts.Persistance
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            try
            {
                RelationalDatabaseCreator databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }

                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public DbSet<NewsPiece> NewsPiece { get; set; }
        public DbSet<NewsSource> NewsSource { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<NewsPiece>().HasKey(np => np.NewsID); 
            builder.Entity<NewsSource>().HasKey(ns => ns.SourceID);
            builder.Entity<NewsPiece>().HasOne(n => n.NewsSource).WithMany(ns => ns.NewsPieces).HasForeignKey(ns => ns.NewsSourceID);
        }
    }
}


