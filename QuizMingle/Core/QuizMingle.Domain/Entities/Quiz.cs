
using QuizMingle.Domain.Common;


namespace QuizMingle.Domain.Entities
{
    public class Quiz : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset SartTime { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
