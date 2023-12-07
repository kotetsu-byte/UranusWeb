using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IPartVideoRepository
    {
        Task<ICollection<PartVideoDto>> GetAllPartVideos(int courseId, int aboutId);
        Task<PartVideoDto> GetPartVideoById(int courseId, int aboutId, int id);
        Task<string> Create(int courseId, int aboutId, PartVideoDto partVideo);
        Task<string> Update(PartVideoDto partVideo);
        Task<string> Delete(int id);
    }
}
