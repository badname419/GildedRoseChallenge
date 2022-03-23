namespace GildedRose.Application
{
    public class OrdinaryItem : Item
    {
        public override void UpdateItem()
        {

            ReduceSellIn();

            DecreaseQuality();

        }
    }
}
