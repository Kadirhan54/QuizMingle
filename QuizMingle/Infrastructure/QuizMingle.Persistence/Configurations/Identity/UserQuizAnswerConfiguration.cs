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

            // UserQuiz one-many relationship
            builder.HasOne(x => x.UserQuiz)
                   .WithMany(x => x.UserQuizAnswers)
                   .HasForeignKey(x => x.UserQuizId);

            // Question one-many relationship
            builder.HasOne(x => x.Question)
                   .WithMany()
                   .HasForeignKey(x => x.QuestionId);
        }
    }
}