using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IResultRepository
    {
        Task<ICollection<ResultDto>> GetAllResults(int courseId, int aboutId);
        Task<ResultDto> GetResultById(int courseId, int aboutId, int id);
    }
}
