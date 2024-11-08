# Finaktiva (Prueba Tecnica Backend) Daniel Stiven Londoño Ortega daniel.londono.ortega@gmail.com
Prueba Tecnica

#Recursos

- Arquitectura Hexagonal
- DDD
- EntityFramework Code First
- Inyeccion de Dependencias
- Patron Repositorio
- AutoMapper
- FluentValidation - Middleware para validar en la capa Api y tener control de las expeciones.
- Swagger
- .Net 6
- SqlServer
- Angular 18
- PrimeNg - Se utilizaron los componentes de PrimeNg para un mejor diseño
- Signal R - Libreria para comunicar desde el servidor al cliente y poder mantener la tabla de EventLogs Actualizada.

Se diseñaron 2 tablas, la imagen del modelo se subio en el respositorio. 
Una tabla para manejar los EventLogs y la segunda para manejar los Tipos de EventLogs(Api, Formulario) TypeEventLogs

#¡Recomendaciones Importante!

.Net:

1. Restaurar paquetes de NuGet
2. Cambiar cadena de conexion a la base de datos SQL en appsettings.json ("FinaktivaBDConnection")
3. Crear Base de Datos con el nombre de "Registration"
4. Abrir Consola y seleccionar proyecto de infraestructura
5. Inicializar EntityFramework - Add-Migration
6. Realizar despliegue a la base de datos - Update-database

Angular:

1. Npm Install
2. Ng serve -o

Adjunto Video 
https://www.loom.com/share/2ae470e67e8d4ded9ddd5d40abc2368c
