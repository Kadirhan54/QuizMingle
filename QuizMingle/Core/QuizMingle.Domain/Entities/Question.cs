﻿using QuizMingle.Domain.Common;
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
        public string Text { get; set; }

        public string CorrectAnswer { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
