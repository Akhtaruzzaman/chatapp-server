using Application.IService.Messenger;
using Application.ViewModel.Messenger;
using Repository.IRepository.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Messenger
{
    public class MessagesService : IMessagesService
    {
        protected readonly IMessagesRepository messagesRepository;
        public MessagesService(IMessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }
        public async Task<bool> Add(MessagesVM entity)
        {
            try
            {
                return await messagesRepository.Add(entity.ToEntity());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(MessagesVM entity)
        {
            try
            {
                var data = await messagesRepository.Get(entity.Id);
                data.IsArchived = true;
                return await messagesRepository.Update(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MessagesVM> Get(Guid id)
        {
            try
            {
                var x = await messagesRepository.Get(id);
                var vm = new MessagesVM
                {
                    Id = x.Id,
                    FromId = x.FromId,
                    ToId = x.ToId,
                    Message = x.Message,
                    SeenStatus = x.SeenStatus,
                    CreatedAt = x.CreatedAt
                };
                return await Task.FromResult(vm);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<MessagesVM>> GetAll()
        {
            throw new NotImplementedException();
        }
        public object GetAllByUser(Guid fromid, Guid toid)
        {
            var data = (from x in messagesRepository.GetAll().ToList()
                        where (x.FromId == fromid && x.ToId == toid) || (x.FromId == toid && x.ToId == fromid)
                        select new
                        {
                            Id = x.Id,
                            FromId = x.FromId,
                            ToId = x.ToId,
                            Message = x.Message,
                            SeenStatus = x.SeenStatus,
                            CreatedAt = x.CreatedAt,
                            Incomming = x.FromId.Equals(fromid) ? false : true
                        }).OrderBy(x => x.CreatedAt).ToList();
            return data;
        }

        public Tuple<long, List<MessagesVM>> GetAll(int currentPage, int pageSize, MessagesVM entity)
        {
            throw new NotImplementedException();
        }
        public object GetAllByUser(Guid fromid, Guid toid, int currentPage, int pageSize)
        {
            try
            {
                int skip = (currentPage * pageSize);
                var data_qry = (from x in messagesRepository.GetAll().ToList()
                                where (x.FromId == fromid && x.ToId == toid) || (x.FromId == toid && x.ToId == fromid)
                                select new
                                {
                                    Id = x.Id,
                                    FromId = x.FromId,
                                    ToId = x.ToId,
                                    Message = x.Message,
                                    SeenStatus = x.SeenStatus,
                                    CreatedAt = x.CreatedAt,
                                    Incomming = x.FromId.Equals(fromid) ? false : true
                                }).OrderBy(x => x.CreatedAt);

                long total = data_qry.Count();
                var data = data_qry.Skip(skip).Take(pageSize).ToList();
                return new { total, data };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(MessagesVM entity)
        {
            throw new NotImplementedException();
        }
    }
}
