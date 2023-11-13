using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllMaterials();
        Task<Material> GetMaterialById(int id);
        bool Create(Material material);
        bool Update(Material material);
        bool Delete(Material material);
        bool Save();
    }
}
