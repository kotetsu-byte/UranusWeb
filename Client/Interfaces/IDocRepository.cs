using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IDocRepository
    {
        Task<ICollection<DocDto>> GetAllDocs(int courseId, int lessonId);
        Task<DocDto> GetDocById(int courseId, int lessonId, int id);
        Task<string> Create(int courseId, int lessonId, DocDto doc);
        Task<string> Update(DocDto doc);
        Task<string> Delete(int id);
    }
}
