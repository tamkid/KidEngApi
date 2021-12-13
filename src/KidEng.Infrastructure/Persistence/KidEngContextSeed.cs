using KidEng.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEng.Infrastructure.Persistence
{
    public class KidEngContextSeed
    {
        public static async Task SeedAsync(KidEngContext context, ILogger<KidEngContextSeed> logger)
        {
            if (!context.Vocabularies.Any())
            {
                logger.LogInformation("Start Seeding data for orders");

                context.Vocabularies.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();

                logger.LogInformation("End Seeding data for orders");
            }
        }

        private static IEnumerable<Vocabulary> GetPreconfiguredOrders()
        {
            return new List<Vocabulary>
            {
                new Vocabulary() {
                    Word = "Hello",
                    Definition = "Definition of hello",
                    Example = "Hello! How are you?",
                    Type = "V"
                }
            };
        }
    }
}
