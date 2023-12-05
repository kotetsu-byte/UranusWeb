using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterials(int courseId, int lessonId, int homeworkId);
        Task<Material> GetMaterialById(int courseId, int lessonId, int homeworkId, int id);
        bool Create(Material material);
        bool Update(Material material);
        bool Delete(int id);
        bool Save();
    }
}
