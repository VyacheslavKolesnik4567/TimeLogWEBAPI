using System;
using System.ComponentModel.DataAnnotations;

namespace TimeLogWebApi.Models
{
    public class TimeLogViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public string Description { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required, Range(0, 59)]
        public int Minutes { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int StartTime { get; set; }
        [Required]
        public int EndTime { get; set; }
        [Required]
        public int LoggedBy { get; set; }
        [Required]
        public bool IsBilled { get; set; }
    }
}