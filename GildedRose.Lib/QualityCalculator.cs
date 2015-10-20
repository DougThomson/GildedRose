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
                if (IsStandardAgeingRuleHavingQuality(i))
                {
                    DecrementItemQuality(i);
                }
//                if(IsNotStandardAgeingRuleHavingQuality(i))
//                {
                    //                    if (IsQualityLessThan50(i))
                    if(IsNotStandardAgeingRuleHavingQuality(i) && IsQualityLessThan50(i))
                    {
                        IncrementItemQuality(i);

                        if (IsBackStagePass(i) && IsSellinLessThan11(i) && IsQualityLessThan50(i))
                        {
                            IncrementItemQuality(i);
                            if (IsSellinLessThan6(i) && IsQualityLessThan50(i))
                            {
                                IncrementItemQuality(i);
                            }
                        }
                    }
//                }

                if (IsNotSulfuras(i))
                {
                    DecrementSelIn(i);
                }

                if (IsSellinNegative(i))
                {
                    if (IsNotBrie(i) && IsNotBackStagePass(i) && HasQuality(i) && IsNotSulfuras(i))
                    {
                        DecrementItemQuality(i);
                    }
                    if (IsBackStagePass(i))
                    {
                        //Backstage pass has gone past its sellby, thus being useless and quality set to zero
                        SetItemQualityToZero(i);
                    }
                    if (IsBrie(i) && IsQualityLessThan50(i))
                    {
                        IncrementItemQuality(i);
                    }
                }
            }
        }

        private bool IsNotStandardAgeingRuleHavingQuality(int itemNumber)
        {
            return !IsStandardAgeingRuleHavingQuality(itemNumber);
        }

        private bool IsBrie(int itemNumber)
        {
            return !IsNotBrie(itemNumber);
        }

        private bool IsNotBackStagePass(int i)
        {
            return !IsBackStagePass(i);
        }

        private int SetItemQualityToZero(int i)
        {
            return _items[i].Quality = _items[i].Quality - _items[i].Quality;
        }

        private bool HasQuality(int itemNumber)
        {
            return _items[itemNumber].Quality > 0;
        }

        private bool IsNotBrie(int itemNumber)
        {
            return _items[itemNumber].Name != _agedBrie;
        }

        private bool IsSellinNegative(int itemNumber)
        {
            return _items[itemNumber].SellIn < 0;
        }

        private int DecrementSelIn(int itemNumber)
        {
            return _items[itemNumber].SellIn = _items[itemNumber].SellIn - 1;
        }

        private bool IsSellinLessThan6(int itemNumber)
        {
            return _items[itemNumber].SellIn < 6;
        }

        private bool IsSellinLessThan11(int itemNumber)
        {
            return _items[itemNumber].SellIn < 11;
        }

        private bool IsBackStagePass(int itemNumber)
        {
            return _items[itemNumber].Name == _backstagePassesToATafkal80EtcConcert;
        }

        private int DecrementItemQuality(int itemNumber)
        {
            return _items[itemNumber].Quality = _items[itemNumber].Quality - 1;
        }

        private int IncrementItemQuality(int i)
        {
            return _items[i].Quality = _items[i].Quality + 1;
        }

        private bool IsQualityLessThan50(int itemNumber)
        {
            return _items[itemNumber].Quality < 50;
        }

        private bool IsStandardAgeingRuleHavingQuality(int i)
        {
            return IsitemHavingStandardAgeingRules(i) && DoesItemHaveAnyQuality(i) && IsNotSulfuras(i);
        }

        private bool IsNotSulfuras(int itemNumber)
        {
            return _items[itemNumber].Name != _sulfurasHandOfRagnaros;
        }

        private bool DoesItemHaveAnyQuality(int itemNumber)
        {
            return _items[itemNumber].Quality > 0;
        }

        private bool IsitemHavingStandardAgeingRules(int itemNumber)
        {
            return _items[itemNumber].Name != _agedBrie && _items[itemNumber].Name != _backstagePassesToATafkal80EtcConcert;
        }
    }
}