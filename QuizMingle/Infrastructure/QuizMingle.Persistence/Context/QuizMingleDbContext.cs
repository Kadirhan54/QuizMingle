using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;
using QuizMingle.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Persistence.Context
{
    public class QuizMingleDbContext : IdentityDbContext
    {

        public System.Data.Entity.DbSet<Question> Questions { get; set; }

        public System.Data.Entity.DbSet<Score> Scores { get; set; }

        public System.Data.Entity.DbSet<Quiz> Quiz {  get; set; }

        public System.Data.Entity.DbSet<UserQuiz> UserQuiz { get; set; }

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL");
        }




    }
}
