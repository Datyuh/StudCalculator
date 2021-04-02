using System.ComponentModel.DataAnnotations;

namespace StudCalculator.Data.Models
{
    public class Type_11
    {
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? b_1 { get; set; }

        public double? b_2 { get; set; }

        [StringLength(255)]
        public string Thread_1 { get; set; }

        [StringLength(255)]
        public string Thread_2 { get; set; }

        public double? n_type1 { get; set; }

        public double? n_type2 { get; set; }
    }
}
