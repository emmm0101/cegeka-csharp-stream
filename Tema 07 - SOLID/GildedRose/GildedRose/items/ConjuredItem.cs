using System;

namespace GildedRoseKata.items
{
    internal class ConjuredItem: Item
    {
        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (isQualityIsLessThanMax())
                if (SellIn > 0)
                    Quality -= 2;
                else
                    Quality -= 4;
            else
                Console.WriteLine("Item s quality cannot be updated");
            truncateToMin();
        }
    }
}
