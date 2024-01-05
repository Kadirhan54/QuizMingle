using FluentValidation;
using QuizMingle.API.Models;
using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Validators
{
    public class QuestionCreateReqauestValidator : AbstractValidator<QuestionCreateRequest>
    {
    
        public QuestionCreateReqauestValidator()
        {
            RuleFor(quiz => quiz.OptionA).NotEmpty().NotNull();
            RuleFor(quiz => quiz.OptionB).NotEmpty().NotNull();
            //
            //
            //

        }
    }
}
