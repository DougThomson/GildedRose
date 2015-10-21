using System.Collections.Generic;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

namespace Given_a_ConjuredItem
{
    [TestFixture]
    public class When_Update_IsCalled
    {
        [Test]
        public void Then_Quality_ShouldBeDecrementedBy2()
        {
            IList<Item> items = TestResources.GetConjuredItems();
            int originalQuality = GetQualityOfConjuredItem(items);
            QualityCalculator qualityCalculator = new QualityCalculator(items);
            qualityCalculator.UpdateQuality();

            int updatedQuality = GetQualityOfConjuredItem(items);
            int qualityDifference = originalQuality - updatedQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }

        private static int GetQualityOfConjuredItem(IList<Item> items)
        {
            return GildedTestHelper.GetQualityOfItem(items, GildedRoseResourceStrings.ConjuredItemName);
        }
    }}
