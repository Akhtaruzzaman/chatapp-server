using Application.IService.Master;
using Application.IService.Messenger;
using Application.Service.Master;
using Application.Service.Messenger;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
{
    public class Service
    {
        public Service(IServiceCollection services)
        {
            #region Application
            services.AddTransient<IUsersService, UsersService>();

            #region web site
            services.AddTransient<IMessagesService, MessagesService>();
            #endregion

            #endregion
            #region System
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
        }
    }
}
