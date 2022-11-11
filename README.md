### Connection String Scaffold DB EF

dotnet ef dbcontext scaffold "server=zhacark.mysql.database.azure.com; port=3306; user=userSITHEC; password=SITHEC; database=sithec" Mysql.EntityFrameworkCore -o ModelDB -c exContext -t humano -f --no-onconfiguring --no-pluralize

### API examen SITHEC
A continuación se muestran los request para el correcto funcionamiento de la api.


### API tipo GET que retorne un arreglo de objetos de tipo "HUMANO", esta información sera mock
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home 
    [GET Mock][get-mock]
### API tipo POST que se envíen 3 argumentos para la realización de una operación matemática y retorne el resultado
    Realizar petición POST utilizando la url https://apihumano.azurewebsites.net/Home 
    [Request POST Operación][post-operacion]
### API tipo GET que reciba 3 argumentos Headers para la realización de una operación matemática y retorne el resultado
    Realizar petición GET utilizando la url https://apihumano.azurewebsites.net/Home/GetHeader 
    [Request GET Operación][get-operacion]
### Creación de migración para una base de datos con tabla humanos

### API tipo GET para traer toda la tabla de humanos
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home/GetAll
    [Request GET Humanos][get-all]
### API tipo GET para traer un humano en especifico
    Realizar petición GET  utilizando la url https://apihumano.azurewebsites.net/Home/GetSingle
    [Request GET Humano][get-single]
### API tipo POST para crear un humano
    Realizar petición POST  utilizando la url https://apihumano.azurewebsites.net/Home/Add
    [Request POST humano][post-humano]
### API tipo PUT para editar un humano
    Realizar petición PUT  utilizando la url https://apihumano.azurewebsites.net/Home
    [Request PUT humano][put-humano]

### NOTAS
    - El tipo humano debe de tener de atributos: Id, Nombre, Sexo, Edad, Altura y Peso
    - Lost tipos de operaciones erán básicas; suma, resta, multiplicación y división.

[get-mock]: https://drive.google.com/file/d/14PB3xlf3bWzRTWp-L6hH4NIs3rOnlMiy/view?usp=share_link
[post-operacion]: https://drive.google.com/file/d/1mCkGmwFcIHj-VETZ1Vt5Y49X6QhPg4xC/view?usp=share_link
[get-operacion]: https://drive.google.com/file/d/1ny8eXHYxyfFxdUBcAeDtvNzCik_FQgjC/view?usp=share_link
[get-all]: https://drive.google.com/file/d/1gJngX_IFUy2XS82rTSct_TamCtBUU7Jg/view?usp=share_link
[get-single]: https://drive.google.com/file/d/1CbvAWeJkJMgL-nfMgzCUFoxW1VTafuTy/view?usp=share_link
[post-humano]: https://drive.google.com/file/d/17ZFwLuc-_RdGdGUhM5q8lO2sL-uAWc1I/view?usp=share_link
[put-humano]: https://drive.google.com/file/d/1FdlmQIe0P5PFwtNo_Kny4yhNhQxSfdth/view?usp=share_link
