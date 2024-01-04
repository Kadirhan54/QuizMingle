using FluentValidation;
using QuizMingle.API.Models;
using QuizMingle.Domain.Entities;

namespace QuizMingle.API.Validators
{
    public class QuizCreateRequestValidator : AbstractValidator<QuizCreateRequest>
    {
    
        public QuizCreateRequestValidator()
        {
            RuleFor(quiz => quiz.StartTime).NotEmpty().NotNull();
            RuleFor(quiz => quiz.TimeLimit).NotEmpty().NotNull();

        }
    }
}
