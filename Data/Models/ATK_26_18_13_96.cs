using System.ComponentModel.DataAnnotations;

namespace StudCalculator.Data.Models
{
    public class ATK_26_18_13_96
    {
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? b { get; set; }

        public double? h1 { get; set; }

        public double? h2 { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? n { get; set; }

        [StringLength(255)]
        public string Execution { get; set; }

        [StringLength(255)]
        public string Execution_Caps { get; set; }
    }
}
