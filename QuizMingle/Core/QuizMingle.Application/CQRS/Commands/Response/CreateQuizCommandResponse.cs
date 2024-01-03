

namespace QuizMingle.Application.CQRS.Commands.Response
{
    public class CreateQuizCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid QuizId { get; set; }


    }
}