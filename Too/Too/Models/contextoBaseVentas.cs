namespace Too.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class contextoBaseVentas : DbContext
    {
        public contextoBaseVentas()
            : base("name=contextoBaseVentas")
        {
        }

        public virtual DbSet<CANTIDADPRODUCTO> CANTIDADPRODUCTO { get; set; }
        public virtual DbSet<CARRITOCOMPRA> CARRITOCOMPRA { get; set; }
        public virtual DbSet<DEPARTAMENTO> DEPARTAMENTO { get; set; }
        public virtual DbSet<DETALLECARRITO> DETALLECARRITO { get; set; }
        public virtual DbSet<IMPUESTO> IMPUESTO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<SUBDEPARTAMENTO> SUBDEPARTAMENTO { get; set; }
        public virtual DbSet<TAG> TAG { get; set; }
        public virtual DbSet<TARIFAENVIO> TARIFAENVIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CANTIDADPRODUCTO>()
                .Property(e => e.IDCANTIDADPROD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CANTIDADPRODUCTO>()
                .Property(e => e.IDPRODUCTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.IDCARRITO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.IDTARIFAENVIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.IDUSUARIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.SUBTOTAL)
                .HasPrecision(9, 2);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.LUGARENTREGA)
                .IsUnicode(false);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.METODOPAGO)
                .IsUnicode(false);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .Property(e => e.TOTAL)
                .HasPrecision(9, 2);

            modelBuilder.Entity<CARRITOCOMPRA>()
                .HasMany(e => e.DETALLECARRITO)
                .WithRequired(e => e.CARRITOCOMPRA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.IDCATEGORIAPROD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DEPARTAMENTO>()
                .Property(e => e.NOMBRECATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTAMENTO>()
                .HasMany(e => e.SUBDEPARTAMENTO)
                .WithRequired(e => e.DEPARTAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETALLECARRITO>()
                .Property(e => e.IDPRODUCTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DETALLECARRITO>()
                .Property(e => e.IDCARRITO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DETALLECARRITO>()
                .Property(e => e.PRECIO)
                .HasPrecision(8, 2);

            modelBuilder.Entity<IMPUESTO>()
                .Property(e => e.IDIMPUESTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<IMPUESTO>()
                .Property(e => e.NOMIMPUESTO)
                .IsUnicode(false);

            modelBuilder.Entity<IMPUESTO>()
                .Property(e => e.VALORIMPUESTO)
                .HasPrecision(3, 2);

            modelBuilder.Entity<IMPUESTO>()
                .HasMany(e => e.SUBDEPARTAMENTO)
                .WithMany(e => e.IMPUESTO)
                .Map(m => m.ToTable("IMPUESTO_SUBDEPARTAMENTO").MapLeftKey("IDIMPUESTO").MapRightKey("IDSUBCATEGORIA"));

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.IDPRODUCTO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.IDSUBCATEGORIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.NOMBREPROD)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCPROD)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIOUNIT)
                .HasPrecision(7, 2);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.CANTIDADPRODUCTO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLECARRITO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.IDREGION)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REGION>()
                .Property(e => e.NOMBREREGION)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .HasMany(e => e.TARIFAENVIO)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBDEPARTAMENTO>()
                .Property(e => e.IDSUBCATEGORIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUBDEPARTAMENTO>()
                .Property(e => e.IDCATEGORIAPROD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SUBDEPARTAMENTO>()
                .Property(e => e.NOMSUBCATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<SUBDEPARTAMENTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.SUBDEPARTAMENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAG>()
                .Property(e => e.IDTAGPROD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TAG>()
                .Property(e => e.NOMTAG)
                .IsUnicode(false);

            modelBuilder.Entity<TAG>()
                .HasMany(e => e.PRODUCTO)
                .WithMany(e => e.TAG)
                .Map(m => m.ToTable("TAG_PROD").MapLeftKey("IDTAGPROD").MapRightKey("IDPRODUCTO"));

            modelBuilder.Entity<TARIFAENVIO>()
                .Property(e => e.IDTARIFA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TARIFAENVIO>()
                .Property(e => e.IDREGION)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TARIFAENVIO>()
                .Property(e => e.NOMBRETARIFA)
                .IsUnicode(false);

            modelBuilder.Entity<TARIFAENVIO>()
                .Property(e => e.VALORTARIFA)
                .HasPrecision(6, 2);

            modelBuilder.Entity<TARIFAENVIO>()
                .HasMany(e => e.CARRITOCOMPRA)
                .WithRequired(e => e.TARIFAENVIO)
                .HasForeignKey(e => e.IDTARIFAENVIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.IDUSUARIO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PRIMERNOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PRIMERAPELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.DIRECCION2)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CIUDAD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PROVINCIA)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.CARRITOCOMPRA)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);
        }
    }
}
