using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DarbaUzdevumaProjekts.Persistance
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            try {
                RelationalDatabaseCreator databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null) {
                    if (!databaseCreator.CanConnect()) {
                        databaseCreator.Create();
                    }

                    if (!databaseCreator.HasTables())
                        databaseCreator.CreateTables();
                }
            } 
                
            catch (Exception ex) {

                Console.WriteLine(ex.Message); 
            }
            
        }
    }
}
