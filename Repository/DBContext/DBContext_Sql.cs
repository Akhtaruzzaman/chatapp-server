using Common.Library;
using Domain.Master;
using Domain.Messenger;
using Microsoft.EntityFrameworkCore;

namespace Repository.DBContext
{
    public class DBContext_Sql : DbContext
    {


        public DBContext_Sql()
             : base(GetOptions())
        {
        }
        public DBContext_Sql(DbContextOptions<DBContext_Sql> options)
        : base(options)
        {
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), SYS_DATA.DB_Connection).Options;
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>().HasIndex(u => new { u.LoginId }).IsUnique();
            #region Masterdata unique
            #endregion

            SeedData.SeedValue(builder);
        }
    }
}
