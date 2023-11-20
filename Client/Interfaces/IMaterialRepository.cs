using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterials();
        Task<MaterialDto> GetMaterialById(int id);
        Task<string> Create(MaterialDto material);
        Task<string> Update(MaterialDto material);
        Task<string> Delete(int id);
    }
}
