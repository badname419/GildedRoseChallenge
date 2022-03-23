namespace GildedRose.Application
{
    public class AgedBrieItem : Item
    {
        public override void UpdateItem()
        {
            ReduceSellIn();

            IncreaseQuality();
        }
    }
}
