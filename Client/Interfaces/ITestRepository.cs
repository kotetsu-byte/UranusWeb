using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<TestDto>> GetAllTests();
        Task<TestDto> GetTestById(int id);
        Task<string> Create(TestDto testDto);
        Task<string> Update(TestDto testDto);
        Task<string> Delete(int id);
    }
}
