using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required(ErrorMessage = "A Name is required (2-50 characters)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be from 2 to 50 characters in length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A Street is required (2-50 characters)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Street must be from 2 to 50 characters in length")]
        public string Street { get; set; }

        [Required(ErrorMessage = "A City is required (2-35 characters)")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "City must be from 2 to 35 characters in length")]
        public string City { get; set; }

        [Required(ErrorMessage = "A Province is required (2 characters)")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Province must be 2 characters in length")]
        public string Province { get; set; }

        [StringLength(50, ErrorMessage = "Contact cannot exceed 50 characters in length")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "A Province is required (12 characters)")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Phone must be 12 characters in length")]
        public string Phone { get; set; }

        
        [Required(ErrorMessage = "Active is required")]        
        public bool Active { get; set; }    
        
        public Location()
        {
            Active = true;
        }
    }
}
