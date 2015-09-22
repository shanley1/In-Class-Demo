using eRestsaurant.Framework.DAL; //Needed to access DAL classes
using eRestsaurant.Framework.Entities; // Needed for Entity Classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestsaurant.Framework.BLL
{
    public class TempController
    {
        public List<MenuCategory> ListMenuCategories()
        {
            using(var context = new RestaurantContext())
            {
                var data = from category in context.MenuCategories
                           select category;
                return data.ToList();
            }
        }
    }
}
