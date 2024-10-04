
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2024 21:39:53
-- Generated from EDMX file: C:\Users\Tania Silva\Desktop\AppPlayaParadise\HotelPlayaParadise\Models\PlayaParadise.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelPlayaParadise];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Actividad__Emple__5BE2A6F2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actividades_Empleados] DROP CONSTRAINT [FK__Actividad__Emple__5BE2A6F2];
GO
IF OBJECT_ID(N'[dbo].[FK__Check_in___Clien__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Check_in_Out] DROP CONSTRAINT [FK__Check_in___Clien__5535A963];
GO
IF OBJECT_ID(N'[dbo].[FK__Check_in___Habit__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Check_in_Out] DROP CONSTRAINT [FK__Check_in___Habit__5629CD9C];
GO
IF OBJECT_ID(N'[dbo].[FK__Comentari__Clien__6B24EA82]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comentarios_Valoraciones_Clientes] DROP CONSTRAINT [FK__Comentari__Clien__6B24EA82];
GO
IF OBJECT_ID(N'[dbo].[FK__Compras_S__Reser__73BA3083]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras_Servicios_Adicionales] DROP CONSTRAINT [FK__Compras_S__Reser__73BA3083];
GO
IF OBJECT_ID(N'[dbo].[FK__Compras_S__Servi__74AE54BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras_Servicios_Adicionales] DROP CONSTRAINT [FK__Compras_S__Servi__74AE54BC];
GO
IF OBJECT_ID(N'[dbo].[FK__Facturas__Client__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facturas] DROP CONSTRAINT [FK__Facturas__Client__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__Registros__Clien__6477ECF3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Registros_Actividad_Cliente] DROP CONSTRAINT [FK__Registros__Clien__6477ECF3];
GO
IF OBJECT_ID(N'[dbo].[FK__Registros__Clien__778AC167]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Registros_Acceso_Hotel] DROP CONSTRAINT [FK__Registros__Clien__778AC167];
GO
IF OBJECT_ID(N'[dbo].[FK__Registros__Emple__68487DD7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Registros_Actividad_Intermediario] DROP CONSTRAINT [FK__Registros__Emple__68487DD7];
GO
IF OBJECT_ID(N'[dbo].[FK__Registros__Inter__6754599E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Registros_Actividad_Intermediario] DROP CONSTRAINT [FK__Registros__Inter__6754599E];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservaci__Clien__5EBF139D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservaciones] DROP CONSTRAINT [FK__Reservaci__Clien__5EBF139D];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservaci__Habit__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservaciones] DROP CONSTRAINT [FK__Reservaci__Habit__60A75C0F];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservaci__Inter__619B8048]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservaciones] DROP CONSTRAINT [FK__Reservaci__Inter__619B8048];
GO
IF OBJECT_ID(N'[dbo].[FK__Reservaci__Paque__5FB337D6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservaciones] DROP CONSTRAINT [FK__Reservaci__Paque__5FB337D6];
GO
IF OBJECT_ID(N'[dbo].[FK__Servicios__Clien__02084FDA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicios_Comida_Bebida] DROP CONSTRAINT [FK__Servicios__Clien__02084FDA];
GO
IF OBJECT_ID(N'[dbo].[FK__Servicios__Produ__02FC7413]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicios_Comida_Bebida] DROP CONSTRAINT [FK__Servicios__Produ__02FC7413];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Actividades_Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actividades_Empleados];
GO
IF OBJECT_ID(N'[dbo].[Check_in_Out]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Check_in_Out];
GO
IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Comentarios_Valoraciones_Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comentarios_Valoraciones_Clientes];
GO
IF OBJECT_ID(N'[dbo].[Compras_Servicios_Adicionales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compras_Servicios_Adicionales];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eventos];
GO
IF OBJECT_ID(N'[dbo].[Facturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facturas];
GO
IF OBJECT_ID(N'[dbo].[Habitaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Habitaciones];
GO
IF OBJECT_ID(N'[dbo].[Intermediarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Intermediarios];
GO
IF OBJECT_ID(N'[dbo].[Paquetes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paquetes];
GO
IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[Promociones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Promociones];
GO
IF OBJECT_ID(N'[dbo].[Registros_Acceso_Hotel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Registros_Acceso_Hotel];
GO
IF OBJECT_ID(N'[dbo].[Registros_Actividad_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Registros_Actividad_Cliente];
GO
IF OBJECT_ID(N'[dbo].[Registros_Actividad_Intermediario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Registros_Actividad_Intermediario];
GO
IF OBJECT_ID(N'[dbo].[Reservaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservaciones];
GO
IF OBJECT_ID(N'[dbo].[Servicios_Adicionales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios_Adicionales];
GO
IF OBJECT_ID(N'[dbo].[Servicios_Comida_Bebida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios_Comida_Bebida];
GO
IF OBJECT_ID(N'[dbo].[Transacciones_Financieras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transacciones_Financieras];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actividades_Empleados'
CREATE TABLE [dbo].[Actividades_Empleados] (
    [Actividad_ID] int  NOT NULL,
    [Empleado_ID] int  NULL,
    [Fecha_Hora_Actividad] datetime  NULL,
    [Tipo_Actividad] varchar(100)  NULL,
    [Rol] varchar(100)  NULL
);
GO

-- Creating table 'Check_in_Out'
CREATE TABLE [dbo].[Check_in_Out] (
    [Check_in_Out_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Habitacion_ID] int  NULL,
    [Fecha_Check_in] datetime  NULL,
    [Fecha_Check_out] datetime  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Cliente_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Apellido] varchar(100)  NULL,
    [Nacionalidad] varchar(100)  NULL,
    [Tipo_Cliente] varchar(100)  NULL,
    [Metodo_Reservacion] varchar(100)  NULL
);
GO

-- Creating table 'Comentarios_Valoraciones_Clientes'
CREATE TABLE [dbo].[Comentarios_Valoraciones_Clientes] (
    [Comentario_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Comentario] varchar(max)  NULL,
    [Valoracion] int  NULL
);
GO

-- Creating table 'Compras_Servicios_Adicionales'
CREATE TABLE [dbo].[Compras_Servicios_Adicionales] (
    [Compra_Servicio_ID] int  NOT NULL,
    [Reservacion_ID] int  NULL,
    [Servicio_ID] int  NULL,
    [Fecha_Hora] datetime  NULL,
    [Cantidad] int  NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [Empleado_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Apellido] varchar(100)  NULL,
    [Puesto] varchar(100)  NULL,
    [Area] varchar(100)  NULL
);
GO

-- Creating table 'Eventos'
CREATE TABLE [dbo].[Eventos] (
    [Evento_ID] int  NOT NULL,
    [Nombre_Evento] varchar(100)  NULL,
    [Fecha_Hora] datetime  NULL,
    [Descripcion] varchar(max)  NULL
);
GO

-- Creating table 'Facturas'
CREATE TABLE [dbo].[Facturas] (
    [Factura_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Fecha_Factura] datetime  NULL,
    [Total] decimal(10,2)  NULL
);
GO

-- Creating table 'Habitaciones'
CREATE TABLE [dbo].[Habitaciones] (
    [Habitacion_ID] int  NOT NULL,
    [Tipo_Habitacion] varchar(100)  NULL,
    [Capacidad] int  NULL,
    [Precio_Noche] decimal(10,2)  NULL,
    [Disponibilidad] varchar(100)  NULL
);
GO

-- Creating table 'Intermediarios'
CREATE TABLE [dbo].[Intermediarios] (
    [Intermediario_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Tipo_Intermediario] varchar(100)  NULL
);
GO

-- Creating table 'Paquetes'
CREATE TABLE [dbo].[Paquetes] (
    [Paquete_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Descripcion] varchar(max)  NULL,
    [Precio] decimal(10,2)  NULL
);
GO

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Producto_ID] int  NOT NULL
);
GO

-- Creating table 'Promociones'
CREATE TABLE [dbo].[Promociones] (
    [Promocion_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Descripcion] varchar(max)  NULL,
    [Fecha_Inicio] datetime  NULL,
    [Fecha_Fin] datetime  NULL,
    [Descuento] decimal(5,2)  NULL
);
GO

-- Creating table 'Registros_Acceso_Hotel'
CREATE TABLE [dbo].[Registros_Acceso_Hotel] (
    [Registro_Acceso_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Fecha_Hora_Acceso] datetime  NULL,
    [Tipo_Acceso] varchar(100)  NULL
);
GO

-- Creating table 'Registros_Actividad_Cliente'
CREATE TABLE [dbo].[Registros_Actividad_Cliente] (
    [Registro_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Fecha_Hora_Actividad] datetime  NULL,
    [Tipo_Actividad] varchar(100)  NULL
);
GO

-- Creating table 'Registros_Actividad_Intermediario'
CREATE TABLE [dbo].[Registros_Actividad_Intermediario] (
    [Registro_Intermediario_ID] int  NOT NULL,
    [Intermediario_ID] int  NULL,
    [Empleado_ID] int  NULL,
    [Rol] varchar(100)  NULL,
    [Fecha_Hora_Actividad] datetime  NULL,
    [Tipo_Actividad] varchar(100)  NULL
);
GO

-- Creating table 'Reservaciones'
CREATE TABLE [dbo].[Reservaciones] (
    [Reservacion_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Paquete_ID] int  NULL,
    [Habitacion_ID] int  NULL,
    [Intermediario_ID] int  NULL,
    [Fecha_Reservacion] datetime  NULL,
    [Metodo_Pago] varchar(100)  NULL
);
GO

-- Creating table 'Servicios_Adicionales'
CREATE TABLE [dbo].[Servicios_Adicionales] (
    [Servicio_ID] int  NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Descripcion] varchar(max)  NULL,
    [Precio] decimal(10,2)  NULL
);
GO

-- Creating table 'Servicios_Comida_Bebida'
CREATE TABLE [dbo].[Servicios_Comida_Bebida] (
    [Servicio_Comida_Bebida_ID] int  NOT NULL,
    [Cliente_ID] int  NULL,
    [Fecha_Hora] datetime  NULL,
    [Producto_ID] int  NULL,
    [Cantidad] int  NULL
);
GO

-- Creating table 'Transacciones_Financieras'
CREATE TABLE [dbo].[Transacciones_Financieras] (
    [Transaccion_ID] int  NOT NULL,
    [Tipo_Transaccion] varchar(100)  NULL,
    [Monto] decimal(10,2)  NULL,
    [Fecha_Hora] datetime  NULL,
    [Metodo_Pago] varchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Actividad_ID] in table 'Actividades_Empleados'
ALTER TABLE [dbo].[Actividades_Empleados]
ADD CONSTRAINT [PK_Actividades_Empleados]
    PRIMARY KEY CLUSTERED ([Actividad_ID] ASC);
GO

-- Creating primary key on [Check_in_Out_ID] in table 'Check_in_Out'
ALTER TABLE [dbo].[Check_in_Out]
ADD CONSTRAINT [PK_Check_in_Out]
    PRIMARY KEY CLUSTERED ([Check_in_Out_ID] ASC);
GO

-- Creating primary key on [Cliente_ID] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Cliente_ID] ASC);
GO

-- Creating primary key on [Comentario_ID] in table 'Comentarios_Valoraciones_Clientes'
ALTER TABLE [dbo].[Comentarios_Valoraciones_Clientes]
ADD CONSTRAINT [PK_Comentarios_Valoraciones_Clientes]
    PRIMARY KEY CLUSTERED ([Comentario_ID] ASC);
GO

-- Creating primary key on [Compra_Servicio_ID] in table 'Compras_Servicios_Adicionales'
ALTER TABLE [dbo].[Compras_Servicios_Adicionales]
ADD CONSTRAINT [PK_Compras_Servicios_Adicionales]
    PRIMARY KEY CLUSTERED ([Compra_Servicio_ID] ASC);
GO

-- Creating primary key on [Empleado_ID] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([Empleado_ID] ASC);
GO

-- Creating primary key on [Evento_ID] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [PK_Eventos]
    PRIMARY KEY CLUSTERED ([Evento_ID] ASC);
GO

-- Creating primary key on [Factura_ID] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [PK_Facturas]
    PRIMARY KEY CLUSTERED ([Factura_ID] ASC);
GO

-- Creating primary key on [Habitacion_ID] in table 'Habitaciones'
ALTER TABLE [dbo].[Habitaciones]
ADD CONSTRAINT [PK_Habitaciones]
    PRIMARY KEY CLUSTERED ([Habitacion_ID] ASC);
GO

-- Creating primary key on [Intermediario_ID] in table 'Intermediarios'
ALTER TABLE [dbo].[Intermediarios]
ADD CONSTRAINT [PK_Intermediarios]
    PRIMARY KEY CLUSTERED ([Intermediario_ID] ASC);
GO

-- Creating primary key on [Paquete_ID] in table 'Paquetes'
ALTER TABLE [dbo].[Paquetes]
ADD CONSTRAINT [PK_Paquetes]
    PRIMARY KEY CLUSTERED ([Paquete_ID] ASC);
GO

-- Creating primary key on [Producto_ID] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Producto_ID] ASC);
GO

-- Creating primary key on [Promocion_ID] in table 'Promociones'
ALTER TABLE [dbo].[Promociones]
ADD CONSTRAINT [PK_Promociones]
    PRIMARY KEY CLUSTERED ([Promocion_ID] ASC);
GO

-- Creating primary key on [Registro_Acceso_ID] in table 'Registros_Acceso_Hotel'
ALTER TABLE [dbo].[Registros_Acceso_Hotel]
ADD CONSTRAINT [PK_Registros_Acceso_Hotel]
    PRIMARY KEY CLUSTERED ([Registro_Acceso_ID] ASC);
GO

-- Creating primary key on [Registro_ID] in table 'Registros_Actividad_Cliente'
ALTER TABLE [dbo].[Registros_Actividad_Cliente]
ADD CONSTRAINT [PK_Registros_Actividad_Cliente]
    PRIMARY KEY CLUSTERED ([Registro_ID] ASC);
GO

-- Creating primary key on [Registro_Intermediario_ID] in table 'Registros_Actividad_Intermediario'
ALTER TABLE [dbo].[Registros_Actividad_Intermediario]
ADD CONSTRAINT [PK_Registros_Actividad_Intermediario]
    PRIMARY KEY CLUSTERED ([Registro_Intermediario_ID] ASC);
GO

-- Creating primary key on [Reservacion_ID] in table 'Reservaciones'
ALTER TABLE [dbo].[Reservaciones]
ADD CONSTRAINT [PK_Reservaciones]
    PRIMARY KEY CLUSTERED ([Reservacion_ID] ASC);
GO

-- Creating primary key on [Servicio_ID] in table 'Servicios_Adicionales'
ALTER TABLE [dbo].[Servicios_Adicionales]
ADD CONSTRAINT [PK_Servicios_Adicionales]
    PRIMARY KEY CLUSTERED ([Servicio_ID] ASC);
GO

-- Creating primary key on [Servicio_Comida_Bebida_ID] in table 'Servicios_Comida_Bebida'
ALTER TABLE [dbo].[Servicios_Comida_Bebida]
ADD CONSTRAINT [PK_Servicios_Comida_Bebida]
    PRIMARY KEY CLUSTERED ([Servicio_Comida_Bebida_ID] ASC);
GO

-- Creating primary key on [Transaccion_ID] in table 'Transacciones_Financieras'
ALTER TABLE [dbo].[Transacciones_Financieras]
ADD CONSTRAINT [PK_Transacciones_Financieras]
    PRIMARY KEY CLUSTERED ([Transaccion_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Empleado_ID] in table 'Actividades_Empleados'
ALTER TABLE [dbo].[Actividades_Empleados]
ADD CONSTRAINT [FK__Actividad__Emple__5BE2A6F2]
    FOREIGN KEY ([Empleado_ID])
    REFERENCES [dbo].[Empleados]
        ([Empleado_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Actividad__Emple__5BE2A6F2'
CREATE INDEX [IX_FK__Actividad__Emple__5BE2A6F2]
ON [dbo].[Actividades_Empleados]
    ([Empleado_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Check_in_Out'
ALTER TABLE [dbo].[Check_in_Out]
ADD CONSTRAINT [FK__Check_in___Clien__5535A963]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Check_in___Clien__5535A963'
CREATE INDEX [IX_FK__Check_in___Clien__5535A963]
ON [dbo].[Check_in_Out]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Habitacion_ID] in table 'Check_in_Out'
ALTER TABLE [dbo].[Check_in_Out]
ADD CONSTRAINT [FK__Check_in___Habit__5629CD9C]
    FOREIGN KEY ([Habitacion_ID])
    REFERENCES [dbo].[Habitaciones]
        ([Habitacion_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Check_in___Habit__5629CD9C'
CREATE INDEX [IX_FK__Check_in___Habit__5629CD9C]
ON [dbo].[Check_in_Out]
    ([Habitacion_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Comentarios_Valoraciones_Clientes'
ALTER TABLE [dbo].[Comentarios_Valoraciones_Clientes]
ADD CONSTRAINT [FK__Comentari__Clien__6B24EA82]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Comentari__Clien__6B24EA82'
CREATE INDEX [IX_FK__Comentari__Clien__6B24EA82]
ON [dbo].[Comentarios_Valoraciones_Clientes]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [FK__Facturas__Client__59063A47]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Facturas__Client__59063A47'
CREATE INDEX [IX_FK__Facturas__Client__59063A47]
ON [dbo].[Facturas]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Registros_Actividad_Cliente'
ALTER TABLE [dbo].[Registros_Actividad_Cliente]
ADD CONSTRAINT [FK__Registros__Clien__6477ECF3]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Registros__Clien__6477ECF3'
CREATE INDEX [IX_FK__Registros__Clien__6477ECF3]
ON [dbo].[Registros_Actividad_Cliente]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Registros_Acceso_Hotel'
ALTER TABLE [dbo].[Registros_Acceso_Hotel]
ADD CONSTRAINT [FK__Registros__Clien__778AC167]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Registros__Clien__778AC167'
CREATE INDEX [IX_FK__Registros__Clien__778AC167]
ON [dbo].[Registros_Acceso_Hotel]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Reservaciones'
ALTER TABLE [dbo].[Reservaciones]
ADD CONSTRAINT [FK__Reservaci__Clien__5EBF139D]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservaci__Clien__5EBF139D'
CREATE INDEX [IX_FK__Reservaci__Clien__5EBF139D]
ON [dbo].[Reservaciones]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Cliente_ID] in table 'Servicios_Comida_Bebida'
ALTER TABLE [dbo].[Servicios_Comida_Bebida]
ADD CONSTRAINT [FK__Servicios__Clien__02084FDA]
    FOREIGN KEY ([Cliente_ID])
    REFERENCES [dbo].[Clientes]
        ([Cliente_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Servicios__Clien__02084FDA'
CREATE INDEX [IX_FK__Servicios__Clien__02084FDA]
ON [dbo].[Servicios_Comida_Bebida]
    ([Cliente_ID]);
GO

-- Creating foreign key on [Reservacion_ID] in table 'Compras_Servicios_Adicionales'
ALTER TABLE [dbo].[Compras_Servicios_Adicionales]
ADD CONSTRAINT [FK__Compras_S__Reser__73BA3083]
    FOREIGN KEY ([Reservacion_ID])
    REFERENCES [dbo].[Reservaciones]
        ([Reservacion_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Compras_S__Reser__73BA3083'
CREATE INDEX [IX_FK__Compras_S__Reser__73BA3083]
ON [dbo].[Compras_Servicios_Adicionales]
    ([Reservacion_ID]);
GO

-- Creating foreign key on [Servicio_ID] in table 'Compras_Servicios_Adicionales'
ALTER TABLE [dbo].[Compras_Servicios_Adicionales]
ADD CONSTRAINT [FK__Compras_S__Servi__74AE54BC]
    FOREIGN KEY ([Servicio_ID])
    REFERENCES [dbo].[Servicios_Adicionales]
        ([Servicio_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Compras_S__Servi__74AE54BC'
CREATE INDEX [IX_FK__Compras_S__Servi__74AE54BC]
ON [dbo].[Compras_Servicios_Adicionales]
    ([Servicio_ID]);
GO

-- Creating foreign key on [Empleado_ID] in table 'Registros_Actividad_Intermediario'
ALTER TABLE [dbo].[Registros_Actividad_Intermediario]
ADD CONSTRAINT [FK__Registros__Emple__68487DD7]
    FOREIGN KEY ([Empleado_ID])
    REFERENCES [dbo].[Empleados]
        ([Empleado_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Registros__Emple__68487DD7'
CREATE INDEX [IX_FK__Registros__Emple__68487DD7]
ON [dbo].[Registros_Actividad_Intermediario]
    ([Empleado_ID]);
GO

-- Creating foreign key on [Habitacion_ID] in table 'Reservaciones'
ALTER TABLE [dbo].[Reservaciones]
ADD CONSTRAINT [FK__Reservaci__Habit__60A75C0F]
    FOREIGN KEY ([Habitacion_ID])
    REFERENCES [dbo].[Habitaciones]
        ([Habitacion_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservaci__Habit__60A75C0F'
CREATE INDEX [IX_FK__Reservaci__Habit__60A75C0F]
ON [dbo].[Reservaciones]
    ([Habitacion_ID]);
GO

-- Creating foreign key on [Intermediario_ID] in table 'Registros_Actividad_Intermediario'
ALTER TABLE [dbo].[Registros_Actividad_Intermediario]
ADD CONSTRAINT [FK__Registros__Inter__6754599E]
    FOREIGN KEY ([Intermediario_ID])
    REFERENCES [dbo].[Intermediarios]
        ([Intermediario_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Registros__Inter__6754599E'
CREATE INDEX [IX_FK__Registros__Inter__6754599E]
ON [dbo].[Registros_Actividad_Intermediario]
    ([Intermediario_ID]);
GO

-- Creating foreign key on [Intermediario_ID] in table 'Reservaciones'
ALTER TABLE [dbo].[Reservaciones]
ADD CONSTRAINT [FK__Reservaci__Inter__619B8048]
    FOREIGN KEY ([Intermediario_ID])
    REFERENCES [dbo].[Intermediarios]
        ([Intermediario_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservaci__Inter__619B8048'
CREATE INDEX [IX_FK__Reservaci__Inter__619B8048]
ON [dbo].[Reservaciones]
    ([Intermediario_ID]);
GO

-- Creating foreign key on [Paquete_ID] in table 'Reservaciones'
ALTER TABLE [dbo].[Reservaciones]
ADD CONSTRAINT [FK__Reservaci__Paque__5FB337D6]
    FOREIGN KEY ([Paquete_ID])
    REFERENCES [dbo].[Paquetes]
        ([Paquete_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Reservaci__Paque__5FB337D6'
CREATE INDEX [IX_FK__Reservaci__Paque__5FB337D6]
ON [dbo].[Reservaciones]
    ([Paquete_ID]);
GO

-- Creating foreign key on [Producto_ID] in table 'Servicios_Comida_Bebida'
ALTER TABLE [dbo].[Servicios_Comida_Bebida]
ADD CONSTRAINT [FK__Servicios__Produ__02FC7413]
    FOREIGN KEY ([Producto_ID])
    REFERENCES [dbo].[Productos]
        ([Producto_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Servicios__Produ__02FC7413'
CREATE INDEX [IX_FK__Servicios__Produ__02FC7413]
ON [dbo].[Servicios_Comida_Bebida]
    ([Producto_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------