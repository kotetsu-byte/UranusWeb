using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> GetAllDocs();
        Task<Doc> GetDocById(int id);
        bool Create(Doc doc);
        bool Update(Doc doc);
        bool Delete(Doc doc);
        bool Save();
    }
}
