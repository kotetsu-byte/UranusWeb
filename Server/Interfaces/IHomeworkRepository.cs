using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworks(int courseId, int lessonId);
        Task<Homework> GetHomeworkById(int courseId, int lessonId, int id);
        bool Create(Homework homework);
        bool Update(Homework homework);
        bool Delete(int id);
        bool Save();
    }
}
