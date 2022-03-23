using System.ComponentModel.DataAnnotations;

namespace GildedRoseWeb.Models
{
    public abstract class Item
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Sell In")]
        public int SellIn { get; set; }

        [Range(0, 50)]
        public int Quality { get; set; }

        public string Type { get; set; }    

        protected int QualityModifier { get; set; } = 1;

        protected int QualityLimit { get; set; } = 50;

        protected int ExpiredQualityModifier { get; set; } = 2;

        public int GetQualityLimit()
        {
            return QualityLimit;
        }

        public abstract void UpdateItem();

        public void ReduceSellIn()
        {
            this.SellIn -= 1;
        }

        private bool CanModifyQuality()
        {
            return (this.Quality < QualityLimit) && (Quality >= 0);
        }

        private bool IsExpired()
        {
            return SellIn < 0;
        }

        public void IncreaseQuality()
        {
            if (CanModifyQuality())
            {
                Quality += QualityModifier;

                if (Quality > QualityLimit)
                {
                    Quality = QualityLimit;
                }
            }
        }

        public void DecreaseQuality()
        {
            if (CanModifyQuality())
            {
                if (IsExpired())
                {
                    this.Quality -= ExpiredQualityModifier * QualityModifier;
                }
                else
                {
                    this.Quality -= QualityModifier;
                }

                if (Quality < 0)
                {
                    Quality = 0;
                }
            }
        }
    }
}
