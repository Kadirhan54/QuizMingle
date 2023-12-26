using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Persistence.Context
{
    public class QuizMingleDbContext : IdentityDbContext
    {

        public DbSet<Question> Questions { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Quiz> Quizzes {  get; set; }
            
        public DbSet<UserQuiz> UserQuizzes { get; set; }

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    base.OnModelCreating(modelBuilder);
        //}

        public QuizMingleDbContext(DbContextOptions<QuizMingleDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }



    }
}
