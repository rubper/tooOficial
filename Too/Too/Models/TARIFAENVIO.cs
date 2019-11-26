namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TARIFAENVIO")]
    public partial class TARIFAENVIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TARIFAENVIO()
        {
            CARRITOCOMPRA = new HashSet<CARRITOCOMPRA>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDTARIFA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDREGION { get; set; }

        [Required]
        [StringLength(150)]
        public string NOMBRETARIFA { get; set; }

        public decimal VALORTARIFA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITOCOMPRA> CARRITOCOMPRA { get; set; }

        public virtual REGION REGION { get; set; }
    }
}
