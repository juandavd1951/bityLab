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
--MARCAS
CREATE TABLE MARCAS (
    id INT PRIMARY KEY,
    nombre nvarchar(50),
    sitio_web nvarchar(100),
    correo_soporte nvarchar(100),
    telefono_contacto nvarchar(20)
);
GO
--PROVEEDORES
CREATE TABLE PROVEEDORES (
    id INT PRIMARY KEY,
    nombre_empresa nvarchar(100),
    nit_empresa nvarchar(20),
    nombre_contacto nvarchar(100),
    telefono_principal nvarchar(20),
    correo_ventas nvarchar(100),
    direccion_fisica nvarchar(150)
);
GO
--METODOS DE PAGO
CREATE TABLE METODOS_PAGO (
    id INT PRIMARY KEY,
    nombre nvarchar(50),
    descripcion nvarchar(255)
);
GO
--PROMOCIONES
CREATE TABLE PROMOCIONES (
    id INT PRIMARY KEY,
    codigo_cupon nvarchar(50),
    descripcion nvarchar(255),
    porcentaje_descuento DECIMAL(5, 2),
    fecha_inicio DATETIME,
    fecha_fin DATETIME
);
GO
--SUCURSALES
CREATE TABLE SUCURSALES (
    id INT PRIMARY KEY,
    nombre nvarchar(100),
    direccion nvarchar(150),
    ciudad nvarchar(50),
    telefono_contacto nvarchar(20),
    horario_atencion nvarchar(100)
);
GO
--PAQUETERIA
CREATE TABLE EmpresaPaqueteria (
    id INT PRIMARY KEY,
    teléfono nvarchar(20),
    correoElectronico nvarchar(100),
    NIT nvarchar(20),
    nombre_paqueteria nvarchar(100)
);
GO


