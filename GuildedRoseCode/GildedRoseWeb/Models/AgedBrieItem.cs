using System.ComponentModel.DataAnnotations.Schema;

namespace GildedRoseWeb.Models
{
    [NotMapped]
    public class AgedBrieItem : Item
    {
        public override void UpdateItem()
        {
            ReduceSellIn();

            IncreaseQuality();
        }
    }
}
