using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMingle.Domain.Identity
{
    public class User : IdentityUser
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        


    }
}
