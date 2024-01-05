
using QuizMingle.Application.Repositories;
using QuizMingle.Domain.Entities;
using QuizMingle.Persistence.Context;

namespace QuizMingle.Application.Repositories.QuizRepositories
{
    public class QuizWriteRepository : WriteRepository<Quiz, Guid>, IQuizWriteRepository
    {
        public QuizWriteRepository(QuizMingleDbContext context) : base(context)
        {
        }
    }
}
