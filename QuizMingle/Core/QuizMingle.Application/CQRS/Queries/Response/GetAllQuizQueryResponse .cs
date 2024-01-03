namespace QuizMingle.Application.CQRS.Queries.Response
{
    public class GetAllQuizQueryResponse
    {
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public Guid Id { get; set; }
    }
}