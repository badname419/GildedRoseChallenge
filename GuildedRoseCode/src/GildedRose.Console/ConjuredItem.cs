namespace GildedRose.Application
{
    public class ConjuredItem : OrdinaryItem
    {
        private int ConjuredQualityModifier = 2;
		private int SomeRandomStat = 0;
        public ConjuredItem()
        {
            QualityModifier *= ConjuredQualityModifier;
        }
    }
}
