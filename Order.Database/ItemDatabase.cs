using Order.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Database
{
    public class ItemDatabase
    {
        public static List<Item> ItemDB = new List<Item>()
        {
            new Item("SadItem", 12.99m, 1563, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tristique tempor bibendum. Phasellus facilisis tincidunt risus, vitae commodo libero vestibulum et. Vestibulum tristique purus nec ligula dictum dictum quis et turpis. Duis accumsan purus vel nunc lobortis consequat eu quis nibh. Etiam at metus et velit ornare dictum.")
        };
    }
}
