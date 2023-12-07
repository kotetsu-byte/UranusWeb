using UranusWeb.Shared.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface ILessonRepository
    {
        Task<ICollection<LessonDto>> GetAllLessons(int courseId);
        Task<LessonDto> GetLessonById(int courseId, int id);
        Task<string> Create(int courseId, LessonDto lesson);
        Task<string> Update(LessonDto lesson);
        Task<string> Delete(int id);
    }
}
