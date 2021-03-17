namespace StudCalculator.Data.ModelsFromLotsman
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("stMain")]
    public class stMain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stMain()
        {
            stVersions = new HashSet<stVersions>();
            stVersions1 = new HashSet<stVersions>();
            stVersions2 = new HashSet<stVersions>();
        }

        [Key]
        public int inId { get; set; }

        public int inIdType { get; set; }

        [Required]
        [StringLength(255)]
        public string stKeyAttr { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stVersions> stVersions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stVersions> stVersions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stVersions> stVersions2 { get; set; }
    }
}
