# GymTrack — Sistema de Gestión de Gimnasio

Sistema de escritorio desarrollado en C# para gestionar las operaciones principales de un gimnasio, incluyendo el registro de socios, la renovación de membresías, el control de ingresos y la administración de casilleros.

# Descripción del proyecto

GymTrack permite centralizar la información de los socios y facilitar las tareas operativas del personal del gimnasio mediante una interfaz gráfica conectada a una base de datos en SQL Server.

El proyecto fue desarrollado como parte de un trabajo académico en equipo, aplicando programación orientada a objetos, acceso a datos y consultas mediante procedimientos almacenados.

# Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8
- **Interfaz gráfica:** Windows Forms
- **Base de datos:** Microsoft SQL Server
- **Acceso a datos:** ADO.NET
- **Lenguaje SQL:** T-SQL
- **Entorno de desarrollo:** Visual Studio

# Funcionalidades principales

- **Gestión de socios:** registro y consulta de información de los socios.
- **Renovación de membresías:** registro de renovaciones para los socios.
- **Control de ingreso:** verificación de la membresía para gestionar el acceso al gimnasio.
- **Gestión de casilleros:** administración de casilleros y sus estados de disponibilidad.
- **Organización por zonas:** clasificación de casilleros según las zonas configuradas.
- **Administración de información:** interacción entre los formularios y la base de datos mediante operaciones SQL.

# Arquitectura y acceso a datos

El proyecto organiza la interfaz de usuario, la lógica de las operaciones y el acceso a la base de datos mediante componentes diferenciados.

- **Presentación:** formularios de Windows Forms para la interacción con el usuario.
- **Acceso a datos:** conexión y ejecución de consultas y procedimientos almacenados mediante ADO.NET.
- **Base de datos:** tablas relacionadas mediante claves primarias y foráneas para mantener la integridad de la información.
- **Procedimientos almacenados:** centralización de operaciones de consulta y registro en SQL Server.

# Base de datos

La base de datos contiene las estructuras necesarias para administrar socios, membresías, zonas, casilleros y estados relacionados con su disponibilidad.

Los scripts SQL incluidos en el repositorio permiten consultar la estructura de la base de datos y preparar el entorno para ejecutar el sistema.

# Mi contribución

En este proyecto académico realizado en equipo, mis principales responsabilidades fueron:

- Diseñar la estructura de la base de datos y las relaciones entre sus tablas.
- Diseñar los formularios de la aplicación.
- Programar el formulario de registro de socios.
- Desarrollar el formulario de renovación de membresías.
- Implementar el formulario para marcar el ingreso de socios.
- Desarrollar funcionalidades relacionadas con las zonas y los casilleros.

# Instalación y ejecución

1. Clonar o descargar este repositorio.
2. Abrir la solución del proyecto en Visual Studio.
3. Ejecutar los scripts SQL incluidos en el repositorio para preparar la base de datos.
4. Revisar la cadena de conexión y adaptarla a la instancia local de SQL Server.
5. Restaurar las dependencias necesarias y compilar la solución.
6. Ejecutar la aplicación desde Visual Studio.

> Los nombres de la base de datos, el orden de ejecución de los scripts y la configuración de conexión deben corresponder a los archivos incluidos en el repositorio.

# Capturas de pantalla


![Formulario Login](imagenes/image.png)   
![Formulario Registrar Socico](imagenes/image-1.png) 
![Formulario Renovación de Membresías](imagenes/image-2.png)
![Formulario Marcación de Ingreso de Socios](imagenes/image-3.png)
![Formulario Distribución de Casilleros por Zonas](imagenes/image-4.png)


# Objetivo del proyecto

Aplicar conocimientos de programación orientada a objetos, desarrollo de aplicaciones de escritorio, diseño de bases de datos relacionales y acceso a datos con C# y SQL Server.

---

**Proyecto académico | Portafolio de desarrollo de software**