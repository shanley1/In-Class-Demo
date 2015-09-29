using System;
using eRestsaurant.Framework.Entities; // Needed for Entity Classes
using System.Collections.Generic;
using System.Data.Entity; // Needed for the DbContext and other EF classes
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestsaurant.Framework.DAL
{
    // By making our DAL class internal, that means outside projects cant directly access our Data Access Layer
    //(They will have to go through our BLL to do stuff)
    internal class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("DefaultConnection")
        { }

        // One Property for each Table/Entity in the database
        public DbSet<MenuCategory> MenuCategories {get;set;}
        public DbSet<Item> Items { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }

        // The property name must match the database title
        public DbSet<Table> Tables { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        // For Customizing the model of our entities as we want them to match our database, we would put any details
        // inside the following method
        protected override void OnModelICreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
