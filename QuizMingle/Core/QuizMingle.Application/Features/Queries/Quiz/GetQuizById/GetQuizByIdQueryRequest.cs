using MediatR;
using QuizMingle.Application.Features.Queries.Quiz.GetQuizById;

namespace QuizMingle.Application.Features.Queries
{
    public class GetQuizByIdQueryRequest : IRequest<GetQuizByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
