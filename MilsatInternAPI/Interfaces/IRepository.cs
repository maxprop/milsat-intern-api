using Microsoft.AspNetCore.Mvc;

namespace MilsatInternAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize);
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Create();
        void Update();
        void DeleteMentor(int id);
    }
}                                                                                                                     