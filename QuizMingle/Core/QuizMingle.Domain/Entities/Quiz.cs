
using QuizMingle.Domain.Common;


namespace QuizMingle.Domain.Entities
{
    public class Quiz : EntityBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public ICollection<Question> Questions { get; set; }

        public ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
