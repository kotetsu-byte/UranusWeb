using UranusWeb.Server.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IPartVideoRepository
    {
        Task<ICollection<PartVideo>> GetAllPartVideos(int courseId, int aboutId);  
        Task<PartVideo> GetPartVideoById(int courseId, int aboutId, int id);
        bool Create(PartVideo partVideo);
        bool Update(PartVideo partVideo);
        bool Delete(int id);
        bool Save();
    }
}
