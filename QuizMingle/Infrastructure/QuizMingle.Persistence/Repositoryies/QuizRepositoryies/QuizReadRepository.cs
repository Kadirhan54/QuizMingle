

using QuizMingle.Domain.Entities;
using QuizMingle.Persistence.Context;

namespace QuizMingle.Application.Repositories.QuizRepositories
{
    public class QuizReadRepository : ReadRepository<Quiz, Guid>, IQuizReadRepository
    {
        public QuizReadRepository(QuizMingleDbContext context) : base(context) { }
    }
}
