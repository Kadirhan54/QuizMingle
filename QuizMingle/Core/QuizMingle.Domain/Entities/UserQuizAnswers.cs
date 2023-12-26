using QuizMingle.Domain.Common;

namespace QuizMingle.Domain.Entities
{
    public class UserQuizAnswers : ICreatedOn
    {
        public Guid Id { get; set; }
        public string GivenAnswer { get; set; }

        // Foreign keys
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid UserQuizId { get; set; }
        public UserQuiz UserQuiz { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}