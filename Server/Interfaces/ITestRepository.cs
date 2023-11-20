using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestById(int id);
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(int id);
        bool Save();
    }
}
