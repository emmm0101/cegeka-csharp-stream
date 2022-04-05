using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items = new List<Item>(); // stock
        public GildedRose(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                this.Items.Add(item);
            }    
        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }
    }

}
