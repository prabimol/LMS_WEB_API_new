using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_WEB_API.Models
{
    public class LeaveDetails
    {
        public int LeaveDetailsId { get; set; }
        public int NumberOfDays { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LeaveType { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LeaveReason { get; set; }

        public virtual Employee employee { get; set; }
    }
}
