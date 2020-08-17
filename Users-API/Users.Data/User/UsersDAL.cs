using System;
using System.Collections.Generic;
using System.Linq;
using Users.Application.Interfaces;
using Users.Data.Context;

namespace Users.Data.User
{
    public class UsersDAL : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsersDAL(AppDbContext context)
        {
            _appDbContext = context;

            _appDbContext.Database.EnsureCreated();
        }

        public void AddUser(Domain.User.User user)
        {
            try
            {
                user.Status = "Inactive";
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool DeleteUser(int userID)
        {
            try
            {
                var userToDelete = _appDbContext.Users.FirstOrDefault(user => user.UserID == userID);

                if (userToDelete == null)
                    return false;

                _appDbContext.Users.Remove(userToDelete);
                _appDbContext.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Domain.User.User> GetUsers()
        {
            try
            {
                return _appDbContext.Users.ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool UpdateUser(int userID, Domain.User.User newUser)
        {
            bool isFound = true;

            try
            {
                var oldUser = _appDbContext.Users.FirstOrDefault(user => user.UserID == userID);
                if (oldUser == null)
                    isFound = false;

                oldUser.Name = newUser.Name;
                oldUser.EmailID = newUser.EmailID;
                oldUser.IsAdmin = newUser.IsAdmin;
                oldUser.MobileNumber = newUser.MobileNumber;

                _appDbContext.SaveChanges();

                return isFound;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
