using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<VideoDto>> GetAllVideos();
        Task<VideoDto> GetVideoById(int id);
        Task<string> Create(VideoDto videoDto);
        Task<string> Update(VideoDto videoDto);
        Task<string> Delete(int id);
    }
}
