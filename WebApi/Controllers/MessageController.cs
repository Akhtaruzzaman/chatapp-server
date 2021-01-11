using Application.IService.Master;
using Application.IService.Messenger;
using Application.ViewModel.Messenger;
using Application.ViewModel.Others;
using Common.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        private readonly IMessagesService messagesService;
        private readonly IUsersService usersService;
        public MessageController(IMessagesService messagesService, IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.usersService = usersService;
        }
        [HttpGet]
        public object Get(Guid toid)
        {
            try
            {
                var userid = GetUserId().StringToGuid();
                var data = messagesService.GetAllByUser(userid, toid);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetForScroll")]
        public object Get(Guid toid,int currentPage, int pageSize)
        {
            try
            {
                var userid = GetUserId().StringToGuid();
                var data = messagesService.GetAllByUser(userid, toid, currentPage, pageSize);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetUser")]
        public object GetUser()
        {
            try
            {
                var userid = GetUserId().StringToGuid();
                var data = usersService.GetAllExceptMe(userid);
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<object> PostAsync(MessageSendVM vm)
        {
            try
            {
                MessagesVM entity = new MessagesVM();
                entity.ToId = vm.ToId;
                entity.Message = vm.Message;
                entity.SeenStatus = Sys_Enum.SeenStatus.Pending;
                entity = SetCreateAudit<MessagesVM>(entity);
                entity.FromId = entity.CreatedBy;
                var data = await messagesService.Add(entity);
                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            };
        }


    }
}
