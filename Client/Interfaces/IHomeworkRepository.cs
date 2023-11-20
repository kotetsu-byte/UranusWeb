using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<IEnumerable<HomeworkDto>> GetAllHomeworks();
        Task<HomeworkDto> GetHomeworkById(int id);
        Task<string> Create(HomeworkDto homework);
        Task<string> Update(HomeworkDto homework);
        Task<string> Delete(int id);
    }
}
