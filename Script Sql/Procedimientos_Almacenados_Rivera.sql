USE GYMTRACKFINAL;
GO

-------------------------------------------------------------------------------------
----------------- PROCEDIMIENTOS CRUD PARA ASESOR -----------------------------------
-------------------------------------------------------------------------------------




--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS LISTAR ASESORES -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarAsesores
AS
BEGIN
    SELECT 
        IDASESOR, 
        NOMBRES, 
        APELLIDOS, 
        USUARIO, 
        CLAVE
    FROM ASESOR
    WHERE ACTIVO = 1 -- Eliminación lógica
    ORDER BY APELLIDOS ASC, NOMBRES ASC;
END
GO



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA INSERTAR ASESOR -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_InsertarAsesor
(
    @NOMBRES VARCHAR(20),
    @APELLIDOS VARCHAR(20),
    @CLAVE VARCHAR(30),
    @USUARIO VARCHAR(20)
)
AS
BEGIN
    INSERT INTO ASESOR (NOMBRES, APELLIDOS, CLAVE, USUARIO)
    VALUES (@NOMBRES, @APELLIDOS, @CLAVE, @USUARIO);
END
GO



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA ACTUALIZAR ASESOR -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ActualizarAsesor
(
    @IDASESOR INT,
    @NOMBRES VARCHAR(20),
    @APELLIDOS VARCHAR(20),
    @CLAVE VARCHAR(30),
    @USUARIO VARCHAR(20)
)
AS
BEGIN
    UPDATE ASESOR
    SET NOMBRES = @NOMBRES,
        APELLIDOS = @APELLIDOS,
        CLAVE = @CLAVE,
        USUARIO = @USUARIO
    WHERE IDASESOR = @IDASESOR;
END
GO

--------------------------------------------------------------------------------------------------------------
----------------------------------- PROCEDIMIENTOS PARA ELIMINAR ASESOR---------------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_EliminarAsesor
(
    @IDASESOR INT
)
AS
BEGIN
    -- Se comenta la validación de integridad referencial ya que solo se cambiará el estado
    /*
    IF EXISTS (SELECT 1 FROM CONTROL_ACCESOS WHERE IDASESOR = @IDASESOR)
    BEGIN
        RAISERROR('No se puede eliminar el asesor porque ya tiene registros de acceso asociados.', 16, 1);
        RETURN;
    END
    */

    UPDATE ASESOR SET ACTIVO = 0 WHERE IDASESOR = @IDASESOR; -- Eliminación lógica
END
GO



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA BUSCAR ASESOR------ -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_BuscarAsesor
(
    @TEXTO VARCHAR(50)
)
AS
BEGIN
    SELECT 
        IDASESOR, 
        NOMBRES, 
        APELLIDOS, 
        USUARIO, 
        CLAVE
    FROM ASESOR
    WHERE ACTIVO = 1 AND (NOMBRES LIKE '%' + @TEXTO + '%'
       OR APELLIDOS LIKE '%' + @TEXTO + '%'
       OR USUARIO LIKE '%' + @TEXTO + '%')
    ORDER BY APELLIDOS ASC, NOMBRES ASC;
END
GO




-------------------------------------------------------------------------------------
----------------- PROCEDIMIENTOS CRUD PARA SOCIOS -----------------------------------
-------------------------------------------------------------------------------------

-- Nota: El insertar socio ya existe (sp_Registrar_Socio)




--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA LISTAR SOCIOS------------------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarSocios
AS
BEGIN
    SELECT 
        S.IDSOCIO, 
        S.DNI, 
        S.NOMBRES, 
        S.APELLIDOS, 
        S.FECHA_NACIMIENTO, 
        S.SEXO, 
        S.TELEFONO, 
        S.IDZONA,
        Z.DESCRIPCION AS ZONA_DESCRIPCION,
        M.FECHA_INICIO, 
        M.FECHA_FIN
    FROM SOCIOS S
    INNER JOIN ZONA Z ON S.IDZONA = Z.IDZONA
    OUTER APPLY (
        SELECT TOP 1 FECHA_INICIO, FECHA_FIN
        FROM MEMBRESIA
        WHERE IDSOCIO = S.IDSOCIO
        ORDER BY IDMEMBRESIA DESC
    ) M
    WHERE S.ACTIVO = 1 -- Eliminación lógica
    ORDER BY S.APELLIDOS ASC, S.NOMBRES ASC;
