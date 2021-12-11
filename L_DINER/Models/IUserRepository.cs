using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void SaveUser(User user);
    }
}
