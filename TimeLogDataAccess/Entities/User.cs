using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeLogDataAccess.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public IList<TimeLog> TimeLogs { get; set; }
    }
}
