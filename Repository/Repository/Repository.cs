using Common.Library;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public abstract class Repository<TEntity>
          where TEntity : Entity, new()
    {
        private readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async virtual Task<bool> Add(TEntity entity)
        {
            try
            {
                this.Context.Set<TEntity>().Add(entity);
                this.Context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                //SqlException innerException = ex.InnerException.InnerException as SqlException;
                //if (innerException == null)
                //{
                //    innerException = ex.InnerException as SqlException;
                //}

                //if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                //{
                //    throw new Exception("Duplicate unique key");
                //}
                //else if (innerException != null && (innerException.Number == 8152 || innerException.Number == 8152))
                //{
                //    throw new Exception("Field lenght getting big");
                //}
                //else
                //{
                //    throw new Exception("OTHER ERROR " + ex.Message);
                //}
                throw ex;
            }
        }
        public async Task<bool> AddMany(List<TEntity> entity)
        {
            try
            {
                this.Context.Set<TEntity>().AddRange(entity);
                this.Context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException == null)
                {
                    innerException = ex.InnerException as SqlException;
                }

                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    throw new Exception("Duplicate unique key");
                }
                else if (innerException != null && (innerException.Number == 8152 || innerException.Number == 8152))
                {
                    throw new Exception("Field lenght getting big");
                }
                else
                {
                    throw new Exception("OTHER ERROR " + ex.Message);
                }
            }
        }

        public async virtual Task<bool> Update(TEntity entity)
        {
            try
            {

                if (!this.Context.Set<TEntity>().Any(x => x.Id == entity.Id))
                {
                    this.Context.Set<TEntity>().Attach(entity);
                    this.Context.Set<TEntity>().Update(entity).State = EntityState.Modified;
                }
                else
                {
                    var currentEntity = this.Context.Set<TEntity>().Where(x => x.Id.Equals(entity.Id)).FirstOrDefault();
                    this.Context.Set<TEntity>().Update(currentEntity).CurrentValues.SetValues(entity);
                }
                this.Context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException == null)
                {
                    innerException = ex.InnerException as SqlException;
                }

                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    throw new Exception("Duplicate unique key");
                }
                else if (innerException != null && (innerException.Number == 8152 || innerException.Number == 8152))
                {
                    throw new Exception("Field lenght getting big");
                }
                else
                {
                    throw new Exception("OTHER ERROR " + ex.Message);
                }
                //foreach(var entityError in ex.EntityValidationErrors)
                //{
                //    foreach(var error in entityError.ValidationErrors)
                //    {
                //        throw new Exception(error.PropertyName + " : " + error.ErrorMessage);
                //        //Trace.TraceInformation("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
                //    }
                //}
            }
        }
        public async Task<bool> UpdateMany(List<TEntity> entity)
        {
            try
            {
                this.Context.Set<TEntity>().UpdateRange(entity);
                this.Context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException == null)
                {
                    innerException = ex.InnerException as SqlException;
                }

                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    throw new Exception("Duplicate unique key");
                }
                else if (innerException != null && (innerException.Number == 8152 || innerException.Number == 8152))
                {
                    throw new Exception("Field lenght getting big");
                }
                else
                {
                    throw new Exception("OTHER ERROR " + ex.Message);
                }
            }
        }

        public async virtual Task<bool> Delete(Guid id)
        {
            try
            {
                var currentEntity = this.Context.Set<TEntity>().Where(x => x.Id.Equals(id)).FirstOrDefault();
                this.Context.Set<TEntity>().Remove(currentEntity);
                this.Context.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Count()
        {
            try
            {
                int result = await Count(x => true);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = this.Context.Set<TEntity>().Count(expression);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> Get(Guid id)
        {
            try
            {
                var result = this.Context.Set<TEntity>().First(x => x.Id.Equals(id));
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                var result = GetAll(x => true);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = this.Context.Set<TEntity>().Where(expression);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetAny(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                TEntity rValue = this.Context.Set<TEntity>().Where(expression).FirstOrDefault();
                if (rValue == null)
                {
                    rValue = Activator.CreateInstance<TEntity>();
                }
                return await Task.FromResult(rValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid GetId()
        {
            return Guid.NewGuid();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}