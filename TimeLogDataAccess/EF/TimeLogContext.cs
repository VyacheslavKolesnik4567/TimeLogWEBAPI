using System.Data.Entity;
using TimeLogDataAccess.Entities;

namespace TimeLogDataAccess.EF
{
    public class TimeLogContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
    }
}
