using Application.ViewModel.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Messenger
{
    public interface IMessagesService : IService<MessagesVM>
    {
        object GetAllByUser(Guid fromid, Guid toid, int currentPage, int pageSize);
        object GetAllByUser(Guid fromid, Guid toid);
    }
}
