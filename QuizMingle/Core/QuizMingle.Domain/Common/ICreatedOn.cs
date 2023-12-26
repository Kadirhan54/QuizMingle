

namespace QuizMingle.Domain.Common
{
    public interface ICreatedOn
    {
        public string CreatedByUserId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
