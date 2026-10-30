-------------------------------------------------------------------------------------
-----------------PROCEDIMIENTO PARA REGISTRAR SOCIO----------------------------------
-------------------------------------------------------------------------------------
	CREATE PROCEDURE sp_Registrar_Socio  --abad
(
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
        INSERT INTO SOCIOS
        (
            DNI,
            NOMBRES,
            APELLIDOS,
            FECHA_NACIMIENTO,
            SEXO,
            TELEFONO,
            IDZONA
        )
        VALUES
        (
            @DNI,
            @NOMBRES,
            @APELLIDOS,
            @FECHA_NACIMIENTO,
            @SEXO,
            @TELEFONO,
            @IDZONA
        );

        DECLARE @IDSOCIO INT;

        SET @IDSOCIO = SCOPE_IDENTITY();

        INSERT INTO MEMBRESIA
        (
            IDSOCIO,
            FECHA_INICIO,
            FECHA_FIN
        )
        VALUES
        (
            @IDSOCIO,
            @FECHA_INICIO,
            @FECHA_FIN
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-------------------------------------------------------------------------------------
------PROCEDIMIENTO PARA CARGAR LA ZONA EN EL FORMULARIO DE REGISTRO SOCIOS----------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_CargarZona --abad
AS
BEGIN
    SELECT
        IDZONA,
        DESCRIPCION
    FROM ZONA
END
GO
-------------------------------------------------------------------------------------
------PROCEDIMIENTO PARA  FILTRAR LA DUPLICIDAD DE DNI EN EL REGISTRO DE SOCIOS-----
-------------------------------------------------------------------------------------

CREATE PROCEDURE SP_EXISTE_DNI --abad
(
    @DNI VARCHAR(10)
)
AS
BEGIN
    SELECT COUNT(*) 
    FROM SOCIOS
    WHERE DNI = @DNI
END
GO

-------------------------------------------------------------------------------------
-----PROCEDIMIENTO PARA BUSCAR SOCIO EN EL FORMULARIO DE RENOVACION MEMBRESIA--------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_BuscarSocioRenova  --abad
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
    WHERE S.DNI = @p_dni;
END
GO

-------------------------------------------------------------------------------------
-------------PROCEDIMIENTO PARA GUARDAR NUEVA MEMBRESIA EN RENOVACION----------------
-------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Renovar_Membresia --abad
(
    @IDSOCIO INT,
    @FECHA_INICIO DATE,
    @FECHA_FIN DATE
)
AS
BEGIN

    INSERT INTO MEMBRESIA
    (
        IDSOCIO,
        FECHA_INICIO,
        FECHA_FIN
    )
    VALUES
    (
        @IDSOCIO,
        @FECHA_INICIO,
        @FECHA_FIN
    );

END
GO


--------------------------------CASILLEROS--------------------------------------
-------------------------------------------------------------------------------------
----------- PROCEDIMIENTO PARA LISTAR CASILLEROS POR ZONA --------------------------MODIFICAR 29/06
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarCasilleros --abad
(
    @IDZONA INT
)
AS
BEGIN

    SELECT
        C.IDCASILLERO,
        C.IDZONA,
        C.IDESTADO_ACTUAL_CASILLEROS,
        C.NUMERO_CASILLERO,
        Z.DESCRIPCION AS ZONA,
        E.DESCRIPCION AS ESTADO_CASILLERO

    FROM CASILLEROS C
    INNER JOIN ZONA Z
    ON C.IDZONA = Z.IDZONA
    INNER JOIN ESTADO_ACTUAL_CASILLEROS E
    ON C.IDESTADO_ACTUAL_CASILLEROS =
       E.IDESTADO_ACTUAL_CASILLEROS
    WHERE C.IDZONA = @IDZONA AND ACTIVO = 1
    ORDER BY C.NUMERO_CASILLERO ASC;


END
GO

-------------------------------------------------------------------------------------
--------PROCEDIMIENTO PARA MOSTRAR LOS CASILLEROS EN FRM DISTRIBUCION ZONAS----------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_ListarCasillerosPorZona --abad
(
    @IDZONA INT
)
AS
BEGIN

    SELECT
        C.IDCASILLERO,
        C.NUMERO_CASILLERO,
        C.IDZONA,
        C.IDESTADO_ACTUAL_CASILLEROS,
        E.DESCRIPCION AS ESTADO
    FROM CASILLEROS C
    INNER JOIN ESTADO_ACTUAL_CASILLEROS E
        ON C.IDESTADO_ACTUAL_CASILLEROS = E.IDESTADO_ACTUAL_CASILLEROS
    WHERE C.IDZONA = @IDZONA AND ACTIVO = 1
    ORDER BY C.NUMERO_CASILLERO;

END
GO

-------------------------------------------------------------------------------------
-----------PROCEDIMIENTO PARA AGREGAR CASILLEROS EN FRM DISTRIBUCION ZONAS-----------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_AgregarCasillero --abad
(
    @IDZONA INT
)
AS
BEGIN

    DECLARE @NUMERO INT;

    SELECT
        @NUMERO = ISNULL(MAX(NUMERO_CASILLERO),0) + 1
    FROM CASILLEROS
    WHERE IDZONA = @IDZONA;

    INSERT INTO CASILLEROS
    (
        IDZONA,
        IDESTADO_ACTUAL_CASILLEROS,
        NUMERO_CASILLERO
    )
    VALUES
    (
        @IDZONA,
        1,
        @NUMERO
    );

END
GO


-------------------------------------------------------------------------------------
-----------PROCEDIMIENTO PARA ELIMINAR CASILLEROS EN FRM DISTRIBUCION ZONAS-----------MODIFICAR 29/06
-------------------------------------------------------------------------------------

CREATE PROCEDURE sp_EliminarCasillero  --abad
(
    @IDCASILLERO INT
)
AS
BEGIN
    
    IF EXISTS
    (
        SELECT 1
        FROM CASILLEROS
        WHERE IDCASILLERO=@IDCASILLERO
        AND IDESTADO_ACTUAL_CASILLEROS <> 1
        AND ACTIVO = 1
    )
    BEGIN

        RAISERROR('No se puede eliminar un casillero ocupado o en mantenimiento.',16,1);
        RETURN;
    END

    UPDATE CASILLEROS
    SET ACTIVO = 0
    WHERE IDCASILLERO=@IDCASILLERO
    AND ACTIVO = 1;

END
GO


-------------------------------------------------------------------------------------
----------------------IINSERTAR VALOR A  USUARIO EN LA TABLA ASESOR-------------
-------------------------------------------------------------------------------------
INSERT INTO ASESOR VALUES ('Juan José', 'Ramirez Gonzales','1234', 'jjramirez')



-------------------------------------------------------------------------------------
------------------------PROCEDIMIENTO DE LOGIN ASESOR--------------------------------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_Login  --abad
(
    @Usuario VARCHAR(20),
    @Password VARCHAR(30)
)
AS
BEGIN
    SELECT *
    FROM ASESOR
    WHERE USUARIO = @Usuario
      AND CLAVE = @Password
      AND ACTIVO = 1
END
GO


-------------------------------------------------------------------------------------
-------------PROCEDIMIENTO DE MARCACION DE INGRESOS VAN CONTROL DE ACCESOS-----------
-------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------
-----------PROCEDIMIENTO PARA BUSCAR AL SOCIO EN MARCACION INGRESOS------------------
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_BuscarSocioIngreso  --abad
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
            WHEN M.FECHA_FIN >= CAST(GETDATE() AS DATE)  ---ESTO ES PARA MOSTRAR EN EL TEXTBOX DE ESTADO SI ES MEMBRESIA ACTIVA O VENCIDA
                THEN 'ACTIVO'
            ELSE 'VENCIDO'
        END AS ESTADO,
        S.IDZONA

    FROM SOCIOS S
    INNER JOIN ZONA Z
        ON S.IDZONA = Z.IDZONA

    INNER JOIN MEMBRESIA M
        ON S.IDSOCIO = M.IDSOCIO

    WHERE S.DNI = @DNI

    ORDER BY M.FECHA_FIN DESC; -- AQUI ES PARA QUE BUSQUE LA MEMBRESIA MAS ACTUAL, YA QUE VAMOS A A RENOVAR MEMBRESIAS

END
GO


-------------------------------------------------------------------------------------
-----------PROCEDIMIENTO PARA CHAPAR EL 1ER CASILLERO VACIO PARA ASIGNAR-------------
-------------------------------------------------------------------------------------

CREATE PROCEDURE sp_ObtenerPrimerCasilleroLibre  --abad
(
    @IDZONA INT
)
AS
BEGIN

    SELECT TOP 1
        IDCASILLERO,
        NUMERO_CASILLERO
    FROM CASILLEROS
    WHERE IDZONA = @IDZONA
      AND IDESTADO_ACTUAL_CASILLEROS = 1 --- 1 es el estado de libre
    ORDER BY NUMERO_CASILLERO;

END
GO


-------------------------------------------------------------------------------------
------------------------PROCEDIMIENTO PARA REGISTRAR EL INGRESO----------------------
-------------------------------------------------------------------------------------

CREATE PROCEDURE sp_RegistrarIngreso  --abad
(
    @IDSOCIO INT,
    @IDCASILLERO INT,
    @IDASESOR INT
)
AS
BEGIN

    BEGIN TRANSACTION;

    BEGIN TRY
         IF EXISTS
            (
                SELECT 1
                FROM CONTROL_ACCESOS
                WHERE IDSOCIO = @IDSOCIO
                  AND HORA_SALIDA IS NULL ---- ACA VALIDAMOS PARA VER SI EL SOCIO YA TIENE UN INGRESO ACTIVO Y NO MARQUE 2 INGRESOS
            )
            BEGIN
                RAISERROR('El socio ya tiene un ingreso activo.',16,1);
                RETURN;
            END

        INSERT INTO CONTROL_ACCESOS
        (
            IDSOCIO,
            IDCASILLERO,
            IDASESOR,
            FECHA,
            HORA_INGRESO
        )
        VALUES
        (
            @IDSOCIO,
            @IDCASILLERO,
            @IDASESOR,
            CAST(GETDATE() AS DATE),
            CAST(GETDATE() AS TIME)
        );

        UPDATE CASILLEROS
        SET IDESTADO_ACTUAL_CASILLEROS = 2
        WHERE IDCASILLERO = @IDCASILLERO;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END
GO
