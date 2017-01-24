using System.Collections.Generic;
using TimeLogDataAccess.Entities;
using TimeLogDataAccess.Interfaces;
using TimeLogDomain.Interfaces;

namespace TimeLogDomain.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork uow;

        public UserService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return uow.Users.GetAll();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