-- 2. TABLAS CON DEPENDENCIAS
--USUARIOS
CREATE TABLE USUARIOS (
    id INT PRIMARY KEY,
    id_rol INT REFERENCES ROLES(id_rol),
    nombre_completo_u nvarchar(100),
    cedula nvarchar(20),
    correo nvarchar(100),
    contrasena nvarchar(100),
    fecha_registro DATETIME
);
GO
--EMPLEADOS
CREATE TABLE EMPLEADOS (
    id INT PRIMARY KEY,
    id_usuario INT REFERENCES USUARIOS(id_usuario),
    id_sucursal INT REFERENCES SUCURSALES(id_sucursal),
    cargo_puesto nvarchar(50),
    salario DECIMAL(10, 2),
    fecha_contratacion DATE
);
GO
--CLIENTES
CREATE TABLE CLIENTES (
    id INT PRIMARY KEY,
    id_usuario INT REFERENCES USUARIOS(id_usuario),
    nombre_completo_C nvarchar(100),
    telefono nvarchar(20),
    direccion_principal nvarchar(150),
    fecha_nacimiento DATE
);
GO
--PRODUCTOS
CREATE TABLE PRODUCTOS (
    id INT PRIMARY KEY,
    categoria INT,
    id_marca INT REFERENCES MARCAS(id_marca),
    nombre_producto nvarchar(100),
    descripcion_larga nvarchar(200),
    precio_venta DECIMAL(10, 2),
    Número_serie nvarchar(50),
    modelo nvarchar(50),
    especificaciones_Técnicas nvarchar(MAX) -- Cambiado a nvarchar(MAX) para compatibilidad estándar con SQL Server
);
GO
--INVENTARIOS
CREATE TABLE INVENTARIOS (
    id INT PRIMARY KEY,
    id_producto INT REFERENCES PRODUCTOS(id_producto),
    id_sucursal INT REFERENCES SUCURSALES(id_sucursal),
    cantidad_disponible INT,
    stock_minimo INT,
    estanteria_ubicacion nvarchar(50),
    ultima_actualizacion DATETIME,
    capacidad_bodega INT
);
GO
--COMPRAS_PRODUCTOS
CREATE TABLE COMPRAS_PRODUCTOS (
    id INT PRIMARY KEY,
    id_proveedor INT REFERENCES PROVEEDORES(id_proveedor),
    id_sucursal INT REFERENCES SUCURSALES(id_sucursal),
    fecha_orden DATETIME,
    estado_orden nvarchar(50),
    total_estimado DECIMAL(10, 2),
    notas_internas nvarchar(200)
);
GO
--DETALLES_ORDENES_COMPRAS
CREATE TABLE DETALLES_ORDENES_COMPRAS (
    id INT PRIMARY KEY,
    id_compras_producto INT REFERENCES COMPRAS_PRODUCTOS(id_compras_producto),
    id_producto INT REFERENCES PRODUCTOS(id_producto),
    cantidad_solicitada INT,
    costo_unitario DECIMAL(10, 2),
    subtotal_costo DECIMAL(10, 2)
);
GO
--VENTAS
CREATE TABLE VENTAS (
    id INT PRIMARY KEY,
    id_cliente INT REFERENCES CLIENTES(id_cliente),
    id_sucursal INT REFERENCES SUCURSALES(id_sucursal),
    id_promocion INT REFERENCES PROMOCIONES(id_promocion),
    fecha_venta DATETIME,
    estado_venta nvarchar(50),
    total_pagar DECIMAL(10, 2),
    direccion_envio nvarchar(150)
);
GO
--DETALLE_VENTAS
CREATE TABLE DETALLE_VENTAS (
    id INT PRIMARY KEY,
    id_venta INT REFERENCES VENTAS(id_venta),
    id_producto INT REFERENCES PRODUCTOS(id_producto),
    cantidad INT,
    precio_unitario_venta DECIMAL(10, 2),
    descuento_aplicado DECIMAL(10, 2),
    subtotal DECIMAL(10, 2)
);
GO
--pagos
CREATE TABLE PAGOS (
    id INT PRIMARY KEY,
    id_venta INT REFERENCES VENTAS(id_venta),
    id_metodo_pago INT REFERENCES METODOS_PAGO(id_metodo_pago),
    monto_pagado DECIMAL(10, 2),
    fecha_pago DATETIME,
    estado_transaccion nvarchar(50),
    referencia_pasarela nvarchar(100)
);
GO
--envios
CREATE TABLE ENVIOS (
    id INT PRIMARY KEY,
    id_venta INT REFERENCES VENTAS(id_venta),
    EmpresaPaqueteriaID INT REFERENCES EmpresaPaqueteria(EmpresaPaqueteriaID),
    numero_guia nvarchar(50),
    estado nvarchar(50),
    fecha_estimada_entrega DATE,
    fecha_entrega_real DATE,
    costo DECIMAL(10, 2)
);
GO
--GARANTIAS
CREATE TABLE GARANTIAS (
    id INT PRIMARY KEY,
    id_detalle_venta INT REFERENCES DETALLE_VENTAS(id_detalle_venta),
    fecha_solicitud DATE,
    motivo_falla nvarchar(255),
    estado nvarchar(50),
    resolucion_tecnica nvarchar(255),
    fecha_cierre DATE
);
GO
--DEVOLUCIONES
CREATE TABLE DEVOLUCIONES (
    id INT PRIMARY KEY,
    id_VENTAS INT REFERENCES VENTAS(id_venta),
    id_metodo_pago_reembolso INT REFERENCES METODOS_PAGO(id_metodo_pago),
    fecha_solicitud DATE,
    motivo nvarchar(255),
    estado_proceso nvarchar(50),
    monto_reembolsado DECIMAL(10, 2)
);
GO

CREATE TABLE RESENAS (
    id INT PRIMARY KEY,
    id_producto INT REFERENCES PRODUCTOS(id_producto),
    id_cliente INT REFERENCES CLIENTES(id_cliente),
    calificacion_estrellas INT,
    comentario nvarchar(200),
    fecha_publicacion DATETIME
);
GO*/
