using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IDocRepository
    {
        Task<IEnumerable<DocDto>> GetAllDocs();
        Task<DocDto> GetDocById(int id);
        Task<string> Create(DocDto doc);
        Task<string> Update(DocDto doc);
        Task<string> Delete(int id);
    }
}
