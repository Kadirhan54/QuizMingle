using Microsoft.Extensions.DependencyInjection;
using QuizMingle.Application.Repositories.QuizRepositories;

namespace StudyTimer.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //add scoped repositories services
            services.AddScoped<IQuizReadRepository,QuizReadRepository>();
            services.AddScoped<IQuizWriteRepository, QuizWriteRepository>();

        }
    }
}
