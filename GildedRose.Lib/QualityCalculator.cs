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
                    _items[i].Quality = _items[i].Quality - 1;
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality = _items[i].Quality + 1;

                        if (_items[i].Name == _backstagePassesToATafkal80EtcConcert)
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality = _items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_items[i].Name != _sulfurasHandOfRagnaros)
                {
                    _items[i].SellIn = _items[i].SellIn - 1;
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != _agedBrie)
                    {
                        if (_items[i].Name != _backstagePassesToATafkal80EtcConcert)
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (_items[i].Name != _sulfurasHandOfRagnaros)
                                {
                                    _items[i].Quality = _items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = _items[i].Quality - _items[i].Quality;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality = _items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        private bool IsStandardAgeingRuleHavingQuality(int i)
        {
            return IsitemHavingStandardAgeingRules(i) && DoesItemHaveAnyQuality(i) && IsNotASulfurasItem(i);
        }

        private bool IsNotASulfurasItem(int itemNumber)
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