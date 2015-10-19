using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

namespace GivenABackStagePass
{
    [TestFixture]
    public class WhenThereAreBetween_10_and_6_days_Sellin_left
    {
        [Test]
        [TestCase(10)]
        public void Then_QualityIncreasesBy2_EachDay(int initialSellinValue)
        {
            IList<Item> items = TestResources.GetBackStagePassesHavingSellinOf(initialSellinValue);
            int originalQuality = GildedTestHelper.GetQuality(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            QualityCalculator qualityCalculator = new QualityCalculator(items);

            qualityCalculator.UpdateQuality();
            int updatedQuality = GildedTestHelper.GetQuality(items, TestResources.BackstagePassesToATafkal80EtcConcert);
            int qualityDifference = updatedQuality - originalQuality;

            Assert.That(qualityDifference, Is.EqualTo(2));
        }
    }}
