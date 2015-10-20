using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class Skill
    {
        [Key]
        public int ShiftID { get; set; }               

        [Required(ErrorMessage = "A Description is required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters in length")]
        public string Description { get; set; }

        public bool RequiresTicket { get; set; }

        public Skill()
        {
            RequiresTicket = false;
        }
    }
}
