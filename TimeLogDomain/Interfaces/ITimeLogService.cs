using System;
using TimeLogDataAccess.Entities;

namespace TimeLogDomain.Interfaces
{
    public interface ITimeLogService: IDisposable
    {
        void AddTimeLog(TimeLog timeLog);
        bool Delete(int timeLogId);
    }
}
