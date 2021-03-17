namespace StudCalculator.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OGK_StudCalculator_Octagonal_Gasket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? c { get; set; }
    }
}
