using System.ComponentModel.DataAnnotations.Schema;

namespace GildedRoseWeb.Models
{
    [NotMapped]
    public class OrdinaryItem : Item
    {

        public override void UpdateItem()
        {

            ReduceSellIn();

            DecreaseQuality();

        }
    }
}
