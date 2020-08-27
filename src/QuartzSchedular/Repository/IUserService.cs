using QuartzSchedular.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Repository
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
