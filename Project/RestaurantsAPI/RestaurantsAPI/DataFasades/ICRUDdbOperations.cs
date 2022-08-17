using System;
using System.Collections.Generic;

namespace RestaurantsAPI.DataFasades
{
    public interface ICRUDdbOperations<T>
    {
        List<T> Get();
        T Get(Guid id);
        T Add(T element);
        bool Delete(Guid id);
        T Edit(T element);
    }
}
