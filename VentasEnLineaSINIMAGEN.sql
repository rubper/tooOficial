/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     28/11/2019 0:59:05                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CANTIDADPRODUCTO') and o.name = 'FK_CANTIDAD_RELATIONS_PRODUCTO')
alter table CANTIDADPRODUCTO
   drop constraint FK_CANTIDAD_RELATIONS_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CARRITOCOMPRA') and o.name = 'FK_CARRITOC_PUEDE_TEN_TARIFAEN')
alter table CARRITOCOMPRA
   drop constraint FK_CARRITOC_PUEDE_TEN_TARIFAEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CARRITOCOMPRA') and o.name = 'FK_CARRITOC_RELATIONS_USUARIO')
alter table CARRITOCOMPRA
   drop constraint FK_CARRITOC_RELATIONS_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLECARRITO') and o.name = 'FK_DETALLEC_PROD_CARR_PRODUCTO')
alter table DETALLECARRITO
   drop constraint FK_DETALLEC_PROD_CARR_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLECARRITO') and o.name = 'FK_DETALLEC_PROD_CARR_CARRITOC')
alter table DETALLECARRITO
   drop constraint FK_DETALLEC_PROD_CARR_CARRITOC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('IMPUESTO_SUBDEPARTAMENTO') and o.name = 'FK_IMPUESTO_RELATIONS_IMPUESTO')
alter table IMPUESTO_SUBDEPARTAMENTO
   drop constraint FK_IMPUESTO_RELATIONS_IMPUESTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('IMPUESTO_SUBDEPARTAMENTO') and o.name = 'FK_IMPUESTO_RELATIONS_SUBDEPAR')
alter table IMPUESTO_SUBDEPARTAMENTO
   drop constraint FK_IMPUESTO_RELATIONS_SUBDEPAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTO') and o.name = 'FK_PRODUCTO_RELATIONS_SUBDEPAR')
alter table PRODUCTO
   drop constraint FK_PRODUCTO_RELATIONS_SUBDEPAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SUBDEPARTAMENTO') and o.name = 'FK_SUBDEPAR_CONTIENE_DEPARTAM')
alter table SUBDEPARTAMENTO
   drop constraint FK_SUBDEPAR_CONTIENE_DEPARTAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAG_PROD') and o.name = 'FK_TAG_PROD_TAG_PROD1_TAG')
alter table TAG_PROD
   drop constraint FK_TAG_PROD_TAG_PROD1_TAG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAG_PROD') and o.name = 'FK_TAG_PROD_TAG_PROD2_PRODUCTO')
alter table TAG_PROD
   drop constraint FK_TAG_PROD_TAG_PROD2_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TARIFAENVIO') and o.name = 'FK_TARIFAEN_RELATIONS_REGION')
