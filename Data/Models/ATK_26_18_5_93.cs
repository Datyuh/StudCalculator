using System.ComponentModel.DataAnnotations;

namespace StudCalculator.Data.Models
{
    public class ATK_26_18_5_93
    {
        public int id { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        public double? b { get; set; }

        [StringLength(255)]
        public string Style { get; set; }
    }
}
