### Connection String Scaffold DB EF

dotnet ef dbcontext scaffold "server=zhacark.mysql.database.azure.com; port=3306; user=userSITHEC; password=SITHEC; database=sithec" Mysql.EntityFrameworkCore -o ModelDB -c exContext -t humano -f --no-onconfiguring --no-pluralize

### API examen SITHEC
A continuación se muestran los request para el correcto funcionamiento de la api.


### API tipo GET que retorne un arreglo de objetos de tipo "HUMANO", esta información sera mock
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home
### API tipo POST que se envíen 3 argumentos para la realización de una operación matemática y retorne el resultado
    Realizar petición POST utilizando la url https://apihumano.azurewebsites.net/Home
### API tipo GET que reciba 3 argumentos Headers para la realización de una operación matemática y retorne el resultado
    Realizar petición GET utilizando la url https://apihumano.azurewebsites.net/Home/GetHeader
### Creación de migración para una base de datos con tabla humanos

### API tipo GET para traer toda la tabla de humanos
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home/GetAll
### API tipo GET para traer un humano en especifico
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home/GetSingle
### API tipo POST para crear un humano
    Realizar petición POST  utilizando la url https://apihumano.azurewebsites.net/Home/Add
### API tipo PUT para editar un humano
    Realizar petición PUT  utilizando la url https://apihumano.azurewebsites.net/Home


### NOTAS
    - El tipo humano debe de tener de atributos: Id, Nombre, Sexo, Edad, Altura y Peso
    - Lost tipos de operaciones erán básicas; suma, resta, multiplicación y división.