namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            CARRITOCOMPRA = new HashSet<CARRITOCOMPRA>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDUSUARIO { get; set; }

        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PRIMERNOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string PRIMERAPELLIDO { get; set; }

        [Required]
        [StringLength(250)]
        public string DIRECCION { get; set; }

        [StringLength(250)]
        public string DIRECCION2 { get; set; }

        [Required]
        [StringLength(250)]
        public string CIUDAD { get; set; }

        [Required]
        [StringLength(250)]
        public string PROVINCIA { get; set; }

        [Required]
        [StringLength(25)]
        public string TELEFONO { get; set; }

        [StringLength(25)]
        public string CELULAR { get; set; }

        [Required]
        [StringLength(50)]
        public string PAIS { get; set; }

        [Required]
        [StringLength(150)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITOCOMPRA> CARRITOCOMPRA { get; set; }
    }
}
