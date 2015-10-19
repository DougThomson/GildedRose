using System.Collections.Generic;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace GivenABackStagePass
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class WhenThereAreBetween_10_and_6_days_Sellin_left
    {
        [Test]
        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void Then_QualityIncreasesBy2_EachDay(int initialSellinValue)
        {
            IList<Item> items = TestResources.GetBackStagePassesHavingSellinOf(initialSellinValue);
            int originalQuality = GetQualityOfBackstagePass(items);
            QualityCalculator qualityCalculator = new QualityCalculator(items);

            qualityCalculator.UpdateQuality();
            int updatedQuality = GetQualityOfBackstagePass(items);
            int qualityDifference = updatedQuality - originalQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }

        private static int GetQualityOfBackstagePass(IList<Item> items)
        {
            int originalQuality = GildedTestHelper.GetQuality(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            return originalQuality;
        }
    }
}
