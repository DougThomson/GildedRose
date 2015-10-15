using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Lib;
using NUnit.Framework;

namespace Given_a_QualityCalculator
{
    public class WhenQuality_IsUpdated_51Times
    {
        IList<Item> _standardItems = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = _agedBrieName, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = _sulfurasName, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

        private QualityCalculator _qualityCalculator;
        private static string _sulfurasName = "Sulfuras, Hand of Ragnaros";
        private static string _agedBrieName = "Aged Brie";

        [SetUp]
        public void Setup()
        {
            _qualityCalculator = new QualityCalculator(_standardItems);
            for (int i = 0; i < 51; i++)
            {
                _qualityCalculator.UpdateQuality();
            }
        }

        [Test]
        public void ThenTheQualityOfSulfuras_IsStill_80()
        {
            var sulfuras = GetItem(_sulfurasName);
            

            Assert.That(sulfuras.Quality, Is.EqualTo(80));
        }

        [Test]
        public void ThenTheQuality_OfBrie_Is50()
        {
            var brie = GetItem(_agedBrieName);

            Assert.That(brie.Quality, Is.EqualTo(50));
        }

        private Item GetItem(string itemName)
        {
            return _standardItems.ToList().Find(n => n.Name.Equals(itemName));
        }
    }
}
