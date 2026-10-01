/*CREATE DATABASE BityLab;
GO

USE BityLab;
GO

-- =============================================
-- 1. TABLAS INDEPENDIENTES
-- =============================================

CREATE TABLE ROLES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    descripcion NVARCHAR(255),
    salarioEstimado DECIMAL(10, 2)
);
GO

CREATE TABLE MARCAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    sitioWeb NVARCHAR(100),
    correoSoporte NVARCHAR(100),
    telefonoContacto NVARCHAR(20)
);
GO

CREATE TABLE PROVEEDORES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombreEmpresa NVARCHAR(100),
    nitEmpresa NVARCHAR(20),
    nombreContacto NVARCHAR(100),
    telefonoPrincipal NVARCHAR(20),
    correoVentas NVARCHAR(100),
    direccionFisica NVARCHAR(150)
);
GO

CREATE TABLE METODOS_PAGO (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    descripcion NVARCHAR(255)
);
GO

CREATE TABLE PROMOCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    codigoCupon NVARCHAR(50),
    descripcion NVARCHAR(255),
    porcentajeDescuento DECIMAL(5, 2),
    fechaInicio DATETIME,
    fechaFin DATETIME
);
GO

CREATE TABLE SUCURSALES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100),
    direccion NVARCHAR(150),
    ciudad NVARCHAR(50),
    telefonoContacto NVARCHAR(20),
    horarioAtencion NVARCHAR(100)
);
GO

CREATE TABLE EmpresaPaqueteria (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    telefono NVARCHAR(20),
    correoElectronico NVARCHAR(100),
    NIT NVARCHAR(20),
    nombrePaqueteria NVARCHAR(100)
);
GO

-- =============================================
-- 2. TABLAS CON DEPENDENCIAS
-- =============================================

CREATE TABLE USUARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES ROLES(id),
    nombreCompletoU NVARCHAR(100),
    cedula NVARCHAR(20),
    correo NVARCHAR(100),
    contrasena NVARCHAR(100),
    fechaRegistro DATETIME
);
GO

CREATE TABLE EMPLEADOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT REFERENCES USUARIOS(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    cargoPuesto NVARCHAR(50),
    salario DECIMAL(10, 2),
    fechaContratacion DATE
);
GO

CREATE TABLE CLIENTES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT REFERENCES USUARIOS(id),
    nombreCompletoC NVARCHAR(100),
    telefono NVARCHAR(20),
    direccionPrincipal NVARCHAR(150),
    fechaNacimiento DATE
);
GO

CREATE TABLE PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    categoria INT,
    id_marca INT REFERENCES MARCAS(id),
    nombreProducto NVARCHAR(100),
    descripcionLarga NVARCHAR(200),
    precioVenta DECIMAL(10, 2),
    numeroSerie NVARCHAR(50),
    modelo NVARCHAR(50),
    especificacionesTecnicas NVARCHAR(MAX)
);
GO

CREATE TABLE INVENTARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT REFERENCES PRODUCTOS(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    cantidadDisponible INT,
    stockMinimo INT,
    estanteriaUbicacion NVARCHAR(50),
    ultimaActualizacion DATETIME,
    capacidadBodega INT
);
GO

CREATE TABLE COMPRAS_PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT REFERENCES PROVEEDORES(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    fechaOrden DATETIME,
    estadoOrden NVARCHAR(50),
    totalEstimado DECIMAL(10, 2),
    notasInternas NVARCHAR(200)
);
GO

CREATE TABLE DETALLES_ORDENES_COMPRAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_compras_producto INT REFERENCES COMPRAS_PRODUCTOS(id),
    id_producto INT REFERENCES PRODUCTOS(id),
    cantidadSolicitada INT,
    costoUnitario DECIMAL(10, 2),
    subtotalCosto DECIMAL(10, 2)
);
GO

CREATE TABLE VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_cliente INT REFERENCES CLIENTES(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    id_promocion INT REFERENCES PROMOCIONES(id),
    fechaVenta DATETIME,
    estadoVenta NVARCHAR(50),
    totalPagar DECIMAL(10, 2),
    direccionEnvio NVARCHAR(150)
);
GO

CREATE TABLE DETALLE_VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_producto INT REFERENCES PRODUCTOS(id),
    cantidad INT,
    precioUnitarioVenta DECIMAL(10, 2),
    descuentoAplicado DECIMAL(10, 2),
    subtotal DECIMAL(10, 2)
);
GO

CREATE TABLE PAGOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_metodo_pago INT REFERENCES METODOS_PAGO(id),
    montoPagado DECIMAL(10, 2),
    fechaPago DATETIME,
    estadoTransaccion NVARCHAR(50),
    referenciaPasarela NVARCHAR(100)
);
GO

CREATE TABLE ENVIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_empresa_paqueteria INT REFERENCES EmpresaPaqueteria(id),
    numeroGuia NVARCHAR(50),
    estado NVARCHAR(50),
    fechaEstimadaEntrega DATE,
    fechaEntregaReal DATE,
    costo DECIMAL(10, 2)
);
GO

CREATE TABLE GARANTIAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_detalle_venta INT REFERENCES DETALLE_VENTAS(id),
    fechaSolicitud DATE,
    motivoFalla NVARCHAR(255),
    estado NVARCHAR(50),
    resolucionTecnica NVARCHAR(255),
    fechaCierre DATE
);
GO

CREATE TABLE DEVOLUCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_metodo_pago_reembolso INT REFERENCES METODOS_PAGO(id),
    fechaSolicitud DATE,
    motivo NVARCHAR(255),
    estadoProceso NVARCHAR(50),
    montoReembolsado DECIMAL(10, 2)
);
GO

CREATE TABLE RESENAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT REFERENCES PRODUCTOS(id),
    id_cliente INT REFERENCES CLIENTES(id),
    calificacionEstrellas INT,
    comentario NVARCHAR(200),
    fechaPublicacion DATETIME
);
GO

-- =============================================
-- 3. INSERCIÓN DE DATOS
-- =============================================

-- 1. ROLES
INSERT INTO ROLES (nombre, descripcion, salarioEstimado)
VALUES ('Administrador', 'Control total del sistema y gestión de usuarios', 4500000.00);
GO

-- 2. MARCAS
INSERT INTO MARCAS (nombre, sitioWeb, correoSoporte, telefonoContacto)
VALUES ('Logitech', 'https://www.logitech.com', 'soporte@logitech.com', '+18005550199');
GO

-- 3. PROVEEDORES
INSERT INTO PROVEEDORES (nombreEmpresa, nitEmpresa, nombreContacto, telefonoPrincipal, correoVentas, direccionFisica)
VALUES ('Tech Supply S.A.S.', '900123456-1', 'Carlos Gómez', '6015551234', 'ventas@techsupply.com', 'Calle 100 # 15-20, Bogotá');
GO

-- 4. METODOS_PAGO
INSERT INTO METODOS_PAGO (nombre, descripcion)
VALUES ('Tarjeta de Crédito', 'Pago mediante pasarela electrónica Visa/Mastercard');
GO

-- 5. PROMOCIONES
INSERT INTO PROMOCIONES (codigoCupon, descripcion, porcentajeDescuento, fechaInicio, fechaFin)
VALUES ('LANZAMIENTO2026', 'Descuento de bienvenida por apertura', 15.00, '2026-01-01 00:00:00', '2026-12-31 23:59:59');
GO

-- 6. SUCURSALES
INSERT INTO SUCURSALES (nombre, direccion, ciudad, telefonoContacto, horarioAtencion)
VALUES ('Sucursal Principal Bello', 'Carrera 50 # 38-10', 'Bello', '6044445566', 'Lunes a Sábado 8:00 AM - 7:00 PM');
GO

-- 7. EmpresaPaqueteria
INSERT INTO EmpresaPaqueteria (telefono, correoElectronico, NIT, nombrePaqueteria)
VALUES ('018000911000', 'servicio@servientrega.com', '860012345-8', 'Servientrega');
GO

-- 8. USUARIOS
INSERT INTO USUARIOS (id_rol, nombreCompletoU, cedula, correo, contrasena, fechaRegistro)
VALUES (1, 'Juan David Cano', '1017123456', 'juan.david.cano@example.com', 'password123', GETDATE());
GO

-- 9. PRODUCTOS
INSERT INTO PRODUCTOS (categoria, id_marca, nombreProducto, descripcionLarga, precioVenta, numeroSerie, modelo, especificacionesTecnicas)
VALUES (1, 1, 'Mouse Gamer G502', 'Mouse óptico de alta precisión para gaming', 250000.00, 'SN-LOG-98765', 'G502 HERO', 'Sensor HERO 25K, 11 botones programables, RGB');
GO

-- 10. COMPRAS_PRODUCTOS
INSERT INTO COMPRAS_PRODUCTOS (id_proveedor, id_sucursal, fechaOrden, estadoOrden, totalEstimado, notasInternas)
VALUES (1, 1, GETDATE(), 'Completada', 2000000.00, 'Orden inicial de reabastecimiento');
GO

-- 11. EMPLEADOS
INSERT INTO EMPLEADOS (id_usuario, id_sucursal, cargoPuesto, salario, fechaContratacion)
VALUES (1, 1, 'Gerente de Tienda', 3500000.00, '2026-02-01');
GO

-- 12. CLIENTES
INSERT INTO CLIENTES (id_usuario, nombreCompletoC, telefono, direccionPrincipal, fechaNacimiento)
VALUES (1, 'Juan David Cano', '3001234567', 'Calle 50 # 40-20', '2000-05-15');
GO

-- 13. INVENTARIOS
INSERT INTO INVENTARIOS (id_producto, id_sucursal, cantidadDisponible, stockMinimo, estanteriaUbicacion, ultimaActualizacion, capacidadBodega)
VALUES (1, 1, 50, 5, 'Estante A-12', GETDATE(), 200);
GO

-- 14. DETALLES_ORDENES_COMPRAS
INSERT INTO DETALLES_ORDENES_COMPRAS (id_compras_producto, id_producto, cantidadSolicitada, costoUnitario, subtotalCosto)
VALUES (1, 1, 10, 200000.00, 2000000.00);
GO

-- 15. VENTAS
INSERT INTO VENTAS (id_cliente, id_sucursal, id_promocion, fechaVenta, estadoVenta, totalPagar, direccionEnvio)
VALUES (1, 1, 1, GETDATE(), 'Completada', 212500.00, 'Calle 50 # 40-20, Bello');
GO

-- 16. DETALLE_VENTAS
INSERT INTO DETALLE_VENTAS (id_venta, id_producto, cantidad, precioUnitarioVenta, descuentoAplicado, subtotal)
VALUES (1, 1, 1, 250000.00, 37500.00, 212500.00);
GO

-- 17. PAGOS
INSERT INTO PAGOS (id_venta, id_metodo_pago, montoPagado, fechaPago, estadoTransaccion, referenciaPasarela)
VALUES (1, 1, 212500.00, GETDATE(), 'Aprobado', 'TRX-9988776655');
GO

-- 18. ENVIOS
INSERT INTO ENVIOS (id_venta, id_empresa_paqueteria, numeroGuia, estado, fechaEstimadaEntrega, fechaEntregaReal, costo)
VALUES (1, 1, 'ENV-2026-0001', 'Entregado', '2026-10-05', '2026-10-04', 12000.00);
GO

-- 19. GARANTIAS
INSERT INTO GARANTIAS (id_detalle_venta, fechaSolicitud, motivoFalla, estado, resolucionTecnica, fechaCierre)
VALUES (1, GETDATE(), 'Fallo en clic derecho', 'En Proceso', 'Pendiente de revisión en laboratorio', NULL);
GO

-- 20. DEVOLUCIONES
INSERT INTO DEVOLUCIONES (id_venta, id_metodo_pago_reembolso, fechaSolicitud, motivo, estadoProceso, montoReembolsado)
VALUES (1, 1, GETDATE(), 'Producto defectuoso reportado en garantía', 'Aprobado', 212500.00);
GO

-- 21. RESENAS
INSERT INTO RESENAS (id_producto, id_cliente, calificacionEstrellas, comentario, fechaPublicacion)
VALUES (1, 1, 5, 'Excelente mouse, muy ergonómico y preciso.', GETDATE());
GO
*/