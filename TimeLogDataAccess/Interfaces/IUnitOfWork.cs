using System;
using TimeLogDataAccess.Entities;
using TimeLogDataAccess.Repositories;

namespace TimeLogDataAccess.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        GenericRepository<User> Users { get; }
        GenericRepository<TimeLog> TimeLogs { get; }
        void Save();
    }
}
