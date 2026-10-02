/*CREATE DATABASE BityLab;
GO

USE BityLab;
GO

-- =============================================
-- 1. TABLAS INDEPENDIENTES
-- =============================================

CREATE TABLE ROLES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL UNIQUE,
    descripcion NVARCHAR(255) NOT NULL,
    salarioEstimado DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE MARCAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL UNIQUE,
    sitioWeb NVARCHAR(100) NOT NULL,
    correoSoporte NVARCHAR(100) NOT NULL,
    telefonoContacto NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE PROVEEDORES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombreEmpresa NVARCHAR(100) NOT NULL,
    nitEmpresa NVARCHAR(20) NOT NULL UNIQUE,
    nombreContacto NVARCHAR(100) NOT NULL,
    telefonoPrincipal NVARCHAR(20) NOT NULL,
    correoVentas NVARCHAR(100) NOT NULL UNIQUE,
    direccionFisica NVARCHAR(150) NOT NULL
);
GO

CREATE TABLE METODOS_PAGO (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL UNIQUE,
    descripcion NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE PROMOCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    codigoCupon NVARCHAR(50) NOT NULL UNIQUE,
    descripcion NVARCHAR(255) NOT NULL,
    porcentajeDescuento DECIMAL(5, 2) NOT NULL,
    fechaInicio DATETIME NOT NULL,
    fechaFin DATETIME NOT NULL
);
GO

CREATE TABLE SUCURSALES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL UNIQUE,
    direccion NVARCHAR(150) NOT NULL,
    ciudad NVARCHAR(50) NOT NULL,
    telefonoContacto NVARCHAR(20) NOT NULL,
    horarioAtencion NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE EMPRESAS_PAQUETERIA (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    telefono NVARCHAR(20) NOT NULL,
    correoElectronico NVARCHAR(100) NOT NULL UNIQUE,
    NIT NVARCHAR(20) NOT NULL UNIQUE,
    nombrePaqueteria NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- =============================================
-- 2. TABLAS CON DEPENDENCIAS
-- =============================================

CREATE TABLE USUARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_rol INT NOT NULL REFERENCES ROLES(id),
    nombreCompletoU NVARCHAR(100) NOT NULL,
    cedula NVARCHAR(20) NOT NULL UNIQUE,
    correo NVARCHAR(100) NOT NULL UNIQUE,
    contrasena NVARCHAR(100) NOT NULL,
    fechaRegistro DATETIME NOT NULL
);
GO

CREATE TABLE EMPLEADOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL UNIQUE REFERENCES USUARIOS(id),
    id_sucursal INT NOT NULL REFERENCES SUCURSALES(id),
    cargoPuesto NVARCHAR(50) NOT NULL,
    salario DECIMAL(10, 2) NOT NULL,
    fechaContratacion DATE NOT NULL
);
GO

CREATE TABLE CLIENTES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL UNIQUE REFERENCES USUARIOS(id),
    nombreCompletoC NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(20) NOT NULL,
    direccionPrincipal NVARCHAR(150) NOT NULL,
    fechaNacimiento DATE NOT NULL
);
GO

CREATE TABLE PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    categoria INT NOT NULL,
    id_marca INT NOT NULL REFERENCES MARCAS(id),
    nombreProducto NVARCHAR(100) NOT NULL,
    descripcionLarga NVARCHAR(200) NOT NULL,
    precioVenta DECIMAL(10, 2) NOT NULL,
    numeroSerie NVARCHAR(50) NOT NULL UNIQUE,
    modelo NVARCHAR(50) NOT NULL,
    especificacionesTecnicas NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE INVENTARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT NOT NULL REFERENCES PRODUCTOS(id),
    id_sucursal INT NOT NULL REFERENCES SUCURSALES(id),
    cantidadDisponible INT NOT NULL,
    stockMinimo INT NOT NULL,
    estanteriaUbicacion NVARCHAR(50) NOT NULL,
    ultimaActualizacion DATETIME NOT NULL,
    capacidadBodega INT NOT NULL
);
GO

CREATE TABLE COMPRAS_PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT NOT NULL REFERENCES PROVEEDORES(id),
    id_sucursal INT NOT NULL REFERENCES SUCURSALES(id),
    fechaOrden DATETIME NOT NULL,
    estadoOrden NVARCHAR(50) NOT NULL,
    totalEstimado DECIMAL(10, 2) NOT NULL,
    notasInternas NVARCHAR(200) NOT NULL
);
GO

CREATE TABLE DETALLES_ORDENES_COMPRAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_compras_producto INT NOT NULL REFERENCES COMPRAS_PRODUCTOS(id),
    id_producto INT NOT NULL REFERENCES PRODUCTOS(id),
    cantidadSolicitada INT NOT NULL,
    costoUnitario DECIMAL(10, 2) NOT NULL,
    subtotalCosto DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL REFERENCES CLIENTES(id),
    id_sucursal INT NOT NULL REFERENCES SUCURSALES(id),
    id_promocion INT REFERENCES PROMOCIONES(id), -- Opcional: la venta puede no tener cupón de descuento
    fechaVenta DATETIME NOT NULL,
    estadoVenta NVARCHAR(50) NOT NULL,
    totalPagar DECIMAL(10, 2) NOT NULL,
    direccionEnvio NVARCHAR(150) NOT NULL
);
GO

CREATE TABLE DETALLE_VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT NOT NULL REFERENCES VENTAS(id),
    id_producto INT NOT NULL REFERENCES PRODUCTOS(id),
    cantidad INT NOT NULL,
    precioUnitarioVenta DECIMAL(10, 2) NOT NULL,
    descuentoAplicado DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE PAGOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT NOT NULL REFERENCES VENTAS(id),
    id_metodo_pago INT NOT NULL REFERENCES METODOS_PAGO(id),
    montoPagado DECIMAL(10, 2) NOT NULL,
    fechaPago DATETIME NOT NULL,
    estadoTransaccion NVARCHAR(50) NOT NULL,
    referenciaPasarela NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE ENVIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT NOT NULL UNIQUE REFERENCES VENTAS(id),
    id_empresa_paqueteria INT NOT NULL REFERENCES EMPRESAS_PAQUETERIA(id),
    numeroGuia NVARCHAR(50) NOT NULL UNIQUE,
    estado NVARCHAR(50) NOT NULL,
    fechaEstimadaEntrega DATE NOT NULL,
    fechaEntregaReal DATE, -- Opcional: nulo hasta que el pedido sea entregado
    costo DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE GARANTIAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_detalle_venta INT NOT NULL REFERENCES DETALLE_VENTAS(id),
    fechaSolicitud DATE NOT NULL,
    motivoFalla NVARCHAR(255) NOT NULL,
    estado NVARCHAR(50) NOT NULL,
    resolucionTecnica NVARCHAR(255), -- Opcional: nulo hasta ser revisado en laboratorio
    fechaCierre DATE -- Opcional: nulo hasta que la garantía concluya
);
GO

CREATE TABLE DEVOLUCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT NOT NULL REFERENCES VENTAS(id),
    id_metodo_pago_reembolso INT NOT NULL REFERENCES METODOS_PAGO(id),
    fechaSolicitud DATE NOT NULL,
    motivo NVARCHAR(255) NOT NULL,
    estadoProceso NVARCHAR(50) NOT NULL,
    montoReembolsado DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE RESENAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT NOT NULL REFERENCES PRODUCTOS(id),
    id_cliente INT NOT NULL REFERENCES CLIENTES(id),
    calificacionEstrellas INT NOT NULL,
    comentario NVARCHAR(200) NOT NULL,
    fechaPublicacion DATETIME NOT NULL
);
GO

-- =============================================
-- 3. INSERCIÓN DE DATOS DE PRUEBA
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

-- 7. EMPRESAS_PAQUETERIA
INSERT INTO EMPRESAS_PAQUETERIA (telefono, correoElectronico, NIT, nombrePaqueteria)
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
VALUES (1, GETDATE(), 'Fallo en clic derecho', 'En Proceso', 'Pendiente de revisión en laboratorio', '2026-10-04');
GO

-- 20. DEVOLUCIONES
INSERT INTO DEVOLUCIONES (id_venta, id_metodo_pago_reembolso, fechaSolicitud, motivo, estadoProceso, montoReembolsado)
VALUES (1, 1, GETDATE(), 'Producto defectuoso reportado en garantía', 'Aprobado', 212500.00);
GO

-- 21. RESENAS
INSERT INTO RESENAS (id_producto, id_cliente, calificacionEstrellas, comentario, fechaPublicacion)
VALUES (1, 1, 5, 'Excelente mouse, muy ergonómico y preciso.', GETDATE());
GO*/