using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizMingle.Application.Repositories.QuizRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries
{
    public class GetAllQuizQueryHandler : IRequestHandler<GetAllQuizQueryRequest, GetAllQuizQueryResponse>
    {

        private readonly IQuizReadRepository _quizReadRepository;

        public GetAllQuizQueryHandler(IQuizReadRepository quizReadRepository)
        {
            _quizReadRepository = quizReadRepository;
        }

        public async Task<GetAllQuizQueryResponse> Handle(GetAllQuizQueryRequest request, CancellationToken cancellationToken)
        {
            var quizzes = await _quizReadRepository.GetAllQuizzesAsync(cancellationToken);
            // send response
            var quizResponse = new GetAllQuizQueryResponse
            {
                Quizzes = quizzes.Select(x => new GetAllQuizQueryResponse.Quiz
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    TimeLimit = x.TimeLimit
                }).ToList()
            };
            return quizResponse;
        }

    }
}
