using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IAboutRepository
    {
        Task<IEnumerable<AboutDto>> GetAllAbouts(int courseId);
        Task<AboutDto> GetAboutById(int courseId, int id);
        Task<string> Create(int courseId, AboutDto about);
        Task<string> Update(AboutDto about);
        Task<string> Delete(int id);
    }
}
