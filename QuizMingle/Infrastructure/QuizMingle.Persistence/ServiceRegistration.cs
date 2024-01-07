using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizMingle.Application.Repositories.QuizRepositories;
using QuizMingle.Persistence.Context;
using Microsoft.Extensions.Configuration;

namespace StudyTimer.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //add scoped repositories services
            services.AddScoped<IQuizReadRepository,QuizReadRepository>();
            services.AddScoped<IQuizWriteRepository, QuizWriteRepository>();

            string connectionString = configuration.GetSection("Team3PostgreSQLDB").Value;
            services.AddDbContext<QuizMingleDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

        }
    }
}
