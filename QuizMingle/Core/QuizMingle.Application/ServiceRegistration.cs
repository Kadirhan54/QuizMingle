using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuizMingle.Application.Features.Queries;
using QuizMingle.Application.Repositories;
using QuizMingle.Application.Repositories.QuizRepositories;
using System.Net.NetworkInformation;

namespace QuizMingle.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllQuizQueryHandler).Assembly));
        
            collection.AddTransient<GetAllQuizQueryHandler>();

           
        }
    }
}