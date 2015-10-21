using System.Collections.Generic;

namespace GildedRose.Lib
{
    public class QualityCalculator
    {
        private readonly IList<Item> _items;
        private readonly string _agedBrie = GildedRoseResourceStrings.AgedBrieName;
        private readonly string _backstagePassesToATafkal80EtcConcert = GildedRoseResourceStrings.BackstagePassesToATafkal80EtcConcert;
        private readonly string _sulfurasHandOfRagnaros = GildedRoseResourceStrings.SulfurasName;
        private string _conjuredItemName = GildedRoseResourceStrings.ConjuredItemName;

        public QualityCalculator(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (IsStandardAgeingRuleHavingQuality(item))
                {
                    DecrementItemQuality(item);
                }

                if (IsConjuredItem(item))
                {
                    DecrementItemQualityBy2(item);
                }

                if (IsNotStandardAgeingRuleHavingQuality(item) && IsQualityLessThan50(item) && IsNotConjuredItem(item))
                {
                    IncrementItemQuality(item);

                    if (IsBackStagePass(item) && IsSellinLessThan11(item) && IsQualityLessThan50(item))
                    {
                        IncrementItemQuality(item);
                        if (IsSellinLessThan6(item) && IsQualityLessThan50(item))
                        {
                            IncrementItemQuality(item);
                        }
                    }
                }

                if (IsNotSulfuras(item))
                {
                    DecrementSelIn(item);
                }

                if (!IsSellinNegative(item))
                    continue;

                if (IsNotBrie(item) && IsNotBackStagePass(item) && HasQuality(item) && IsNotSulfuras(item))
                {
                    DecrementItemQuality(item);
                }
                if (IsBackStagePass(item))
                {
                    //Backstage pass has gone past its sellby, thus being useless and quality set to zero
                    SetItemQualityToZero(item);
                }
                if (IsBrie(item) && IsQualityLessThan50(item))
                {
                    IncrementItemQuality(item);
                }
            }
        }

        private bool IsNotConjuredItem(Item item)
        {
            return !IsConjuredItem(item);
        }

        private bool IsConjuredItem(Item item)
        {
            return item.Name.Equals(_conjuredItemName);
        }

        private void DecrementItemQualityBy2(Item item)
        {
            item.Quality = item.Quality - 2;
        }

        private bool IsNotStandardAgeingRuleHavingQuality(Item item)
        {
            return !IsStandardAgeingRuleHavingQuality(item);
        }

        private bool IsBrie(Item item)
        {
            return !IsNotBrie(item);
        }

        private bool IsNotBackStagePass(Item item)
        {
            return !IsBackStagePass(item);
        }

        private void SetItemQualityToZero(Item item)
        {
            item.Quality = item.Quality - item.Quality;
        }

        private bool HasQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool IsNotBrie(Item item)
        {
            return item.Name != _agedBrie;
        }

        private bool IsSellinNegative(Item item)
        {
            return item.SellIn < 0;
        }

        private void DecrementSelIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private bool IsSellinLessThan6(Item item)
        {
            return item.SellIn < 6;
        }

        private bool IsSellinLessThan11(Item item)
        {
            return item.SellIn < 11;
        }

        private bool IsBackStagePass(Item item)
        {
            return item.Name == _backstagePassesToATafkal80EtcConcert;
        }

        private void DecrementItemQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }

        private void IncrementItemQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private bool IsQualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        private bool IsStandardAgeingRuleHavingQuality(Item item)
        {
            return IsitemHavingStandardAgeingRules(item) && DoesItemHaveAnyQuality(item) && IsNotSulfuras(item);
        }

        private bool IsNotSulfuras(Item item)
        {
            return item.Name != _sulfurasHandOfRagnaros;
        }

        private bool DoesItemHaveAnyQuality(Item item)
        {
            return item.Quality > 0;
        }

        private bool IsitemHavingStandardAgeingRules(Item item)
        {
            return item.Name != _agedBrie && item.Name != _backstagePassesToATafkal80EtcConcert && item.Name != _conjuredItemName;
        }
    }
}