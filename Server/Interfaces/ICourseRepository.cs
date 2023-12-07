using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>> GetAllCourses();
        Task<Course> GetCourseById(int courseId);
        Task<int?> GetAboutId(int courseId);
        Task<int?> GetPartVideoId(int courseId);
        bool Create(Course course);
        bool Update(Course course);
        bool Delete(int id);
        bool Save();
    }
}
