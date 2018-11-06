using Order.Database;
using Order.Database.Exceptions;
using Order.Domain.Items;
using Order.Domain.Items.Exceptions;
using Order.Services.ItemServices;
using Order.Services.ItemServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Order.Services.Tests.ItemServices
{
    public class ItermServiceTests
    {
        IItemService itemService;

        public ItermServiceTests()
        {
            ItemDatabase.ItemDB.Clear();
            var temp = new List<Item>()
                {
                    new Item("SadItem", 12.99m, 1563, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tristique tempor bibendum. Phasellus facilisis tincidunt risus, vitae commodo libero vestibulum et. Vestibulum tristique purus nec ligula dictum dictum quis et turpis. Duis accumsan purus vel nunc lobortis consequat eu quis nibh. Etiam at metus et velit ornare dictum."),
                    new Item("that", 2.99m, 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tristique tempor bibendum. Phasellus facilisis tincidunt risus, vitae commodo libero vestibulum et. Vestibulum tristique purus nec ligula dictum dictum quis et turpis. Duis accumsan purus vel nunc lobortis consequat eu quis nibh. Etiam at metus et velit ornare dictum."),
                    new Item("this", 8.99m, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce tristique tempor bibendum. Phasellus facilisis tincidunt risus, vitae commodo libero vestibulum et. Vestibulum tristique purus nec ligula dictum dictum quis et turpis. Duis accumsan purus vel nunc lobortis consequat eu quis nibh. Etiam at metus et velit ornare dictum.")
                };
            ItemDatabase.ItemDB.AddRange(temp);

            itemService = new ItemService();
        }

        [Fact]
        public void GivenADatabase_Happy_WhenPromptingToSeeAllEntries_TheDataBaseIsReturned()
        {
            var result = itemService.GetAllItems();
            Assert.Equal(ItemDatabase.ItemDB, result);
        }
        [Fact]
        public void GivenADatabase_WhenPromptingToSeeAllEntriesButDBIsEmpty_ExceptionIsThrown()
        {
            ItemDatabase.ItemDB.Clear();

            var item = Assert.Throws<DatabaseException>(() => itemService.GetAllItems());
            Assert.Equal("Items Database is empty", item.Message);
        }
        [Fact]
        public void GivenANewItem_Happy_WhenAddingAnItem_TheItemIsAddedToTheDB()
        {
            var totalCountOfItemsInDB = ItemDatabase.ItemDB.Count;
            var newItem = new Item("test", 12m, 5, "somerandomdescriptionhereplss");
            itemService.AddNewItem(newItem);
            var newCountOfItemsInDB = ItemDatabase.ItemDB.Count;

            Assert.True(totalCountOfItemsInDB + 1 == newCountOfItemsInDB);
        }
        [Fact]
        public void GivenANewItem_NotSoHappy1_WhenAddingAnItem_Exception()
        {
            var item = Assert.Throws<ItemException>(() => new Item("", 12m, 5, "somerandomdescriptionhereplss"));

            Assert.Equal("All fields are required", item.Message);
        }
        [Fact]
        public void GivenANewItem_NotSoHappy2_WhenAddingAnItem_Exception()
        {
            var item = Assert.Throws<ItemException>(() => new Item("test", -12m, 5, "somerandomdescriptionhereplss"));

            Assert.Equal("The price cannot be negative", item.Message);
        }
        [Fact]
        public void GivenANewItem_NotSoHappy3_WhenAddingAnItem_Exception()
        {
            var item = Assert.Throws<ItemException>(() => new Item("test", 12m, -5, "somerandomdescriptionhereplss"));

            Assert.Equal("The amount cannot be negative", item.Message);
        }
        [Fact]
        public void GivenANewItem_NotSoHappy4_WhenAddingAnItem_Exception()
        {
            var item = Assert.Throws<ItemException>(() => new Item("test", 12m, -5, ""));

            Assert.Equal("All fields are required", item.Message);
        }
        [Fact]
        public void GivenAItemGUID_Happy_WhenUpdatingThisItemWithOther_ItemIsUpdated()
        {
            var item = Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Name == "SadItem");
            var guidOfItem = item.Id;
            var newItem = new Item("SadItem", 15482m, 12, "randommmm");

            itemService.UpdateItem(guidOfItem, newItem);

            Assert.Equal(Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == guidOfItem).Price, newItem.Price);
            Assert.Equal(Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == guidOfItem).Name, newItem.Name);
            Assert.Equal(Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == guidOfItem).Description, newItem.Description);
            Assert.Equal(Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == guidOfItem).Amount, newItem.Amount);
            Assert.False(Database.ItemDatabase.ItemDB.Single(itemFromDB => itemFromDB.Id == guidOfItem).Id == newItem.Id);

        }
        [Fact]
        public void GivenAItemGUID_WhenUpdatingThisItemWithOtherButGuidCannotBeFound_Exception()
        {
            var newItem = new Item("SadItem", 15482m, 12, "randommmm");

            var updatedItem = Assert.Throws<ItemException>(() => itemService.UpdateItem(Guid.NewGuid(), newItem));

            Assert.Equal("Item to update cannot be found.", updatedItem.Message);
        }

    }
}
