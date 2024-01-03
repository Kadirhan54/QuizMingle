using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Commands
{
    public class GetAllQuizQueryHandler : IRequestHandler<GetAllQuizQueryRequest, GetAllQuizQueryResponse>
    {
        public Task<GetAllQuizQueryResponse> Handle(GetAllQuizQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
