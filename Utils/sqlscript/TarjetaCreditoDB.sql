﻿CREATE DATABASE [TarjetaCreditoDBTest];
go
USE [TarjetaCreditoDBTest]
GO
/****** Object:  Table [dbo].[AuditoriaTransacciones]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaTransacciones](
	[AuditoriaID] [int] IDENTITY(1,1) NOT NULL,
	[TablaAfectada] [varchar](50) NULL,
	[Operacion] [varchar](10) NULL,
	[FechaOperacion] [datetime] NULL,
	[Usuario] [varchar](100) NULL,
	[DescripcionOperacion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuditoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[CompraID] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaID] [int] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Monto] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosCuenta]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosCuenta](
	[TarjetaID] [int] NOT NULL,
	[NombreTitular] [nvarchar](100) NULL,
	[NumeroTarjeta] [varchar](16) NULL,
	[SaldoUtilizado] [decimal](18, 2) NULL,
	[SaldoDisponible] [decimal](18, 2) NULL,
	[LimiteCredito] [decimal](18, 2) NULL,
	[ComprasMesActual] [decimal](18, 2) NULL,
	[ComprasMesAnterior] [decimal](18, 2) NULL,
	[InteresBonificable] [decimal](18, 2) NULL,
	[CuotaMinima] [decimal](18, 2) NULL,
	[MontoTotalPagar] [decimal](18, 2) NULL,
	[FechaGeneracion] [date] NULL,
	[IDEstadoCuenta] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_EstadosCuenta] PRIMARY KEY CLUSTERED 
(
	[IDEstadoCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosTarjeta]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosTarjeta](
	[EstadoID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[MovimientoID] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaID] [int] NOT NULL,
	[FechaMovimiento] [datetime] NOT NULL,
	[TipoMovimiento] [nvarchar](10) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Monto] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovimientoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[PagoID] [int] IDENTITY(1,1) NOT NULL,
	[TarjetaID] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjetas]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjetas](
	[TarjetaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[NumeroTarjeta] [varbinary](256) NOT NULL,
	[NombreTitular] [varchar](100) NOT NULL,
	[FechaEmision] [date] NOT NULL,
	[FechaExpiracion] [date] NOT NULL,
	[CVV] [varbinary](256) NOT NULL,
	[LimiteCredito] [decimal](12, 2) NOT NULL,
	[SaldoUtilizado] [decimal](12, 2) NULL,
	[SaldoDisponible]  AS ([LimiteCredito]-[SaldoUtilizado]),
	[EstadoID] [int] NOT NULL,
	[TipoTarjetaID] [int] NOT NULL,
	[PorcentajeInteres] [decimal](5, 2) NOT NULL,
	[PorcentajeSaldoMinimo] [decimal](5, 2) NOT NULL,
	[FechaUltimaActualizacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposTarjeta]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposTarjeta](
	[TipoTarjetaID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoTarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [varchar](100) NOT NULL,
	[SegundoNombre] [varchar](100) NOT NULL,
	[PrimerApellido] [varchar](100) NOT NULL,
	[SegundoApellido] [varchar](100) NOT NULL,
	[Dui] [varchar](9) NOT NULL,
	[CorreoElectronico] [varchar](255) NOT NULL,
	[Telefono] [varchar](15) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuditoriaTransacciones] ADD  DEFAULT (getdate()) FOR [FechaOperacion]
GO
ALTER TABLE [dbo].[Tarjetas] ADD  DEFAULT ((0.00)) FOR [SaldoUtilizado]
GO
ALTER TABLE [dbo].[Tarjetas] ADD  DEFAULT ((25.00)) FOR [PorcentajeInteres]
GO
ALTER TABLE [dbo].[Tarjetas] ADD  DEFAULT ((5.00)) FOR [PorcentajeSaldoMinimo]
GO
ALTER TABLE [dbo].[Tarjetas] ADD  DEFAULT (getdate()) FOR [FechaUltimaActualizacion]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([TarjetaID])
REFERENCES [dbo].[Tarjetas] ([TarjetaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD FOREIGN KEY([TarjetaID])
REFERENCES [dbo].[Tarjetas] ([TarjetaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD FOREIGN KEY([TarjetaID])
REFERENCES [dbo].[Tarjetas] ([TarjetaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD FOREIGN KEY([EstadoID])
REFERENCES [dbo].[EstadosTarjeta] ([EstadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD FOREIGN KEY([TipoTarjetaID])
REFERENCES [dbo].[TiposTarjeta] ([TipoTarjetaID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarjetas]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD CHECK  (([Descripcion]<>''))
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD CHECK  (([Monto]>=(0)))
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD CHECK  (([Descripcion]<>''))
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD CHECK  (([Monto]>=(0)))
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD CHECK  (([TipoMovimiento]='PAGO' OR [TipoMovimiento]='COMPRA'))
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD CHECK  (([Monto]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[CalcularCuotaMinima]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalcularCuotaMinima] @Tarjeta INT
AS
BEGIN
    DECLARE @SaldoTotal DECIMAL(10,2);
    DECLARE @Porcentaje DECIMAL(5,2);
    SELECT @SaldoTotal = SaldoUtilizado, @Porcentaje = PorcentajeSaldoMinimo
    FROM Tarjetas
    WHERE TarjetaID = @Tarjeta;

    SELECT @SaldoTotal * (@Porcentaje / 100) AS CuotaMinima;
END
GO
/****** Object:  StoredProcedure [dbo].[CalcularMontoContadoConIntereses]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalcularMontoContadoConIntereses] @Tarjeta INT
AS
BEGIN
    DECLARE @SaldoTotal DECIMAL(10,2);
    DECLARE @InteresBonificable DECIMAL(10,2);
    DECLARE @PorcentajeInteres DECIMAL(5,2);

    SELECT @SaldoTotal = SaldoUtilizado, @PorcentajeInteres = PorcentajeInteres
    FROM Tarjetas
    WHERE TarjetaID = @Tarjeta;

    SET @InteresBonificable = @SaldoTotal * (@PorcentajeInteres / 100);

    SELECT @SaldoTotal + @InteresBonificable AS MontoContadoConIntereses;
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTransaccionesPorMes]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTransaccionesPorMes] @Tarjeta INT, @Mes INT, @Anio INT
AS
BEGIN
    SELECT FechaMovimiento, TipoMovimiento, Descripcion, Monto
    FROM Movimientos
    WHERE TarjetaID = @Tarjeta AND MONTH(FechaMovimiento) = @Mes AND YEAR(FechaMovimiento) = @Anio
    ORDER BY FechaMovimiento DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[DetalleMovimientos]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Detalle de movimientos
CREATE PROCEDURE [dbo].[DetalleMovimientos] @Tarjeta INT
AS
BEGIN
    SELECT 
        FechaMovimiento, 
        TipoMovimiento, 
        Descripcion, 
        Monto
    FROM Movimientos
    WHERE TarjetaID = @Tarjeta
    ORDER BY FechaMovimiento DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[EstadoCuenta]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EstadoCuenta]
    @TarjetaID INT
AS
BEGIN
    BEGIN TRY
        -- Abrir la clave simétrica para descifrar los datos
        OPEN SYMMETRIC KEY ClaveSimetricaTarjetas
        DECRYPTION BY CERTIFICATE CertificadoTarjetas;

        -- Variables para almacenar los cálculos
        DECLARE @NombreTitular NVARCHAR(100),
                @NumeroTarjeta NVARCHAR(16),
                @SaldoUtilizado DECIMAL(12, 2),
                @SaldoDisponible DECIMAL(12, 2),
                @LimiteCredito DECIMAL(12, 2),
                @ComprasMesActual DECIMAL(12, 2),
                @ComprasMesAnterior DECIMAL(12, 2),
                @InteresBonificable DECIMAL(12, 2),
                @CuotaMinimaPagar DECIMAL(12, 2),
                @MontoTotalPagar DECIMAL(12, 2),
                @IDEstadoCuenta INT;

        -- Consultar y descifrar los datos del encabezado del estado de cuenta
        SELECT 
            @NombreTitular = t.NombreTitular,
            @NumeroTarjeta = CONVERT(NVARCHAR(16), DECRYPTBYKEY(t.NumeroTarjeta)),
            @SaldoUtilizado = t.SaldoUtilizado,
            @SaldoDisponible = t.SaldoDisponible,
            @LimiteCredito = t.LimiteCredito,
            @ComprasMesActual = (SELECT ISNULL(SUM(c.Monto), 0)
                                 FROM Compras c
                                 WHERE c.TarjetaID = @TarjetaID 
                                   AND YEAR(c.FechaCompra) = YEAR(GETDATE())
                                   AND MONTH(c.FechaCompra) = MONTH(GETDATE())),
            @ComprasMesAnterior = (SELECT ISNULL(SUM(c.Monto), 0)
                                   FROM Compras c
                                   WHERE c.TarjetaID = @TarjetaID 
                                     AND YEAR(c.FechaCompra) = YEAR(DATEADD(MONTH, -1, GETDATE()))
                                     AND MONTH(c.FechaCompra) = MONTH(DATEADD(MONTH, -1, GETDATE()))),
            @InteresBonificable = (t.SaldoUtilizado * t.PorcentajeInteres / 100),
            @CuotaMinimaPagar = (t.SaldoUtilizado * t.PorcentajeSaldoMinimo / 100),
            @MontoTotalPagar = (t.SaldoUtilizado + 
                                (SELECT ISNULL(SUM(c.Monto), 0)
                                 FROM Compras c
                                 WHERE c.TarjetaID = @TarjetaID))
        FROM 
            Tarjetas t
        WHERE 
            t.TarjetaID = @TarjetaID;

        -- Insertar los datos en la tabla EstadosCuenta (sin incluir IDEstadoCuenta)
        INSERT INTO EstadosCuenta (
            TarjetaID,
            NombreTitular,
            NumeroTarjeta,
            SaldoUtilizado,
            SaldoDisponible,
            LimiteCredito,
            ComprasMesActual,
            ComprasMesAnterior,
            InteresBonificable,
            CuotaMinima,
            MontoTotalPagar,
            FechaGeneracion
        )
        VALUES (
            @TarjetaID,
            @NombreTitular,
            @NumeroTarjeta,
            @SaldoUtilizado,
            @SaldoDisponible,
            @LimiteCredito,
            @ComprasMesActual,
            @ComprasMesAnterior,
            @InteresBonificable,
            @CuotaMinimaPagar,
            @MontoTotalPagar,
            GETDATE()
        );

        -- Obtener el ID del estado de cuenta recién generado
        SET @IDEstadoCuenta = SCOPE_IDENTITY();

        -- Devolver los datos junto con el ID del estado de cuenta
        SELECT 
            @IDEstadoCuenta AS IDEstadoCuenta,
            @NombreTitular AS NombreTitular,
            @NumeroTarjeta AS NumeroTarjeta,
            @SaldoUtilizado AS SaldoUtilizado,
            @SaldoDisponible AS SaldoDisponible,
            @LimiteCredito AS LimiteCredito,
            @ComprasMesActual AS TotalComprasMesActual,
            @ComprasMesAnterior AS TotalComprasMesAnterior,
            @InteresBonificable AS InteresBonificable,
            @CuotaMinimaPagar AS CuotaMinima,
            @MontoTotalPagar AS MontoTotalPagar;

        -- Cerrar la clave simétrica
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas;

    END TRY
    BEGIN CATCH
        -- Manejo de errores
        IF EXISTS (SELECT * FROM sys.symmetric_keys WHERE name = 'ClaveSimetricaTarjetas')
        BEGIN
            CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas; -- Asegurarse de cerrar la clave
        END;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarTarjetaCredito]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarTarjetaCredito]
    @UsuarioID INT,
    @NumeroTarjeta NVARCHAR(16),
    @NombreTitular NVARCHAR(100),
    @FechaEmision DATE,
    @FechaExpiracion DATE,
    @CVV NVARCHAR(3),
    @LimiteCredito DECIMAL(12,2),
    @EstadoID INT,
    @TipoTarjetaID INT
AS
BEGIN
    BEGIN TRY
        -- Abrir la clave simétrica
        OPEN SYMMETRIC KEY ClaveSimetricaTarjetas
        DECRYPTION BY CERTIFICATE CertificadoTarjetas;

        -- Insertar los datos cifrados
        INSERT INTO Tarjetas (
            UsuarioID,
            NumeroTarjeta,
            NombreTitular,
            FechaEmision,
            FechaExpiracion,
            CVV,
            LimiteCredito,
            EstadoID,
            TipoTarjetaID
        )
        VALUES (
            @UsuarioID,
            ENCRYPTBYKEY(KEY_GUID('ClaveSimetricaTarjetas'), CAST(@NumeroTarjeta AS NVARCHAR(16))),
            @NombreTitular,
            @FechaEmision,
            @FechaExpiracion,
            ENCRYPTBYKEY(KEY_GUID('ClaveSimetricaTarjetas'), CAST(@CVV AS NVARCHAR(16))),
            @LimiteCredito,
            @EstadoID,
            @TipoTarjetaID
        );

        -- Cerrar la clave simétrica
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas;

    END TRY
    BEGIN CATCH
        -- Manejo de errores
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas; -- Asegurarse de cerrar la clave
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[MostrarSaldo]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MostrarSaldo] @Tarjeta INT
AS
BEGIN
    SELECT LimiteCredito,SaldoUtilizado, (LimiteCredito - SaldoUtilizado) AS SaldoDisponible
    FROM Tarjetas
    WHERE TarjetaID = @Tarjeta;
END
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComprasMesActual]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarComprasMesActual]
    @TarjetaID INT
AS
BEGIN
    BEGIN TRY
        -- Consultar la lista de compras realizadas este mes
        SELECT 
			c.CompraID,
			c.TarjetaID,
            c.FechaCompra,
            c.Descripcion,
            c.Monto
        FROM 
            Compras c
        WHERE 
            c.TarjetaID = @TarjetaID
            AND YEAR(c.FechaCompra) = YEAR(GETDATE())
            AND MONTH(c.FechaCompra) = MONTH(GETDATE());
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[RecuperarTarjetaCredito]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarTarjetaCredito]
    @TarjetaID INT
AS
BEGIN
    BEGIN TRY
        -- Abrir la clave simétrica
        OPEN SYMMETRIC KEY ClaveSimetricaTarjetas
        DECRYPTION BY CERTIFICATE CertificadoTarjetas;

        -- Consultar y descifrar los datos
       select t.TarjetaID,
			  CONVERT(NVARCHAR(16), DECRYPTBYKEY(t.NumeroTarjeta)) AS NumeroTarjeta,
	       		  CONVERT(NVARCHAR(3), DECRYPTBYKEY(t.CVV)) AS CVV,
			  t.NombreTitular, 
			  t.FechaEmision,
			  t.FechaExpiracion,
			  t.LimiteCredito,
			  t.SaldoUtilizado,
			  t.SaldoDisponible,
			  t.PorcentajeInteres,
			  t.PorcentajeSaldoMinimo,
			  e.Descripcion,
			  concat(u.PrimerNombre, u.PrimerApellido) as NombreUsuario
			  from Tarjetas t join Usuarios u on u.UsuarioID=t.UsuarioID
              join EstadosTarjeta e on e.EstadoID=t.EstadoID
			  where t.TarjetaID = @TarjetaID;

        -- Cerrar la clave simétrica
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas;

    END TRY
    BEGIN CATCH
        -- Manejo de errores
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas; -- Asegurarse de cerrar la clave
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[RecuperarTarjetasActivas]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarTarjetasActivas]
AS
BEGIN
    BEGIN TRY
        -- Abrir la clave simétrica
        OPEN SYMMETRIC KEY ClaveSimetricaTarjetas
        DECRYPTION BY CERTIFICATE CertificadoTarjetas;

        -- Consultar y descifrar los datos para todas las tarjetas con EstadoID = 1
        SELECT 
            t.TarjetaID,
            CONVERT(NVARCHAR(16), DECRYPTBYKEY(t.NumeroTarjeta)) AS NumeroTarjeta,
            CONVERT(NVARCHAR(3), DECRYPTBYKEY(t.CVV)) AS CVV,
            t.NombreTitular, 
            t.FechaEmision,
            t.FechaExpiracion,
            t.LimiteCredito,
            t.SaldoUtilizado,
            t.SaldoDisponible,
            t.PorcentajeInteres,
            t.PorcentajeSaldoMinimo,
            --e.Descripcion AS EstadoDescripcion,
            CONCAT(u.PrimerNombre, ' ', u.PrimerApellido) AS NombreUsuario
        FROM 
            Tarjetas t
        INNER JOIN 
            Usuarios u ON u.UsuarioID = t.UsuarioID
        INNER JOIN 
            EstadosTarjeta e ON e.EstadoID = t.EstadoID
        WHERE 
            t.EstadoID = 1; -- Filtrar tarjetas con EstadoID = 1

        -- Cerrar la clave simétrica
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas;

    END TRY
    BEGIN CATCH
        -- Manejo de errores
        IF EXISTS (SELECT * FROM sys.symmetric_keys WHERE name = 'ClaveSimetricaTarjetas')
        BEGIN
            CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas; -- Asegurarse de cerrar la clave
        END;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCompra]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para registrar una compra
CREATE PROCEDURE [dbo].[RegistrarCompra]
    @TarjetaID INT,
    @FechaCompra DATETIME,
    @Descripcion VARCHAR(255),
    @Monto DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Validaciones
        IF @Monto <= 0
            THROW 50001, 'El monto de la compra debe ser mayor a cero.', 1;

        IF LEN(@Descripcion) = 0
            THROW 50002, 'La descripción de la compra no puede estar vacía.', 1;

        -- Inserción de la compra
        INSERT INTO Compras (TarjetaID, FechaCompra, Descripcion, Monto)
        VALUES (@TarjetaID, @FechaCompra, @Descripcion, @Monto);

       
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        DECLARE @ErrorMsg NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMsg, @ErrorSeverity, @ErrorState);
    END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[RegistrarPago]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para registrar un pago
CREATE PROCEDURE [dbo].[RegistrarPago]
    @TarjetaID INT,
    @FechaPago DATETIME,
    @Monto DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        -- Validaciones
        IF @Monto <= 0
            THROW 50001, 'El monto del pago debe ser mayor a cero.', 1;

        -- Inserción del pago
        INSERT INTO Pagos (TarjetaID, FechaPago, Monto)
        VALUES (@TarjetaID, @FechaPago, @Monto);

        
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        DECLARE @ErrorMsg NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT @ErrorMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMsg, @ErrorSeverity, @ErrorState);
    END CATCH
END

GO
/****** Object:  Trigger [dbo].[ActualizarSaldoCompra]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizarSaldoCompra]
ON [dbo].[Compras]
AFTER INSERT
AS
BEGIN
    UPDATE Tarjetas
    SET SaldoUtilizado = SaldoUtilizado + inserted.Monto
    FROM Tarjetas
    INNER JOIN inserted ON Tarjetas.TarjetaID = inserted.TarjetaID;
END
GO
ALTER TABLE [dbo].[Compras] ENABLE TRIGGER [ActualizarSaldoCompra]
GO
/****** Object:  Trigger [dbo].[InsertarMovimientoCompra]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertarMovimientoCompra]
ON [dbo].[Compras]
AFTER INSERT
AS
BEGIN
    INSERT INTO Movimientos (TarjetaID, FechaMovimiento, TipoMovimiento, Descripcion, Monto)
    SELECT TarjetaID, FechaCompra, 'COMPRA', Descripcion, Monto
    FROM inserted;
END
GO
ALTER TABLE [dbo].[Compras] ENABLE TRIGGER [InsertarMovimientoCompra]
GO
/****** Object:  Trigger [dbo].[AuditoriaMovimientos]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Trigger de auditoría para la tabla Movimientos
CREATE TRIGGER [dbo].[AuditoriaMovimientos]
ON [dbo].[Movimientos]
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    DECLARE @Operacion VARCHAR(10);
    SET @Operacion = (CASE WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
                           WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
                           WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE' END);

    INSERT INTO AuditoriaTransacciones (TablaAfectada, Operacion, Usuario, DescripcionOperacion)
    SELECT 'Movimientos', @Operacion, SYSTEM_USER, 'Cambio en la tabla Movimientos';
END
GO
ALTER TABLE [dbo].[Movimientos] ENABLE TRIGGER [AuditoriaMovimientos]
GO
/****** Object:  Trigger [dbo].[ActualizarSaldoPago]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Trigger para actualizar saldo al registrar un pago
CREATE TRIGGER [dbo].[ActualizarSaldoPago]
ON [dbo].[Pagos]
AFTER INSERT
AS
BEGIN
    UPDATE Tarjetas
    SET SaldoUtilizado = SaldoUtilizado - inserted.Monto
    FROM Tarjetas
    INNER JOIN inserted ON Tarjetas.TarjetaID = inserted.TarjetaID;
END
GO
ALTER TABLE [dbo].[Pagos] ENABLE TRIGGER [ActualizarSaldoPago]
GO
/****** Object:  Trigger [dbo].[InsertarMovimientoPago]    Script Date: 31/12/2024 00:14:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertarMovimientoPago]
ON [dbo].[Pagos]
AFTER INSERT
AS
BEGIN
    INSERT INTO Movimientos (TarjetaID, FechaMovimiento, TipoMovimiento, Descripcion, Monto)
    SELECT TarjetaID, FechaPago, 'PAGO', 'Pago realizado', Monto
    FROM inserted;
END
GO
ALTER TABLE [dbo].[Pagos] ENABLE TRIGGER [InsertarMovimientoPago]
GO

-- Crear clave maestra
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'ContraseñaSegura123!';
GO

-- Crear un certificado
CREATE CERTIFICATE CertificadoTarjetas
WITH SUBJECT = 'Cifrado de datos sensibles';
GO

-- Crear una clave simétrica
CREATE SYMMETRIC KEY ClaveSimetricaTarjetas
WITH ALGORITHM = AES_256
ENCRYPTION BY CERTIFICATE CertificadoTarjetas;
GO

-- Insertar estados iniciales
INSERT INTO EstadosTarjeta (Descripcion) 
VALUES ('ACTIVA'), ('BLOQUEADA'), ('CANCELADA');

-- Insertar tipos de tarjeta iniciales
INSERT INTO TiposTarjeta (Descripcion)
VALUES ('DÉBITO'), ('CRÉDITO'), ('PREPAGO');

-- Insertar usuario inicial
INSERT INTO [dbo].[Usuarios]
           ([PrimerNombre]
           ,[SegundoNombre]
           ,[PrimerApellido]
           ,[SegundoApellido]
           ,[Dui]
           ,[CorreoElectronico]
           ,[Telefono]
           )
     VALUES
           ('Denis'
           ,'Raul'
           ,'Arana'
           ,'Valladares'
           ,'020304056'
           ,'drarana@gmail.es'
           ,'70001010'
           );

go
 -- Abrir la clave simétrica
        OPEN SYMMETRIC KEY ClaveSimetricaTarjetas
        DECRYPTION BY CERTIFICATE CertificadoTarjetas;

        -- Insertar los datos cifrados
        INSERT INTO Tarjetas (
            UsuarioID,
            NumeroTarjeta,
            NombreTitular,
            FechaEmision,
            FechaExpiracion,
            CVV,
            LimiteCredito,
            EstadoID,
            TipoTarjetaID
        )
        VALUES (
            1,
            ENCRYPTBYKEY(KEY_GUID('ClaveSimetricaTarjetas'), '0001000200030004'),
            'Denis Arana',
            '2024-12-30',
            '2027-12-30',
            ENCRYPTBYKEY(KEY_GUID('ClaveSimetricaTarjetas'), '123'),
            114.47,
            1,
            2
        );

        -- Cerrar la clave simétrica
        CLOSE SYMMETRIC KEY ClaveSimetricaTarjetas;
