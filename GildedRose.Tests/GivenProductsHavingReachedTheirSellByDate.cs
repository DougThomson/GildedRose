using System.Collections.Generic;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

namespace GivenProductsHavingReachedTheirSellByDate
{
    [TestFixture]
    public class WhenTheNightlyQualityUpdateOccurs
    {
        [Test]
        public void ThenTheQuality_IsReducedBy_2()
        {
            IList<Item> standardItems = TestResources.GetStandardItems();
            QualityCalculator qualityCalculator = new QualityCalculator(standardItems);

            for (int i = 0; i < 10; i++)
            {
                qualityCalculator.UpdateQuality(); 
            }
            int qualityWhenSellInReached0 = GetQuality(standardItems, TestResources.DexterityVestName);
            qualityCalculator.UpdateQuality();
            int newQuality = GetQuality(standardItems, TestResources.DexterityVestName);

            int qualityDifference =  qualityWhenSellInReached0 - newQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }

        private static int GetQuality(IList<Item> itemList, string itemName)
        {
            return TestResources.GetItem(itemName, itemList).Quality;
        }
    }
}
