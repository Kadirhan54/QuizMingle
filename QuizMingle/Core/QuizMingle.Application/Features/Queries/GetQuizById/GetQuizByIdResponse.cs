using QuizMingle.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries.GetQuizById
{
    public class GetQuizByIdResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeLimit { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
