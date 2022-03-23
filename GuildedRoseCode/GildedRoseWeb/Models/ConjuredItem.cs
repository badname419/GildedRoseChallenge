using System.ComponentModel.DataAnnotations.Schema;

namespace GildedRoseWeb.Models
{
    [NotMapped]
    public class ConjuredItem : OrdinaryItem
    {
        private int ConjuredQualityModifier = 2;
        public ConjuredItem()
        {
            QualityModifier *= ConjuredQualityModifier;
        }
    }
}