alter table TARIFAENVIO
   drop constraint FK_TARIFAEN_RELATIONS_REGION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CANTIDADPRODUCTO')
            and   name  = 'RELATIONSHIP_13_FK'
            and   indid > 0
            and   indid < 255)
   drop index CANTIDADPRODUCTO.RELATIONSHIP_13_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CANTIDADPRODUCTO')
            and   type = 'U')
   drop table CANTIDADPRODUCTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CARRITOCOMPRA')
            and   name  = 'RELATIONSHIP_10_FK'
            and   indid > 0
            and   indid < 255)
   drop index CARRITOCOMPRA.RELATIONSHIP_10_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CARRITOCOMPRA')
            and   name  = 'PUEDE_TENER_FK'
            and   indid > 0
            and   indid < 255)
   drop index CARRITOCOMPRA.PUEDE_TENER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CARRITOCOMPRA')
            and   type = 'U')
   drop table CARRITOCOMPRA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DEPARTAMENTO')
            and   type = 'U')
   drop table DEPARTAMENTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLECARRITO')
            and   name  = 'PROD_CARRITO2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLECARRITO.PROD_CARRITO2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLECARRITO')
            and   name  = 'PROD_CARRITO1_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLECARRITO.PROD_CARRITO1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLECARRITO')
            and   type = 'U')
   drop table DETALLECARRITO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('IMPUESTO')
            and   type = 'U')
   drop table IMPUESTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('IMPUESTO_SUBDEPARTAMENTO')
            and   name  = 'RELATIONSHIP_15_FK'
            and   indid > 0
            and   indid < 255)
   drop index IMPUESTO_SUBDEPARTAMENTO.RELATIONSHIP_15_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('IMPUESTO_SUBDEPARTAMENTO')
            and   name  = 'RELATIONSHIP_14_FK'
            and   indid > 0
            and   indid < 255)
   drop index IMPUESTO_SUBDEPARTAMENTO.RELATIONSHIP_14_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('IMPUESTO_SUBDEPARTAMENTO')
            and   type = 'U')
   drop table IMPUESTO_SUBDEPARTAMENTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'RELATIONSHIP_11_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.RELATIONSHIP_11_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REGION')
            and   type = 'U')
   drop table REGION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SUBDEPARTAMENTO')
            and   name  = 'CONTIENE_FK'
            and   indid > 0
            and   indid < 255)
   drop index SUBDEPARTAMENTO.CONTIENE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SUBDEPARTAMENTO')
            and   type = 'U')
   drop table SUBDEPARTAMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAG')
            and   type = 'U')
   drop table TAG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAG_PROD')
            and   name  = 'TAG_PROD1_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAG_PROD.TAG_PROD1_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAG_PROD')
            and   name  = 'TAG_PROD2_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAG_PROD.TAG_PROD2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAG_PROD')
            and   type = 'U')
   drop table TAG_PROD
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TARIFAENVIO')
            and   name  = 'RELATIONSHIP_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index TARIFAENVIO.RELATIONSHIP_12_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TARIFAENVIO')
            and   type = 'U')
   drop table TARIFAENVIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: CANTIDADPRODUCTO                                      */
