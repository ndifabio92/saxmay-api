# Saxmay API

Aplicación para el control y gestion de clientes, deportes, descuentos, cuotas mensuales.

## Tecnologías Utilizadas

El proyecto se construye utilizando las siguientes tecnologías:

- **.NET 8:** La última versión del framework de desarrollo de Microsoft para la creación de aplicaciones en diversas plataformas.
- **.NET Core:** Utilizado para desarrollar APIs RESTful.
- **Entity Framework Core:** ORM utilizado para interactuar con la base de datos SQL Server.
- **.NET Identity:** Utilizado para la autenticación y autorización de usuarios en la aplicación.
- **JWT (JSON Web Tokens):** Utilizado para la autenticación y generación de tokens de acceso.
- **Auth y Roles de .NET Core 8:** Mecanismos integrados para la gestión de autenticación y roles.

## Patrón Repository

Se implementa el patrón Repository para gestionar el acceso a los datos. Se definen interfaces y clases concretas para cada entidad de base de datos, lo que permite una separación clara entre la lógica de negocio y la lógica de acceso a datos.

## Entity Framework Commands with Azure CLI

### Add Migrations

```
dotnet ef migrations add v1.0.0 --project Saxmay.Data/ --startup-project Saxmay.API/ --verbose
```

### Apply Migration

```
dotnet ef database update --project Saxmay.Data/ --startup-project Saxmay.API/ --verbose
```

### Remove Migration

```
dotnet ef migrations remove --project Saxmay.Data/ --startup-project Saxmay.API/ --verbose
```
