using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.items
{
    public class BackStage : Item
    {
        public BackStage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void updateQuality()
        {
            if(isQualityIsLessThanMax())
                if (SellIn < 11 && SellIn > 5) Quality += 2;
                if (SellIn <= 5) Quality += 3;
                if (SellIn <= 0) Quality = 0;
            truncateToMax();    

        }
    }
}
