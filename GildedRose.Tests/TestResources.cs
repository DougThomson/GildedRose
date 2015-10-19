using System.Collections.Generic;
using GildedRose.Lib;

namespace GildedRose.Tests
{
    public class TestResources
    {
        internal static List<Item> GetStandardItems()
        {
            
            return new List<Item>
            {
                new Item {Name = GildedRoseResourceStrings.DexterityVestName, SellIn = 10, Quality = 20},
                new Item {Name = GildedRoseResourceStrings.AgedBrieName, SellIn = 2, Quality = 0},
                new Item {Name = GildedRoseResourceStrings.ElixirOfTheMongooseName, SellIn = 5, Quality = 7},
                new Item {Name = GildedRoseResourceStrings.SulfurasName, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = GildedRoseResourceStrings.BackstagePassesToATafkal80EtcConcert,
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = GildedRoseResourceStrings.ConjuredManaCake, SellIn = 3, Quality = 6}
            };
        }

        internal static List<Item> GetStandardItemsHavingSellInOf0()
        {

            return new List<Item>
            {
                new Item {Name = GildedRoseResourceStrings.DexterityVestName, SellIn = 0, Quality = 20},
                new Item {Name = GildedRoseResourceStrings.AgedBrieName, SellIn = 0, Quality = 0},
                new Item {Name = GildedRoseResourceStrings.ElixirOfTheMongooseName, SellIn = 0, Quality = 7},
                new Item {Name = GildedRoseResourceStrings.SulfurasName, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = GildedRoseResourceStrings.BackstagePassesToATafkal80EtcConcert,
                    SellIn = 0,
                    Quality = 20
                },
                new Item {Name = GildedRoseResourceStrings.ConjuredManaCake, SellIn = 0, Quality = 6}
            };
        }


        public static IList<Item> GetBackStagePassesHavingSellinOf(int initialSellinValue)
        {
            return new List<Item>
            {
                new Item
                {
                    Name = GildedRoseResourceStrings.BackstagePassesToATafkal80EtcConcert,
                    SellIn = initialSellinValue,
                    Quality = 20
                },
                new Item {Name = GildedRoseResourceStrings.ConjuredManaCake, SellIn = 0, Quality = 6}
            };
        }
    }
}