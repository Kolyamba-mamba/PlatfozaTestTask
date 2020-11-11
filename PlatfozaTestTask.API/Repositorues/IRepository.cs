using System;
using System.Linq;

namespace PlatfozaTestTask.API.Repositorues
{
    public interface IRepository<T>
    {
        // Получение списка
        IQueryable<T> Get();
        //Получение одного элемента
        T GetById(Guid id);
        //Изменение элемента
        void Change(T item);
        //Удаление элемента
        void Delete(T item);
        //Создание элемента
        void Create(T item);
    }
}