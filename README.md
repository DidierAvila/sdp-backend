# SDP Backend

## Descripción del Proyecto

SDP Backend es una API RESTful desarrollada con ASP.NET Core que implementa principios de Clean Architecture, Clean Code y SOLID. El proyecto está diseñado para gestionar datos de clientes, empleados, productos, órdenes y envíos, siguiendo las mejores prácticas de desarrollo de software.

## Arquitectura

El proyecto sigue una arquitectura en capas bien definida:

### Capas principales:

1. **SDP.API**: Capa de presentación que gestiona las solicitudes HTTP.
   - Controllers
   - Middleware
   - Extensions

2. **SDP.Domain**: Capa de dominio que contiene la lógica de negocio.
   - Entities
   - DTOs
   - Interfaces de repositorios
   - Casos de uso (Commands y Queries)
   - Validadores

3. **SDP.Infrastructure**: Capa de infraestructura que implementa las abstracciones definidas en el dominio.
   - Implementaciones de repositorios
   - Contexto de base de datos
   - Servicios externos

4. **SDP.Test**: Pruebas unitarias y de integración.

## Principios SOLID Implementados

1. **Principio de Responsabilidad Única (SRP)**
   - Cada clase tiene un único propósito
   - Separación clara entre API, Dominio e Infraestructura

2. **Principio Abierto/Cerrado (OCP)**
   - Uso de interfaces permite extender sin modificar
   - La estructura de excepciones permite añadir nuevos tipos sin modificar el middleware existente

3. **Principio de Sustitución de Liskov (LSP)**
   - Las implementaciones de repositorios respetan el contrato de sus interfaces
   - Las clases derivadas mantienen el comportamiento esperado

4. **Principio de Segregación de Interfaces (ISP)**
   - Interfaces pequeñas y específicas como `ICustomerQueryHandler`

5. **Principio de Inversión de Dependencias (DIP)**
   - Dependencia de abstracciones en lugar de implementaciones concretas
   - Inyección de dependencias correctamente implementada

## Características Principales

- API RESTful para la gestión de entidades de negocio
- Implementación de CQRS (Command Query Responsibility Segregation)
- Validación de datos con FluentValidation
- Manejo centralizado de errores con middleware especializado
- Documentación automática con Swagger/OpenAPI
- Paginación de resultados
- Configuración CORS para integración con frontend

## Requisitos

- .NET 6.0 o superior
- SQL Server (Express o superior)
- Visual Studio 2022 (recomendado)

## Instalación

1. Clonar el repositorio:
   ```
   git clone https://github.com/DidierAvila/sdp-backend.git
   ```

2. Configurar la cadena de conexión:
   - Abrir `SDP.API/appsettings.json`
   - Modificar la cadena de conexión según su entorno local

3. Ejecutar migraciones de Entity Framework (si aplica):
   ```
   dotnet ef database update
   ```

4. Ejecutar el proyecto:
   ```
   dotnet run --project SDP.API/SDP.API.csproj
   ```

## Uso de la API

Una vez iniciado el servidor, puede acceder a:

- API Endpoints: `https://localhost:5001`
- Documentación Swagger: `https://localhost:5001/index.html`

## Pruebas

Para ejecutar las pruebas:

```
dotnet test
```

## Estructura de Proyecto

```
sdp-backend/
├── SDP.API/
│   ├── Controllers/
│   ├── Extensions/
│   ├── Middleware/
│   └── Program.cs
├── SDP.Domain/
│   ├── Common/
│   ├── Dtos/
│   ├── Entities/
│   ├── Exceptions/
│   ├── Repository/
│   ├── UseCases/
│   └── Validators/
├── SDP.Infrastructure/
│   ├── DbContexts/
│   └── Repository/
└── SDP.Test/
```

## Contribución

1. Fork el repositorio
2. Crea una rama para tu feature: `git checkout -b feature/amazing-feature`
3. Commit tus cambios: `git commit -m 'Add some amazing feature'`
4. Push a la rama: `git push origin feature/amazing-feature`
5. Abre un Pull Request

## Licencia

Este proyecto está licenciado bajo [especificar licencia].

## Contacto

Didier Ávila - [tu email o contacto]

Link del proyecto: [https://github.com/DidierAvila/sdp-backend](https://github.com/DidierAvila/sdp-backend)