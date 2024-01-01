using QuizMingle.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Persistence.Service
{
    public interface ITokenService
    {
        public string CreateToken(User user);

    }
}
