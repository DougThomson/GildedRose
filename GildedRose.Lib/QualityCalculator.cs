using System.Collections.Generic;

namespace GildedRose.Lib
{
    public class QualityCalculator
    {
        private readonly IList<Item> _items;
        private readonly string _agedBrie = GildedRoseResourceStrings.AgedBrieName;
        private readonly string _backstagePassesToATafkal80EtcConcert = GildedRoseResourceStrings.BackstagePassesToATafkal80EtcConcert;
        private readonly string _sulfurasHandOfRagnaros = GildedRoseResourceStrings.SulfurasName;

        public QualityCalculator(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (IsStandardAgeingRuleHavingQuality(_items[i]))
                {
                    DecrementItemQuality(_items[i]);
                }

                if (IsNotStandardAgeingRuleHavingQuality(_items[i]) && IsQualityLessThan50(_items[i]))
                {
                    IncrementItemQuality(_items[i]);

                    if (IsBackStagePass(_items[i]) && IsSellinLessThan11(_items[i]) && IsQualityLessThan50(_items[i]))
                    {
                        IncrementItemQuality(_items[i]);
                        if (IsSellinLessThan6(_items[i]) && IsQualityLessThan50(_items[i]))
                        {
                            IncrementItemQuality(_items[i]);
                        }
                    }
                }

                if (IsNotSulfuras(_items[i]))
                {
                    DecrementSelIn(_items[i]);
                }

                if (!IsSellinNegative(_items[i]))
                    continue;

                if (IsNotBrie(_items[i]) && IsNotBackStagePass(_items[i]) && HasQuality(_items[i]) && IsNotSulfuras(_items[i]))
                {
                    DecrementItemQuality(_items[i]);
                }
                if (IsBackStagePass(_items[i]))
                {
                    //Backstage pass has gone past its sellby, thus being useless and quality set to zero
                    SetItemQualityToZero(_items[i]);
                }
                if (IsBrie(_items[i]) && IsQualityLessThan50(_items[i]))
                {
                    IncrementItemQuality(_items[i]);
                }
            }
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
            return item.Name != _agedBrie && item.Name != _backstagePassesToATafkal80EtcConcert;
        }
    }
}