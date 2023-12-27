

namespace QuizMingle.Domain.Common
{
    public interface IDeletedByEntity
    {
        public string? DeletedByUserId { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
