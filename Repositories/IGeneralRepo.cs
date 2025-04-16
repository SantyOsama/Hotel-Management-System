using HotelMangementSystem.Models;

namespace HotelMangementSystem.Repositories
{
    public interface IGeneralRepo<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void Insert(T item);
        public void Update(T item);
        public bool Delete(int id);
        public void Save();

    }
}
