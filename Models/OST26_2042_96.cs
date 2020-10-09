namespace StudCalculator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OST26_2042_96
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Thread { get; set; }

        public double? S { get; set; }
    }
}
