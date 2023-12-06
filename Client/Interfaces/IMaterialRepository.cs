using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterials(int courseId, int lessonId, int homeworkId);
        Task<MaterialDto> GetMaterialById(int courseId, int lessonId, int homeworkId, int id);
        Task<string> Create(int courseId, int lessonId, int homeworkId, MaterialDto material);
        Task<string> Update(MaterialDto material);
        Task<string> Delete(int id);
    }
}
