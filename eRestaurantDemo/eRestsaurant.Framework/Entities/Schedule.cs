using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required(ErrorMessage = "A Day is required")]
        public DateTime Day { get; set; }

        [Required(ErrorMessage = "A ShiftID is required")]
        public int ShiftID { get; set; }

        [Required(ErrorMessage = "A EmployeeID is required")]
        public int EmployeeID { get; set; }
        
    }
}
