using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "A First Name is required (2-50 characters)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be from 2 to 50 characters in length")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A Last Name is required (2-50 characters)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be from 2 to 50 characters in length")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A Home Phone is required (12 characters)")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Home Phone must be 12 characters in length")]
        public string HomePhone { get; set; }
        
        [Required(ErrorMessage = "Active is required")]        
        public bool Active { get; set; }    
        
        public Employee()
        {
            Active = true;
        }
    }
}
