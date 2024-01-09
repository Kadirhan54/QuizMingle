using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries.GetAllQuiz
{
    public class GetAllQuizQueryResponse
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
