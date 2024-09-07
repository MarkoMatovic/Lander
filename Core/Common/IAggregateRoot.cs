using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLander.Core.Common;

public interface IAggregateRoot { }

public interface IRepository<T> where T : class
{
    //IUnitOfWork UnitOfWork { get; }
    T Add(T entity);
}
