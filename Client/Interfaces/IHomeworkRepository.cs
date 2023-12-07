using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<ICollection<HomeworkDto>> GetAllHomeworks(int courseId, int lessonId);
        Task<HomeworkDto> GetHomeworkById(int courseId, int lessonId, int id);
        Task<string> Create(int courseId, int lessonId, HomeworkDto homework);
        Task<string> Update(HomeworkDto homework);
        Task<string> Delete(int id);
    }
}
