﻿using System.Collections.Generic;
using GildedRose.Lib;
using GildedRose.Tests;
using NUnit.Framework;

// ReSharper disable once CheckNamespace
namespace Given_a_QualityCalculator
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class WhenQuality_IsUpdated_51Times
    {
        readonly IList<Item> _standardItems = TestResources.GetStandardItems();

        private QualityCalculator _qualityCalculator;

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
            var sulfuras = GildedTestHelper.GetItem(GildedRoseResourceStrings.SulfurasName, _standardItems);
            

            Assert.That(sulfuras.Quality, Is.EqualTo(80));
        }

        [Test]
        public void ThenTheQualityOfBrie_IncreasesToaMaxim_Of50()
        {
            var brie = GildedTestHelper.GetItem(GildedRoseResourceStrings.AgedBrieName, _standardItems);

            Assert.That(brie.Quality, Is.EqualTo(50));
        }

        [Test]
        [TestCase("+5 Dexterity Vest")]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Conjured Mana Cake")]
        public void ThenTheQualityOfAnyProductOtherThanBrie_IsNeverLessThan_0(string itemName)
        {
            int actualQuality = GildedTestHelper.GetItem(itemName, _standardItems).Quality;

            Assert.That(actualQuality, Is.EqualTo(0));
        }  
    }


}
