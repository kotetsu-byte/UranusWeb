using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> GetAllDocs(int courseId, int lessonId);
        Task<Doc> GetDocById(int courseId, int lessonId, int id);
        bool Create(Doc doc);
        bool Update(Doc doc);
        bool Delete(int id);
        bool Save();
    }
}
