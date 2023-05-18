
using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if(!context.Resources.Any())
            {
                var resourceData = File.ReadAllText("../Infrastructure/Data/SeedData/resources.json");
                var resources = JsonSerializer.Deserialize<List<Resource>>(resourceData);
                context.Resources.AddRange(resources);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();    
        }
    }
}
