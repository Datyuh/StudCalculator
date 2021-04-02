using System.ComponentModel.DataAnnotations;

namespace StudCalculator.Data.Models
{
    public class Execution_All
    {
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? h { get; set; }

        public double? h1 { get; set; }

        public double? h2 { get; set; }

        public double? h4 { get; set; }

        public double? h5 { get; set; }
    }
}
