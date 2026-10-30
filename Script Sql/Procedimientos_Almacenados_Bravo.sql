--------------------------------------------------------------------------------------------------------------
------------------------------------- PROCEDIMIENTOS PARA AFLUENCIAS POR HORAS--------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_AfluenciaPorHoras
@Desde DATETIME,
@Hasta DATETIME
AS
BEGIN
    SELECT 
        DATEPART(HOUR, HORA_INGRESO) AS Hora,
        COUNT(*) AS Cantidad
    FROM CONTROL_ACCESOS
    WHERE 
        CAST(FECHA AS DATETIME) + CAST(HORA_INGRESO AS DATETIME) >= @Desde
        AND 
        CAST(FECHA AS DATETIME) + CAST(HORA_INGRESO AS DATETIME) < DATEADD(DAY, 1, @Hasta)
    GROUP BY DATEPART(HOUR, HORA_INGRESO)
    ORDER BY Hora
END




--------------------------------------------------------------------------------------------------------------
--------------------------- PROCEDIMIENTOS PARA BUSCAR CASILLEROS OCUPADOS -----------------------------------
--------------------------------------------------------------------------------------------------------------

-- FrmCasillerosRetenidos
CREATE PROCEDURE sp_BuscarCasillerosOcupados
@NumeroCasillero INT = 0,
@Zona VARCHAR(50) = ''
AS
BEGIN
SELECT 
c.NUMERO_CASILLERO,
z.DESCRIPCION AS Zona,
e.DESCRIPCION AS Estado,
ISNULL(s.NOMBRES + ' ' + s.APELLIDOS, 'Sin socio') AS Socio
FROM Casilleros c 
INNER JOIN ZONA z ON c.IDZONA = z.IDZONA
INNER JOIN ESTADO_ACTUAL_CASILLEROS e 
ON c.IDESTADO_ACTUAL_CASILLEROS = e.IDESTADO_ACTUAL_CASILLEROS
LEFT JOIN CONTROL_ACCESOS ca
ON c.IDCASILLERO = ca.IDCASILLERO AND ca.HORA_SALIDA IS NULL 
LEFT JOIN SOCIOS s ON ca.IDSOCIO = s.IDSOCIO AND s.ACTIVO = 1
WHERE
c.IDESTADO_ACTUAL_CASILLEROS = 2
AND c.ACTIVO = 1
AND (@NumeroCasillero = 0 OR c.NUMERO_CASILLERO = @NumeroCasillero)
AND (@Zona = '' OR z.DESCRIPCION = @Zona)
END



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA LIBERAR CASILLERO -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_LiberarCasillero
@NumeroCasillero INT
AS
BEGIN
DECLARE @IdCasillero INT
SELECT @IdCasillero = IDCASILLERO
FROM CASILLEROS
WHERE NUMERO_CASILLERO = @NumeroCasillero
UPDATE CONTROL_ACCESOS
SET HORA_SALIDA = GETDATE()
WHERE IDCASILLERO = @IdCasillero
AND HORA_SALIDA IS NULL
UPDATE CASILLEROS
SET IDESTADO_ACTUAL_CASILLEROS = 1
WHERE IDCASILLERO = @IdCasillero
END

 
--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA LISTAR ZONAS EN COMBOBOX -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarZonas_Retenidos
AS
BEGIN
    SELECT IDZONA, DESCRIPCION
    FROM ZONA
END
 

 --------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA LISTAR ESTADOS -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarEstados
AS
BEGIN
    SELECT 
        IDESTADO_ACTUAL_CASILLEROS AS idEstado,
        DESCRIPCION AS descripcion
    FROM ESTADO_ACTUAL_CASILLEROS
END



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA BUSCAR CASILLERO -----------------------------------
--------------------------------------------------------------------------------------------------------------
-- FrmMantenimientoCasillero
CREATE PROCEDURE sp_BuscarCasillero
(
    @NumeroCasillero INT,
    @Zona INT
)
AS
BEGIN
    SELECT 
        c.NUMERO_CASILLERO,
        c.IDZONA,
        z.DESCRIPCION,
        c.IDESTADO_ACTUAL_CASILLEROS,
        e.DESCRIPCION AS ESTADO,
        s.NOMBRES,
        s.APELLIDOS
    FROM CASILLEROS c
    INNER JOIN ZONA z ON c.IDZONA = z.IDZONA
    INNER JOIN ESTADO_ACTUAL_CASILLEROS e 
        ON c.IDESTADO_ACTUAL_CASILLEROS = e.IDESTADO_ACTUAL_CASILLEROS
    LEFT JOIN CONTROL_ACCESOS ca ON c.IdCasillero = ca.IdCasillero AND  ca.HORA_SALIDA IS NULL
    LEFT JOIN SOCIOS s ON ca.IdSocio = s.IdSocio
    WHERE c.NUMERO_CASILLERO = @NumeroCasillero
    AND c.IDZONA = @Zona
