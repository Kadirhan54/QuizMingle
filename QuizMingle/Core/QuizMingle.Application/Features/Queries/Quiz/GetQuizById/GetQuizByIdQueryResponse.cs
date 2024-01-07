namespace QuizMingle.Application.Features.Queries.Quiz.GetQuizById
{
    public class GetQuizByIdQueryResponse
    {
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();

        public class Quiz
        {
            public Guid Id { get; set; }
            public DateTimeOffset StartTime { get; set; }
            public DateTimeOffset TimeLimit { get; set; }
        }
    }
}
