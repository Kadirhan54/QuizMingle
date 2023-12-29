using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Models
{
    public class QuizCreateRequest
    {
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset StartTime { get; set; }
       

    }
}