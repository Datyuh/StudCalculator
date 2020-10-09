namespace StudCalculator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OST26_2008_83
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
