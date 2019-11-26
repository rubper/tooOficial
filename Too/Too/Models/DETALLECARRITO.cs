namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETALLECARRITO")]
    public partial class DETALLECARRITO
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal IDPRODUCTO { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IDCARRITO { get; set; }

        public int CANTIDADPROD { get; set; }

        public decimal PRECIO { get; set; }

        public virtual CARRITOCOMPRA CARRITOCOMPRA { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
