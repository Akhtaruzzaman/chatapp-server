using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Common.Library.Sys_Enum;

namespace Application.IService
{
    public interface IService<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Tuple<long, List<T>> GetAll(int currentPage, int pageSize, T entity);
    }
}
