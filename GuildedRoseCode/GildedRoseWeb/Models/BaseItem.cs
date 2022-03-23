using System.ComponentModel.DataAnnotations;

namespace GildedRoseWeb.Models
{
    public class BaseItem
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sell In")]
        public int SellIn { get; set; }

        [Required]
        [Range(0, 50)]
        public int Quality { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
