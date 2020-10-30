namespace StudCalculator.Data.ModelsFromLotsman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dsAttributes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dsAttributes()
        {
            rlTypesAndAttributes = new HashSet<rlTypesAndAttributes>();
            rlTypesAndAttributes1 = new HashSet<rlTypesAndAttributes>();
            rlTypesAndAttributes2 = new HashSet<rlTypesAndAttributes>();
        }

        [Key]
        public int inId { get; set; }

        [Required]
        [StringLength(255)]
        public string stName { get; set; }

        public byte inType { get; set; }

        [Required]
        [StringLength(255)]
        public string stDefault { get; set; }

        [Column(TypeName = "text")]
        public string txtList { get; set; }

        public byte biSystem { get; set; }

        public byte inDefAccess { get; set; }

        public byte biOnlyListItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rlTypesAndAttributes> rlTypesAndAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rlTypesAndAttributes> rlTypesAndAttributes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rlTypesAndAttributes> rlTypesAndAttributes2 { get; set; }
    }
}
