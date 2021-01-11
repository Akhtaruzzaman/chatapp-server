using Domain.Messenger;
using Repository.DBContext;
using Repository.IRepository.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Messenger
{
    public class MessagesRepository : Repository<Messages>, IMessagesRepository
    {
        public MessagesRepository(DBContext_Sql context) : base(context)
        {

        }
    }
}
