using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllLessons();
        Task<Lesson> GetLessonById(int id);
        bool Create(Lesson lesson);
        bool Update(Lesson lesson);
        bool Delete(int id);
        bool Save();
    }
}
