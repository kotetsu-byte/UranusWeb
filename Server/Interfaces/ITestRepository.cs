using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllTests(int courseId);
        Task<Test> GetTestById(int courseId, int id);
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(int id);
        bool Save();
    }
}
