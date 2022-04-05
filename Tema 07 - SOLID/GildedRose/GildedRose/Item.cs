using System;
namespace GildedRoseKata
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item() { }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            if (sellIn > 0) { 
                SellIn = sellIn; 
            } else
            {
                return;
            }
            Quality = quality;
        }

        public void ChangeDay()
        {
            SellIn--;
        }

        public virtual bool isQualityIsLessThanMax()
        {
            return Quality <= 50;
        }

        public virtual bool isQualityIsGreaterThan0()
        {
            return Quality > 0;
        }

        public virtual bool checkIsSold()
        {
            return true;
        }

        public virtual void updateQuality()
        {
            if (isQualityIsGreaterThan0())
                if(SellIn > 0 ) 
                    Quality --;
                else
                    Quality -=2;
            else
                Console.WriteLine("Item s quality cannot be updated");
            truncateToMin();
        }

        public void truncateToMin() // if decreasing quality will invalidate the condition
        {
            if (Quality < 0)
                Quality = 0;
        }

        public void truncateToMax() // if increasing quality will invalidate the condition
        {
            if (Quality > 50)
                Quality = 50;
        }

    }

}
