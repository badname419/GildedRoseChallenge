using System;
using System.Collections.Generic;
using MarkdownLog;

namespace GildedRose.Application
{
    public static class Program
    {
        public static IList<Item> Items;

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            Shop.Items = new List<Item>
                {
                    new OrdinaryItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new AgedBrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new OrdinaryItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new BackstagePassesItem
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };

            Shop.VerifyQuality();

            while (true)
            {
                Console.Clear();

                Shop.UpdateQuality();

                Console.WriteLine(Shop.Items.ToMarkdownTable());

                Console.ReadKey();
            }
        }
    }
}
