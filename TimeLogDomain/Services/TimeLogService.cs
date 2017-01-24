using System;
using TimeLogDataAccess.Entities;
using TimeLogDataAccess.Interfaces;
using TimeLogDomain.Interfaces;

namespace TimeLogDomain.Services
{
    public class TimeLogService : ITimeLogService
    {
        IUnitOfWork uow;

        public TimeLogService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public void AddTimeLog(TimeLog timeLog)
        {
            uow.TimeLogs.Add(timeLog);
            uow.Save();
        }

        public bool Delete(int timeLogId)
        {
            return uow.TimeLogs.Delete(timeLogId);
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
