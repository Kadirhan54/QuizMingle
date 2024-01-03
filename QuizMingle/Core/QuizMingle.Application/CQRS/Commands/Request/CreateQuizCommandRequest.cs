

namespace QuizMingle.API.Models
{
    public class CreateQuizCommandRequest
    {
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset StartTime { get; set; }
       
    }
}