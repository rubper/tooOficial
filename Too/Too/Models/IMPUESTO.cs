namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IMPUESTO")]
    public partial class IMPUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IMPUESTO()
        {
            SUBDEPARTAMENTO = new HashSet<SUBDEPARTAMENTO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDIMPUESTO { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMIMPUESTO { get; set; }

        public decimal VALORIMPUESTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBDEPARTAMENTO> SUBDEPARTAMENTO { get; set; }
    }
}
