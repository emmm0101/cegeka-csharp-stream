using GildedRoseKata;


    try
    {
        var item1= ItemFactory.createItem("Backstage", new ItemDefinition("", 3, 5));
        var item2 = ItemFactory.createItem("Aged Brie", new ItemDefinition("", 3, 49));
        var item3 = ItemFactory.createItem("Normal", new ItemDefinition("", 2 ,2));

        IList<Item> items = new List<Item>();
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);

        GildedRose gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();
        gildedRose.UpdateQuality();
        gildedRose.UpdateQuality();
        gildedRose.UpdateQuality();

        Console.WriteLine("");
}
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    
