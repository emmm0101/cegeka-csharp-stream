using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.items
{
    public class AgedBrie : Item
    {
        private const string name = "Aged Brie";
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if (isQualityIsLessThanMax())
                Quality += 2;
            truncateToMax();
        }
    }
}
