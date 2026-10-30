USE GYMTRACKFINAL;
GO

-------------------------------------------------------------------------------------
----------------- PROCEDIMIENTOS PARA CONFIGURACIÓN ---------------------------------
-------------------------------------------------------------------------------------

-- Procedimiento para obtener la configuración (se asume que siempre hay 1 sola fila con ID 1)  --SARAI
CREATE PROCEDURE sp_Obtener_Configuracion
AS
BEGIN
    -- Si no existe, insertamos un valor por defecto primero
    IF NOT EXISTS (SELECT 1 FROM CONFIGURACION_SISTEMA)
    BEGIN
        INSERT INTO CONFIGURACION_SISTEMA (NOMBRE_GIMNASIO, DIRECCION, TELEFONO, HORA_APERTURA, HORA_CIERRE, TIEMPO_MAXIMO_ESTANCIA)
        VALUES ('GymTrack', 'Av. Principal 123', '999888777', '06:00:00', '22:00:00', 120);
    END

    SELECT 
        NOMBRE_GIMNASIO,
        DIRECCION,
        TELEFONO,
        HORA_APERTURA,
        HORA_CIERRE,
        TIEMPO_MAXIMO_ESTANCIA
    FROM CONFIGURACION_SISTEMA
    WHERE IDCONFIGURACION_SISTEMA = 1;
END
GO

--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS ACTUALIZAR CONFIGURACION------------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_Actualizar_Configuracion
(
    @NOMBRE_GIMNASIO VARCHAR(100),
    @DIRECCION VARCHAR(200),
    @TELEFONO VARCHAR(20),
    @HORA_APERTURA TIME,
    @HORA_CIERRE TIME,
    @TIEMPO_MAXIMO_ESTANCIA INT
)
AS
BEGIN
    UPDATE CONFIGURACION_SISTEMA
    SET 
        NOMBRE_GIMNASIO = @NOMBRE_GIMNASIO,
        DIRECCION = @DIRECCION,
        TELEFONO = @TELEFONO,
        HORA_APERTURA = @HORA_APERTURA,
        HORA_CIERRE = @HORA_CIERRE,
        TIEMPO_MAXIMO_ESTANCIA = @TIEMPO_MAXIMO_ESTANCIA
    WHERE IDCONFIGURACION_SISTEMA = 1;
END
GO

--------------------------------------------------------------------------------------------------------------
--------------------------------- PROCEDIMIENTOS PARA BUSCAR INGRESO ACTIVO-----------------------------------
--------------------------------------------------------------------------------------------------------------

-- Procedimiento para buscar si un socio está dentro del gimnasio (Hora de salida es NULL)  -----29/06  --SARAI
CREATE PROCEDURE sp_Buscar_IngresoActivo
(
    @DNI VARCHAR(10)
)
AS
BEGIN
    SELECT 
        ca.ID_ACCESO,
        s.DNI,
        s.APELLIDOS + ', ' + s.NOMBRES AS NOMBRE_COMPLETO,
        c.NUMERO_CASILLERO,
        z.DESCRIPCION AS ZONA,
        ca.HORA_INGRESO
    FROM CONTROL_ACCESOS ca
    INNER JOIN SOCIOS s ON ca.IDSOCIO = s.IDSOCIO
    INNER JOIN CASILLEROS c ON ca.IDCASILLERO = c.IDCASILLERO
    INNER JOIN ZONA z ON c.IDZONA = z.IDZONA
    WHERE s.DNI = @DNI 
      AND ca.HORA_SALIDA IS NULL
      --AND ca.FECHA = CAST(GETDATE() AS DATE);
END
GO


--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA REGISTRAR SALIDA -----------------------------------
--------------------------------------------------------------------------------------------------------------
-- Procedimiento para registrar la salida del socio y liberar el casillero  --SARAI
CREATE PROCEDURE sp_Registrar_Salida
(
    @ID_ACCESO INT,
    @NUMERO_CASILLERO INT,
    @HORA_SALIDA TIME
)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Actualizar la hora de salida en el Control de Accesos
        UPDATE CONTROL_ACCESOS
        SET HORA_SALIDA = @HORA_SALIDA
        WHERE ID_ACCESO = @ID_ACCESO;

        -- 2. Liberar el casillero (Asumimos que el Estado 1 es 'Libre' en ESTADO_ACTUAL_CASILLEROS)
        -- Si Sarai tiene 'Libre' con otro ID, deberá cambiar este 1.
        DECLARE @ID_ESTADO_LIBRE INT = 1; 

        UPDATE CASILLEROS
        SET IDESTADO_ACTUAL_CASILLEROS = @ID_ESTADO_LIBRE
        WHERE NUMERO_CASILLERO = @NUMERO_CASILLERO;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
