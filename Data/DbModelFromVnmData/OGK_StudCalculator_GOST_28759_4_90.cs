using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudCalculator.Data.DbModelFromVnmData
{
    public class OGK_StudCalculator_GOST_28759_4_90
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string DN { get; set; }

        [StringLength(255)]
        public string PN { get; set; }

        public double? b { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? n { get; set; }
    }
}
