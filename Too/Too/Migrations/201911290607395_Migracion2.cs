namespace Too.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CANTIDADPRODUCTO", "IDPRODUCTO", "dbo.PRODUCTO");
            DropForeignKey("dbo.DETALLECARRITO", "IDCARRITO", "dbo.CARRITOCOMPRA");
            DropForeignKey("dbo.CARRITOCOMPRA", "IDTARIFAENVIO", "dbo.TARIFAENVIO");
            DropForeignKey("dbo.TARIFAENVIO", "IDREGION", "dbo.REGION");
            DropForeignKey("dbo.CARRITOCOMPRA", "IDUSUARIO", "dbo.USUARIO");
            DropForeignKey("dbo.DETALLECARRITO", "IDPRODUCTO", "dbo.PRODUCTO");
            DropForeignKey("dbo.SUBDEPARTAMENTO", "IDCATEGORIAPROD", "dbo.DEPARTAMENTO");
            DropForeignKey("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDIMPUESTO", "dbo.IMPUESTO");
            DropForeignKey("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDSUBCATEGORIA", "dbo.SUBDEPARTAMENTO");
            DropForeignKey("dbo.PRODUCTO", "IDSUBCATEGORIA", "dbo.SUBDEPARTAMENTO");
            DropForeignKey("dbo.TAG_PROD", "IDTAGPROD", "dbo.TAG");
            DropForeignKey("dbo.TAG_PROD", "IDPRODUCTO", "dbo.PRODUCTO");
            DropIndex("dbo.CANTIDADPRODUCTO", new[] { "IDPRODUCTO" });
            DropIndex("dbo.PRODUCTO", new[] { "IDSUBCATEGORIA" });
            DropIndex("dbo.DETALLECARRITO", new[] { "IDPRODUCTO" });
            DropIndex("dbo.DETALLECARRITO", new[] { "IDCARRITO" });
            DropIndex("dbo.CARRITOCOMPRA", new[] { "IDTARIFAENVIO" });
            DropIndex("dbo.CARRITOCOMPRA", new[] { "IDUSUARIO" });
            DropIndex("dbo.TARIFAENVIO", new[] { "IDREGION" });
            DropIndex("dbo.SUBDEPARTAMENTO", new[] { "IDCATEGORIAPROD" });
            DropIndex("dbo.IMPUESTO_SUBDEPARTAMENTO", new[] { "IDIMPUESTO" });
            DropIndex("dbo.IMPUESTO_SUBDEPARTAMENTO", new[] { "IDSUBCATEGORIA" });
            DropIndex("dbo.TAG_PROD", new[] { "IDTAGPROD" });
            DropIndex("dbo.TAG_PROD", new[] { "IDPRODUCTO" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.CANTIDADPRODUCTO");
            DropTable("dbo.PRODUCTO");
            DropTable("dbo.DETALLECARRITO");
            DropTable("dbo.CARRITOCOMPRA");
            DropTable("dbo.TARIFAENVIO");
            DropTable("dbo.REGION");
            DropTable("dbo.USUARIO");
            DropTable("dbo.SUBDEPARTAMENTO");
            DropTable("dbo.DEPARTAMENTO");
            DropTable("dbo.IMPUESTO");
            DropTable("dbo.TAG");
            DropTable("dbo.IMPUESTO_SUBDEPARTAMENTO");
            DropTable("dbo.TAG_PROD");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TAG_PROD",
                c => new
                    {
                        IDTAGPROD = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        IDPRODUCTO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.IDTAGPROD, t.IDPRODUCTO });
            
            CreateTable(
                "dbo.IMPUESTO_SUBDEPARTAMENTO",
                c => new
                    {
                        IDIMPUESTO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        IDSUBCATEGORIA = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => new { t.IDIMPUESTO, t.IDSUBCATEGORIA });
            
            CreateTable(
                "dbo.TAG",
                c => new
                    {
                        IDTAGPROD = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        NOMTAG = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IDTAGPROD);
            
            CreateTable(
                "dbo.IMPUESTO",
                c => new
                    {
                        IDIMPUESTO = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        NOMIMPUESTO = c.String(nullable: false, maxLength: 200, unicode: false),
                        VALORIMPUESTO = c.Decimal(nullable: false, precision: 3, scale: 2),
                    })
                .PrimaryKey(t => t.IDIMPUESTO);
            
            CreateTable(
                "dbo.DEPARTAMENTO",
                c => new
                    {
                        IDCATEGORIAPROD = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        NOMBRECATEGORIA = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IDCATEGORIAPROD);
            
            CreateTable(
                "dbo.SUBDEPARTAMENTO",
                c => new
                    {
                        IDSUBCATEGORIA = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        IDCATEGORIAPROD = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        NOMSUBCATEGORIA = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IDSUBCATEGORIA);
            
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        IDUSUARIO = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        USERNAME = c.String(nullable: false, maxLength: 50, unicode: false),
                        PRIMERNOMBRE = c.String(nullable: false, maxLength: 50, unicode: false),
                        PRIMERAPELLIDO = c.String(nullable: false, maxLength: 50, unicode: false),
                        DIRECCION = c.String(nullable: false, maxLength: 250, unicode: false),
                        DIRECCION2 = c.String(maxLength: 250, unicode: false),
                        CIUDAD = c.String(nullable: false, maxLength: 250, unicode: false),
                        PROVINCIA = c.String(nullable: false, maxLength: 250, unicode: false),
                        TELEFONO = c.String(nullable: false, maxLength: 25, unicode: false),
                        CELULAR = c.String(maxLength: 25, unicode: false),
                        PAIS = c.String(nullable: false, maxLength: 50, unicode: false),
                        EMAIL = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.IDUSUARIO);
            
            CreateTable(
                "dbo.REGION",
                c => new
                    {
                        IDREGION = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        NOMBREREGION = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IDREGION);
            
            CreateTable(
                "dbo.TARIFAENVIO",
                c => new
                    {
                        IDTARIFA = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        IDREGION = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        NOMBRETARIFA = c.String(nullable: false, maxLength: 150, unicode: false),
                        VALORTARIFA = c.Decimal(nullable: false, precision: 6, scale: 2),
                    })
                .PrimaryKey(t => t.IDTARIFA);
            
            CreateTable(
                "dbo.CARRITOCOMPRA",
                c => new
                    {
                        IDCARRITO = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        IDTARIFAENVIO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        IDUSUARIO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        ENVIO = c.Boolean(nullable: false),
                        SUBTOTAL = c.Decimal(nullable: false, precision: 9, scale: 2),
                        LUGARENTREGA = c.String(maxLength: 200, unicode: false),
                        METODOPAGO = c.String(maxLength: 100, unicode: false),
                        TOTAL = c.Decimal(nullable: false, precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.IDCARRITO);
            
            CreateTable(
                "dbo.DETALLECARRITO",
                c => new
                    {
                        IDPRODUCTO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        IDCARRITO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        CANTIDADPROD = c.Int(nullable: false),
                        PRECIO = c.Decimal(nullable: false, precision: 8, scale: 2),
                    })
                .PrimaryKey(t => new { t.IDPRODUCTO, t.IDCARRITO });
            
            CreateTable(
                "dbo.PRODUCTO",
                c => new
                    {
                        IDPRODUCTO = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        IDSUBCATEGORIA = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        NOMBREPROD = c.String(nullable: false, maxLength: 200, unicode: false),
                        DESCPROD = c.String(nullable: false, maxLength: 500, unicode: false),
                        PRECIOUNIT = c.Decimal(nullable: false, precision: 7, scale: 2),
                        IMAGENPROD = c.Binary(storeType: "image"),
                        DISPONIBILIDAD = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDPRODUCTO);
            
            CreateTable(
                "dbo.CANTIDADPRODUCTO",
                c => new
                    {
                        IDCANTIDADPROD = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        IDPRODUCTO = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        STOCKPROD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDCANTIDADPROD);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.TAG_PROD", "IDPRODUCTO");
            CreateIndex("dbo.TAG_PROD", "IDTAGPROD");
            CreateIndex("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDSUBCATEGORIA");
            CreateIndex("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDIMPUESTO");
            CreateIndex("dbo.SUBDEPARTAMENTO", "IDCATEGORIAPROD");
            CreateIndex("dbo.TARIFAENVIO", "IDREGION");
            CreateIndex("dbo.CARRITOCOMPRA", "IDUSUARIO");
            CreateIndex("dbo.CARRITOCOMPRA", "IDTARIFAENVIO");
            CreateIndex("dbo.DETALLECARRITO", "IDCARRITO");
            CreateIndex("dbo.DETALLECARRITO", "IDPRODUCTO");
            CreateIndex("dbo.PRODUCTO", "IDSUBCATEGORIA");
            CreateIndex("dbo.CANTIDADPRODUCTO", "IDPRODUCTO");
            AddForeignKey("dbo.TAG_PROD", "IDPRODUCTO", "dbo.PRODUCTO", "IDPRODUCTO", cascadeDelete: true);
            AddForeignKey("dbo.TAG_PROD", "IDTAGPROD", "dbo.TAG", "IDTAGPROD", cascadeDelete: true);
            AddForeignKey("dbo.PRODUCTO", "IDSUBCATEGORIA", "dbo.SUBDEPARTAMENTO", "IDSUBCATEGORIA");
            AddForeignKey("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDSUBCATEGORIA", "dbo.SUBDEPARTAMENTO", "IDSUBCATEGORIA", cascadeDelete: true);
            AddForeignKey("dbo.IMPUESTO_SUBDEPARTAMENTO", "IDIMPUESTO", "dbo.IMPUESTO", "IDIMPUESTO", cascadeDelete: true);
            AddForeignKey("dbo.SUBDEPARTAMENTO", "IDCATEGORIAPROD", "dbo.DEPARTAMENTO", "IDCATEGORIAPROD");
            AddForeignKey("dbo.DETALLECARRITO", "IDPRODUCTO", "dbo.PRODUCTO", "IDPRODUCTO");
            AddForeignKey("dbo.CARRITOCOMPRA", "IDUSUARIO", "dbo.USUARIO", "IDUSUARIO");
            AddForeignKey("dbo.TARIFAENVIO", "IDREGION", "dbo.REGION", "IDREGION");
            AddForeignKey("dbo.CARRITOCOMPRA", "IDTARIFAENVIO", "dbo.TARIFAENVIO", "IDTARIFA");
            AddForeignKey("dbo.DETALLECARRITO", "IDCARRITO", "dbo.CARRITOCOMPRA", "IDCARRITO");
            AddForeignKey("dbo.CANTIDADPRODUCTO", "IDPRODUCTO", "dbo.PRODUCTO", "IDPRODUCTO");
        }
    }
}
