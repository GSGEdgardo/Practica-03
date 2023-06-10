Link de repositorio: https://github.com/GSGEdgardo/Practica-03
La aplicación fue desarrollada con .NET core 7 y la base de datos con ServerSQL

Pasos para ejecutar la aplicación:

Lo primero es ver el tema de las dependencias, para eso debe ejecutar el comando:
"dotnet restore" que va a arreglar el problemas de las dependencias.

Luego debe cambiar en el appsettings la conexión con la base de datos (en mi caso utilicé ServerSQL)
debe colocar su servidor y su base de datos en el "DefaultConnection".

Para finalizar debe actualizar las tablas con el comando:
"dotnet ef database update"
Con esto la base de datos está lista porque las migraciones ya vienen incluidas en el proyecto.

Se generaron los 2 endpoints que se solicitaron,

El primero se encuentra en el UserController y es el que despliega los usuarios con su lista de libros
reservado. En mi caso utiliza el url "http://localhost:5296/api/User", acá usted debe cambiar el puerto
al que esté configurado en su pc a la hora de correr la aplicación porque yo tengo configurado el 5296.

El segundo endpoint se encuentra en el BookController y es el que despliega los libros con la lista de 
todos los usuarios que los han reservado, el url usado en este caso es "http://localhost:5296/api/books".

Con eso la API debería funcionar sin problemas.



