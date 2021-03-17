namespace StudCalculator.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OGK_StudCalculator_Execution_All
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
