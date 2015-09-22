﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestsaurant.Framework.Entities
{
    public class MenuCategory
    {
        [Key] //This attribute identifies the MenuCategoryID property as mapping to a PK
        public int MenuCategoryID { get; set; }
        public string Description { get; set; }

        //Navigation Property
        public virtual ICollection<Item> Items { get; set; }

    }
}
