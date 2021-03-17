namespace StudCalculator.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OGK_StudCalculator_ATK_24_200_02_90
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        public double? b { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        [StringLength(255)]
        public string Style { get; set; }
    }
}
