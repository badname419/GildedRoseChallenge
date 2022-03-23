namespace GildedRose.Application
{
    public class ConjuredItem : OrdinaryItem
    {
        private int ConjuredQualityModifier = 2;
        public ConjuredItem()
        {
            QualityModifier *= ConjuredQualityModifier;
        }
    }
}
