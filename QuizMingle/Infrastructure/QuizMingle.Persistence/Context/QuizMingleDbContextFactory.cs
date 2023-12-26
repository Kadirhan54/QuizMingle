using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Persistence.Context
{
    public class QuizMingleDbContextFactory : IDesignTimeDbContextFactory<QuizMingleDbContext>
    {
        public QuizMingleDbContext CreateDbContext(string[] args)
        {
            var basePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Persistence\\QuizMingle.API\\";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(basePath)
                 .AddJsonFile("appsettings.json")
                 .Build();

            var optionsBuilder = new DbContextOptionsBuilder<QuizMingleDbContext>();

            var connectionString = configuration.GetSection("Team3PostgreSQLDB").Value;

            optionsBuilder.UseNpgsql(connectionString);

            return new QuizMingleDbContext(optionsBuilder.Options);
        }
    }
}
