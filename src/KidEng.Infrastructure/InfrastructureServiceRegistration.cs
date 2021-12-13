using KidEng.Application.Persistences;
using KidEng.Infrastructure.Persistence;
using KidEng.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KidEng.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KidEngContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KidEngConnectionString"))
            );
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVocabularyRepository, VocabularyRepository>();
            return services;
        }
    }
}
