namespace QuizMingle.API.Models
{
    public class QuizUpdateRequest
    {
        public Guid QuizId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset TimeLimit { get; set; }
    }
}
