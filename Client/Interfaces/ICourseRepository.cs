using UranusWeb.Server.Dtos;

namespace UranusWeb.Client.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();
        Task<CourseDto> GetCourseById(int id);
        Task<string> Create(CourseDto courseDto);
        Task<string> Update(CourseDto courseDto);
        Task<string> Delete(int id);
    }
}