END



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA MODIFICAR CASILLERO -----------------------------------
--------------------------------------------------------------------------------------------------------------
-- FrmMantenimientoCasillero
CREATE PROCEDURE  sp_ModificarCasillero
(
    @NumeroCasillero INT,
    @IdZona INT,
    @IdEstado INT
)
AS
BEGIN
    UPDATE CASILLEROS
    SET 
        IDZONA = @IdZona,
        IDESTADO_ACTUAL_CASILLEROS = @IdEstado
    WHERE NUMERO_CASILLERO = @NumeroCasillero
END

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------


--Ingresar Datos CONTROL_ACCESO
INSERT INTO CONTROL_ACCESOS VALUES (9,10,1,'2026-06-24','07:15:00','08:45:00');
INSERT INTO CONTROL_ACCESOS VALUES (10,11,1,'2026-06-24','07:30:00','09:00:00');

-- Hora pico mañana
INSERT INTO CONTROL_ACCESOS VALUES (11,12,1,'2026-06-24','08:00:00','09:30:00');
INSERT INTO CONTROL_ACCESOS VALUES (12,13,1,'2026-06-24','08:10:00','10:00:00');
INSERT INTO CONTROL_ACCESOS VALUES (13,16,1,'2026-06-24','08:25:00','09:50:00');

-- Media mañana
INSERT INTO CONTROL_ACCESOS VALUES (14,14,1,'2026-06-24','09:30:00','10:30:00');
INSERT INTO CONTROL_ACCESOS VALUES (15,15,1,'2026-06-24','10:00:00','11:00:00');

-- Medio día (baja afluencia)
INSERT INTO CONTROL_ACCESOS VALUES (16,16,1,'2026-06-24','12:00:00','13:00:00');

-- Tarde
INSERT INTO CONTROL_ACCESOS VALUES (9,19,1,'2026-06-24','16:00:00','17:30:00');
INSERT INTO CONTROL_ACCESOS VALUES (11,12,1,'2026-06-24','16:30:00','18:00:00');

-- Hora pico noche
INSERT INTO CONTROL_ACCESOS VALUES (10,15,1,'2026-06-24','18:00:00','19:30:00');
INSERT INTO CONTROL_ACCESOS VALUES (11,13,1,'2026-06-24','18:15:00','20:00:00');
INSERT INTO CONTROL_ACCESOS VALUES (14,16,1,'2026-06-24','18:30:00','20:10:00');
INSERT INTO CONTROL_ACCESOS VALUES (15,14,1,'2026-06-24','19:00:00','21:00:00');

-- Clientes activos (sin salida)
INSERT INTO CONTROL_ACCESOS VALUES (16,16,1,'2026-06-24','20:00:00',NULL);
INSERT INTO CONTROL_ACCESOS VALUES (16,19,1,'2026-06-24','20:30:00',NULL);



--Ingresar datos Casilleros
INSERT INTO CASILLEROS (IDZONA, IDESTADO_ACTUAL_CASILLEROS, NUMERO_CASILLERO) VALUES
(1, 2, 101),
(1, 1, 102),
(1, 2, 103),
(1, 3, 104),
(1, 1, 105),
(1, 2, 106),
(2, 2, 201),
(2, 1, 202),
(2, 2, 203),
(2, 3, 204),
(2, 1, 205),
(2, 2, 206);


SELECT * FROM ESTADO_ACTUAL_CASILLEROS;
SELECT * FROM CASILLEROS;
SELECT * FROM SOCIOS
SELECT * FROM ASESOR;

--Ingresar datos Socios
INSERT INTO SOCIOS (DNI, NOMBRES, APELLIDOS, FECHA_NACIMIENTO, SEXO, TELEFONO, IDZONA) VALUES
('12345678', 'Juan', 'Perez', '1995-03-15', 'Masculino', '987654321', 1),
('87654321', 'Maria', 'Gomez', '1998-07-22', 'Femenino', '912345678', 2),
('11223344', 'Carlos', 'Lopez', '1992-11-10', 'Masculino', '934567890', 1),
('44332211', 'Ana', 'Torres', '2000-01-05', 'Femenino', '923456789', 2),
('55667788', 'Luis', 'Ramirez', '1997-09-18', 'Masculino', '945678123', 1),
('88776655', 'Sofia', 'Castro', '1999-12-30', 'Femenino', '956789234', 2),
('66778899', 'Diego', 'Vargas', '1994-06-25', 'Masculino', '967891345', 1),
('99887766', 'Lucia', 'Mendoza', '2001-04-12', 'Femenino', '978912456', 2);


INSERT INTO ASESOR (NOMBRES, APELLIDOS, CLAVE,USUARIO) VALUES
('Juan', 'Ramirres', '123456', 'juanRA');
