# Intcomex - Prueba técnica - Desarrollador de software

La documentación de la api se encuentra en swagger, para visualizarla se debe ingresar al endpoint url_de_la_api/swagger

La aplicación esta desarrollada con asp.net core 7.0 y se usó una arquitectura de capas para separar la lógica del negocio,
el acceso a datos y la comunicación con estos.

## Instalación de la api

1. Compilar el proyecto para que se descarguen los paquetes nuget requeridos
2. En archivo de configuraciones appsettings.json especificar en la sección ConnectionStrings en el campo "sqlServerAzure" la respectiva información de conexión a la base de datos
3. En archivo de configuraciones appsettings.json especificar en el campo jwtkey una cadena no menor a 100 caracteres que se usará como llave de encripción de los token de autenticación
4. Publicar la aplicación en el servidor
