using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repository.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);
    }
}
