-------------------------------------------------------------------------------------
-----------------------BASE DE DATOS DE GYMTRACK-------------------------------------
-------------------------------------------------------------------------------------
	
	Create DATABASE GYMTRACKFINAL;
	GO

	USE GYMTRACKFINAL;
	GO

-------------------------------------------------------------------------------------
--------------------------------TABLA ZONA-------------------------------------------
-------------------------------------------------------------------------------------
		
	CREATE TABLE ZONA(
	IDZONA INT IDENTITY(1,1) PRIMARY KEY,
	DESCRIPCION VARCHAR(30)NOT NULL
	);
	GO
-------------------------------------------------------------------------------------
-----------------------TABLA ESTADO ACTUAL DE CASILLEROS-----------------------------
-------------------------------------------------------------------------------------

	CREATE TABLE ESTADO_ACTUAL_CASILLEROS(
	IDESTADO_ACTUAL_CASILLEROS INT IDENTITY(1,1) PRIMARY KEY,
	DESCRIPCION VARCHAR(30)NOT NULL
	);
	GO
-------------------------------------------------------------------------------------
-----------------------TABLA SOCIOS-------------------------------------
-------------------------------------------------------------------------------------

	CREATE TABLE SOCIOS(
	IDSOCIO INT IDENTITY(1,1) PRIMARY KEY,		
	DNI VARCHAR(10) UNIQUE NOT NULL,
	NOMBRES VARCHAR (20)NOT NULL,
	APELLIDOS VARCHAR(20)NOT NULL,
	FECHA_NACIMIENTO DATE NOT NULL,
	SEXO VARCHAR (10) NOT NULL,
	TELEFONO VARCHAR (30) NOT NULL,
    ACTIVO BIT NOT NULL DEFAULT 1,
	IDZONA INT NOT NULL,

	CONSTRAINT FK_SOCIOS_ZONA
		FOREIGN KEY (IDZONA) 
		REFERENCES ZONA(IDZONA)

	);
	GO


-------------------------------------------------------------------------------------
-----------------------TABLA ASESOR-------------------------------------
-------------------------------------------------------------------------------------
	CREATE TABLE ASESOR(
	IDASESOR INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRES VARCHAR (20) NOT NULL,
	APELLIDOS VARCHAR (20) NOT NULL,
	CLAVE VARCHAR (30) NOT NULL,
    ACTIVO BIT NOT NULL DEFAULT 1,
    USUARIO VARCHAR (20) NOT NULL
	);
	GO

-------------------------------------------------------------------------------------
-----------------------TABLA CASILLEROS-------------------------------------
-------------------------------------------------------------------------------------

	CREATE TABLE CASILLEROS(
	IDCASILLERO INT IDENTITY(1,1) PRIMARY KEY,
	IDZONA INT FOREIGN KEY REFERENCES ZONA(IDZONA),
	IDESTADO_ACTUAL_CASILLEROS INT NOT NULL FOREIGN KEY REFERENCES ESTADO_ACTUAL_CASILLEROS(IDESTADO_ACTUAL_CASILLEROS),
	NUMERO_CASILLERO INT NOT NULL ,
    ACTIVO bit not null default 1
	);
	GO

    ALTER TABLE CASILLEROS 
    ADD CONSTRAINT UQ_CASILLERO_ZONA
    UNIQUE(IDZONA, NUMERO_CASILLERO);
    GO

 
-------------------------------------------------------------------------------------
-----------------------TABLA MEMBRESIA-------------------------------------
-------------------------------------------------------------------------------------
    	
	CREATE TABLE MEMBRESIA(
    IDMEMBRESIA INT IDENTITY(1,1) PRIMARY KEY,
    IDSOCIO INT NOT NULL FOREIGN KEY REFERENCES SOCIOS(IDSOCIO),
    FECHA_INICIO DATE NOT NULL,
    FECHA_FIN DATE NOT NULL 
    );
	GO

-------------------------------------------------------------------------------------
-----------------------TABLA TURNO DE ASESOR-------------------------------------
-------------------------------------------------------------------------------------
	CREATE TABLE TURNO(
    IDTURNO INT IDENTITY(1,1) PRIMARY KEY,
    IDASESOR INT NOT NULL FOREIGN KEY REFERENCES ASESOR(IDASESOR) ,
    FECHA DATE NOT NULL,
    HORA_INICIO DATETIME NOT NULL,
    HORA_FIN DATETIME NULL
	);
	GO

-------------------------------------------------------------------------------------
-----------------------TABLA CONTROL DE ACCESOS-------------------------------------
-------------------------------------------------------------------------------------

	CREATE TABLE CONTROL_ACCESOS(
	ID_ACCESO INT IDENTITY (1,1) PRIMARY KEY,
	IDSOCIO INT NOT NULL FOREIGN KEY REFERENCES SOCIOS(IDSOCIO) ,
	IDCASILLERO INT NOT NULL FOREIGN KEY REFERENCES CASILLEROS(IDCASILLERO)  ,
	IDASESOR INT   NOT NULL  FOREIGN KEY REFERENCES ASESOR(IDASESOR),
	FECHA DATE NOT NULL,
	HORA_INGRESO TIME NOT NULL,
	HORA_SALIDA TIME  NULL	
	);
	GO
	select * from CONTROL_ACCESOS
	-------------------------------------------------------------------------------------
	-----------------------TABLA CONFIGURACION DEL SISTEMA---------------------------
	-------------------------------------------------------------------------------------

	CREATE TABLE CONFIGURACION_SISTEMA(
    IDCONFIGURACION_SISTEMA INT IDENTITY(1,1) PRIMARY KEY,

    NOMBRE_GIMNASIO VARCHAR(100) ,
    DIRECCION VARCHAR(200),
    TELEFONO VARCHAR(20),

    HORA_APERTURA TIME,
    HORA_CIERRE TIME,

    TIEMPO_MAXIMO_ESTANCIA INT
	);

-------------------------------------------------------------------------------------
-----------------------INSERCION DE DATOS EN LA TABLA ZONA---------------------------
-------------------------------------------------------------------------------------

	INSERT INTO ZONA VALUES ('Varones')
	INSERT INTO ZONA VALUES ('Mujeres')

	SELECT * FROM ZONA

-------------------------------------------------------------------------------------
--------------INSERCION DE DATOS EN LA TABLA estado actual casilleros----------------
-------------------------------------------------------------------------------------

    INSERT INTO ESTADO_ACTUAL_CASILLEROS VALUES ('Libre')
    INSERT INTO ESTADO_ACTUAL_CASILLEROS VALUES ('Ocupado')
    INSERT INTO ESTADO_ACTUAL_CASILLEROS VALUES ('Mantenimiento')

    select * from ESTADO_ACTUAL_CASILLEROS
	
--------------------------------------------

select *  from MEMBRESIA
select * from ZONA
select * from CASILLEROS
select * from ASESOR
select * from CONTROL_ACCESOS
select * from SOCIOS

insert into CONTROL_ACCESOS values (1,1,2,'2026-06-24','07:00:00','09:17:00')

SELECT * FROM ZONA

