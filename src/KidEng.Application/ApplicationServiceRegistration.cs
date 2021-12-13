using KidEng.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KidEng.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IVocabularyService, VocabularyService>();
            return services;
        }
    }
}
