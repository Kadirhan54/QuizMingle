using QuizMingle.Domain.Common;

namespace QuizMingle.Domain.Entities
{
    public class UserQuizAnswer : ICreatedOn
    {
        public Guid Id { get; set; }
        public string GivenAnswer { get; set; }

        // Foreign keys for UserQuiz
        public Guid UserId { get; set; }
        public Guid QuizId { get; set; }
        public UserQuiz UserQuiz { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}