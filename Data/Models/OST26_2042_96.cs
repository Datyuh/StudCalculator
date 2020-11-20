namespace StudCalculator
{
    using System.ComponentModel.DataAnnotations;

    public partial class OST26_2042_96
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? S { get; set; }
    }
}