/*==============================================================*/
create table CANTIDADPRODUCTO (
   IDCANTIDADPROD       numeric              identity,
   IDPRODUCTO           numeric              not null,
   STOCKPROD            int                  not null,
   constraint PK_CANTIDADPRODUCTO primary key nonclustered (IDCANTIDADPROD)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('CANTIDADPRODUCTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'cantidadProducto', 
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CANTIDADPRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDCANTIDADPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'IDCANTIDADPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idCantidadProd',
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'IDCANTIDADPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CANTIDADPRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDPRODUCTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'IDPRODUCTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idProducto',
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'IDPRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CANTIDADPRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'STOCKPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'STOCKPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'stockProd',
   'user', @CurrentUser, 'table', 'CANTIDADPRODUCTO', 'column', 'STOCKPROD'
go

/*==============================================================*/
/* Index: RELATIONSHIP_13_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_13_FK on CANTIDADPRODUCTO (
IDPRODUCTO ASC
)
go

/*==============================================================*/
/* Table: CARRITOCOMPRA                                         */
/*==============================================================*/
create table CARRITOCOMPRA (
   IDCARRITO            numeric              identity,
   IDTARIFAENVIO        numeric              null,
   IDUSUARIO            numeric              null,
   ENVIO                bit                  null,
   SUBTOTAL             decimal(9,2)         null,
   LUGARENTREGA         varchar(200)         null,
   METODOPAGO           varchar(100)         null,
   TOTAL                decimal(9,2)         null,
   constraint PK_CARRITOCOMPRA primary key nonclustered (IDCARRITO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('CARRITOCOMPRA') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'CarritoCompra', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDCARRITO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDCARRITO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idCarrito',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDCARRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDTARIFAENVIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDTARIFAENVIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idTarifaEnvio',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDTARIFAENVIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDUSUARIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDUSUARIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idUsuario',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'IDUSUARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ENVIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'ENVIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'envio',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'ENVIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SUBTOTAL')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'SUBTOTAL'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'subtotal',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'SUBTOTAL'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LUGARENTREGA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'LUGARENTREGA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'lugarEntrega',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'LUGARENTREGA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'METODOPAGO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'METODOPAGO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'metodoPago',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'METODOPAGO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CARRITOCOMPRA')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TOTAL')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'TOTAL'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'total',
   'user', @CurrentUser, 'table', 'CARRITOCOMPRA', 'column', 'TOTAL'
go

/*==============================================================*/
/* Index: PUEDE_TENER_FK                                        */
/*==============================================================*/
create index PUEDE_TENER_FK on CARRITOCOMPRA (
IDTARIFAENVIO ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_10_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_10_FK on CARRITOCOMPRA (
IDUSUARIO ASC
)
go

/*==============================================================*/
/* Table: DEPARTAMENTO                                          */
/*==============================================================*/
create table DEPARTAMENTO (
   IDCATEGORIAPROD      numeric              identity,
   NOMBRECATEGORIA      varchar(200)         not null,
   constraint PK_DEPARTAMENTO primary key nonclustered (IDCATEGORIAPROD)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DEPARTAMENTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DEPARTAMENTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Departamento', 
   'user', @CurrentUser, 'table', 'DEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDCATEGORIAPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DEPARTAMENTO', 'column', 'IDCATEGORIAPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idCategoriaProd',
   'user', @CurrentUser, 'table', 'DEPARTAMENTO', 'column', 'IDCATEGORIAPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMBRECATEGORIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DEPARTAMENTO', 'column', 'NOMBRECATEGORIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nombreCategoria',
   'user', @CurrentUser, 'table', 'DEPARTAMENTO', 'column', 'NOMBRECATEGORIA'
go

/*==============================================================*/
/* Table: DETALLECARRITO                                        */
/*==============================================================*/
create table DETALLECARRITO (
   IDPRODUCTO           numeric              not null,
   IDCARRITO            numeric              not null,
   CANTIDADPROD         int                  not null,
   PRECIO               decimal(8,2)         not null,
   constraint PK_DETALLECARRITO primary key nonclustered (IDPRODUCTO, IDCARRITO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DETALLECARRITO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DETALLECARRITO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'detalleCarrito', 
   'user', @CurrentUser, 'table', 'DETALLECARRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DETALLECARRITO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDPRODUCTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'IDPRODUCTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idProducto',
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'IDPRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DETALLECARRITO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDCARRITO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'IDCARRITO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idCarrito',
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'IDCARRITO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DETALLECARRITO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CANTIDADPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'CANTIDADPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'cantidadProd',
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'CANTIDADPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DETALLECARRITO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PRECIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'PRECIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'precio',
   'user', @CurrentUser, 'table', 'DETALLECARRITO', 'column', 'PRECIO'
go

/*==============================================================*/
/* Index: PROD_CARRITO1_FK                                      */
/*==============================================================*/
create index PROD_CARRITO1_FK on DETALLECARRITO (
IDPRODUCTO ASC
)
go

/*==============================================================*/
/* Index: PROD_CARRITO2_FK                                      */
/*==============================================================*/
create index PROD_CARRITO2_FK on DETALLECARRITO (
IDCARRITO ASC
)
go

/*==============================================================*/
/* Table: IMPUESTO                                              */
/*==============================================================*/
create table IMPUESTO (
   IDIMPUESTO           numeric              identity,
   NOMIMPUESTO          varchar(200)         not null,
   VALORIMPUESTO        decimal(3,2)         not null,
   constraint PK_IMPUESTO primary key nonclustered (IDIMPUESTO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('IMPUESTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'IMPUESTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'impuesto', 
   'user', @CurrentUser, 'table', 'IMPUESTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('IMPUESTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDIMPUESTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'IDIMPUESTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idImpuesto',
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'IDIMPUESTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('IMPUESTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMIMPUESTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'NOMIMPUESTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nomImpuesto',
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'NOMIMPUESTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('IMPUESTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VALORIMPUESTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'VALORIMPUESTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'valorImpuesto',
   'user', @CurrentUser, 'table', 'IMPUESTO', 'column', 'VALORIMPUESTO'
go

/*==============================================================*/
/* Table: IMPUESTO_SUBDEPARTAMENTO                              */
/*==============================================================*/
create table IMPUESTO_SUBDEPARTAMENTO (
   IDIMPUESTO           numeric              not null,
   IDSUBCATEGORIA       numeric              not null,
   constraint PK_IMPUESTO_SUBDEPARTAMENTO primary key nonclustered (IDIMPUESTO, IDSUBCATEGORIA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('IMPUESTO_SUBDEPARTAMENTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'impuesto_subdepartamento', 
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('IMPUESTO_SUBDEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDIMPUESTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO', 'column', 'IDIMPUESTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idImpuesto',
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO', 'column', 'IDIMPUESTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('IMPUESTO_SUBDEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDSUBCATEGORIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO', 'column', 'IDSUBCATEGORIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idSubcategoria',
   'user', @CurrentUser, 'table', 'IMPUESTO_SUBDEPARTAMENTO', 'column', 'IDSUBCATEGORIA'
go

/*==============================================================*/
/* Index: RELATIONSHIP_14_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_14_FK on IMPUESTO_SUBDEPARTAMENTO (
IDIMPUESTO ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_15_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_15_FK on IMPUESTO_SUBDEPARTAMENTO (
IDSUBCATEGORIA ASC
)
go

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   IDPRODUCTO           numeric              identity,
   IDSUBCATEGORIA       numeric              not null,
   NOMBREPROD           varchar(200)         not null,
   DESCPROD             varchar(500)         not null,
   PRECIOUNIT           decimal(7,2)         not null,
   IMAGENPROD           image                null,
   DISPONIBILIDAD       bit                  not null,
   constraint PK_PRODUCTO primary key nonclustered (IDPRODUCTO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PRODUCTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PRODUCTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Producto', 
   'user', @CurrentUser, 'table', 'PRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDPRODUCTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IDPRODUCTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idProducto',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IDPRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDSUBCATEGORIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IDSUBCATEGORIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idSubcategoria',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IDSUBCATEGORIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMBREPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'NOMBREPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nombreProd',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'NOMBREPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DESCPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'DESCPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'descProd',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'DESCPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PRECIOUNIT')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'PRECIOUNIT'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'precioUnit',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'PRECIOUNIT'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IMAGENPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IMAGENPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'imagenProd',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'IMAGENPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PRODUCTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DISPONIBILIDAD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'DISPONIBILIDAD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'disponibilidad',
   'user', @CurrentUser, 'table', 'PRODUCTO', 'column', 'DISPONIBILIDAD'
go

/*==============================================================*/
/* Index: RELATIONSHIP_11_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_11_FK on PRODUCTO (
IDSUBCATEGORIA ASC
)
go

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION (
   IDREGION             numeric              identity,
   NOMBREREGION         varchar(200)         not null,
   constraint PK_REGION primary key nonclustered (IDREGION)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('REGION') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'REGION' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Region', 
   'user', @CurrentUser, 'table', 'REGION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('REGION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDREGION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'REGION', 'column', 'IDREGION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idRegion',
   'user', @CurrentUser, 'table', 'REGION', 'column', 'IDREGION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('REGION')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMBREREGION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'REGION', 'column', 'NOMBREREGION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'NombreRegion',
   'user', @CurrentUser, 'table', 'REGION', 'column', 'NOMBREREGION'
go

/*==============================================================*/
/* Table: SUBDEPARTAMENTO                                       */
/*==============================================================*/
create table SUBDEPARTAMENTO (
   IDSUBCATEGORIA       numeric              identity,
   IDCATEGORIAPROD      numeric              not null,
   NOMSUBCATEGORIA      varchar(200)         not null,
   constraint PK_SUBDEPARTAMENTO primary key nonclustered (IDSUBCATEGORIA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SUBDEPARTAMENTO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'SubDepartamento', 
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SUBDEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDSUBCATEGORIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'IDSUBCATEGORIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idSubcategoria',
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'IDSUBCATEGORIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SUBDEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDCATEGORIAPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'IDCATEGORIAPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idCategoriaProd',
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'IDCATEGORIAPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SUBDEPARTAMENTO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMSUBCATEGORIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'NOMSUBCATEGORIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nomSubcategoria',
   'user', @CurrentUser, 'table', 'SUBDEPARTAMENTO', 'column', 'NOMSUBCATEGORIA'
go

/*==============================================================*/
/* Index: CONTIENE_FK                                           */
/*==============================================================*/
create index CONTIENE_FK on SUBDEPARTAMENTO (
IDCATEGORIAPROD ASC
)
go

/*==============================================================*/
/* Table: TAG                                                   */
/*==============================================================*/
create table TAG (
   IDTAGPROD            numeric              identity,
   NOMTAG               varchar(200)         not null,
   constraint PK_TAG primary key nonclustered (IDTAGPROD)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TAG') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TAG' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Tag', 
   'user', @CurrentUser, 'table', 'TAG'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAG')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDTAGPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAG', 'column', 'IDTAGPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idTagProd',
   'user', @CurrentUser, 'table', 'TAG', 'column', 'IDTAGPROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAG')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMTAG')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAG', 'column', 'NOMTAG'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nomTag',
   'user', @CurrentUser, 'table', 'TAG', 'column', 'NOMTAG'
go

/*==============================================================*/
/* Table: TAG_PROD                                              */
/*==============================================================*/
create table TAG_PROD (
   IDPRODUCTO           numeric              not null,
   IDTAGPROD            numeric              not null,
   constraint PK_TAG_PROD primary key nonclustered (IDPRODUCTO, IDTAGPROD)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TAG_PROD') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TAG_PROD' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'tag_prod', 
   'user', @CurrentUser, 'table', 'TAG_PROD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAG_PROD')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDPRODUCTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAG_PROD', 'column', 'IDPRODUCTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idProducto',
   'user', @CurrentUser, 'table', 'TAG_PROD', 'column', 'IDPRODUCTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TAG_PROD')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDTAGPROD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TAG_PROD', 'column', 'IDTAGPROD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idTagProd',
   'user', @CurrentUser, 'table', 'TAG_PROD', 'column', 'IDTAGPROD'
go

/*==============================================================*/
/* Index: TAG_PROD2_FK                                          */
/*==============================================================*/
create index TAG_PROD2_FK on TAG_PROD (
IDPRODUCTO ASC
)
go

/*==============================================================*/
/* Index: TAG_PROD1_FK                                          */
/*==============================================================*/
create index TAG_PROD1_FK on TAG_PROD (
IDTAGPROD ASC
)
go

/*==============================================================*/
/* Table: TARIFAENVIO                                           */
/*==============================================================*/
create table TARIFAENVIO (
   IDTARIFA             numeric              identity,
   IDREGION             numeric              not null,
   NOMBRETARIFA         varchar(150)         not null,
   VALORTARIFA          decimal(6,2)         not null,
   constraint PK_TARIFAENVIO primary key nonclustered (IDTARIFA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TARIFAENVIO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TARIFAENVIO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'tarifaEnvio', 
   'user', @CurrentUser, 'table', 'TARIFAENVIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TARIFAENVIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDTARIFA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'IDTARIFA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idTarifa',
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'IDTARIFA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TARIFAENVIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDREGION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'IDREGION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idRegion',
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'IDREGION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TARIFAENVIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOMBRETARIFA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'NOMBRETARIFA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'nombreTarifa',
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'NOMBRETARIFA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TARIFAENVIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'VALORTARIFA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'VALORTARIFA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'valorTarifa',
   'user', @CurrentUser, 'table', 'TARIFAENVIO', 'column', 'VALORTARIFA'
go

/*==============================================================*/
/* Index: RELATIONSHIP_12_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_12_FK on TARIFAENVIO (
IDREGION ASC
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   IDUSUARIO            numeric              identity,
   USERNAME             varchar(50)          not null,
   PRIMERNOMBRE         varchar(50)          not null,
   PRIMERAPELLIDO       varchar(50)          not null,
   DIRECCION            varchar(250)         not null,
   DIRECCION2           varchar(250)         null,
   CIUDAD               varchar(250)         not null,
   PROVINCIA            varchar(250)         not null,
   TELEFONO             varchar(25)          not null,
   CELULAR              varchar(25)          null,
   PAIS                 varchar(50)          not null,
   EMAIL                varchar(150)         not null,
   constraint PK_USUARIO primary key nonclustered (IDUSUARIO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('USUARIO') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'USUARIO' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'usuario', 
   'user', @CurrentUser, 'table', 'USUARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IDUSUARIO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'IDUSUARIO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'idUsuario',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'IDUSUARIO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'USERNAME')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'USERNAME'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'username',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'USERNAME'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PRIMERNOMBRE')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PRIMERNOMBRE'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'primerNombre',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PRIMERNOMBRE'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PRIMERAPELLIDO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PRIMERAPELLIDO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'primerApellido',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PRIMERAPELLIDO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DIRECCION')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'DIRECCION'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'direccion',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'DIRECCION'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DIRECCION2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'DIRECCION2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'direccion2',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'DIRECCION2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CIUDAD')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'CIUDAD'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ciudad',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'CIUDAD'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PROVINCIA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PROVINCIA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'provincia',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PROVINCIA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TELEFONO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'TELEFONO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'telefono',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'TELEFONO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CELULAR')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'CELULAR'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'celular',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'CELULAR'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PAIS')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PAIS'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'pais',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'PAIS'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EMAIL')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'EMAIL'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'email',
   'user', @CurrentUser, 'table', 'USUARIO', 'column', 'EMAIL'
go

alter table CANTIDADPRODUCTO
   add constraint FK_CANTIDAD_RELATIONS_PRODUCTO foreign key (IDPRODUCTO)
      references PRODUCTO (IDPRODUCTO)
go

alter table DETALLECARRITO
   add constraint FK_DETALLEC_PROD_CARR_PRODUCTO foreign key (IDPRODUCTO)
      references PRODUCTO (IDPRODUCTO)
go

alter table DETALLECARRITO
   add constraint FK_DETALLEC_PROD_CARR_CARRITOC foreign key (IDCARRITO)
      references CARRITOCOMPRA (IDCARRITO)
go

alter table IMPUESTO_SUBDEPARTAMENTO
   add constraint FK_IMPUESTO_RELATIONS_IMPUESTO foreign key (IDIMPUESTO)
      references IMPUESTO (IDIMPUESTO)
go

alter table IMPUESTO_SUBDEPARTAMENTO
   add constraint FK_IMPUESTO_RELATIONS_SUBDEPAR foreign key (IDSUBCATEGORIA)
      references SUBDEPARTAMENTO (IDSUBCATEGORIA)
go

alter table PRODUCTO
   add constraint FK_PRODUCTO_RELATIONS_SUBDEPAR foreign key (IDSUBCATEGORIA)
      references SUBDEPARTAMENTO (IDSUBCATEGORIA)
go

alter table SUBDEPARTAMENTO
   add constraint FK_SUBDEPAR_CONTIENE_DEPARTAM foreign key (IDCATEGORIAPROD)
      references DEPARTAMENTO (IDCATEGORIAPROD)
go

alter table TAG_PROD
   add constraint FK_TAG_PROD_TAG_PROD1_TAG foreign key (IDTAGPROD)
      references TAG (IDTAGPROD)
go

alter table TAG_PROD
   add constraint FK_TAG_PROD_TAG_PROD2_PRODUCTO foreign key (IDPRODUCTO)
      references PRODUCTO (IDPRODUCTO)
go

alter table TARIFAENVIO
   add constraint FK_TARIFAEN_RELATIONS_REGION foreign key (IDREGION)
      references REGION (IDREGION)
go

