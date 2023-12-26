using QuizMingle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Entities
{
    public class Question : EntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string text { get; set; }

        public string CorrectAnswer { get; set; }
        public string optionA { get; set; }
        public string optionB { get; set; }
        public string optionC { get; set; }
        public string optionD { get; set; }

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
