using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestDto>> GetAllTests(int courseId);
        Task<TestDto> GetTestById(int courseId, int id);
        Task<string> Create(int courseId, TestDto testDto);
        Task<string> Update(TestDto testDto);
        Task<string> Delete(int id);
    }
}
