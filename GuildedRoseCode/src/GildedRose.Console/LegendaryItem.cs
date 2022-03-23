namespace GildedRose.Application
{
    public class LegendaryItem : Item
    {
        public override void UpdateItem() 
        {
            if (SellIn > 0) SellIn = 0;
        }
    }
}
