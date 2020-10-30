namespace StudCalculator.Data.ModelsFromLotsman
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class stVersions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stVersions()
        {
            stAttributes = new HashSet<stAttributes>();
            stAttributes1 = new HashSet<stAttributes>();
            stAttributes2 = new HashSet<stAttributes>();
            stVersions1 = new HashSet<stVersions>();
        }

        [Key]
        public int inId { get; set; }

        public int inIdMain { get; set; }

        public int inIdState { get; set; }

        [StringLength(255)]
        public string stNumber { get; set; }

        public int? inIdParentVersion { get; set; }

        public int? inOwner { get; set; }

        public DateTime dtDateOfCreate { get; set; }

        public byte biRevision { get; set; }

        public DateTime dtModified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stAttributes> stAttributes2 { get; set; }

        public virtual stMain stMain { get; set; }

        public virtual stMain stMain1 { get; set; }

        public virtual stMain stMain2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stVersions> stVersions1 { get; set; }

        public virtual stVersions stVersions2 { get; set; }
    }
}
