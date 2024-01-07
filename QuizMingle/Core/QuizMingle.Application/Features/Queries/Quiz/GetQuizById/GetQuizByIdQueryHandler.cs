using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Application.Features.Queries.Quiz.GetQuizById;
using QuizMingle.Application.Repositories.QuizRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries
{
    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQueryRequest, GetQuizByIdQueryResponse>
    {

        private readonly IQuizReadRepository _quizReadRepository;

        public GetQuizByIdQueryHandler(IQuizReadRepository quizReadRepository)
        {
            _quizReadRepository = quizReadRepository;
        }

        public async Task<GetQuizByIdQueryResponse> Handle(GetQuizByIdQueryRequest request, CancellationToken cancellationToken)
        {
           //var quiz = await _quizReadRepository.GetQuizByIdAsync(request.Id, cancellationToken);

           // return quizResponse;

           return null;
        }

    }
}
