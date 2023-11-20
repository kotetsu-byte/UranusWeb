using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworks();
        Task<Homework> GetHomeworkById(int id);
        bool Create(Homework homework);
        bool Update(Homework homework);
        bool Delete(int id);
        bool Save();
    }
}
