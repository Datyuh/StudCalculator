using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudCalculator.Data.DbModelFromVnmData
{
    public class OGK_StudCalculator_OST26_2042_96
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? S { get; set; }
    }
}
