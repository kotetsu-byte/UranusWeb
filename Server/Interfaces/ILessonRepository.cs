using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetAllLessons(int courseId);
        Task<Lesson> GetLessonById(int courseId, int id);
        bool Create(Lesson lesson);
        bool Update(Lesson lesson);
        bool Delete(int id);
        bool Save();
    }
}
