using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<LessonDto>> GetAllLessons();
        Task<LessonDto> GetLessonById(int id);
        Task<string> Create(LessonDto lesson);
        Task<string> Update(LessonDto lesson);
        Task<string> Delete(int id);
    }
}
