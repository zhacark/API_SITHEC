using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Persistence.Models;
using Persistence.ModelDB;
using Persistence.UnitOfWork;
using Persistence.Repository.Interfaces;

namespace Persistence.Repository
{
    public interface IHumano : IPagedRepository<Humano>, IReadRepository<Humano>, ICreateRepository<Humano>, IRemoveRepository<Humano>, IUpdateRepository<Humano>
    {
        List<DTOHumano> getAll();
        DTOHumano getSingle(int id);
    }
    public class HumanoRepository : GenericRepository<Humano>, IHumano
    {
        public HumanoRepository(exContext _context)
        {
            context = _context;
        }
        public List<DTOHumano> getAll()
        {
            try
            {
                var result = (from h in context.Humano
                              select new DTOHumano()
                              {
                                  Id = h.HumanoId,
                                  Nombre = h.Nombre,
                                  Edad = h.Edad,
                                  Sexo = h.Sexo,
                                  Altura = h.Altura,
                                  Peso = h.Peso
                              }).ToList();
                return result;
            }
            catch
            {
                return new List<DTOHumano>();
            }
        }
        public DTOHumano getSingle(int id)
        {
            try
            {
                var result = context.Humano.Select(c => new DTOHumano()
                {
                    Id = c.HumanoId,
                    Nombre = c.Nombre,
                    Edad = c.Edad,
                    Sexo = c.Sexo,
                    Altura = c.Altura,
                    Peso = c.Peso
                }).FirstOrDefault(c => c.Id == id);
                return result;
            }
            catch
            {
                return new DTOHumano();
            }
        }
    }
}