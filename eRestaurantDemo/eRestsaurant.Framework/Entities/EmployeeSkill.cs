using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class EmployeeSkill
    {
        [Key]
        public int EmployeeSkillID { get; set; }

        [Required(ErrorMessage = "A EmployeeID is required")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "A SkillID is required")]
        public int SkillID { get; set; }

        [Required(ErrorMessage = "A Level is required")]
        public int Level { get; set; }
        
        public int? YearsOfExperience { get; set; }
    }
}
