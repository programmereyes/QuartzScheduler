using QuartzSchedular.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Repository
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User(){ Firstname="Jhon", Lastname="Cena"},
                new User(){ Firstname="Dwayne", Lastname="Jhonson"},
                new User(){ Firstname="Lincon", Lastname="Borrow"}
            };
        }
    }
}
