using System;
using TimeLogDataAccess.EF;
using TimeLogDataAccess.Entities;
using TimeLogDataAccess.Interfaces;

namespace TimeLogDataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        TimeLogContext db;
        bool disposed = false;
        GenericRepository<User> userRepository;
        GenericRepository<TimeLog> timeLogRepository;

        public GenericRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(db);
                return userRepository;
            }
        }

        public GenericRepository<TimeLog> TimeLogs
        {
            get
            {
                if (timeLogRepository == null)
                    timeLogRepository = new GenericRepository<TimeLog>(db);
                return timeLogRepository;
            }
        }

        public UnitOfWork(TimeLogContext _context)
        {
            this.db = _context;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
