namespace StudCalculator.Data.ModelsFromLotsman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stAttributes
    {
        [Key]
        public int inId { get; set; }

        public int inIdVersion { get; set; }

        public int inIdTypeAttr { get; set; }

        [Required]
        [StringLength(255)]
        public string stValue { get; set; }

        public int? inValue { get; set; }

        public double? reValue { get; set; }

        public DateTime? dtValue { get; set; }

        public int? inIdUnit { get; set; }

        public int? inIdExternal { get; set; }

        public int? State { get; set; }

        public DateTime dtModified { get; set; }

        public virtual rlTypesAndAttributes rlTypesAndAttributes { get; set; }

        public virtual rlTypesAndAttributes rlTypesAndAttributes1 { get; set; }

        public virtual rlTypesAndAttributes rlTypesAndAttributes2 { get; set; }

        public virtual stVersions stVersions { get; set; }

        public virtual stVersions stVersions1 { get; set; }

        public virtual stVersions stVersions2 { get; set; }
    }
}
