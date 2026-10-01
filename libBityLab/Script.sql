/*
CREATE DATABASE BityLab;
GO

USE BityLab;


        --ROLES
CREATE TABLE ROLES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre nvarchar(50),
    descripcion nvarchar(255),
    salario_estimado DECIMAL(10, 2)
);



GO
-- MARCAS
CREATE TABLE MARCAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    sitio_web NVARCHAR(100),
    correo_soporte NVARCHAR(100),
    telefono_contacto NVARCHAR(20)
);
GO

-- PROVEEDORES
CREATE TABLE PROVEEDORES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre_empresa NVARCHAR(100),
    nit_empresa NVARCHAR(20),
    nombre_contacto NVARCHAR(100),
    telefono_principal NVARCHAR(20),
    correo_ventas NVARCHAR(100),
    direccion_fisica NVARCHAR(150)
);
GO

-- METODOS DE PAGO
CREATE TABLE METODOS_PAGO (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50),
    descripcion NVARCHAR(255)
);
GO

-- PROMOCIONES
CREATE TABLE PROMOCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    codigo_cupon NVARCHAR(50),
    descripcion NVARCHAR(255),
    porcentaje_descuento DECIMAL(5, 2),
    fecha_inicio DATETIME,
    fecha_fin DATETIME
);
GO

-- SUCURSALES
CREATE TABLE SUCURSALES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100),
    direccion NVARCHAR(150),
    ciudad NVARCHAR(50),
    telefono_contacto NVARCHAR(20),
    horario_atencion NVARCHAR(100)
);
GO

-- PAQUETERIA
CREATE TABLE EmpresaPaqueteria (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    telefono NVARCHAR(20),
    correoElectronico NVARCHAR(100),
    NIT NVARCHAR(20),
    nombre_paqueteria NVARCHAR(100)
);
GO

-- 2. TABLAS CON DEPENDENCIAS

-- USUARIOS
CREATE TABLE USUARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES ROLES(id),
    nombre_completo_u NVARCHAR(100),
    cedula NVARCHAR(20),
    correo NVARCHAR(100),
    contrasena NVARCHAR(100),
    fecha_registro DATETIME
);
GO

-- EMPLEADOS
CREATE TABLE EMPLEADOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT REFERENCES USUARIOS(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    cargo_puesto NVARCHAR(50),
    salario DECIMAL(10, 2),
    fecha_contratacion DATE
);
GO

-- CLIENTES
CREATE TABLE CLIENTES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT REFERENCES USUARIOS(id),
    nombre_completo_C NVARCHAR(100),
    telefono NVARCHAR(20),
    direccion_principal NVARCHAR(150),
    fecha_nacimiento DATE
);
GO

-- PRODUCTOS
CREATE TABLE PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    categoria INT,
    id_marca INT REFERENCES MARCAS(id),
    nombre_producto NVARCHAR(100),
    descripcion_larga NVARCHAR(200),
    precio_venta DECIMAL(10, 2),
    numero_serie NVARCHAR(50),
    modelo NVARCHAR(50),
    especificaciones_tecnicas NVARCHAR(MAX)
);
GO

-- INVENTARIOS
CREATE TABLE INVENTARIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT REFERENCES PRODUCTOS(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    cantidad_disponible INT,
    stock_minimo INT,
    estanteria_ubicacion NVARCHAR(50),
    ultima_actualizacion DATETIME,
    capacidad_bodega INT
);
GO

-- COMPRAS_PRODUCTOS
CREATE TABLE COMPRAS_PRODUCTOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_proveedor INT REFERENCES PROVEEDORES(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    fecha_orden DATETIME,
    estado_orden NVARCHAR(50),
    total_estimado DECIMAL(10, 2),
    notas_internas NVARCHAR(200)
);
GO

-- DETALLES_ORDENES_COMPRAS
CREATE TABLE DETALLES_ORDENES_COMPRAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_compras_producto INT REFERENCES COMPRAS_PRODUCTOS(id),
    id_producto INT REFERENCES PRODUCTOS(id),
    cantidad_solicitada INT,
    costo_unitario DECIMAL(10, 2),
    subtotal_costo DECIMAL(10, 2)
);
GO

-- VENTAS
CREATE TABLE VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_cliente INT REFERENCES CLIENTES(id),
    id_sucursal INT REFERENCES SUCURSALES(id),
    id_promocion INT REFERENCES PROMOCIONES(id),
    fecha_venta DATETIME,
    estado_venta NVARCHAR(50),
    total_pagar DECIMAL(10, 2),
    direccion_envio NVARCHAR(150)
);
GO

-- DETALLE_VENTAS
CREATE TABLE DETALLE_VENTAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_producto INT REFERENCES PRODUCTOS(id),
    cantidad INT,
    precio_unitario_venta DECIMAL(10, 2),
    descuento_aplicado DECIMAL(10, 2),
    subtotal DECIMAL(10, 2)
);
GO

-- PAGOS
CREATE TABLE PAGOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_metodo_pago INT REFERENCES METODOS_PAGO(id),
    monto_pagado DECIMAL(10, 2),
    fecha_pago DATETIME,
    estado_transaccion NVARCHAR(50),
    referencia_pasarela NVARCHAR(100)
);
GO

-- ENVIOS
CREATE TABLE ENVIOS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_empresa_paqueteria INT REFERENCES EmpresaPaqueteria(id),
    numero_guia NVARCHAR(50),
    estado NVARCHAR(50),
    fecha_estimada_entrega DATE,
    fecha_entrega_real DATE,
    costo DECIMAL(10, 2)
);
GO

-- GARANTIAS
CREATE TABLE GARANTIAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_detalle_venta INT REFERENCES DETALLE_VENTAS(id),
    fecha_solicitud DATE,
    motivo_falla NVARCHAR(255),
    estado NVARCHAR(50),
    resolucion_tecnica NVARCHAR(255),
    fecha_cierre DATE
);
GO

-- DEVOLUCIONES
CREATE TABLE DEVOLUCIONES (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_venta INT REFERENCES VENTAS(id),
    id_metodo_pago_reembolso INT REFERENCES METODOS_PAGO(id),
    fecha_solicitud DATE,
    motivo NVARCHAR(255),
    estado_proceso NVARCHAR(50),
    monto_reembolsado DECIMAL(10, 2)
);
GO

-- RESENAS
CREATE TABLE RESENAS (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_producto INT REFERENCES PRODUCTOS(id),
    id_cliente INT REFERENCES CLIENTES(id),
    calificacion_estrellas INT,
    comentario NVARCHAR(200),
    fecha_publicacion DATETIME
);
GO
USE BityLab;
GO

-- =============================================
-- 1. REGISTROS EN TABLAS INDEPENDIENTES (SIN FORÁNEAS)
-- =============================================

-- 1. ROLES
INSERT INTO ROLES (nombre, descripcion, salario_estimado)
VALUES ('Administrador', 'Control total del sistema y gestión de usuarios', 4500000.00);
GO

-- 2. MARCAS
INSERT INTO MARCAS (nombre, sitio_web, correo_soporte, telefono_contacto)
VALUES ('Logitech', 'https://www.logitech.com', 'soporte@logitech.com', '+18005550199');
GO

-- 3. PROVEEDORES
INSERT INTO PROVEEDORES (nombre_empresa, nit_empresa, nombre_contacto, telefono_principal, correo_ventas, direccion_fisica)
VALUES ('Tech Supply S.A.S.', '900123456-1', 'Carlos Gómez', '6015551234', 'ventas@techsupply.com', 'Calle 100 # 15-20, Bogotá');
GO

-- 4. METODOS_PAGO
INSERT INTO METODOS_PAGO (nombre, descripcion)
VALUES ('Tarjeta de Crédito', 'Pago mediante pasarela electrónica Visa/Mastercard');
GO

-- 5. PROMOCIONES
INSERT INTO PROMOCIONES (codigo_cupon, descripcion, porcentaje_descuento, fecha_inicio, fecha_fin)
VALUES ('LANZAMIENTO2026', 'Descuento de bienvenida por apertura', 15.00, '2026-01-01 00:00:00', '2026-12-31 23:59:59');
GO

-- 6. SUCURSALES
INSERT INTO SUCURSALES (nombre, direccion, ciudad, telefono_contacto, horario_atencion)
VALUES ('Sucursal Principal Bello', 'Carrera 50 # 38-10', 'Bello', '6044445566', 'Lunes a Sábado 8:00 AM - 7:00 PM');
GO

-- 7. EmpresaPaqueteria
INSERT INTO EmpresaPaqueteria (telefono, correoElectronico, NIT, nombre_paqueteria)
VALUES ('018000911000', 'servicio@servientrega.com', '860012345-8', 'Servientrega');
GO


-- =============================================
-- 2. REGISTROS EN TABLAS DEPENDIENTES (NIVEL 1)
-- =============================================

-- 8. USUARIOS (Depende de ROLES - Usamos id_rol = 1)
INSERT INTO USUARIOS (id_rol, nombre_completo_u, cedula, correo, contrasena, fecha_registro)
VALUES (1, 'Juan David Cano', '1017123456', 'juan.david.cano@example.com', 'password123', GETDATE());
GO

-- 9. PRODUCTOS (Depende de MARCAS - Usamos id_marca = 1)
INSERT INTO PRODUCTOS (categoria, id_marca, nombre_producto, descripcion_larga, precio_venta, numero_serie, modelo, especificaciones_tecnicas)
VALUES (1, 1, 'Mouse Gamer G502', 'Mouse óptico de alta precisión para gaming', 250000.00, 'SN-LOG-98765', 'G502 HERO', 'Sensor HERO 25K, 11 botones programables, RGB');
GO

-- 10. COMPRAS_PRODUCTOS (Depende de PROVEEDORES id=1 y SUCURSALES id=1)
INSERT INTO COMPRAS_PRODUCTOS (id_proveedor, id_sucursal, fecha_orden, estado_orden, total_estimado, notas_internas)
VALUES (1, 1, GETDATE(), 'Completada', 2000000.00, 'Orden inicial de reabastecimiento');
GO


-- =============================================
-- 3. REGISTROS EN TABLAS DEPENDIENTES (NIVEL 2)
-- =============================================

-- 11. EMPLEADOS (Depende de USUARIOS id=1 y SUCURSALES id=1)
INSERT INTO EMPLEADOS (id_usuario, id_sucursal, cargo_puesto, salario, fecha_contratacion)
VALUES (1, 1, 'Gerente de Tienda', 3500000.00, '2026-02-01');
GO

-- 12. CLIENTES (Depende de USUARIOS id=1)
INSERT INTO CLIENTES (id_usuario, nombre_completo_C, telefono, direccion_principal, fecha_nacimiento)
VALUES (1, 'Juan David Cano', '3001234567', 'Calle 50 # 40-20', '2000-05-15');
GO

-- 13. INVENTARIOS (Depende de PRODUCTOS id=1 y SUCURSALES id=1)
INSERT INTO INVENTARIOS (id_producto, id_sucursal, cantidad_disponible, stock_minimo, estanteria_ubicacion, ultima_actualizacion, capacidad_bodega)
VALUES (1, 1, 50, 5, 'Estante A-12', GETDATE(), 200);
GO

-- 14. DETALLES_ORDENES_COMPRAS (Depende de COMPRAS_PRODUCTOS id=1 y PRODUCTOS id=1)
INSERT INTO DETALLES_ORDENES_COMPRAS (id_compras_producto, id_producto, cantidad_solicitada, costo_unitario, subtotal_costo)
VALUES (1, 1, 10, 200000.00, 2000000.00);
GO


-- =============================================
-- 4. REGISTROS EN TABLAS DEPENDIENTES (NIVEL 3 - VENTAS Y PROCESOS)
-- =============================================

-- 15. VENTAS (Depende de CLIENTES id=1, SUCURSALES id=1 y PROMOCIONES id=1)
INSERT INTO VENTAS (id_cliente, id_sucursal, id_promocion, fecha_venta, estado_venta, total_pagar, direccion_envio)
VALUES (1, 1, 1, GETDATE(), 'Completada', 212500.00, 'Calle 50 # 40-20, Bello');
GO

-- 16. DETALLE_VENTAS (Depende de VENTAS id=1 y PRODUCTOS id=1)
INSERT INTO DETALLE_VENTAS (id_venta, id_producto, cantidad, precio_unitario_venta, descuento_aplicado, subtotal)
VALUES (1, 1, 1, 250000.00, 37500.00, 212500.00);
GO

-- 17. PAGOS (Depende de VENTAS id=1 y METODOS_PAGO id=1)
INSERT INTO PAGOS (id_venta, id_metodo_pago, monto_pagado, fecha_pago, estado_transaccion, referencia_pasarela)
VALUES (1, 1, 212500.00, GETDATE(), 'Aprobado', 'TRX-9988776655');
GO

-- 18. ENVIOS (Depende de VENTAS id=1 y EmpresaPaqueteria id=1)
INSERT INTO ENVIOS (id_venta, id_empresa_paqueteria, numero_guia, estado, fecha_estimada_entrega, fecha_entrega_real, costo)
VALUES (1, 1, 'ENV-2026-0001', 'Entregado', '2026-10-05', '2026-10-04', 12000.00);
GO

-- 19. GARANTIAS (Depende de DETALLE_VENTAS id=1)
INSERT INTO GARANTIAS (id_detalle_venta, fecha_solicitud, motivo_falla, estado, resolucion_tecnica, fecha_cierre)
VALUES (1, GETDATE(), 'Fallo en clic derecho', 'En Proceso', 'Pendiente de revisión en laboratorio', NULL);
GO

-- 20. DEVOLUCIONES (Depende de VENTAS id=1 y METODOS_PAGO id=1)
INSERT INTO DEVOLUCIONES (id_venta, id_metodo_pago_reembolso, fecha_solicitud, motivo, estado_proceso, monto_reembolsado)
VALUES (1, 1, GETDATE(), 'Producto defectuoso reportado en garantía', 'Aprobado', 212500.00);
GO

-- 21. RESENAS (Depende de PRODUCTOS id=1 y CLIENTES id=1)
INSERT INTO RESENAS (id_producto, id_cliente, calificacion_estrellas, comentario, fecha_publicacion)
VALUES (1, 1, 5, 'Excelente mouse, muy ergonómico y preciso.', GETDATE());
GO
*/