USE [restaurante]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[idArticulo] [int] NOT NULL,
	[descipcion] [varchar](100) NOT NULL,
	[precio] [numeric](18, 3) NOT NULL,
	[cantidad] [numeric](18, 3) NOT NULL,
	[sku] [varchar](13) NULL,
	[fechaIngreso] [datetime] NULL,
	[fechaCaducidad] [datetime] NULL,
	[idCategoria] [int] NOT NULL,
	[idUnidadMedida] [int] NOT NULL,
	[idProveedor] [int] NULL,
	[tarifaImpuesto] [numeric](3, 0) NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[idCaja] [int] NOT NULL,
	[fechaApertura] [datetime] NULL,
	[fechaCierre] [datetime] NULL,
	[fondo] [numeric](18, 3) NULL,
	[usuario] [varchar](20) NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[idCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CajaMovimiento]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CajaMovimiento](
	[idCaja] [int] NOT NULL,
	[secuencia] [int] NOT NULL,
	[idTipoMoviento] [int] NULL,
	[idTipoMedioPago] [int] NULL,
	[monto] [numeric](18, 3) NULL,
 CONSTRAINT [PK_CajaMovimiento] PRIMARY KEY CLUSTERED 
(
	[idCaja] ASC,
	[secuencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CajaTipoMoviento]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CajaTipoMoviento](
	[idCajaMovimiento] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CajaTipoMoviento] PRIMARY KEY CLUSTERED 
(
	[idCajaMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] NOT NULL,
	[descipcion] [varchar](50) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [varchar](12) NOT NULL,
	[nombreCompleto] [varchar](100) NOT NULL,
	[correoElectronico] [varchar](100) NULL,
	[telefonoCelular] [varchar](20) NULL,
	[telefonoResidencial] [varchar](20) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[idMesa] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[idEstado] [int] NULL,
	[capacidadPersona] [int] NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[idMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MesaEstado]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MesaEstado](
	[idMesaEstado] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MesaEstado] PRIMARY KEY CLUSTERED 
(
	[idMesaEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [int] NOT NULL,
	[idCliente] [varchar](12) NULL,
	[observacion] [varchar](100) NULL,
	[numeroFactura] [numeric](20, 0) NULL,
	[idMesa] [int] NULL,
	[idEstado] [int] NOT NULL,
	[idCaja] [int] NULL,
	[usuario] [varchar](20) NULL,
	[subTotal] [numeric](18, 3) NOT NULL,
	[descuento] [numeric](18, 3) NOT NULL,
	[impuesto] [numeric](18, 3) NOT NULL,
	[total] [numeric](18, 3) NOT NULL,
 CONSTRAINT [PK_pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoDetalle]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetalle](
	[idPedido] [int] NOT NULL,
	[idArticulo] [int] NOT NULL,
	[secuencia] [int] NOT NULL,
	[precioUnitario] [numeric](18, 3) NULL,
	[cantidad] [numeric](18, 3) NULL,
	[subTotal] [numeric](18, 3) NULL,
	[porcentajeDescuento] [numeric](18, 3) NULL,
	[impuesto] [numeric](18, 3) NULL,
	[total] [numeric](18, 3) NULL,
 CONSTRAINT [PK_PedidoDetalle] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC,
	[idArticulo] ASC,
	[secuencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoEstado]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoEstado](
	[idPedidoEstado] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_PedidoEstado] PRIMARY KEY CLUSTERED 
(
	[idPedidoEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[idUnidadMedida] [int] NOT NULL,
	[descipcion] [varchar](50) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[idUnidadMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario] [varchar](20) NOT NULL,
	[contrasena] [varchar](20) NOT NULL,
	[nombreCompleto] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioRol]    Script Date: 29/11/2020 11:11:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioRol](
	[idUsuario] [varchar](20) NOT NULL,
	[idRol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categoria] ([idCategoria], [descipcion], [activo]) VALUES (1, N'Plato', NULL)
GO
INSERT [dbo].[Categoria] ([idCategoria], [descipcion], [activo]) VALUES (2, N'Bebida', NULL)
GO
INSERT [dbo].[Mesa] ([idMesa], [descripcion], [idEstado], [capacidadPersona]) VALUES (1, N'Mesa Principal', 1, 8)
GO
INSERT [dbo].[MesaEstado] ([idMesaEstado], [descripcion]) VALUES (1, N'DISPONIBLE')
GO
INSERT [dbo].[MesaEstado] ([idMesaEstado], [descripcion]) VALUES (2, N'OCUPADA')
GO
INSERT [dbo].[MesaEstado] ([idMesaEstado], [descripcion]) VALUES (3, N'RESERVADA')
GO
INSERT [dbo].[UnidadMedida] ([idUnidadMedida], [descipcion], [activo]) VALUES (1, N'Unidad', NULL)
GO
INSERT [dbo].[UnidadMedida] ([idUnidadMedida], [descipcion], [activo]) VALUES (2, N'Servicio', NULL)
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Categoria]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_UnidadMedida] FOREIGN KEY([idUnidadMedida])
REFERENCES [dbo].[UnidadMedida] ([idUnidadMedida])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_UnidadMedida]
GO
ALTER TABLE [dbo].[CajaMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CajaMovimiento_Caja] FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([idCaja])
GO
ALTER TABLE [dbo].[CajaMovimiento] CHECK CONSTRAINT [FK_CajaMovimiento_Caja]
GO
ALTER TABLE [dbo].[CajaMovimiento]  WITH CHECK ADD  CONSTRAINT [FK_CajaMovimiento_CajaTipoMoviento] FOREIGN KEY([idTipoMoviento])
REFERENCES [dbo].[CajaTipoMoviento] ([idCajaMovimiento])
GO
ALTER TABLE [dbo].[CajaMovimiento] CHECK CONSTRAINT [FK_CajaMovimiento_CajaTipoMoviento]
GO
ALTER TABLE [dbo].[Mesa]  WITH CHECK ADD  CONSTRAINT [FK_Mesa_MesaEstado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[MesaEstado] ([idMesaEstado])
GO
ALTER TABLE [dbo].[Mesa] CHECK CONSTRAINT [FK_Mesa_MesaEstado]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Caja] FOREIGN KEY([idCaja])
REFERENCES [dbo].[Caja] ([idCaja])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Caja]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Mesa] FOREIGN KEY([idMesa])
REFERENCES [dbo].[Mesa] ([idMesa])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Mesa]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_PedidoEstado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[PedidoEstado] ([idPedidoEstado])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_PedidoEstado]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([usuario])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoDetalle_Articulo] FOREIGN KEY([idArticulo])
REFERENCES [dbo].[Articulo] ([idArticulo])
GO
ALTER TABLE [dbo].[PedidoDetalle] CHECK CONSTRAINT [FK_PedidoDetalle_Articulo]
GO
ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoDetalle_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[PedidoDetalle] CHECK CONSTRAINT [FK_PedidoDetalle_Pedido]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO
ALTER TABLE [dbo].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([usuario])
GO
ALTER TABLE [dbo].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO
