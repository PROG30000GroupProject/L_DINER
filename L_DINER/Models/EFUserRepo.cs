using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class EFUserRepo : IUserRepository
    {

        private LDINER_DBContext context;

        public EFUserRepo(LDINER_DBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;

        
        public void SaveUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
