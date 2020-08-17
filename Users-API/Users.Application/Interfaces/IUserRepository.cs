using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.User;

namespace Users.Application.Interfaces
{
    public interface IUserRepository
    {
        List<Domain.User.User> GetUsers();
        void AddUser(Domain.User.User user);
        bool UpdateUser(int userID, Domain.User.User newUser);
        bool DeleteUser(int userID);
    }
}
