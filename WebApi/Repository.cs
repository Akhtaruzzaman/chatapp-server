using Microsoft.Extensions.DependencyInjection;
using Repository.IRepository.Master;
using Repository.IRepository.Messenger;
using Repository.Repository.Master;
using Repository.Repository.Messenger;

namespace WebApi
{
    public class Repository
    {
        public Repository(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IMessagesRepository, MessagesRepository>();

            #endregion

        }
    }
}
