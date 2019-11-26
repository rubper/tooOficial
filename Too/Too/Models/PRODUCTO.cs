namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            CANTIDADPRODUCTO = new HashSet<CANTIDADPRODUCTO>();
            DETALLECARRITO = new HashSet<DETALLECARRITO>();
            TAG = new HashSet<TAG>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDPRODUCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDSUBCATEGORIA { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMBREPROD { get; set; }

        [Required]
        [StringLength(500)]
        public string DESCPROD { get; set; }

        public decimal PRECIOUNIT { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] IMAGENPROD { get; set; }

        public bool DISPONIBILIDAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CANTIDADPRODUCTO> CANTIDADPRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLECARRITO> DETALLECARRITO { get; set; }

        public virtual SUBDEPARTAMENTO SUBDEPARTAMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAG> TAG { get; set; }
    }
}
