

namespace QuizMingle.Domain.Common
{
    public interface IDeletedOn
    {
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
