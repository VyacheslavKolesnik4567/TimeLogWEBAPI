using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeLogDataAccess.Entities
{
    public class TimeLog
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }        

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Decimal DecimalHours { get; set; }
        public int LoggedBy { get; set; }
        public bool IsBilled { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
