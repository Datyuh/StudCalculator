namespace StudCalculator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OST_26_2041_96
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? Р_Large { get; set; }

        public double? P_Small { get; set; }

        public double? H { get; set; }
    }
}
