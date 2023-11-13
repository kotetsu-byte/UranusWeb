using UranusAdmin.Models;

namespace UranusWeb.Server.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        bool Create(Course course);
        bool Update(Course course);
        bool Delete(Course course);
        bool Save();
    }
}
