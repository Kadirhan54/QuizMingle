using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Domain.Entities;


namespace QuizMingle.Persistence.Configurations.Identity
{
    public class UserQuizAnswerConfiguration : IEntityTypeConfiguration<UserQuizAnswer>
    {
        public void Configure(EntityTypeBuilder<UserQuizAnswer> builder)
        {
            builder.HasKey(x => x.Id);

            // UserQuiz ile ilişki
            builder.HasOne(x => x.UserQuiz)
                   .WithMany(x => x.UserQuizAnswers)
                   .HasForeignKey(x => new { x.UserId, x.QuizId });

            // Question ile ilişki
            builder.HasOne(x => x.Question)
                   .WithMany()
                   .HasForeignKey(x => x.QuestionId);
        }
    }
}