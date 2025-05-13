Descripción del Proyecto
Este proyecto ha sido desarrollado utilizando .NET 8 con una arquitectura centrada en el dominio, combinando enfoques como Hexagonal, Clean y Onion Architecture. Su principal objetivo es proporcionar un sistema CRUD (Create, Read, Update, Delete) para productos, expuesto a través de una API RESTful.

Requisitos Previos para Iniciar el Proyecto
Para poner en marcha este microservicio, se debe crear una base de datos en SQL Server y configurar las credenciales en el archivo appsettings.json. Luego, es necesario ejecutar el siguiente comando en la Package Manager Console, seleccionando el proyecto Infrastructure:

bash
Copiar
Editar
Update-Database
Este comando aplicará las migraciones definidas en el proyecto, creando automáticamente las tablas necesarias en la base de datos.

Patrones de Diseño y Arquitectura Implementados
El proyecto sigue los principios de Clean Architecture, que buscan lograr aplicaciones altamente modulares, desacopladas y fáciles de mantener. Esto se logra mediante la separación clara de responsabilidades en diferentes capas:

Dominio (Domain)

Contiene las entidades del negocio, objetos de valor, agregados y servicios de dominio.

Es completamente independiente de las tecnologías externas, promoviendo un diseño centrado en la lógica del negocio.

Aplicación (Application)

Incluye la lógica de orquestación, como comandos, queries y servicios de aplicación.

Define contratos mediante interfaces para repositorios y servicios de dominio, promoviendo un alto grado de desacoplamiento.

Infraestructura (Infrastructure)

Maneja la conexión con servicios externos, bases de datos y otros recursos del sistema.

Incluye adaptadores, configuraciones de contexto, repositorios y servicios externos.

Interfaz de Usuario / API (API)

Punto de entrada para las solicitudes de usuarios y otros sistemas.

Exposición de endpoints RESTful para interactuar con el dominio y la capa de aplicación.

Especificaciones Técnicas del Proyecto
Framework: .NET 8 (uso de top-level statements, minimal APIs, mapGroup para agrupar endpoints, global usings y records).

Inyección de Dependencias: Uso de anotaciones para servicios y repositorios (Application.Service para servicios y Infrastructure.Repository para repositorios).

Entity Framework Core 8 (SQL Server): Patrón Code-First para crear esquemas de base de datos automáticamente.

Documentación: Uso de Swagger para generar documentación automática de los endpoints expuestos.

Estructura del Proyecto
El proyecto sigue una estructura modular para facilitar su mantenimiento y escalabilidad:

1. Infrastructure (Mantenimiento de datos y conectividad externa)
Data: Configuración del contexto de la base de datos, conexiones y entidades persistentes.

Configurations: Ajustes específicos para la conexión a bases de datos.

ExternalServices: Conexión con servicios externos, como APIs de terceros.

Migrations: Archivos que definen cambios en el esquema de la base de datos.

Repositories: Implementaciones de repositorios para acceder a los datos.

2. Domain (Núcleo del negocio)
Entities: Clases que representan las entidades del dominio (por ejemplo, Comic, User).

ValueObjects: Objetos que definen valores específicos del dominio (por ejemplo, ID, Direcciones).

Enums: Enumeraciones que representan estados específicos del negocio (por ejemplo, roles, categorías).

Exceptions: Excepciones personalizadas para manejar errores del dominio.

3. Application (Lógica de negocio y casos de uso)
DTOs: Objetos para transferir datos entre capas, como UserDto y ComicDto.

Interfaces: Definición de contratos para servicios y repositorios, promoviendo desacoplamiento.

Mappings: Configuración de mapeo entre entidades del dominio y DTOs para simplificar conversiones.

Services: Implementaciones de lógica de negocio que coordinan operaciones entre entidades y repositorios.

4. PruebaTecnicaBack (Punto de entrada a la aplicación)
Controllers: Controladores para exponer la lógica de negocio a través de endpoints RESTful.

Program: Configuración del arranque de la aplicación, incluyendo configuración de servicios y rutas.

Properties: Archivos de configuración, como appsettings.json y responsemessage.json.

5. Tests (Pruebas unitarias e integración)
IntegrationTests: Verificación de la integración entre múltiples componentes del sistema.

Mocks: Objetos simulados para pruebas unitarias y de integración.

UnitTests: Pruebas para validar el comportamiento de unidades individuales de código.

Frontend: Patrones y Estilos de Arquitectura Implementados
Inyección de Dependencias: Uso de inyección automática para gestionar servicios en los componentes.

Rutas Protegidas: Implementación de AuthGuard e interceptores para restringir el acceso a usuarios no autenticados.

Manejo de Estado Local: Uso de localStorage para persistir datos de usuarios autenticados.

Servicios para Lógica de Negocio: Separación de lógica en servicios (AuthService, FavoritesService) para mantener los componentes ligeros y organizados.

Modularización de Estilos: Uso de SCSS para mantener el código limpio y escalable.

Manejo de Errores: Uso de SweetAlert2 para proporcionar una experiencia de usuario más profesional en la gestión de errores.
