namespace Too.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CANTIDADPRODUCTO")]
    public partial class CANTIDADPRODUCTO
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDCANTIDADPROD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IDPRODUCTO { get; set; }

        public int STOCKPROD { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
