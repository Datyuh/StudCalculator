namespace StudCalculator
{
    using System.ComponentModel.DataAnnotations;

    public class OST26_2008_83
    {
        public int id { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        public double? b { get; set; }

        [StringLength(255)]
        public string Figure { get; set; }
    }
}
