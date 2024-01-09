using MediatR;
using QuizMingle.Application.Features.Queries.GetAllQuiz;
using QuizMingle.Application.Repositories.QuizRepositories;
using QuizMingle.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries.GetQuizById
{
    public class GetQuizByIdHandler : IRequestHandler<GetQuizByIdQuery, GetQuizByIdResponse>
    {

        private readonly IQuizReadRepository _quizReadRepository;

        public GetQuizByIdHandler(IQuizReadRepository quizReadRepository)
        {
            _quizReadRepository = quizReadRepository;
        }

        public async Task<GetQuizByIdResponse> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _quizReadRepository.GetQuizByIdAsync(cancellationToken, request.Id);

            if(quiz is null)
            {
                throw new Exception("Quiz ID not found!");
            }

            var quizResponse = new GetQuizByIdResponse
            {
                Id = quiz.Id,
                TimeLimit = quiz.TimeLimit,
                StartTime = quiz.StartTime,
                Questions = quiz.Questions, // TO DO: Bu kısmı tamamla.
                UserQuizzes = quiz.UserQuizzes // TO DO:  Bu kısmı tamamla.
            };

            return quizResponse;

        }

        
    }
}
