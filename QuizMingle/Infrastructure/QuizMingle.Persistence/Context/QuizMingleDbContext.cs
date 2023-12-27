using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Common;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;
using System.Reflection;

namespace QuizMingle.Persistence.Context
{
    public class QuizMingleDbContext : IdentityDbContext<User, Role, Guid>
    {

        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Quiz> Quizzes {  get; set; }
        public DbSet<UserQuiz> UserQuizzes { get; set; }
        public DbSet<UserQuizAnswer> UserQuizAnswers { get; set; }

        //protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(Configurations.GetString("Team3PostgreSQLDBL"));
        //}
        public QuizMingleDbContext(DbContextOptions<QuizMingleDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((ICreatedByEntity)entry.Entity).CreatedOn = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    ((IModifiedByEntity)entry.Entity).ModifiedOn = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    ((IDeletedByEntity)entry.Entity).DeletedOn = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
