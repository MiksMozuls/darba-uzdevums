using Microsoft.AspNetCore.Identity;
using DarbaUzdevumaProjekts.Domain;
namespace DarbaUzdevumaProjekts.Persistance
{
    public class Seed
    {
 
        public static async Task SeedData(DataContext context)
        {
            if (!context.NewsSource.Any()) {
                context.NewsSource.Add(new NewsSource
                {
                    SourceID = new Guid(),
                    SourceName = "TVNET",
                    SourceLink = "www.tvnet.lv"
                });

                context.NewsSource.Add(new NewsSource
                {
                    SourceID = new Guid(),
                    SourceName = "LSM",
                    SourceLink = "www.lsm.lv"
                });

            }

            
            await context.SaveChangesAsync();

        }
        
    }
}

