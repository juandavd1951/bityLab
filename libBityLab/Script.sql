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
*/