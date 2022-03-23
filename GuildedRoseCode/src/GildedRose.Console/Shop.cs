using System.Collections.Generic;

namespace GildedRose.Application
{
    public static class Shop
    {
        public static IList<Item> Items;

        public static void VerifyQuality()
        {
            foreach(Item item in Items)
            {
                if(item.Quality > item.GetQualityLimit())
                {
                    item.Quality = item.GetQualityLimit();
                }
            }
        }

        public static void UpdateQuality()
        {

            foreach (Item item in Items)
            {
                item.UpdateItem();
            }
        }

    }
}
