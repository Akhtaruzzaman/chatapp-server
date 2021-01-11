using Common.Library;
using Domain.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Common.Library.Sys_Enum;

namespace Repository.DBContext
{
    public static class SeedData
    {
        public static void SeedValue(ModelBuilder builder)
        {
            builder.Entity<Users>().HasData(new Users
            {
                Id = SYS_DATA.RS_NA_ID.StringToGuid(),
                Name = "User 1",
                Address = "Dhaka, Banlgadesh",
                Password = "12345".toEncrypt(),
                CreatedAt = DateTime.Now,
                CreatedBy = SYS_DATA.EmpetyGuid.StringToGuid(),
                CreatedFrom = "",
                LoginId = "user1@gmail.com",
                Mobile = "013xxxxxxxx",
                IsActive = true,
                IsArchived = false,
            });
            builder.Entity<Users>().HasData(new Users
            {
                Id = SYS_GUID.GetStaticGuid(1),
                Name = "User 2",
                Address = "Dhaka, Banlgadesh",
                Password = "12345".toEncrypt(),
                CreatedAt = DateTime.Now,
                CreatedBy = SYS_DATA.EmpetyGuid.StringToGuid(),
                CreatedFrom = "",
                LoginId = "user2@gmail.com",
                Mobile = "013xxxxxxxx",
                IsActive = true,
                IsArchived = false,
            });
        }
    }
}
