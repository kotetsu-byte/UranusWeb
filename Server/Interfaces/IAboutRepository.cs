using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IAboutRepository
    {
        Task<IEnumerable<About>> GetAllAbouts(int courseId);
        Task<About> GetAboutById(int courseId, int id);
        bool Create(About about);
        bool Update(About about);
        bool Delete(int id);
        bool Save();
    }
}
