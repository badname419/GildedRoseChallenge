namespace GildedRose.Application
{
    public class BackstagePassesItem : Item
    {
        private int FirstThreshold = 10;
        private int SecondThreshold = 5;
        private int FirstQualityModifier = 2;
        private int SecondQualityModifier = 3;
        public override void UpdateItem()
        {
            ReduceSellIn();

            if (SellIn >= 0)
            {
                if (SellIn <= SecondThreshold)
                {
                    QualityModifier = SecondQualityModifier;
                }
                else if (SellIn <= FirstThreshold)
                {
                    QualityModifier = FirstQualityModifier;
                }
                IncreaseQuality();
            }
            else
            {
                Quality = 0;
            }
        }
    }
}
