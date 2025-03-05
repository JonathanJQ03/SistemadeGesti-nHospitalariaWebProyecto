Sistema de Gestión Hospitalaria

1. Descripción General: Este proyecto es un Sistema de Gestión Hospitalaria desarrollado con ASP.NET Core MVC, diseñado para optimizar la administración de procesos médicos
en un entorno hospitalario teniendo en cuenta todas las variables que entran en un sistema así.

2. Funcionalidades Principales

El sistema permite gestionar:
- Registro y seguimiento de pacientes
- Administración de médicos y las especialidades correspondientes
- Programación y control de citas médicas
- Registro de tratamientos
- Gestión de facturación

3. Características Técnicas

- Arquitectura por capas (Entidad, Datos, Negocio, Presentación)
- Base de datos relacional en SQL Server, con 6 tablas relacionadas entre sí
- Interfaz web responsiva con Bootstrap
- Implementación de seguridad, validación y autenticación
- Uso de Entity Framework Core
- Procedimientos almacenados para operaciones de base de datos en lugar de consultas
- Uso de CNDS extras para implementaciones extras de funcionalidades

4. Módulos del Sistema

a. **Pacientes**: 
   - Registro completo de información personal y médica
   - Consulta y actualización de datos

b. **Médicos**:
   - Gestión de información profesional
   - Asignación de especialidades

c. **Citas Médicas**:
   - Programación de consultas
   - Seguimiento de estado de citas

d. **Tratamientos**:
   - Registro de procedimientos
   - Control de costos de tratamientos

e. **Facturación**:
   - Generación de facturas
   - Registro de pagos

5. Tecnologías Utilizadas

- ASP.NET Core MVC
- Visual Studio 2022
- SQL Server
- Entity Framework Core
- Bootstrap
- JavaScript

6. Despliegue

El proyecto está preparado para desplegarse en la plataforma Somee.com, aprovechando sus recursos gratuitos de hosting.

7. Nota para Desarrolladores

Este sistema fue desarrollado siguiendo estrictos estándares de calidad, con énfasis en:
- Funcionalidad completa
- Interfaz intuitiva
- Código limpio y mantenible
- Buenas prácticas de desarrollo
