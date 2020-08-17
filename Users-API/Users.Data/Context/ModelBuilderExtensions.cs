using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.User;

namespace Users.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.User.User>().HasData(
                new Domain.User.User { UserID=1, Name = "Jasprit Bumrah", EmailID = "jasprit@gmail.com", IsAdmin = true, MobileNumber = "9088776655", Status = "Inactive" }
                );
        }
    }
}
