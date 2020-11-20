namespace StudCalculator.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OGK_StudCalculator_Type_11
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
