using System.Collections.Generic;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace GivenProductsAdheringToStandardAgingQualityRulesAndHavingReachedTheirSellByDate
{
    [TestFixture]
    public class WhenTheNightlyQualityUpdateOccurs
    {
        [Test]
        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Conjured Mana Cake")]
        public void ThenTheQuality_IsReducedBy_2(string itemName)
        {
            IList<Item> standardItems = TestResources.GetStandardItemsHavingSellInOf0();
            QualityCalculator qualityCalculator = new QualityCalculator(standardItems);         
            int qualityWhenSellInReached0 = GildedTestHelper.GetQualityOfItem(standardItems, itemName);

            qualityCalculator.UpdateQuality();
            int newQuality = GildedTestHelper.GetQualityOfItem(standardItems, itemName);
            int qualityDifference =  qualityWhenSellInReached0 - newQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }
    }
}
