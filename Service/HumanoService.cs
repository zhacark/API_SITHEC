using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Persistence.Models;
using Persistence.ModelDB;
using Persistence.Repository;
using Persistence.UnitOfWork;
using Services.Utilities;
using Services.Extensions;
namespace Services
{
    public interface IHumano
    {
        Result<DTOHumano> getAll();
        Result<DTOHumano> getSingle(int id);
        Result create(DTOHumano obj);
        Result update(DTOHumano obj);
        Result delete(int id);
    }
    public class HumanoService : IHumano
    {
        private readonly IUnitOfWork uow;
        public HumanoService(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public Result<DTOHumano> getAll()
        {
            Result<DTOHumano> result = new Result<DTOHumano>();
            try
            {
                var lista = uow.Repository.HumanoRepository.getAll();
                result.ListaObjetoResult = lista;
                result.Estatus = (int)HttpStatusCode.OK;
                result.Mensaje = !lista.esListaVacia() ? Constants.REQ_OK : Constants.LISTEMPTY;
                return result;
            }
            catch (Exception ex)
            {
                result.Estatus = (int)HttpStatusCode.BadRequest;
                result.Mensaje = ex.Message;
                return result;
            }
        }
        public Result<DTOHumano> getSingle(int id)
        {
            Result<DTOHumano> result = new Result<DTOHumano>();
            try
            {
                DTOHumano obj = uow.Repository.HumanoRepository.getSingle(id);
                if (obj == null)
                {
                    result.Estatus = (int)HttpStatusCode.NotFound;
                    result.Mensaje = Constants.NOTEXIST;
                    result.ObjetoResult = obj;
                    return result;
                }
                result.ObjetoResult = obj;
                result.Estatus = (int)HttpStatusCode.OK;
                result.Mensaje = Constants.REQ_OK;
                return result;
            }
            catch (Exception ex)
            {
                result.Estatus = (int)HttpStatusCode.BadRequest;
                result.Mensaje = ex.Message;
                return result;
            }
        }
        public Result create(DTOHumano obj)
        {
            Result result = new Result();
            try
            {
                if (!obj.esHumanoValido())
                    return new Result()
                    {
                        Estatus = (int)HttpStatusCode.BadRequest,
                        Mensaje = Constants.PARAM_ERR
                    };

                uow.CreateTransaction();

                var dataAdd = new Humano()
                {
                    HumanoId = obj.Id,
                    Nombre = obj.Nombre,
                    Sexo = obj.Sexo,
                    Edad = obj.Edad,
                    Altura = obj.Altura,
                    Peso = obj.Peso
                };
                uow.Repository.HumanoRepository.Add(dataAdd);
                uow.Save();


                uow.Commit();
                result.Estatus = (int)HttpStatusCode.OK;
                result.Mensaje = Constants.CREATEOK;
                result.RegistroId = dataAdd.HumanoId;
                return result;
            }
            catch (Exception ex)
            {
                result.Estatus = (int)HttpStatusCode.BadRequest;
                result.Mensaje = ex.Message + " " + ex.InnerException.Message;
                return result;
            }
        }
        public Result update(DTOHumano obj)
        {
            Result result = new Result();
            try
            {
                var oldData = uow.Repository.HumanoRepository.SingleOrDefault(c => c.HumanoId == obj.Id);
                if (oldData == null)
                    return new Result()
                    {
                        Estatus = (int)HttpStatusCode.NotFound,
                        Mensaje = Constants.NOTEXIST
                    };
                if(!obj.Nombre.esCadenaVacia())
                    oldData.Nombre = obj.Nombre;
                if(obj.Edad.esEntero())
                    oldData.Edad = obj.Edad;
                if(!obj.Sexo.esCadenaVacia())
                    oldData.Sexo = obj.Sexo;
                if(obj.Altura.esFlotante())
                    oldData.Altura = obj.Altura;
                if(obj.Peso.esFlotante())
                    oldData.Peso = obj.Peso;
                    

                uow.Repository.HumanoRepository.Update(oldData);

                uow.Save();
                result.Estatus = (int)HttpStatusCode.OK;
                result.Mensaje = Constants.UPDATEOK;
                result.RegistroId = oldData.HumanoId;
                return result;
            }
            catch (Exception ex)
            {
                result.Estatus = (int)HttpStatusCode.BadRequest;
                result.Mensaje = ex.Message + " " + ex.InnerException.Message;
                return result;
            }
        }
        public Result delete(int id)
        {
            Result result = new Result();
            try
            {
                var dataDTO = uow.Repository.HumanoRepository.getSingle(id);

                if (dataDTO == null)
                    return new Result()
                    {
                        Estatus = (int)HttpStatusCode.NotFound,
                        Mensaje = Constants.NOTEXIST
                    };

                var dataDEL = new Humano()
                {
                    HumanoId = dataDTO.Id,
                    Nombre = dataDTO.Nombre,
                    Sexo = dataDTO.Sexo,
                    Altura = dataDTO.Altura,
                    Edad = dataDTO.Edad,
                    Peso = dataDTO.Peso
                };
                uow.Repository.HumanoRepository.Remove(dataDEL);
                uow.Save();
                result.Estatus = (int)HttpStatusCode.OK;
                result.Mensaje = Constants.DELETEOK;
                return result;
            }
            catch (Exception ex)
            {
                result.Estatus = (int)HttpStatusCode.BadRequest;
                result.Mensaje = ex.Message + " " + ex.InnerException.Message;
                return result;
            }
        }
    }
}