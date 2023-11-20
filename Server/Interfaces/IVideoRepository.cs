using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllVideos();
        Task<Video> GetVideoById(int id);
        bool Create(Video video);
        bool Update(Video video);
        bool Delete(int id);
        bool Save();
    }
}
