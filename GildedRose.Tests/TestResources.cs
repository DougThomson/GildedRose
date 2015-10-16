using System.Collections.Generic;
using System.Linq;
using GildedRose.Lib;

namespace GildedRose.Tests
{
    public class TestResources
    {
        internal static List<Item> GetStandardItems()
        {
            
            return new List<Item>
            {
                new Item {Name = DexterityVestName, SellIn = 10, Quality = 20},
                new Item {Name = AgedBrieName, SellIn = 2, Quality = 0},
                new Item {Name = ElixirOfTheMongooseName, SellIn = 5, Quality = 7},
                new Item {Name = SulfurasName, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = BackstagePassesToATafkal80EtcConcert,
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }

        internal static string ConjuredManaCake = "Conjured Mana Cake";
        internal static string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        internal static string ElixirOfTheMongooseName = "Elixir of the Mongoose";
        internal static string DexterityVestName = "+5 Dexterity Vest";
        internal static string SulfurasName = "Sulfuras, Hand of Ragnaros";
        internal static string AgedBrieName = "Aged Brie";

        internal static Item GetItem(string itemName, IList<Item> itemsList)
        {
            return itemsList.ToList().Find(n => n.Name.Equals(itemName));
        }
    }
}