END
GO



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA ACTUALIZAR SOCIO -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ActualizarSocio
(
    @IDSOCIO INT,
    @DNI VARCHAR(10),
    @NOMBRES VARCHAR(20),
    @APELLIDOS VARCHAR(20),
    @FECHA_NACIMIENTO DATE,
    @SEXO VARCHAR(10),
    @TELEFONO VARCHAR(30),
    @IDZONA INT,
    @FECHA_INICIO DATE,
    @FECHA_FIN DATE
)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE SOCIOS
        SET DNI = @DNI,
            NOMBRES = @NOMBRES,
            APELLIDOS = @APELLIDOS,
            FECHA_NACIMIENTO = @FECHA_NACIMIENTO,
            SEXO = @SEXO,
            TELEFONO = @TELEFONO,
            IDZONA = @IDZONA
        WHERE IDSOCIO = @IDSOCIO;

        UPDATE MEMBRESIA
        SET FECHA_INICIO = @FECHA_INICIO,
            FECHA_FIN = @FECHA_FIN
        WHERE IDSOCIO = @IDSOCIO;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO





--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA ELIMINAR SOCIO ----------------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_EliminarSocio
(
    @IDSOCIO INT
)
AS
BEGIN    
    UPDATE SOCIOS SET ACTIVO = 0 WHERE IDSOCIO = @IDSOCIO; -- Eliminación lógica
END
GO





--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA BUSCAR SOCIO -----------------------------------
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_BuscarSocio
(
    @TEXTO VARCHAR(50)
)
AS
BEGIN
    SELECT 
        S.IDSOCIO, 
        S.DNI, 
        S.NOMBRES, 
        S.APELLIDOS, 
        S.FECHA_NACIMIENTO, 
        S.SEXO, 
        S.TELEFONO, 
        S.IDZONA,
        Z.DESCRIPCION AS ZONA_DESCRIPCION,
        M.FECHA_INICIO, 
        M.FECHA_FIN
    FROM SOCIOS S
    INNER JOIN ZONA Z ON S.IDZONA = Z.IDZONA
    OUTER APPLY (
        SELECT TOP 1 FECHA_INICIO, FECHA_FIN
        FROM MEMBRESIA
        WHERE IDSOCIO = S.IDSOCIO
        ORDER BY IDMEMBRESIA DESC
    ) M
    WHERE S.ACTIVO = 1 AND (S.DNI LIKE '%' + @TEXTO + '%'
       OR S.NOMBRES LIKE '%' + @TEXTO + '%'
       OR S.APELLIDOS LIKE '%' + @TEXTO + '%')
    ORDER BY S.APELLIDOS ASC, S.NOMBRES ASC;
END
GO



--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA VALIDAR AL BUSCAR SOCIO EN RENOVACION -----------------------------------
--------------------------------------------------------------------------------------------------------------
-- Evitar que un socio eliminado lógicamente aparezca para renovar membresía
CREATE PROCEDURE sp_BuscarSocioRenova
    @p_dni VARCHAR(10)
AS
BEGIN
    SELECT 
      s.IDSOCIO,
      s.DNI,
      s.APELLIDOS,
      s.NOMBRES,
      m.FECHA_INICIO,
      m.FECHA_FIN, 
      CASE   
        WHEN m.FECHA_FIN >= CAST(GETDATE() AS DATE)
            THEN 'Activo'
        ELSE 'Vencido'
      END AS ESTADO
    FROM SOCIOS s
    INNER JOIN MEMBRESIA m
        ON s.IDSOCIO = m.IDSOCIO
    WHERE S.DNI = @p_dni AND S.ACTIVO = 1; -- Eliminación lógica
END
GO


--------------------------------------------------------------------------------------------------------------
---------------------------------- PROCEDIMIENTOS PARA VALIDAR AL BUSCAR SOCIO EN INGRESO -----------------------------------
--------------------------------------------------------------------------------------------------------------
-- Evitar que un socio eliminado lógicamente pueda marcar ingreso al gimnasio
CREATE PROCEDURE sp_BuscarSocioIngreso
(
    @DNI VARCHAR(10)
)
AS
BEGIN
    SELECT TOP 1
        S.IDSOCIO,
        S.NOMBRES,
        S.APELLIDOS,
        Z.DESCRIPCION AS ZONA,
        CASE
            WHEN M.FECHA_FIN >= CAST(GETDATE() AS DATE)  
                THEN 'ACTIVO'
            ELSE 'VENCIDO'
        END AS ESTADO,
        S.IDZONA
    FROM SOCIOS S
    INNER JOIN ZONA Z
        ON S.IDZONA = Z.IDZONA
    INNER JOIN MEMBRESIA M
        ON S.IDSOCIO = M.IDSOCIO
    WHERE S.DNI = @DNI AND S.ACTIVO = 1 -- Eliminación lógica
    ORDER BY M.FECHA_FIN DESC; 
END
GO
