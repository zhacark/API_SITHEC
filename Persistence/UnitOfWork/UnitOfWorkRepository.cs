using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using Persistence.ModelDB;
using Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Persistence.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IHumano HumanoRepository { get; }
    }
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IHumano HumanoRepository { get; set; }
        public UnitOfWorkRepository(exContext context)
        {
            HumanoRepository = new HumanoRepository(context);
        }
    }
}