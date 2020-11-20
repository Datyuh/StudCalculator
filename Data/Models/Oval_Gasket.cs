namespace StudCalculator
{
    using System.ComponentModel.DataAnnotations;

    public partial class Oval_Gasket
    {
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? c { get; set; }
    }
}
