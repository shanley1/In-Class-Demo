using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Framework.Entities
{
    public class PlacementContract
    {
        [Key]
        public int PlacementContractID { get; set; }

        [Required(ErrorMessage = "A StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "A EndDate is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "A LocationID is required")]
        public int LocationID { get; set; }        
    }
}
