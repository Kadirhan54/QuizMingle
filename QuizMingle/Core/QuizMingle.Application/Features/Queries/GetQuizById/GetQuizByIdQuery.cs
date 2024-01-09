using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Application.Features.Queries.GetQuizById
{
    public class GetQuizByIdQuery : IRequest<GetQuizByIdResponse>
    {
        public Guid Id { get; set; }    
    }
}
