using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Models;
using Persistence.ModelDB;
using Persistence.UnitOfWork;

using Services;
using Services.Utilities;
using Services.Extensions;

namespace ExamenSITHEC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        string[] nombres = { "Romario", "Nicolás", "Paulina", "Luciana" };
        string[] sexos = { "Masculino", "Femenino" };
        public readonly exContext context;
        private IUnitOfWork uow;
        private IHumano humanoService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, exContext _context)
        {
            _logger = logger;
            context = _context;
            uow = new UnitOfWorkContainer(context);
            humanoService = new HumanoService(uow);
        }
        #region Mock Data
        [HttpGet]
        public IEnumerable<DTOHumano> Get()
        {
            var random = new Random();
            return Enumerable.Range(1, 4).Select(index => new DTOHumano
            {
                Id = index,
                Nombre = nombres[random.Next(nombres.Length)],
                Edad = random.Next(2, 30),
                Sexo = sexos[random.Next(sexos.Length)],
                Altura = float.Parse((1 + random.NextDouble()).ToString("f2")),
                Peso = float.Parse((random.Next(30, 100) + random.NextDouble()).ToString("f2"))
            })
            .ToArray();
        }
        #endregion
        #region Operaciones
        [HttpPost]
        public Result Post(string _operacion, string _num1, string _num2)
        {
            if (!_num1.esFlotanteString())
                return new Result() {  Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };
            if (!_num2.esFlotanteString())
                return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };
            if (!_operacion.esOperacion())
                return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };


            float num1 = float.Parse(_num1), num2 = float.Parse(_num2);

            switch (_operacion)
            {
                case "suma":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 + num2).ToString() };
                case "resta":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 - num2).ToString() };
                case "multiplicacion":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 * num2).ToString() };
                case "division":
                    if (num2 <= 0)
                        return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.ZERO };
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 / num2).ToString() };
                default:
                    return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.OPERATION_NOT_FOUND };
            }
        }

        [HttpGet("GetHeader")]
        public Result Get([FromHeader] string _operacion, [FromHeader] string _num1, [FromHeader] string _num2)
        {
            if (!_num1.esFlotanteString())
                return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };
            if (!_num2.esFlotanteString())
                return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };
            if (!_operacion.esOperacion())
                return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.PARAM_ERR };


            float num1 = float.Parse(_num1), num2 = float.Parse(_num2);

            switch (_operacion)
            {
                case "suma":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 + num2).ToString() };
                case "resta":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 - num2).ToString() };
                case "multiplicacion":
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 * num2).ToString() };
                case "division":
                    if (num2 <= 0)
                        return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.ZERO };
                    return new Result() { Estatus = (int)HttpStatusCode.OK, Mensaje = Constants.REQ_OK, Resultado = (num1 / num2).ToString() };
                default:
                    return new Result() { Estatus = (int)HttpStatusCode.BadRequest, Mensaje = Constants.OPERATION_NOT_FOUND };
            }
        }
        #endregion

        #region DB
        [HttpGet("GetAll")]
        public List<DTOHumano> GetAll()
        {
            var data = humanoService.getAll();
            return data.ListaObjetoResult;
        }

        [HttpGet("GetSingle")]
        public DTOHumano GetSingle(int id)
        {
            var data = humanoService.getSingle(id);
            return data.ObjetoResult;
        }

        [HttpPost("Add")]
        public Result Add([FromBody] DTOHumano obj)
        {
            var data = humanoService.create(obj);
            return data;
        }
        [HttpPut]
        public Result Put([FromBody] DTOHumano obj)
        {
            var data = humanoService.update(obj);
            return data;
        }
        [HttpDelete]
        public Result Delete(int id)
        {
            var data = humanoService.delete(id);
            return data;
        }
        #endregion

    }
}
