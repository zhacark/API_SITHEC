using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Models;
using Persistence.ModelDB;
using Persistence.UnitOfWork;

using Services;
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
        public float Post(string _operacion, string _num1, string _num2)
        {
            if (!_num1.esFlotanteString())
                return -1;
            if (!_num2.esFlotanteString())
                return -1;
            if (!_operacion.esOperacion())
                return -1;


            float num1 = float.Parse(_num1), num2 = float.Parse(_num2);

            switch (_operacion)
            {
                case "suma":
                    return num1 + num2;
                case "resta":
                    return num1 - num2;
                case "multiplicacion":
                    return num1 * num2;
                case "division":
                    if (num2 <= 0)
                        return -1;
                    return num1 / num2;
                default:
                    return -1;
            }
        }

        [HttpGet("GetHeader")]
        public float Get([FromHeader] string _operacion, [FromHeader] string _num1, [FromHeader] string _num2)
        {
            if (!_num1.esFlotanteString())
                return -1;
            if (!_num2.esFlotanteString())
                return -1;
            if (!_operacion.esOperacion())
                return -1;


            float num1 = float.Parse(_num1), num2 = float.Parse(_num2);

            switch (_operacion)
            {
                case "suma":
                    return num1 + num2;
                case "resta":
                    return num1 - num2;
                case "multiplicacion":
                    return num1 * num2;
                case "division":
                    if (num2 <= 0)
                        return -1;
                    return num1 / num2;
                default:
                    return -1;
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
