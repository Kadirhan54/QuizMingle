using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;
using QuizMingle.Domain.Identity;

namespace QuizMingle.Persistence.Configurations.Identity
{
    public class UserQuizConfiguration : IEntityTypeConfiguration<UserQuiz>
    {
        public void Configure(EntityTypeBuilder<UserQuiz> builder)
        {

            builder.HasKey(x => new { x.UserId, x.QuizId });

            // User relationship
            builder.HasOne<User>(x => x.User)
                   .WithMany(x => x.UserQuizzes)
                   .HasForeignKey(x => x.UserId);

            // Quiz relationship
            builder.HasOne<Quiz>(x => x.Quiz)
                   .WithMany(x => x.UserQuizzes)
                   .HasForeignKey(x => x.QuizId);
        }
    }
}
