using System.ComponentModel.DataAnnotations.Schema;

namespace GildedRoseWeb.Models
{
    [NotMapped]
    public class LegendaryItem : Item
    {
        public override void UpdateItem() 
        {
            if (SellIn > 0) SellIn = 0;
        }
    }
}
