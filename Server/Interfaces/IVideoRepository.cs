using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllVideos(int courseId, int lessonId);
        Task<Video> GetVideoById(int courseId, int lessonId, int id);
        bool Create(Video video);
        bool Update(Video video);
        bool Delete(int id);
        bool Save();
    }
}
