using Application.ViewModel.Master;
using Application.ViewModel.Others;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Common.Library.Sys_Enum;

namespace Application.IService.Master
{
    public interface IUsersService : IService<UsersVM>
    {
        Task<UsersVM> Login(string userId, string password);
        Task<bool> ChangePassword(ChangePassword changePassword, Guid userId);
        Task<UsersVM> Registration(UserRegVM regvm);
        object GetAllExceptMe(Guid id);
    }
}
