namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CARRITOCOMPRA")]
    public partial class CARRITOCOMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARRITOCOMPRA()
        {
            DETALLECARRITO = new HashSet<DETALLECARRITO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCARRITO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDTARIFAENVIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDUSUARIO { get; set; }

        public bool ENVIO { get; set; }

        public decimal SUBTOTAL { get; set; }

        [StringLength(200)]
        public string LUGARENTREGA { get; set; }

        [StringLength(100)]
        public string METODOPAGO { get; set; }

        public decimal TOTAL { get; set; }

        public virtual TARIFAENVIO TARIFAENVIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLECARRITO> DETALLECARRITO { get; set; }
    }
}
