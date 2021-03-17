namespace StudCalculator.Data.ModelsFromLotsman
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class rlTypesAndAttributes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public rlTypesAndAttributes()
        {
            stAttributes = new HashSet<stAttributes>();
            stAttributes1 = new HashSet<stAttributes>();
            stAttributes2 = new HashSet<stAttributes>();
        }

        [Key]
        public int inId { get; set; }

        public int inIdType { get; set; }

        public int inIdAttribute { get; set; }

        public byte biObligatory { get; set; }

        [StringLength(255)]
        public string stRule { get; set; }

        public int Inherited { get; set; }

        public virtual dsAttributes dsAttributes { get; set; }

        public virtual dsAttributes dsAttributes1 { get; set; }

        public virtual dsAttributes dsAttributes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes2 { get; set; }
    }
}
