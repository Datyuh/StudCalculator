using System.ComponentModel.DataAnnotations;

namespace StudCalculator.Data.Models
{
    public class Octagonal_Gasket
    {
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? c { get; set; }
    }
}
