namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBDEPARTAMENTO")]
    public partial class SUBDEPARTAMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBDEPARTAMENTO()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
            IMPUESTO = new HashSet<IMPUESTO>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDSUBCATEGORIA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDCATEGORIAPROD { get; set; }

        [Required]
        [StringLength(200)]
        public string NOMSUBCATEGORIA { get; set; }

        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPUESTO> IMPUESTO { get; set; }
    }
}
