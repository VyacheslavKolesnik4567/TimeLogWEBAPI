using System;
using System.Collections.Generic;
using TimeLogDataAccess.Entities;

namespace TimeLogDomain.Interfaces
{
    public interface IUserService: IDisposable
    {
        IEnumerable<User> GetAllUsers();
    }
}
