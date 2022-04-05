using GildedRoseKata.items;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class ItemFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public enum ItemType
        {
            Normal, AgedBrie, Backstage, Sulfuras, Conjured
        }

        public static Item createItem(string itemType, ItemDefinition itemDefinition)
        {
            switch (itemType)
            {
                case "Normal": return new NormalItem(itemDefinition.Name, itemDefinition.SellIn, itemDefinition.Quality);
                case "Aged Brie": return new AgedBrie(AgedBrie, itemDefinition.SellIn, itemDefinition.Quality);
                case "Sulfuras": return new Sulfuras(Sulfuras, itemDefinition.SellIn, itemDefinition.Quality);
                case "Backstage": return new BackStage(Backstage, itemDefinition.SellIn, itemDefinition.Quality);
                case "Conjured": return new ConjuredItem(itemDefinition.Name, itemDefinition.SellIn, itemDefinition.Quality);
            }
            throw new ArgumentException($"The item type {itemType} is not recognized.");
        }
    }
}
