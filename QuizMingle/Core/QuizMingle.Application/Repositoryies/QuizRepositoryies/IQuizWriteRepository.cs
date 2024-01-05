
using QuizMingle.Application.Repositories;
using QuizMingle.Domain.Entities;

namespace QuizMingle.Application.Repositories.QuizRepositories
{
    public interface IQuizWriteRepository : IWriteRepository<Quiz, Guid>
    {
        

    }
}
