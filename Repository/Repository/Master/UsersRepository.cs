using Domain.Master;
using Repository.DBContext;
using Repository.IRepository.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Master
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(DBContext_Sql context) : base(context)
        {

        }
    }
}
