using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllResults(int courseId, int aboutId);
        Task<Result> GetResultById(int courseId, int aboutId, int id);
        bool Create(Result result);
        bool Update(Result result);
        bool Delete(int id);
        bool Save();
    }
}
