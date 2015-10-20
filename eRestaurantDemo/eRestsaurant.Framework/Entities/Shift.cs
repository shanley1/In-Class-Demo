using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }

        [Required(ErrorMessage = "A PlacementContractID is required")]
        public int PlacementContractID { get; set; }

        [Required(ErrorMessage = "A DayOfWeek is required")]
        public int DayOfWeek { get; set; }

        [Required(ErrorMessage = "A StartTime is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "A EndTime is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "A NumberOfEmployees is required")]
        public int NumberOfEmployees { get; set; }
        
        public bool Active { get; set; }

        [StringLength(100, ErrorMessage = "Notes cannot exceed 100 characters in length")]
        public string Notes { get; set; }       
}
