using QuizMingle.Domain.Common;
using QuizMingle.Domain.Identity;


namespace QuizMingle.Domain.Entities
{
    public class Score : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public int ScoreValue { get; set; }
        public DateTimeOffset DateTaken { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }

    }
}
