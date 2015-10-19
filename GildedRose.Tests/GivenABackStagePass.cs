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
            int originalQuality = GildedTestHelper.GetQualityOfItem(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            QualityCalculator qualityCalculator = new QualityCalculator(items);

            qualityCalculator.UpdateQuality();
            int updatedQuality = GildedTestHelper.GetQualityOfItem(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            int qualityDifference = updatedQuality - originalQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }
    }

    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class WhenThereAreBetween_5_and_0_days_Sellin_left
    {
        [Test]
        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void Then_QualityIncreasesBy3_EachDay(int initialSellingValue)
        {
            IList<Item> items = TestResources.GetBackStagePassesHavingSellinOf(initialSellingValue);
            int originalQuality = GildedTestHelper.GetQualityOfItem(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            QualityCalculator qualityCalculator = new QualityCalculator(items);

            qualityCalculator.UpdateQuality();
            int updatedQuality = GildedTestHelper.GetQuality(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            int qualityDifference = updatedQuality - originalQuality;

            Assert.That(qualityDifference, Is.EqualTo(3));
        }
    }
}
