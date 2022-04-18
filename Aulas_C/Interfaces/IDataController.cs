using System;

namespace Interfaces{
    public interface IDataController<T>{
        T findByID(T obj);
        List<T> getAll(T obj);
        int save(T obj);
        void update(T obj);
        void delete(T obj);
        T convertModelToDTO(T obj);
    }
}