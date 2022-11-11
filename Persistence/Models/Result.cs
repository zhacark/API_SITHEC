using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Persistence.Models
{
    public class Result
    {
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public int RegistroId { get; set; }
        public string Resultado { get; set; }

    }

    public class Result<T>
    {
        public int Estatus { get; set; }
        public string Mensaje { get; set; }
        public T ObjetoResult { get; set; }
        public List<T> ListaObjetoResult { get; set; }
    }
}