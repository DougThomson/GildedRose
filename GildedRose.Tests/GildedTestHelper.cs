using System.Collections.Generic;
using System.Linq;
using GildedRose.Lib;

namespace GildedRose.Tests
{
    public class GildedTestHelper
    {
        public static int GetQualityOfItem(IList<Item> itemList, string itemName)
        {
            return GetItem(itemName, itemList).Quality;
        }

        internal static Item GetItem(string itemName, IList<Item> itemsList)
        {
            return itemsList.ToList().Find(n => n.Name.Equals(itemName));
        }
    }
}