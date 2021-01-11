using Application.IService.Master;
using Application.ViewModel.Master;
using Common.Library;
using Repository.IRepository.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using static Common.Library.Sys_Enum;
using Application.ViewModel.Others;

namespace Application.Service.Master
{
    public class UsersService : IUsersService
    {
        protected readonly IUsersRepository usersRepo;

        public UsersService(IUsersRepository usersRepo)
        {
            this.usersRepo = usersRepo;
        }


        public async Task<bool> Add(UsersVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.Password = entity.Password.toEncrypt();
                bool result = await usersRepo.Add(entity.ToEntity());
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(UsersVM entity)
        {
            try
            {
                bool result = await usersRepo.Delete(entity.Id);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsersVM> Get(Guid id)
        {
            try
            {
                var x = await usersRepo.Get(id);
                var vm = new UsersVM
                {
                    Id = x.Id,
                    LoginId = x.LoginId,
                    Name = x.Name,
                    IsArchived = x.IsArchived,
                    IsActive = x.IsActive,
                    Address = x.Address,
                    Mobile = x.Mobile,

                };
                return await Task.FromResult(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UsersVM> Login(string userId, string password)
        {
            try
            {
                var x = usersRepo.GetAll(a => a.LoginId.Equals(userId) && a.Password.Equals(password) &&
                (a.IsActive || a.Id == "fadede5d-1c91-4d95-92e4-f447ea6edade".StringToGuid()) && !a.IsArchived).FirstOrDefault();
                var vm = new UsersVM
                {
                    Id = x.Id,
                    LoginId = x.LoginId,
                    Name = x.Name,
                    IsArchived = x.IsArchived,
                    IsActive = x.IsActive,
                    Address = x.Address,
                    Mobile = x.Mobile,
                };
                return await Task.FromResult(vm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tuple<long, List<UsersVM>> GetAll(int currentPage, int pageSize, UsersVM entity)
        {

            int skip = (currentPage * pageSize);
            var data_qry = (from x in usersRepo.GetAll()
                            where x.IsArchived == false
                            && x.IsActive == entity.IsActive
                            select new UsersVM
                            {
                                Id = x.Id,
                                LoginId = x.LoginId,
                                Name = x.Name,
                                IsArchived = x.IsArchived,
                                IsActive = x.IsActive,
                                Address = x.Address,
                                Mobile = x.Mobile,
                                CreatedAt = x.CreatedAt
                            }).OrderByDescending(x => x.CreatedAt);

            long total = data_qry.Count();
            var data = data_qry.Skip(skip).Take(pageSize).ToList();
            return Tuple.Create(total, data);
        }
        public async Task<List<UsersVM>> GetAll()
        {
            try
            {
                var data_list = (from x in usersRepo.GetAll()
                                 where x.IsArchived == false
                                 select new UsersVM
                                 {
                                     Id = x.Id,
                                     LoginId = x.LoginId,
                                     Name = x.Name,
                                     IsArchived = x.IsArchived,
                                     IsActive = x.IsActive,
                                     Address = x.Address,
                                     Mobile = x.Mobile,
                                     CreatedAt = x.CreatedAt
                                 }).OrderByDescending(x => x.CreatedAt).ToList();
                return await Task.FromResult(data_list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object GetAllExceptMe(Guid id)
        {
            try
            {
                var data_list = (from x in usersRepo.GetAll()
                                 where x.IsArchived == false && x.Id != id
                                 select new 
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     IsActive = x.IsActive,
                                     Address = x.Address,
                                     Mobile = x.Mobile,
                                 }).OrderByDescending(x => x.Name).ToList();
                return data_list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(UsersVM entity)
        {
            try
            {
                var Old = await usersRepo.Get(entity.Id);
                Old.Name = entity.Name;
                Old.Address = entity.Address;
                Old.Mobile = entity.Mobile;
                Old.UpdatedAt = entity.UpdatedAt;
                Old.UpdatedBy = entity.UpdatedBy;
                await usersRepo.Update(Old);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<bool> ChangePassword(ChangePassword changePassword, Guid userId)
        {
            try
            {
                var oldP = changePassword.OldPassword.toEncrypt();
                var newP = changePassword.Password.toEncrypt();
                var user = usersRepo.GetAll(x => x.Password.Equals(oldP) && x.Id.Equals(userId)).ToList().FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("Something goes wrong.");
                }
                user.Password = newP;
                bool result = await usersRepo.Update(user);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UsersVM> Registration(UserRegVM regvm)
        {
            try
            {
                UsersVM entity = new UsersVM();
                entity.CreatedBy = SYS_DATA.EmpetyGuid.StringToGuid();
                entity.CreatedAt = DateTime.Now;
                entity.CreatedFrom = "";

                if (regvm.password != regvm.confirm_password)
                {
                    throw new Exception("Confirm password is not matched.");
                }
                if (!LoginIdCheck(regvm.email))
                {
                    throw new Exception("This email already registered.");
                }
                entity.Name = regvm.name;
                entity.LoginId = regvm.email;
                entity.IsActive = true;
                entity.Password = regvm.password.toEncrypt();
                bool result = await usersRepo.Add(entity.ToEntity());
                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool LoginIdCheck(string loginid)
        {
            var result = usersRepo.GetAll(x => x.LoginId.Equals(loginid)).ToList();
            if (result.Count() > 0)
            {
                return false;
            }
            else return true;
        }
    }
}
